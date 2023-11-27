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
    public class ShoppingDetailsController : IShoppingDetails
    {
        private readonly IShoppingDetails _shoppingdetails;
        private readonly IConfiguration _config;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public ShoppingDetailsController(IConfiguration config, IShoppingDetails shoppingdetails)
        {
            _shoppingdetails = shoppingdetails;
            _config = config;
        }
        public Task<IActionResult> DeleteShoppingDetails([FromRoute] int id)
        {
            return _shoppingdetails.DeleteShoppingDetails(id);
        }

        public IEnumerable<CartItemDetails> GetShoppingDetails()
        {
            return _shoppingdetails.GetShoppingDetails();
        }

        public Task<IActionResult> GetShoppingDetails([FromRoute] int id)
        {
            return _shoppingdetails.GetShoppingDetails(id);
        }

        public Task<IActionResult> PostShoppingDetails([FromBody] ShoppingDetails shoppingDetails)
        {
            return _shoppingdetails.PostShoppingDetails(shoppingDetails);
        }

        public Task<IActionResult> PutShoppingDetails([FromRoute] int id, [FromBody] ShoppingDetails shoppingDetails)
        {
            return _shoppingdetails.PutShoppingDetails(id, shoppingDetails);    
        }
    }
}
