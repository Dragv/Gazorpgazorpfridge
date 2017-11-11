using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Paquete
    {
        [Required]
        public int id { get; set; }

        public int cantidad { get; set; }

        public string caducidad { get; set; }

        [ForeignKey("Producto")]
        public int productId { get; set; }
        public virtual Producto Producto { get; set; }
    }
}