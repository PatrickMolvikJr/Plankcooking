using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plankcooking.Models
{
    public class AddOrderItem
    {
        [Required(ErrorMessage = "You need to Enter a Quantity")]
        [Range(1, 20, ErrorMessage = "Please Enter an Amount between 1 and 20")]
        public int Qty { get; set; }

        public int ProductId { get; set; }

        public List<Product> Products;

        public AddOrderItem()
        {
            Qty = 0;
            Products = new List<Product>();
            ProductId = 0;
        }
    }
}
