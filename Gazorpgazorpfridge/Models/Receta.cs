using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Receta
    {
        [Required]
        public int id { get; set; }

        [Display(Name = "Productos")]
        public virtual ICollection<Producto> productos { get; set; }

        public virtual ICollection<ProductForReceta> productosForReceta { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [ForeignKey("ApplicationUser")]
        public string applicationUser_id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}