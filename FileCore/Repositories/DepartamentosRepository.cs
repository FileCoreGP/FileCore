using FileCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileCore.Repositories
{
    public class DepartamentosRepository: Repository<Departamento>
    {
        public void InsertDepartamento(Departamento departamento)
        {
            if (string.IsNullOrWhiteSpace(departamento.Nombre))
            {
                throw new ArgumentException("El nombre no debe estar vacio.");
            }

            if (GetAll().Any(x => x.Nombre == departamento.Nombre))
            {
                throw new ArgumentException("El nombre del departamento ya esta registrado.");
            }

            Insert(departamento);
        }

        public void UpdateDepartamento(Departamento departamento)
        {
            if (GetById(departamento.IdDepartamento).Nombre == departamento.Nombre)
            {
                return;
            }

            if (string.IsNullOrEmpty(departamento.Nombre))
            {
                throw new ArgumentException("El nombre no debe estar vacio.");
            }

            var departamentoDB = GetById(departamento.IdDepartamento);

            if (departamentoDB != null)
            {
                departamentoDB.Nombre = departamento.Nombre;
                if (GetAll().Any(x => x.IdDepartamento != departamentoDB.IdDepartamento && x.Nombre == departamentoDB.Nombre))
                {
                    throw new ArgumentException("El nombre del departamento ya esta registrado.");
                }
            }

            

            Update(departamentoDB);
        }
    }
}
