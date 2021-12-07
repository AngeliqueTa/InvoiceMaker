using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class InvoiceitemsModel
    {
        //(ItemID, ItemDescription, Price, Taxable)
        [Key]
        [Column(Order = 1)]
        [Required]
        public int ItemID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemDescription { get; set; }

        public double Price { get; set; }

        public bool Taxable { get; set; }
    }
}