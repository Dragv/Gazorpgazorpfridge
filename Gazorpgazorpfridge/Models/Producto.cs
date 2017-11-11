using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Producto
    {
        [Required]
        public int id { get; set; }
        [Display(Name = "Codigo")]
        [Required]
        public string codigo { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Espacio en Volumen")]
        [Required]
        public float espacioVol { get; set; }
        [Display(Name = "Medida")]
        [Required]
        public string medida { get; set; }
    }
}