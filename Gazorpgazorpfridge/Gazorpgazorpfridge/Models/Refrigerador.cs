using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Refrigerador
    {
        public int id { get; set; }
        [Display(Name = "Codigo")]
        [Required]
        public string codigo { get; set; }
        public IEnumerable<Producto> productosAlamcenados { get; set; }
        [Required]
        [Display(Name = "Capacidad")]
        public int capacidad { get; set; }
        [Required]
        [Display(Name = "Indice de Enfriamento")]
        public int indiceDeEnfriamento { get; set; }
    }
}