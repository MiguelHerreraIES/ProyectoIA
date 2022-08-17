using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoIA.Models.Entity;

namespace ProyectoIA.Repository.Repositorio.Order
{
    public interface IRepositorioOrders
    {
        List<Orders> getOrders();
        void addOrder(Orders request);
        void updateOrder(Orders request);
    }
}
