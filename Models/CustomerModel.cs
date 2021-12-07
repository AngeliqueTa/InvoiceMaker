using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CustomerModel
    {
        //(CustomerID,LastName, FirstName, City, Street, Zip, PhoneNumber,CompanyID)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        [Required]
        public int CustomerID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 2)]
        [Required]
        public int CompanyID { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string City { get; set; }

        [MaxLength(250)]
        public string Street { get; set; }

        [MaxLength(250)]
        public string Zip { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}