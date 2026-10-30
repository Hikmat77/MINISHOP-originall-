using Domain.Models;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
    Task<Category> GetCategoryAsync(int id);
    Task<List<Category>> GetCategoriesAsync();
    Task<int> GetAmountOfCategoriesAsync();
}