
using JewelryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.Data
{
    public class JewelryContext : DbContext
    {
        public JewelryContext(DbContextOptions<JewelryContext> options) : base(options)
        {
        }

        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Provisioner> Provisioners { get; set; }
        public DbSet<OComponent> OComponents { get; set; }
        public DbSet<MComponent> MComponents { get; set; }
        public DbSet<EResin> EResins { get; set; }
        public DbSet<JType> jTypes { get; set; }
        public DbSet<Metals> Metals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jewelry>().ToTable("Jewelry");
            modelBuilder.Entity<Provisioner>().ToTable("Provisioners");
            modelBuilder.Entity<OComponent>().ToTable("OComponent");
            modelBuilder.Entity<MComponent>().ToTable("MCComponent");
            modelBuilder.Entity<EResin>().ToTable("EResin");
            modelBuilder.Entity<Metals>().ToTable("Metals");
            modelBuilder.Entity<JType>().ToTable("JType");


        }

    }
}
