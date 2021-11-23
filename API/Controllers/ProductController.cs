using Microsoft.AspNetCore.Mvc;
using System;
using Infrastructure.Data;
using System.Collections.Generic;
using core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController :ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo){
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products =await _repo.GetProductAsync();
            return Ok(products);            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var products = await _repo.GetProductByIdAsync(id);
            return products;           
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
           return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes(){
           return Ok(await _repo.GetProductTypesAsync());
        }

        
    }
}