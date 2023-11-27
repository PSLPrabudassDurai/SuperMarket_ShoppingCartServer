using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket_ShoppingCart.Shared.Models;

namespace SuperMarket_ShoppingCartServer.BusinessLayer
{
    public class ShoppingDetailsBusinessLayer : ControllerBase, IShoppingDetails
    {
        ShoppingDBContext _context = new ShoppingDBContext();
        public async Task<IActionResult> DeleteShoppingDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingDetails = await _context.ShoppingDetails.FindAsync(id);
            if (shoppingDetails == null)
            {
                return NotFound();
            }

            _context.ShoppingDetails.Remove(shoppingDetails);
            await _context.SaveChangesAsync();

            return Ok(shoppingDetails);
        }

        public IEnumerable<CartItemDetails> GetShoppingDetails()
        {
            var results = (from items in _context.ItemDetails
                           join shop in _context.ShoppingDetails
                                on items.ItemId equals shop.ItemId
                           select new CartItemDetails
                           {

                               ShopId = shop.ShopId,
                               ItemName = items.ItemName,
                               Qty = shop.Qty,
                               TotalAmount = items.ItemName == "A" && shop.Qty >= 3 ? shop.TotalAmount - 20 : items.ItemName == "B" && shop.Qty >= 2 ? shop.TotalAmount - 11 : shop.TotalAmount,
                               Description = shop.Description,
                               ShoppingDate = shop.ShoppingDate
                           }).ToList();


            return results;
        }

        public async Task<IActionResult> GetShoppingDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shoppingDetails = await _context.ShoppingDetails.FindAsync(id);

            if (shoppingDetails == null)
            {
                return NotFound();
            }

            return Ok(shoppingDetails);
        }

        public async Task<IActionResult> PostShoppingDetails([FromBody] ShoppingDetails shoppingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ShoppingDetails.Add(shoppingDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingDetails", new { id = shoppingDetails.ShopId }, shoppingDetails);
        }

        public async Task<IActionResult> PutShoppingDetails([FromRoute] int id, [FromBody] ShoppingDetails shoppingDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingDetails.ShopId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool ShoppingDetailsExists(int id)
        {
            return _context.ShoppingDetails.Any(e => e.ShopId == id);
        }
    }
}
