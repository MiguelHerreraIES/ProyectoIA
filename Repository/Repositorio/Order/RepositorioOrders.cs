using Microsoft.EntityFrameworkCore;
using ProyectoIA.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Repository.Repositorio.Order
{
    public class RepositorioOrders : IRepositorioOrders
    {
        //------------------------------------------------------------
        private IADBContext _contexto;
        private DbSet<Orders> _dbSet;
        //------------------------------------------------------------
        public RepositorioOrders(IADBContext contexto)
        {
            _contexto = contexto;
            this._dbSet = _contexto.Set<Orders>();
        }
        //------------------------------------------------------------
        public List<Orders> getOrders()
        {
            try
            {
                return _dbSet.OrderBy(x => x.orderNumber).Include(x => x.Products).Include(x => x.CatStatus).ToList();
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
                _dbSet.Add(request);
                _contexto.SaveChanges();
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
                _dbSet.Update(request);
                _contexto.SaveChanges();
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }
    }
}
