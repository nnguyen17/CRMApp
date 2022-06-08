using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Entity
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Contact Title is required")]
        [Column(TypeName = "varchar(50)")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Region ID is required")]
        [Column(TypeName = "int")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [Column(TypeName = "varchar(50)")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

    }
}
