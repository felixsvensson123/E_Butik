using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BlazorEcom.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace BlazorEcom.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }

    //Returns all products in DataBase and puts them into a list.
    [HttpGet]
    public async Task<IEnumerable<ProductModel>> GetProductsDb()
    {
        List<ProductModel> dbProducts = await _context.Products.OfType<ProductModel>().ToListAsync();

        return dbProducts;
    }

    //Returns a specific product from DataBase
    [HttpGet("{id:int}")]
    public async Task<ProductModel> GetProductById(int id)
    {
        var result = await GetProductsDb();

        return result.SingleOrDefault(x => x.Id == id);
    }

    //Posts product to DB
    [HttpPost("add")]
    public async Task<ActionResult> PostProduct(ProductModel productModel)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid Data Has Been Received");
        using (var db = _context)
        {
            await db.AddAsync(new ProductModel()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Stock = productModel.Stock,
                Category = productModel.Category,
                Loaned = productModel.Loaned,
                ImgUrl = productModel.ImgUrl,
                Price =  productModel.Price,
            });
            await db.SaveChangesAsync();
        }

        return Ok();
    }
    
    //Updates product to DB
    [HttpPut("edit/{id}")]
    public async Task<ActionResult> UpdateProduct(ProductModel productModel, int id)
    {
        //Checks if object is valid!
        if (!ModelState.IsValid)
            return BadRequest("Invalid Data Has Been Received");
        
        ProductModel updateThis = await GetProductById(id);
        updateThis.Name = productModel.Name;
        updateThis.Stock = productModel.Stock;
        updateThis.Category = productModel.Category;
        updateThis.Loaned = productModel.Loaned;
        updateThis.Price = productModel.Price;
        updateThis.ImgUrl = productModel.ImgUrl;
        
        _context.Update(updateThis);
        await _context.SaveChangesAsync();
        return Ok(updateThis);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid Data Has Been Recieved");
        
        ProductModel deleteThis = await GetProductById(id);
        _context.Products.Remove(deleteThis);
        await _context.SaveChangesAsync();
        return Ok();
    }
}