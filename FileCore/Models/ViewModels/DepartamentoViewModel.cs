using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FileCore.Models
{
    public class DepartamentoViewModel
    {
        public int IdDepartamento { get; set; }
        [Required(ErrorMessage = "El nombre no debe de estar vacio.")]
        public string Nombre { get; set; }
    }
}
