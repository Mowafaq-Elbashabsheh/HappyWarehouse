using HappyWarehouse.Core.Common;
using HappyWarehouse.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;

namespace HappyWarehouse.DataAccess.Persistence
{
    public class WarehouseDBContext : DbContext
    {
        public WarehouseDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Country> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>(x =>
            {
                x.HasIndex(x => x.Name).IsUnique();

                x.HasMany(z => z.Items)
                    .WithOne(z => z.Warehouse)
                    .HasForeignKey(z=>z.WarehouseId);

                x.HasOne(z => z.Country)
                    .WithMany()
                    .HasForeignKey(z => z.CountryId);

            });
            modelBuilder.Entity<Item>(x =>
            {
                x.HasIndex(x => x.Name).IsUnique();
            });
            modelBuilder.Entity<User>(x =>
            {
                x.HasIndex(x => x.Email).IsUnique();

                x.HasOne(z => z.Role)
                    .WithMany()
                    .HasForeignKey(z => z.RoleId);
            });

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", NameAr = "مسؤول النظام" },
                new Role { Id = 2, Name = "Management", NameAr = "ادارة" },
                new Role { Id = 3, Name = "Auditor", NameAr = "مدقق" }
            );

            /*modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Jordan", NameAr = "الأردن" },
                new Country { Id = 2, Name = "Palastine", NameAr = "فلسطين" },
                new Country { Id = 3, Name = "Syria", NameAr = "سوريا" },
                new Country { Id = 3, Name = "Iraq", NameAr = "العراق" }
            );*/

            base.OnModelCreating(modelBuilder);
        }

    }
}
