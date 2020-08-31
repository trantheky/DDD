using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Infrastructure
{
    public class OrderManagementContext: IdentityDbContext<AppUser>
    {
        public OrderManagementContext(DbContextOptions options)
           : base(options)
        {
            
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Product & OrderLine
            modelBuilder.Entity<Product>().HasMany(c => c.OrderLines).WithOne(c => c.Product).HasForeignKey(p => p.ProductId);            
            modelBuilder.Entity<Product>().Property(p => p.VolumetricWeight).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderLine>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");

            //Order & OrderLine & Address & Transit Locations
            modelBuilder.Entity<Order>().HasMany(c => c.OrderLines).WithOne(c => c.Order).HasForeignKey(p => p.OrderId);
            modelBuilder.Entity<Order>().HasMany(c => c.TransitLocations).WithOne(c => c.Order).HasForeignKey(p => p.OrderId);
            modelBuilder.Entity<TransitLocation>().OwnsOne(c => c.Address);
            //modelBuilder.Entity<Order>().OwnsMany(p => p.TransitLocations, a =>
            //{
            //    a.OwnsOne(c => c.Address);
            //    a.WithOwner()
            //     .HasForeignKey("OrderId");
            //    a.Property<int>("Id");
            //    a.HasKey("Id");
            //});
                        
            modelBuilder.Entity<AppUser>().HasMany(c => c.Orders).WithOne(c => c.Customer).HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Order>().OwnsOne(p => p.BillingAddress);
            modelBuilder.Entity<Order>().OwnsOne(p => p.ShippingAddress);
                        
            modelBuilder.Entity<Order>().Property(p => p.ShippingCost).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>().Property(p => p.TotalCost).HasColumnType("decimal(18,2)");
            
        }
    }
}
