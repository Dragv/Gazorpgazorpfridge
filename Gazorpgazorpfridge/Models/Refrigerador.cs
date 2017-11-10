using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public CanastaBasica micanasta { get; set; }

        [ForeignKey("Modelo")]
        public int modeloId { get; set; }

        public virtual Modelo Modelo { get; set; }
    }
}