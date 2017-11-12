using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class Paquete
    {
        [Required]
        public int id { get; set; }

        [Display(Name = "Cantidad del producto")]
        [Range(1, 100, ErrorMessage = "Cantidad invalida")]
        public int cantidad { get; set; }

        [Required]
        [Display(Name = "Fecha de caducidad")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime caducidad { get; set; }

        [ForeignKey("Refrigerador")]
        public int refriId { get; set; }
        public virtual Refrigerador Refrigerador { get; set; }

        [Display(Name = "Producto")]
        [ForeignKey("Producto")]
        public int productId { get; set; }
        public virtual Producto Producto { get; set; }
    }
}