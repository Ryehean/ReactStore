using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }


    public required DbSet<Books> Books { get; set; }


    public required DbSet<Cart> Carts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
        .HasData(
            new IdentityRole { Id = "40473259-2369-4f02-9731-158578f4f445", Name = "Member", NormalizedName = "MEMBER" },
            new IdentityRole { Id = "40866ae7-dfde-4c22-b872-e0ea532beed5", Name = "Admin", NormalizedName = "ADMIN" }
        );
    }

}
