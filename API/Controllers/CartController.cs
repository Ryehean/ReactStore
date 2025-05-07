using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class CartController(StoreContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<Cart>> GetCart()
    {
        var cart = await RetrieveCart();

        if (cart == null) return NoContent();

        return cart;
    }

    [HttpPost]
    public async Task<ActionResult> AddItemToCart(int productId, int quantity)
    {
        var cart = await RetrieveCart();

        cart ??= CreateCart();

        // get product
        var product = await context.Products.FindAsync(productId);
        if (product == null) return BadRequest("Problem adding item to cart");

        // add item to cart
        cart.AddItem(product, quantity);

        // save changes
        var result = await context.SaveChangesAsync() > 0;

        if (result) return CreatedAtAction(nameof(GetCart), cart);

        return BadRequest("Problem updating cart");
    }



    [HttpDelete]
    public async Task<ActionResult> RemoveCartItem(int productId, int quantity)
    {
        // get cart
        var cart = await RetrieveCart();
        // remove the item from the cart or reduce it's quantity
        // save changes
        return Ok();
    }

    private Cart CreateCart()
    {
        var cartId = Guid.NewGuid().ToString();

        var cookieOptions = new CookieOptions
        {
            IsEssential = true,
            Expires = DateTime.UtcNow.AddDays(30)
        };

        Response.Cookies.Append("cartId", cartId, cookieOptions);
        var cart = new Cart { CartId = cartId };
        context.Carts.Add(cart);
        return cart;
    }

    private async Task<Cart?> RetrieveCart()
    {
        return await context.Carts
        .Include(x => x.Items)
        .ThenInclude(x => x.Product)
        .FirstOrDefaultAsync(x => x.CartId == Request.Cookies["cartid"]);
    }

}
