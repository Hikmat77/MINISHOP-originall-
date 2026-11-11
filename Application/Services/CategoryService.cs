using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IProductRepository productRepository
    ) : ICategoryService
{
    private ICategoryRepository repository = categoryRepository;
    private readonly IProductRepository _productRepository = productRepository;
    public async Task<ApiResponse<bool>> AddCategoryAsync(CreateCategoryDto dto)
    {
        var category = new Category()
        {
            Name = dto.Name
        };
        var res = await repository.AddCategoryAsync(category);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
    {
        var res = await repository.DeleteCategoryAsync(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<CategoryDto>> GetCategoryAsync(int id)
    {
        var category = await repository.GetCategoryAsync(id);
        var res = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
        return new ApiResponse<CategoryDto>(HttpStatusCode.OK, "Category with given id.", res);
    }

    public async Task<ApiResponse<List<CategoryDto>>> GetCategoriesAsync()
    {
        var categories = await repository.GetCategoriesAsync();
        var res = categories.Select(x=>new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
        return new ApiResponse<List<CategoryDto>>(HttpStatusCode.OK, "List of categories.", res);
    }

    public async Task<ApiResponse<int>> GetAmountOfCategoriesAsync()
    {
        var res = await repository.GetAmountOfCategoriesAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of categories.", res);
    }

    public async Task<ApiResponse<List<CategoryWithProducts>>> GetCategoriesWithProductsAsync()
    {
        var categories = await repository.GetCategoriesAsync();
        var res = new List<CategoryWithProducts>();
        foreach (var x in categories)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(x.Id);
            res.Add(new CategoryWithProducts()
            {
                Id = x.Id,
                Name = x.Name,
                Products = products.Select(p=>new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                }).ToList()
            });
        }
        return new ApiResponse<List<CategoryWithProducts>>(HttpStatusCode.OK, "List of categories with products.", res);
    }

    public async Task<ApiResponse<bool>> UpdateCategoryAsync(int id, UpdateCategoryDto dto)
    {
        var category = new Category()
        {
            Id = id,
            Name = dto.Name
        };
        var res = await repository.UpdateCategoryAsync(category);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
