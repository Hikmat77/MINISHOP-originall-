using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private ICategoryRepository repository = categoryRepository;

    public async Task<ApiResponse<bool>> AddCategoryAsync(Category category)
    {
        var res = await repository.AddCategoryAsync(category);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
    {
        var res = await repository.DeleteCategoryAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<Category>> GetCategoryAsync(int id)
    {
        var res = await repository.GetCategoryAsync(id);
        return new ApiResponse<Category>(HttpStatusCode.OK, "Category with given id.", res);
    }

    public async Task<ApiResponse<List<Category>>> GetCategoriesAsync()
    {
        var res = await repository.GetCategoriesAsync();
        return new ApiResponse<List<Category>>(HttpStatusCode.OK, "List of categories.", res);
    }

    public async Task<ApiResponse<bool>> UpdateCategoryAsync(Category category)
    {
        var res = await repository.UpdateCategoryAsync(category);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<int>> GetAmountOfCategoriesAsync()
    {
        var res = await repository.GetAmountOfCategoriesAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of categories.", res);
    }
}