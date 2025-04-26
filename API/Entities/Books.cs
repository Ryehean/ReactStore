using System;

namespace API.Entities;

public class Books
{
    public int Id { get; set; }

    public required string Title { get; set; }
    public int Issue { get; set; }

    public long Price { get; set; }
    public required string PictureUrl { get; set; }

    public required string Publisher { get; set; }

    public required string Writer { get; set; }

    public int QuantityInStock { get; set; }
}
