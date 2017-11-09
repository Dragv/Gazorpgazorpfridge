using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Modelo> modelos { get; set; }
        public IEnumerable<Producto> productos { get; set; }
    }
}