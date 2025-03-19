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

    [HttpGet("ProductById/{id}")]
   public IActionResult GetProduct(int id){
        return Ok(pl.FirstOrDefault(x => x.Id == id));
   }

    [HttpGet("ProductByName/{name}")]
   public IActionResult GetProduct(string name){
        return Ok(pl.FirstOrDefault(x => x.Name == name));
   }
}
