using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DataContext.DataManager.Models
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product register date is required")]
        public DateTime ProductRegisterDate { get; set; }

        [Required(ErrorMessage = "Unit price is required")]
        public decimal UnitPrice { get; set; }
        public bool IsImported { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
