﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gazorpgazorpfridge.Models
{
    public class CanastaBasica
    {
        [Required]
        public int id { get; set; }

        public virtual ICollection<Producto> productos { get; set; }

        [Display(Name = "Productos")]
        public virtual ICollection<ProductForCanasta> productForCanasta { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }


        [Display(Name = "Porcentaje de escasez")]
        [Range(0.1, 1, ErrorMessage = "Cantidad debe ser entre 0.1 - 1.0")]
        public float perEscasez { get; set; }

        [ForeignKey("Refrigerador")]
        public int refriId { get; set; }

        public virtual Refrigerador Refrigerador { get; set; }
    }
}