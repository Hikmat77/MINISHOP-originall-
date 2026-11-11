using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private ICategoryService service = categoryService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto dto)
    {
        return await service.AddCategoryAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCategory(int id, UpdateCategoryDto dto)
    {
        return await service.UpdateCategoryAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        return await service.DeleteCategoryAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryDto>> GetCategory(int id)
    {
        return await service.GetCategoryAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CategoryDto>>> GetCategories()
    {
        return await service.GetCategoriesAsync();
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfCategories()
    {
        return await service.GetAmountOfCategoriesAsync();
    }

    [HttpGet("categories-with-products")]
    public async Task<ApiResponse<List<CategoryWithProducts>>> GetCategoriesWithProducts()
    {
        return await service.GetCategoriesWithProductsAsync();
    }
}
