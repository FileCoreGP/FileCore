using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileCore.Models;

namespace FileCore.Repositories
{
    public class CategoriasRepository : Repository<Categoria>
    {
        public IEnumerable<CategoriaViewModel> GetCategoriasViewModel()
        {
            return GetAll().Select(x=> new CategoriaViewModel(){ Nombre=x.Nombre, Descripcion=x.Descripcion, IdCategoria=x.IdCategoria});
        }

        public CategoriaViewModel GetCategoriaViewModelById(int id)
        {
            return GetAll().Where(x => x.IdCategoria == id).Select(x => new CategoriaViewModel
            {
                IdCategoria = x.IdCategoria,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion
            }).FirstOrDefault();
        }

        public void InsertCategoria(CategoriaViewModel categoria)
        {
            if (GetAll().Any(x => x.Nombre == categoria.Nombre))
                throw new ArgumentException("El nombre de la categoria ya esta registrado");

            string error = Validar(categoria);

            if (error != "")
                throw new ArgumentException(error);

            Categoria cat = new Categoria()
            {
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion
            };

            Insert(cat);
        }

        public void UpdateCategoria(CategoriaViewModel categoria)
        {
            if (GetById(categoria.IdCategoria).Nombre == categoria.Nombre &&  GetById(categoria.IdCategoria).Descripcion == categoria.Descripcion)
            {
                return;
            }

            string error = Validar(categoria);

            if (error != "")
                throw new ArgumentException(error);

            var categoriaDB = GetById(categoria.IdCategoria);

            if (categoriaDB != null)
            {
                categoriaDB.Nombre = categoria.Nombre;
                categoriaDB.Descripcion = categoria.Descripcion;

                if (GetAll().Any(x => x.IdCategoria != categoriaDB.IdCategoria && x.Nombre == categoriaDB.Nombre))
                {
                    throw new ArgumentException("El nombre de la categoria ya esta registrada");
                }
                Update(categoriaDB);
            }
            
        }

        string Validar(CategoriaViewModel categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nombre))
                return "El nombre no debe estar vacio";

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
                return "La descripción no debe estar vacia";

            if (categoria.Nombre.Length > 20)
                return "El Nombre solo puede contener 20 caracteres como maximo";

            if (categoria.Descripcion.Length > 80)
                return "La Descripción solo puede contener 80 caracteres como maximo";

            return "";
        }

    }
}
