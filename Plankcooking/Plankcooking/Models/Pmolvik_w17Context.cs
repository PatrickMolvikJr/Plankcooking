using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plankcooking.Models;

namespace Plankcooking.Models
{
    public class Pmolvik_w17Context : DbContext
    {
        public Pmolvik_w17Context(DbContextOptions<Pmolvik_w17Context> options) : base(options) { }

        public virtual DbSet<Plankcooking.Models.Website> Websites { get; set; }

        public virtual DbSet<Plankcooking.Models.Category> Categories { get; set; }

        public virtual DbSet<Plankcooking.Models.Product> Products { get; set; }

        public virtual DbSet<Plankcooking.Models.OrderCart> OrderCarts { get; set; }

        public virtual DbSet<Plankcooking.Models.OrderItem> OrderItems { get; set; }
    }
}