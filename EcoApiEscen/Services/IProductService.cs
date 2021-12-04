using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommandLib;

namespace EcoApiEscen.Services {
    public interface IProductService {
        Task<Product> Create();
        Task<ReadOnlyCollection<Product>> GetAllProducts();
    }
}