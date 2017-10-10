using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Account
    {
        public string correo { set; get; }
        public string password { set; get; }
        public Receta canastaBasica { set; get; }

    }
}