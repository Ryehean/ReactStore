using System;
using API.DTOs;
using API.Entities;

namespace API.Extensions;

public static class CartExtensions
{
    public static CartDto ToDto(this Cart cart)
    {
        return new CartDto
        {
            CartId = cart.CartId,
            Items = cart.Items.Select(x => new CartItemDto
            {
                ProductId = x.ProductId,
                Name = x.Product.Name,
                Price = x.Product.Price,
                Brand = x.Product.Brand,
                Type = x.Product.Type,
                PictureUrl = x.Product.PictureUrl,
                Quantity = x.Quantity
            }).ToList()
        };
    }
}
