using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Evidencias
    {
        public Evidencias()
        {
            Evidenciasempleado = new HashSet<Evidenciasempleado>();
        }

        public int IdEvidencias { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool AdmiteComprobante { get; set; }
        public int Orden { get; set; }

        public ICollection<Evidenciasempleado> Evidenciasempleado { get; set; }
    }
}
