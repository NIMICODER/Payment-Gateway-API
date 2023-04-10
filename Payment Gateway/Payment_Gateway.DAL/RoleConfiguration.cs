using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment_Gateway.Models.Entities;

namespace Payment_Gateway.DAL
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
             new IdentityRole
             {
                 Name = "Admin",
                 NormalizedName = "ADMIN"
             },
             new IdentityRole
             {
                 Name = "User",
                 NormalizedName = "USER"
             },
             new IdentityRole
             {
                 Name = "Merchant",
                 NormalizedName = "MERCHANT"
             } 
             );
        }

        public void Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Merchant").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Merchant",
                    NormalizedName = "MERCHANT"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

        }
    }


}