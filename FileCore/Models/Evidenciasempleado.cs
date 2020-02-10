using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Evidenciasempleado
    {
        public int IdEvidenciaEmpleado { get; set; }
        public int EmpleadoIdEmpleado { get; set; }
        public int EvidenciasIdEvidencias { get; set; }
        public string Descripcion { get; set; }

        public Empleado EmpleadoIdEmpleadoNavigation { get; set; }
        public Evidencias EvidenciasIdEvidenciasNavigation { get; set; }
    }
}
