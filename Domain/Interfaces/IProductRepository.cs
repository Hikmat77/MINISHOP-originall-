using Domain.Models;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<bool> AddProductAsync(Product product);
    Task<bool> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
    Task<Product> GetProductAsync(int id);
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<int> GetAmountOfProductsAsync();
    Task<int> GetAmountOfProductsByCategoryAsync(int categoryId);
    Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetTotalPriceOfProductsAsync();
}   