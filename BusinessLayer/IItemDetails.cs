using Microsoft.AspNetCore.Mvc;
using SuperMarket_ShoppingCart.Shared.Models;

namespace SuperMarket_ShoppingCartServer.BusinessLayer
{
    public interface IItemDetails
    {
        public IEnumerable<ItemDetails> GetItemDetails();
        public Task<IActionResult> GetItemDetailsAsync([FromRoute] int id);
        public Task<IActionResult> PutItemDetailsAsync([FromRoute] int id, [FromBody] ItemDetails itemDetails);
        public Task<IActionResult> PostItemDetailsAsync([FromBody] ItemDetails itemDetails);
        public Task<IActionResult> DeleteItemDetailsAsync([FromRoute] int id);        
    }
}
