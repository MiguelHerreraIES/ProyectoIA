using ProyectoIA.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Service.Order
{
    public interface IOrdersService
    {
        List<Orders> getOrders();
        void addOrder(Orders request);
        void updateOrder(Orders request);
    }
}
