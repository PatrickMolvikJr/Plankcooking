using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plankcooking.Models
{
    public partial class OrderCart
    {
        [Key]
        public int OrderCartId { get; set; }    

        public int WebsiteId { get; set; }

        public Guid UniqueIdentifier { get; set; }
    }
}
