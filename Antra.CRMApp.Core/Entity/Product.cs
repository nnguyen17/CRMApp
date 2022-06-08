using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Supplier ID is required")]
        [Column(TypeName = "int")]
        public int SypplierId { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        [Column(TypeName = "int")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Column(TypeName = "int")]
        public int QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        [Column(TypeName = "decimal")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "UnitInStock is required")]
        [Column(TypeName = "int")]
        public int UnitInStock { get; set; }

        [Required(ErrorMessage = "UnitInOrder is required")]
        [Column(TypeName = "int")]
        public int UnitInOrder { get; set; }

        [Required(ErrorMessage = "Reorder Level is required")]
        [Column(TypeName = "int")]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }

    }
}
