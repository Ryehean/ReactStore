using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Product> Products { get; set; }


    public required DbSet<Books> Books { get; set; }


    public required DbSet<Cart> Carts { get; set; }

}
