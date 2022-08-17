using Microsoft.EntityFrameworkCore;
using ProyectoIA.Models.Entity;
using ProyectoIA.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Repository.Repositorio
{
    public class RepositorioProduct : IRepositorioProductcs
    {
        //------------------------------------------------------------
        private IADBContext _contexto;
        private DbSet<Products> _dbSet;
        //------------------------------------------------------------
        public RepositorioProduct(IADBContext contexto)
        {
            _contexto = contexto;
            this._dbSet = _contexto.Set<Products>();
        }
        //------------------------------------------------------------
        public List<Products> obtenerProductos()
        {
            try
            {
                return _dbSet.OrderBy(x => x.IdProducto).ToList();
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }

        public void addProduct(AddProductRequest request)
        {
            try
            {
                Products objProducts = new Products();

                objProducts.sku = request.sku;
                objProducts.name = request.name;
                objProducts.stock = request.amount;

                _dbSet.Add(objProducts);
                _contexto.SaveChanges();
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }

        public void updateProduct(Products request)
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

        public void deleteProduct(Products request)
        {
            try
            {
                _dbSet.Remove(request);
                _contexto.SaveChanges();
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }
    }
}
