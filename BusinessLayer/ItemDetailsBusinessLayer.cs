using Microsoft.AspNetCore.Mvc;
using SuperMarket_ShoppingCart.Shared.Models;
using System.Web.Http.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace SuperMarket_ShoppingCartServer.BusinessLayer
{
    public class ItemDetailsBusinessLayer : ControllerBase, IItemDetails
    {
        ShoppingDBContext _context = new ShoppingDBContext();
        public async Task<IActionResult> DeleteItemDetailsAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetails = await _context.ItemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            _context.ItemDetails.Remove(itemDetails);
            await _context.SaveChangesAsync();

            return Ok(itemDetails);
        }

        public IEnumerable<ItemDetails> GetItemDetails()
        {
            return (IEnumerable<ItemDetails>)_context.ItemDetails;
        }               

        public async Task<IActionResult> GetItemDetailsAsync([FromRoute] int id)
        {
            var itemDetails = await _context.ItemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(itemDetails);
            }
        }

        public async Task<IActionResult> PostItemDetailsAsync([FromBody] ItemDetails itemDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (itemDetails == null)
            {
                return NotFound();
            }
            else
            {
                _context.ItemDetails.Add(itemDetails);
                await _context.SaveChangesAsync();
            }
            

            return CreatedAtAction("GetItemDetails", new { id = itemDetails.ItemId }, itemDetails);
        }

        public async Task<IActionResult> PutItemDetailsAsync([FromRoute] int id, [FromBody] ItemDetails itemDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemDetails.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailsExists(id))
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

        public IActionResult PutItemDetailsAsync(ItemDetails itemDetails)
        {
            throw new NotImplementedException();
        }

        private bool ItemDetailsExists(int id)
        {
            return _context.ItemDetails.Any(e => e.ItemId == id);
        }           
    }
}
