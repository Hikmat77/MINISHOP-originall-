using Application.DTOs;
using Application.Responses;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<bool>> AddCategoryAsync(CreateCategoryDto dto);
    Task<ApiResponse<bool>> UpdateCategoryAsync(int id, UpdateCategoryDto dto);
    Task<ApiResponse<bool>> DeleteCategoryAsync(int id);
    Task<ApiResponse<CategoryDto>> GetCategoryAsync(int id);
    Task<ApiResponse<List<CategoryDto>>> GetCategoriesAsync();

    Task<ApiResponse<int>> GetAmountOfCategoriesAsync();
    Task<ApiResponse<List<CategoryWithProducts>>> GetCategoriesWithProductsAsync();
}
