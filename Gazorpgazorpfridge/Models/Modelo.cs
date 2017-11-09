using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Modelo
    {
        public int id { get; set; }
        [Display(Name = "Codigo")]
        [Required]
        public string codigo { get; set; }
        [Display(Name = "Capacidad")]
        [Required]
        public float capacidad { get; set; }
        [Display(Name = "Indice de Enfriamento")]
        [Required]
        public float indiceEnfriamiento { get; set; }
    }
}