using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoIA.Models.Entity;
using ProyectoIA.Models.Request;
using ProyectoIA.Repository.Repositorio;
using ProyectoIA.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProyectoIA.Controllers
{
    [Route("api/product/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //-------------------------------------------------------------------------------------------
        private readonly IRepositorioProductcs _repositorioProductcs;
        //-------------------------------------------------------------------------------------------
        public ProductController(IRepositorioProductcs repositorioProductcs)
        {
            this._repositorioProductcs = repositorioProductcs;
        }
        //-------------------------------------------------------------------------------------------
        [HttpGet("getProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<Products> getProducts()
        {
            try
            {
                var lstProductos = _repositorioProductcs.obtenerProductos();

                return lstProductos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------
        [HttpPost("addProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult addProduct([FromBody] AddProductRequest request)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                List<Products> lstProducts = new List<Products>();

                if (ModelState.IsValid)
                {
                    lstProducts = _repositorioProductcs.obtenerProductos();

                    if(lstProducts != null && lstProducts.Count > 0)
                    {
                        foreach (var product in lstProducts)
                        {
                            if (product.sku.Equals(request.sku))
                            {
                                var msj = "No se puede ingresar otro producto con el SKU: " + request.sku + ", favor de verificar.";
                                return BadRequest(msj);
                            }                           
                        }

                        _repositorioProductcs.addProduct(request);
                    }
                    else
                    {
                        _repositorioProductcs.addProduct(request);
                    }
                }
                else
                {
                    return BadRequest(validationResults);
                }

                return Ok("Se agrego el producto con SKU: " + request.sku + " con éxito");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------
        [HttpPost("updateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult updateProduct([FromBody] UpdateProductRequest request)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                Products objProduct = new Products();

                if (ModelState.IsValid)
                {
                    objProduct = _repositorioProductcs.obtenerProductos().Where(x => x.IdProducto == request.id).FirstOrDefault();

                    if(objProduct != null)
                    {
                        objProduct.name = request.name;
                        objProduct.stock = request.stock;
                        _repositorioProductcs.updateProduct(objProduct);
                    }
                }
                else
                {
                    return BadRequest(validationResults);
                }

                return Ok("El Producto " + request.name + ", se actualizo con éxito.");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------
        [HttpGet("updateProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult deleteProduct([FromHeader] int id)
        {
            try
            {
                Products objProduct = new Products();

                objProduct = _repositorioProductcs.obtenerProductos().Where(x => x.IdProducto == id).FirstOrDefault();

                if(objProduct != null)
                {
                    _repositorioProductcs.deleteProduct(objProduct);
                }
                else
                {
                    var msj = "No se puede eliminar el producto, favor de verificar.";
                    return BadRequest(msj);
                }                

                return Ok("El Producto, se elimino con éxito.");

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------------------------------------------------------------------------------
    }
}
