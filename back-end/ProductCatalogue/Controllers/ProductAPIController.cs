using Microsoft.AspNetCore.Mvc;
using ProductCatalogue.Data;
using ProductCatalogue.Models;

namespace ProductCatalogue.Controllers
{
    [Route("api/ProductAPI")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        //---Get List of Products
        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Product>> GetProducts() 
        {
            return Ok(ProductStore.productList);
        }

        //---Get Single Product by ID
        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProduct(int id)
        {
            if ( id == 0 || id < 0) 
            {
                return BadRequest();
            }
            var product = ProductStore.productList.FirstOrDefault(u => u.Id == id);
            if ( product == null ) 
            {
                return NotFound();
            }
            return Ok(product);
        }

        //---Create a Product
        [HttpPost(Name = "PostProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Product> CreateProduct([FromBody]Product product) 
        {
            if (ProductTypeStore.productTypesList.FirstOrDefault(u => u.Name.ToLower() == product.Type.ToLower()) == null)
            {
                ModelState.AddModelError("CustomError", "Not available product Type");
                return BadRequest(ModelState);
            }
            if (product == null) 
            {
                return BadRequest(product);
            }
            if (product.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            product.Id = ProductStore.productList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            ProductStore.productList.Add(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        //---Delete single Product by ID
        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteProduct(int id) 
        {
            if (id == 0 || id < 0)
            {
                return BadRequest();
            }
            var product = ProductStore.productList.FirstOrDefault(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ProductStore.productList.Remove(product);
            return NoContent();
        }

        //---Edit single Product by ID
        [HttpPut("{id:int}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateProduct(int id, [FromBody]Product product) 
        {
            if (product == null || id != product.Id) 
            {
                return BadRequest();
            }
            if (ProductTypeStore.productTypesList.FirstOrDefault(u => u.Name.ToLower() == product.Type.ToLower()) == null)
            {
                ModelState.AddModelError("CustomError", "Not available product Type");
                return BadRequest(ModelState);
            }
            var productFromList = ProductStore.productList.FirstOrDefault(u => u.Id == id);
            productFromList.Type = product.Type;
            productFromList.Description = product.Description;

            return NoContent();
        }
    }
}
