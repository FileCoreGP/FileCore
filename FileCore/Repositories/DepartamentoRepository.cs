using FileCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace FileCore.Repositories
{
    public class DepartamentoRepository : Repository<Departamento>
    {

        public IEnumerable<DepartamentoViewModel> GetDepartamentosViewModel()
        {
            return GetAll().Select(x => new DepartamentoViewModel
            {
                IdDepartamento = x.IdDepartamento,
                Nombre = x.Nombre
            });
        }

        public DepartamentoViewModel GetDepartamentoById(int Id)
        {
            return Context.Departamento.Where(x => x.IdDepartamento == Id)
               .Select(x => new DepartamentoViewModel
               {
                   IdDepartamento = x.IdDepartamento,
                   Nombre = x.Nombre
               }).FirstOrDefault();
        }

        public void InsertDepartamento(DepartamentoViewModel departamento)
        {
            if (string.IsNullOrWhiteSpace(departamento.Nombre))
                throw new ArgumentException("El nombre no debe estar vacio.");

            if (departamento.Nombre.Length > 80) 
                throw new ArgumentException("El nombre solo puede contener 80 caracteres como maximo");

            if (GetAll().Any(x => x.Nombre == departamento.Nombre))
                throw new ArgumentException("El nombre del departamento ya esta registrado.");

            Departamento d = new Departamento
            {
                IdDepartamento = departamento.IdDepartamento,
                Nombre = departamento.Nombre
            };
            Insert(d);
        }

        public void UpdateDepartamento(DepartamentoViewModel departamento)
        {
            if (GetById(departamento.IdDepartamento).Nombre == departamento.Nombre)
                return;

            if (string.IsNullOrWhiteSpace(departamento.Nombre))
                throw new ArgumentException("El nombre no debe estar vacio.");

            if (departamento.Nombre.Length > 80)
                throw new ArgumentException("El nombre solo puede contener 80 caracteres como maximo");

            var departamentoDB = GetById(departamento.IdDepartamento);

            if (departamentoDB != null)
            {
                if (GetAll().Any(x => x.IdDepartamento != departamento.IdDepartamento && x.Nombre == departamento.Nombre))
                    throw new ArgumentException("El nombre del departamento ya esta registrado.");

                departamentoDB.Nombre = departamento.Nombre;
                Update(departamentoDB);
            }
        }


    }
}
