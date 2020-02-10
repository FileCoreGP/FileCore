using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empleado = new HashSet<Empleado>();
            HistorialcategoriasPuestos = new HashSet<HistorialcategoriasPuestos>();
        }

        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }

        public ICollection<Empleado> Empleado { get; set; }
        public ICollection<HistorialcategoriasPuestos> HistorialcategoriasPuestos { get; set; }
    }
}
