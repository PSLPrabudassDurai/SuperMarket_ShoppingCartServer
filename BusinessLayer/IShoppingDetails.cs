using Microsoft.AspNetCore.Mvc;
using SuperMarket_ShoppingCart.Shared.Models;

namespace SuperMarket_ShoppingCartServer.BusinessLayer
{
    public interface IShoppingDetails
    {
        public IEnumerable<CartItemDetails> GetShoppingDetails();
        public Task<IActionResult> GetShoppingDetails([FromRoute] int id);
        public Task<IActionResult> PutShoppingDetails([FromRoute] int id, [FromBody] ShoppingDetails shoppingDetails);
        public Task<IActionResult> PostShoppingDetails([FromBody] ShoppingDetails shoppingDetails);
        public Task<IActionResult> DeleteShoppingDetails([FromRoute] int id);

    }
}
