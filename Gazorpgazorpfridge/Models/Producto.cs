using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Producto
    {
        [Display(Name = "Producto")]
        [Required]
        public int id { get; set; }
        [Display(Name = "Codigo")]
        [Required]
        public string codigo { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Espacio volumetrico en Litros")]
        [Required]
        public float espacioVol { get; set; }
        [Display(Name = "Unidades de medicion")]
        [Required]
        public string medida { get; set; }
    }
}