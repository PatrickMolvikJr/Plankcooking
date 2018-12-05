using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plankcooking.Models
{
    public class CartViewModel
    {
        public List<Product> Products;
        public int OrderCartId;
        public List<OrderItem> OrderItems;
        public Guid guid;

        public CartViewModel()
        {
            guid = Guid.NewGuid();
            Products = new List<Product>();
            OrderCartId = 0;
            OrderItems = new List<OrderItem>();
        }
    }
}
