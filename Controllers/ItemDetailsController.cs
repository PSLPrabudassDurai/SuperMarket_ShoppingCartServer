using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SuperMarket_ShoppingCart.Shared.Models;
using SuperMarket_ShoppingCartServer.BusinessLayer;
using System.Data;

namespace SuperMarket_ShoppingCartServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDetailsController : ControllerBase, IItemDetails
    {
        private readonly IItemDetails _itemdetails;
        private readonly IConfiguration _config;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public ItemDetailsController(IConfiguration config, IItemDetails itemdetails)
        {
            _itemdetails = itemdetails;
            _config = config;
        }

        public IEnumerable<ItemDetails> GetItemDetails()
        {
            return _itemdetails.GetItemDetails();
        }

        public Task<IActionResult> GetItemDetailsAsync([FromRoute] int id)
        {
            return _itemdetails.GetItemDetailsAsync(id);
        }

        public Task<IActionResult> PutItemDetailsAsync([FromRoute] int id, [FromBody] ItemDetails itemDetails)
        {
            return _itemdetails.PutItemDetailsAsync(id, itemDetails);
        }

        public Task<IActionResult> PostItemDetailsAsync([FromBody] ItemDetails itemDetails)
        {
            return _itemdetails.PostItemDetailsAsync(itemDetails);
        }

        public Task<IActionResult> DeleteItemDetailsAsync([FromRoute] int id)
        {
            return _itemdetails.DeleteItemDetailsAsync(id);
        }        
    }
}
