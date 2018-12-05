using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plankcooking.Models
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public string PriceDescription { get; set; }

        public Int16 SortOrder { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public decimal Ounces { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public decimal HandlingCost { get; set; }

        [Required]
        public bool TaxExempt { get; set; }
    }
}
