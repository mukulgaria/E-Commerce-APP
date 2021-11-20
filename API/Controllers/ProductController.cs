using Microsoft.AspNetCore.Mvc;
using System;
using Infrastructure.Data;
using System.Collections.Generic;
using core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController :ControllerBase
    {
        private readonly StoreContext _context;
        public ProductController(StoreContext storeContext){
            _context= storeContext;

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products =await _context.Products.ToListAsync();
            return Ok(products);            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            var products = await _context.Products.FindAsync(id);
            return products;
           

        }

        
    }
}