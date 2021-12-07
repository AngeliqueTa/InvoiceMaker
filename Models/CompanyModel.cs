using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CompanyModel
    {
        //(CompanyID, CompanyName, City, Street, Zip, PhoneNumber, Fax, Website)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        [Required]
        public int CompanyID { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }

        [MaxLength(250)]
        public string City { get; set; }

        [MaxLength(250)]
        public string Street { get; set; }

        [MaxLength(250)]
        public string Zip { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [MaxLength(10)]
        public string Fax { get; set; }

        [MaxLength(250)]
        public string Website { get; set; }
    }
}