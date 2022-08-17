using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIA.Models.Entity;
using ProyectoIA.Models.Request;
using ProyectoIA.Repository.Repositorio;
using ProyectoIA.Repository.Repositorio.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Controllers
{
    [Route("api/orders/")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //-------------------------------------------------------------------------------------------
        private readonly IRepositorioOrders _repositorioOrders;
        private readonly IRepositorioProductcs _repositorioProducts;
        //-------------------------------------------------------------------------------------------
        public OrdersController(IRepositorioOrders repositorioOrders, IRepositorioProductcs repositorioProductcs)
        {
            this._repositorioOrders = repositorioOrders;
            this._repositorioProducts = repositorioProductcs;
        }
        //-------------------------------------------------------------------------------------------
        [HttpPost("addOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult addNewOrder(AddOrderRequest request)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                List<Orders> orders = new List<Orders>();
                int intOrder = 0;
                int intOrderNumber = 1;

                if (ModelState.IsValid)
                {
                    orders = _repositorioOrders.getOrders().ToList();

                    if(orders.Count != 0)
                    {
                        intOrder = orders.Select(x => x.IdOrder).Max();
                        intOrderNumber = orders.Where(x => x.IdOrder == intOrder).Select(x => x.orderNumber).FirstOrDefault();
                    }                        

                    foreach (var item in request.order)
                    {
                        Orders order = new Orders();
                        order.IdProduct = item.idProduct;
                        order.IdStatus = 1;
                        if (intOrder != 0)
                            order.orderNumber = intOrderNumber + 1;
                        else
                            order.orderNumber = 1;
                        order.amount = item.Amount;

                        //Agregamos la orden a la BD con status pending
                        _repositorioOrders.addOrder(order);
                    }
                }
                else
                {
                    return BadRequest(validationResults);
                }

                return Ok("Orden agregada con éxito");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------
        [HttpGet("getOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Orders> getOrders()
        {
            try
            {
                var lstOrders = _repositorioOrders.getOrders();

                return lstOrders;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------
        [HttpPost("updateOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Orders> updateOrder(UpdateOrderRequest request)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                List<Orders> lstOrder = new List<Orders>();
                List<Products> lstProduct = new List<Products>();
                int iProduct = 0;

                if (ModelState.IsValid)
                {
                    if (request.IdStatus == 2)
                    {
                        lstOrder = _repositorioOrders.getOrders().Where(x => x.orderNumber == request.OrderNumber).ToList();
                        lstProduct = _repositorioProducts.obtenerProductos();
                        foreach (var itemOrder in lstOrder)
                        {
                            Products Product = lstProduct.Where(x => x.IdProducto == itemOrder.IdProduct).FirstOrDefault();
                            iProduct = lstProduct.Where(x => x.IdProducto == itemOrder.IdProduct).Select(x => x.stock).FirstOrDefault();

                            if (iProduct == 0 || Product.stock < itemOrder.amount)
                            {
                                itemOrder.IdStatus = 5;
                                _repositorioOrders.updateOrder(itemOrder);

                                return (IEnumerable<Orders>)Ok("El numero de Orden " + request.OrderNumber + ", fue cancelado debido a falta de stock");
                            }
                            else
                            {
                                itemOrder.IdStatus = request.IdStatus;
                                _repositorioOrders.updateOrder(itemOrder);
                                Product.stock = Product.stock - itemOrder.amount;

                                _repositorioProducts.updateProduct(Product);
                            }
                        }                        
                    }
                    else 
                    {
                        lstOrder = _repositorioOrders.getOrders().Where(x => x.orderNumber == request.OrderNumber).ToList();
                        foreach (var itemOrder in lstOrder)
                        {
                            itemOrder.IdStatus = request.IdStatus;
                            _repositorioOrders.updateOrder(itemOrder);
                        }
                    }                    
                }
                else
                {
                    return (IEnumerable<Orders>)BadRequest(validationResults);
                }


                lstOrder = _repositorioOrders.getOrders().Where(x => x.orderNumber == request.OrderNumber && x.IdStatus == request.IdStatus).ToList();

                return lstOrder;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------
    }
}
