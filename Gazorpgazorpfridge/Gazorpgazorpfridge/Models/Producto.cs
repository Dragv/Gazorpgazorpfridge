using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Producto
    {
        public int id { get; set; }
 
        public string codigo { get; set; }
 
        public string nombre { get; set; }
 
        public float espacioVol { get; set; }
 
        public string medida { get; set; }
    }
}