using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Refrigerador
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "Codigo del refrigerador")]
        [StringLength(12, ErrorMessage = "The {0} must have {2} characters long.", MinimumLength = 12)]
        [ExistModel]
        public string codigo { get; set; }

        [Display(Name = "Capacidad Restante")]
        public float capacidad_restante { get; set; }

        public CanastaBasica micanasta { get; set; }

        public ICollection<Paquete> paquetes { get; set; }

        [ForeignKey("ApplicationUser")]
        public string applicationUser_id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Modelo")]
        public int modeloId { get; set; }

        public virtual Modelo Modelo { get; set; }
    }
}