using ProyectoIA.Models.Entity;
using ProyectoIA.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Service
{
    public interface IProductService
    {
        public List<Products> obtenerProductos();
        void addProduct(AddProductRequest request);
        void updateProduct(Products request);
        void deleteProduct(Products request);
    }
}
