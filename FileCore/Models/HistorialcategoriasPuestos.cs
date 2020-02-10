using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class HistorialcategoriasPuestos
    {
        public int IdHistorialCategoriasPuestos { get; set; }
        public int EmpleadoIdEmpleado { get; set; }
        public int CategoriaIdCategoria { get; set; }
        public DateTime FechaInicioCategoria { get; set; }
        public int DepartamentoIdDepartamento { get; set; }
        public DateTime FechaInicioDepartamento { get; set; }

        public Categoria CategoriaIdCategoriaNavigation { get; set; }
        public Departamento DepartamentoIdDepartamentoNavigation { get; set; }
        public Empleado EmpleadoIdEmpleadoNavigation { get; set; }
    }
}
