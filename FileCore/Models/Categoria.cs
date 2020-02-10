using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Empleado = new HashSet<Empleado>();
            HistorialcategoriasPuestos = new HashSet<HistorialcategoriasPuestos>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Empleado> Empleado { get; set; }
        public ICollection<HistorialcategoriasPuestos> HistorialcategoriasPuestos { get; set; }
    }
}
