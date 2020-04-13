using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TruYumMVCExercise.Models
{
    public class TruYumContext : DbContext
    {
        public TruYumContext() : base("Name =TruYumConnectionString")

        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}