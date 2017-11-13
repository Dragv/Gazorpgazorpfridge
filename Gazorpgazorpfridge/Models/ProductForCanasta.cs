using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class ProductForCanasta
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "Cantidad Maxima")]
        //[Range(1, 100, ErrorMessage = "Cantidad invalida")]
        public float CantidadMaxima { get; set; }

        [ForeignKey("CanastaBasica")]
        public int canastaId { get; set; }
        public virtual CanastaBasica CanastaBasica { get; set; }

        [Display(Name = "Producto")]
        [ForeignKey("Producto")]
        public int productoId { get; set; }
        public virtual Producto Producto { get; set; }
    }
}