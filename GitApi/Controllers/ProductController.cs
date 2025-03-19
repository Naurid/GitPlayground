using Microsoft.AspNetCore.Mvc;

namespace GitApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IList<Product> pl): ControllerBase
{
   [HttpPost("newProduct")]
   public IActionResult CreateProduct([FromBody] Product newproduct){
        pl.Add(newproduct);
        return Ok();
   }
}
