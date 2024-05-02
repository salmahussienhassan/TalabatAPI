using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task Seed(StoreDbContext dbContext)
        {

            if (!dbContext.productBrands.Any())
            {
                var BrandsData = File.ReadAllText("../TalabatRepository/Data/DataSeed/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                if (Brands?.Count > 0)

                    foreach (var Brand in Brands)
                    {
                        dbContext.productBrands.Add(Brand);
                        await dbContext.SaveChangesAsync();
                    }


            }


            if (!dbContext.productsType.Any())
            {
                var TypesData = File.ReadAllText("../TalabatRepository/Data/DataSeed/types.json");
                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                if (Types?.Count > 0)

                    foreach (var type in Types)
                    {
                        dbContext.productsType.Add(type);
                        await dbContext.SaveChangesAsync();
                    }


            }

            if (!dbContext.products.Any())
            {
                var ProductsData = File.ReadAllText("../TalabatRepository/Data/DataSeed/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (Products?.Count > 0)

                    foreach (var product in Products)
                    {
                        dbContext.products.Add(product);
                        await dbContext.SaveChangesAsync();
                    }


            }



        }
    }
}
