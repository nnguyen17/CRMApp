using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Model
{
    public class ProductRequestModel
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Vendor")]
        public int VendorId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Quantity per Unit")]
        public int QuantityPerUnit { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Display(Name = "Unit in Stock")]
        public int UnitsInStock { get; set; }

        [Required]
        [Display(Name = "Unit on Order")]
        public int UnitsOnOrder { get; set; }

        [Required]
        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
