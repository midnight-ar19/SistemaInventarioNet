﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public class CategoriaDAL
    {
        private readonly InventarioDbContext _db;

        public CategoriaDAL(InventarioDbContext db)
        {
            _db = db;
        }

        public List<Categoria> GetAll()
        {
            try
            {
                return _db.Categorias.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarCategoria(Categoria categoria)
        {
            try
            {
                _db.Categorias.Add(categoria);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Categoria BuscarCategoria(int id)
        {
            try
            {
                return _db.Categorias.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            try
            {
                var existente = _db.Categorias.Find(categoria.IdCategoria);
                if (existente != null)
                {
                    existente.Nombre = categoria.Nombre;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void EliminarCategoria(int id)
        {
            try
            {
                var categoria = _db.Categorias.Find(id);
                if (categoria != null)
                {
                    _db.Categorias.Remove(categoria);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
