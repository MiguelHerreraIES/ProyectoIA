using ProyectoIA.Models.DTO;
using ProyectoIA.Models.Entity;
using ProyectoIA.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIA.Repository.Repositorio
{
    public interface IRepositorioProductcs
    {
        List<Products> obtenerProductos();
        void addProduct(AddProductRequest request);
        void updateProduct(Products request);
        void deleteProduct(Products request);
    }
}
