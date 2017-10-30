using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Paquete
    {
        public int id { get; set; }

        public int cantidad { get; set; }

        public string caducidad { get; set; }

        [ForeignKey("Producto")]
        public int productId { get; set; }
    }
}