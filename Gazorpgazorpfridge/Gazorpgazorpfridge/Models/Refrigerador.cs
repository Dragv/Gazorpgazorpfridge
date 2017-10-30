using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Refrigerador
    {
        public int id { get; set; }

        public virtual ICollection<Paquete> productosAlamcenados { get; set; }

        public CanastaBasica canastaBasica { get; set; }

        [ForeignKey("Modelo")]
        public int modeloId { get; set; }
    }
}