using Domain.Models;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    Task<bool> AddCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
    Task<Category> GetCategoryAsync(int id);
    Task<List<Category>> GetCategoriesAsync();
    Task<int> GetAmountOfCategoriesAsync();
}