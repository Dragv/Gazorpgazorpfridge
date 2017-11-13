using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class ProductForReceta
    {
        [Required]
        public int id { get; set; }

        [ForeignKey("Receta")]
        public int recetaId { get; set; }
        public virtual Receta Receta { get; set; }

        [ForeignKey("Producto")]
        public int productoId { get; set; }
        public virtual Producto Producto { get; set; }
    }
}