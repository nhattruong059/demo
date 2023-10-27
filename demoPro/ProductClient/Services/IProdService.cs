using ProductClient.Models;

namespace ProductClient.Services
{
    public interface IProdService
    {
        Task<List<ProductDto>?> FindAll();
        Task<int> Create(ProductDto prod);

        Task<List<ProductDto>?> Search(string name);
    }
}
