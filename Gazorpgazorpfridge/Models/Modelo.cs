using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gazorpgazorpfridge.Models
{
    public class Modelo
    {
        [Required]
        public int id { get; set; }

        [Display(Name = "Codigo")]
        [StringLength(12, ErrorMessage = "The {0} must have {2} characters long.", MinimumLength = 12)]
        [Required]
        public string codigo { get; set; }

        [Display(Name = "Capacidad Maxima")]
        [Required]
        public float capacidad { get; set; }

        [Display(Name = "Indice de Enfriamento")]
        [Required]
        public float indiceEnfriamiento { get; set; }
    }
}