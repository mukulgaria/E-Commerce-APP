using Microsoft.Extensions.Logging;
using System.Linq;
using System.IO;
using System.Text.Json;
using core.Entities;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeedData
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){

            try{
                if(!context.ProductBrands.Any()){
                   var brandData =  File.ReadAllText("../Infrastructure/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach(var item in brands){
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                 if(!context.ProductTypes.Any()){
                   var typesData =  File.ReadAllText("../Infrastructure/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach(var item in types){
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                  if(!context.Products.Any()){
                   var typesData =  File.ReadAllText("../Infrastructure/SeedData/products.json");
                    var types = JsonSerializer.Deserialize<List<Product>>(typesData);

                    foreach(var item in types){
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }
            catch(Exception e){
                var logger = loggerFactory.CreateLogger<StoreContextSeedData>();
                logger.LogError(e.Message);

            }

        }
    }
}