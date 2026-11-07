using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProductAsync(Product product);
    Task<ApiResponse<bool>> UpdateProductAsync(Product product);
    Task<ApiResponse<bool>> DeleteProductAsync(int id);
    Task<ApiResponse<Product>> GetProductAsync(int id);
    Task<ApiResponse<List<Product>>> GetProductsAsync();
    Task<ApiResponse<List<Product>>> GetProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<int>> GetAmountOfProductsAsync();
    Task<ApiResponse<int>> GetAmountOfProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMinPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMaxPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetAveragePriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetTotalPriceOfProductsAsync();
}
