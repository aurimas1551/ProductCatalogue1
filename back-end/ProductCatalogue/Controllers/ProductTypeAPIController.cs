using Microsoft.AspNetCore.Mvc;
using ProductCatalogue.Data;
using ProductCatalogue.Models;

namespace ProductCatalogue.Controllers
{
    [Route("api/ProductTypeAPI")]
    [ApiController]
    public class ProductTypeAPIController : ControllerBase
    {
        //---Get List of ProductTypes
        [HttpGet(Name = "GetProductTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductType>> GetProductTypes() 
        {
            return Ok(ProductTypeStore.productTypesList);
        }

    }
}
