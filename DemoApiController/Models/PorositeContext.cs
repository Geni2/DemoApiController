using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DemoApiController.Models;
using DemoApiController.DbTable;

namespace DemoApiController.Models
{
    public partial class PorositeContext : DbContext
    {


        public DbSet<Porosi> Porosi { get; set; }
        //public DbSet<Porosite> Developer { get; set; }

        public PorositeContext(DbContextOptions<PorositeContext> options)
       : base(options)
        {      
    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Porosi>(entity =>
            {
                entity.ToTable("Porosi");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
