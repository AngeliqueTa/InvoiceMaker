using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class InvoiceModel
    {
        //(InvoiceID, DueDate, TotalAmount, CustomerID)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        [Required]
        public int InvoiceID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 2)]
        [Required]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(100)]
        public DateTime DueDate { get; set; }

        [Required]
        [MaxLength(100)]
        public DateTime DateOfInvoice { get; set; }

        public double TotalAmount { get; set; }
    }
}