using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Refrigerador
    {
        public string codigo { get; set; }
        public IEnumerable<Producto> productosAlamcenados { get; set; }
        public int capacidad { get; set; }
        public int indiceDeEnfriamento { get; set; }
    }
}