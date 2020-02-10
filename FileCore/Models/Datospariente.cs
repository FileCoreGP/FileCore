using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Datospariente
    {
        public int IdDatosPariente { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoParentesco { get; set; }
        public string TelefonoContacto { get; set; }
        public bool Avisar { get; set; }
        public int EmpleadoIdEmpleado { get; set; }

        public Empleado EmpleadoIdEmpleadoNavigation { get; set; }
    }
}
