using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Capacitaciones
    {
        public int IdCapacitaciones { get; set; }
        public int EmpleadoIdEmpleado { get; set; }
        public string NombreCapacitacion { get; set; }

        public Empleado EmpleadoIdEmpleadoNavigation { get; set; }
    }
}
