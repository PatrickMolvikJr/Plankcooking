using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plankcooking.Models
{
    public partial class Website
    {
        [Key]
        public int WebsiteId { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string URL { get; set; }
    }
}
