using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Title of Courstesy is required")]
        [Column(TypeName = "varchar(50)")]
        public string TitleofCourstesy { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Hire Date is required")]
        [Column(TypeName = "datetime")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "varchar(50)")]
        public int City { get; set; }

        [Required(ErrorMessage = "Region ID is required")]
        [Column(TypeName = "int")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [Column(TypeName = "varchar(50)")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "ReportsTo is required")]
        [Column(TypeName = "int")]
        public int ReportsTo { get; set; }

        [Required(ErrorMessage = "Photo Path is required")]
        [Column(TypeName = "varchar(50)")]
        public string PhotoPath { get; set; }
    }
}
