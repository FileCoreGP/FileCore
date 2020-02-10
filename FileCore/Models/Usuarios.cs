using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Usuarios
    {
        public int IdUsuarios { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
    }
}
