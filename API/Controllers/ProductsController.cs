using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
      private readonly IProductRepository _repo;
      public ProductsController(IProductRepository repo)
      {
         _repo = repo;
      }

      [HttpGet]
      public async Task<ActionResult<List<Product>>> GetProducts()
      {
        var prodcuts = await _repo.GetProductAsync();
        return Ok(prodcuts);
      } 

      
      // [HttpGet]
      // public async Task<ActionResult<List<Product>>> GetProductByType()
      // {
      //   var prodcuts = await _repo.GetProductAsync();
      //   return Ok(prodcuts);
      // } 


      [HttpGet("{id}")]
      public async Task<ActionResult<Product>> GetProduct(int id)
      {  
        return await _repo.GetProfuctByIdAsync(id);         
      } 

      // [HttpGet("{brands}")]
      // public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
      // {  
      //   return Ok(await _repo.GetProductBrandAsync());
      // }

      // [HttpGet("{types}")]
      // public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
      // {  
      //   return Ok(await _repo.GetProductTypesAsync());
      // }    
    }
}