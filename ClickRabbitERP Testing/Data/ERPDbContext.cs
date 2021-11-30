using ClickRabbitERP_Testing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClickRabbitERP_Testing.Data
{
    public class ERPDbContext:DbContext
    {
        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Item> ItemMaster { get; set; }
        public DbSet<ItemCategoryModel> ItemCategoryMaster { get; set; }
        public DbSet<VendorViewModel> VendorMaster { get; set; }

        public DbSet<PurchaseOrderModel> PurchaseOrderMaster { get; set; }

        public DbSet<PurchaseLineModel> PurchaseLineMaster { get; set; }

        public DbSet<SalesOrderModel> SalesOrderMaster { get; set; }
        public DbSet<SalesLineModel> SalesLineMaster { get; set; }
        public DbSet<CustomerViewModel> CustomerMaster { get; set; }


        public ERPDbContext(DbContextOptions<ERPDbContext> options):base(options)
        {

        }
        ////
        //public override void OnModelCreateing(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AppUser>(entity =>
        //    {
        //        entity.HasKey(e => e.UserId);
        //        entity.Property(e => e.UserId);
        //        entity.Property(e => e.NameOfIdentifier).HasMaxLength(250);
        //        entity.Property(e => e.Username).HasMaxLength(250);
        //        entity.Property(e => e.Password).HasMaxLength(250);
        //        entity.Property(e => e.Email).HasMaxLength(250);
        //        entity.Property(e => e.FirstName).HasMaxLength(250);
        //        entity.Property(e => e.LastName).HasMaxLength(250);
        //        entity.Property(e => e.Mobile).HasMaxLength(250);
        //        entity.Property(e => e.Roles).HasMaxLength(250);

        //        entity.HasData(new AppUser
        //        {
        //            UserId = 1,
        //            Email = "keyur@gmail.com",
        //            Username = "keyur@gmail.com",
        //            Password = "pizza",
        //            FirstName = "keyur",
        //            LastName = "thakkar",
        //            Mobile = "9265337904",
        //            Roles = "Admin"
        //        });

        //    });
        //}
    }
}
