using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class CanastaBasica
    {

        public int id { get; set; }

        public virtual ICollection<Producto> productos { get; set; }

        public string descripcion { get; set; }

        public float perEscasez { get; set; }

    }
}