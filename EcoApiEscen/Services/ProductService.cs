using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommandLib;
using EcoApiEscen.Database;
using Microsoft.EntityFrameworkCore;

namespace EcoApiEscen.Services {
    internal class ProductService : IProductService {
        private readonly EcoDbContext _dbContext;

        public ProductService(EcoDbContext dbContext) { _dbContext = dbContext; }

        public async Task<Product> Create() { // Example to update, you should add parameters to construct the product
            var productBuilder = new ProductBuilder(); // Use builder to create Products
            productBuilder.SetId(10) // Add needed informations
                .SetName("Smartphone");
            Product product = productBuilder.Build(); // Build the final product

            _dbContext.Products.Add(product); // This add the product to the tracked entities
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return product; // Return to consumer
        }

        public async Task<ReadOnlyCollection<Product>> GetAllProducts() { // Async method ! Sync until await then forwarded to another (or not) thread. /!\
            Product[]
                products = await _dbContext.Products // Fetch all products
                    .Include(pro => pro.Prices) // Add a way to includes Prices on loading
                    .AsNoTracking() // Specify that each entry is not tracked by EF CORE
                    .ToArrayAsync() // Transfrom the query into real object in Memory
                    .ConfigureAwait(false); // Remember this little boy ? 
            return new ReadOnlyCollection<Product>(products); // Wrapp products arround a readonly container
        }
    }
}