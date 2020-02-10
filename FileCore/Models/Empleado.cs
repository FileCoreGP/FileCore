using System;
using System.Collections.Generic;

namespace FileCore.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Capacitaciones = new HashSet<Capacitaciones>();
            Datospariente = new HashSet<Datospariente>();
            Empleosanteriores = new HashSet<Empleosanteriores>();
            Evidenciasempleado = new HashSet<Evidenciasempleado>();
            Gradoescolaridad = new HashSet<Gradoescolaridad>();
            HistorialcategoriasPuestos = new HashSet<HistorialcategoriasPuestos>();
            PremiosReconocimientos = new HashSet<PremiosReconocimientos>();
        }

        public int IdEmpleado { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int DepartamentoIdDepartamento { get; set; }
        public int CategoriaIdCategoria { get; set; }

        public Categoria CategoriaIdCategoriaNavigation { get; set; }
        public Departamento DepartamentoIdDepartamentoNavigation { get; set; }
        public ICollection<Capacitaciones> Capacitaciones { get; set; }
        public ICollection<Datospariente> Datospariente { get; set; }
        public ICollection<Empleosanteriores> Empleosanteriores { get; set; }
        public ICollection<Evidenciasempleado> Evidenciasempleado { get; set; }
        public ICollection<Gradoescolaridad> Gradoescolaridad { get; set; }
        public ICollection<HistorialcategoriasPuestos> HistorialcategoriasPuestos { get; set; }
        public ICollection<PremiosReconocimientos> PremiosReconocimientos { get; set; }
    }
}
