using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoIA.Models.Entity;
using ProyectoIA.Repository.Repositorio.Order;

namespace ProyectoIA.Service.Order
{
    public class OrdersService : IOrdersService
    {
        //-------------------------------------------------------
        private readonly IRepositorioOrders _repositorioOrders;
        //-------------------------------------------------------
        public OrdersService(IRepositorioOrders repositorioOrders)
        {
            this._repositorioOrders = repositorioOrders;
        }
        //-------------------------------------------------------
        public List<Orders> getOrders()
        {
            try
            {
                return _repositorioOrders.getOrders();
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }

        public void addOrder(Orders request)
        {
            try
            {
                _repositorioOrders.addOrder(request);
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }

        public void updateOrder(Orders request)
        {
            try
            {
                _repositorioOrders.updateOrder(request);
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }

    }
}
