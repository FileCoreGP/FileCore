using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class PremiosReconocimientos
    {
        public int IdPremiosReconocimientos { get; set; }
        public int EmpleadoIdEmpleado { get; set; }
        public string Descripcion { get; set; }

        public Empleado EmpleadoIdEmpleadoNavigation { get; set; }
    }
}
