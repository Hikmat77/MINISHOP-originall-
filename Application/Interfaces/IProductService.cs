using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProductAsync(CreateProductDto dto);
    Task<ApiResponse<bool>> UpdateProductAsync(int id, UpdateProductDto dto);
    Task<ApiResponse<bool>> DeleteProductAsync(int id);
    Task<ApiResponse<ProductDto>> GetProductAsync(int id);
    Task<ApiResponse<List<ProductDto>>> GetProductsAsync();

    Task<ApiResponse<List<ProductDto>>> GetProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<int>> GetAmountOfProductsAsync();
    Task<ApiResponse<int>> GetAmountOfProductsByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMinPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetMaxPriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetAveragePriceOfProductByCategoryAsync(int categoryId);
    Task<ApiResponse<decimal>> GetTotalPriceOfProductsAsync();
}
