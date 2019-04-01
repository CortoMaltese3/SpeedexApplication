namespace SpeedexApplication.Application
{
    using SpeedexApplication.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class SpeedexContext : DbContext
    {
        public SpeedexContext()
            : base("name=ConnectionString")
        {
            Database.SetInitializer<SpeedexContext>(new DropCreateDatabaseIfModelChanges<SpeedexContext>());
        }

        public DbSet<Area> Area { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Customer>()
            //    .HasMany(c => c.Areas).WithMany(a => a.Customers)
            //    .Map(t => t.MapLeftKey("CustomerId")
            //               .MapRightKey("AreaId")
            //               .ToTable("CustomerArea")
            //    );
            base.OnModelCreating(modelBuilder);
        }

    }
}