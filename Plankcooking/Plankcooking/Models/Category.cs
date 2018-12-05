using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plankcooking.Models
{
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public int WebsiteId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public Int16 SortOrder { get; set; }
    }
}
