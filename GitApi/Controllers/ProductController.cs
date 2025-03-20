using Microsoft.AspNetCore.Mvc;

namespace GitApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IList<Product> pl): ControllerBase
{
    [HttpPost("newProduct")]
    public IActionResult CreateProduct([FromBody] Product newproduct)
    {
        pl.Add(newproduct);
        return Ok();
    }

    [HttpGet("ProductById/{id}")]
    public IActionResult GetProduct(int id)
    {
        return Ok(pl.FirstOrDefault(x => x.Id == id));
    }

    [HttpGet("ProductByName/{name}")]
    public IActionResult GetProduct(string name)
    {
        return Ok(pl.FirstOrDefault(x => x.Name == name));
    }

    [HttpGet("Products")]
    public IActionResult GetProducts()
    {
        return Ok(pl);
    }

    [HttpPut("ProductName/{id}/{name}")]
    public IActionResult ChangeProductName(int id, string name)
    {
        try
        {
            Product? product = pl.FirstOrDefault(x => x.Id == id);

            if(product!=null){
                product.Name = name;
                return Ok();
            }
            return NotFound();
        }
        catch
        {
            return NotFound();
        }
    }

     [HttpPut("ProductPrice/{id}/{price}")]
    public IActionResult ChangeProductPrice(int id, decimal price)
    {
        try
        {
            Product? product = pl.FirstOrDefault(x => x.Id == id);

            if(product != null){
                product.Price = price;
                return Ok();
            }
            return NotFound();
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id){
        try
        {
            Product? product = pl.FirstOrDefault(x => x.Id == id);

            if(product != null){
                pl.Remove(product);
                return Ok();
            }
            return NotFound();
        }
        catch
        {
            return NotFound();
        }
    }
}
