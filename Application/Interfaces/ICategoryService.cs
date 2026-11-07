using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<bool>> AddCategoryAsync(Category category);
    Task<ApiResponse<bool>> UpdateCategoryAsync(Category category);
    Task<ApiResponse<bool>> DeleteCategoryAsync(int id);
    Task<ApiResponse<Category>> GetCategoryAsync(int id);
    Task<ApiResponse<List<Category>>> GetCategoriesAsync();
    Task<ApiResponse<int>> GetAmountOfCategoriesAsync();
}