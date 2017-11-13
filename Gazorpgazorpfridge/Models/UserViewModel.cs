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
<<<<<<< HEAD
        public CanastaBasica canasta { get; set; }
=======
>>>>>>> 122eac8a0b362dc5dec25d38a7f9a3ac341672dc
    }
}