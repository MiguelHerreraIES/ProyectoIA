using ProyectoIA.Models.Entity;
using ProyectoIA.Models.Request;
using ProyectoIA.Repository.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Service
{
    public class ProductService : IProductService
    {
        //-------------------------------------------------------
        private readonly IRepositorioProductcs _repositorioProducts;
        //-------------------------------------------------------
        public ProductService(IRepositorioProductcs repositorioProductcs)
        {
            this._repositorioProducts = repositorioProductcs;
        }
        //-------------------------------------------------------
        public List<Products> obtenerProductos()
        {
            try
            {
                return _repositorioProducts.obtenerProductos();
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
                _repositorioProducts.addProduct(request);
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
                _repositorioProducts.updateProduct(request);
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
                _repositorioProducts.deleteProduct(request);
            }
            catch (NotImplementedException e)
            {
                throw e;
            }
        }
    }
}
