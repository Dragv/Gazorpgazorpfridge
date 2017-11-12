using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class UserViewModel
    {
        public IEnumerable<Refrigerador> refrigeradores { get; set; }
        public IEnumerable<Receta> recetas { get; set; }
    }
}