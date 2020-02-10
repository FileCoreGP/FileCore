using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Gradoescolaridad
    {
        public int IdGradoEscolaridad { get; set; }
        public string NivelAcademico { get; set; }
        public string NombreGrado { get; set; }
        public string Institucion { get; set; }
        public string Cedula { get; set; }
        public int EmpleadoIdEmpleado { get; set; }

        public Empleado EmpleadoIdEmpleadoNavigation { get; set; }
    }
}
