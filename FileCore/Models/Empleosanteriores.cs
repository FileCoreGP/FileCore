using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Empleosanteriores
    {
        public int IdEmpleosAnteriores { get; set; }
        public int EmpleadoIdEmpleado { get; set; }
        public string Empresa { get; set; }
        public string Puesto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTerminacion { get; set; }

        public Empleado EmpleadoIdEmpleadoNavigation { get; set; }
    }
}
