using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(
    ICategoryService categoryService,
    ILogger<CategoriesController> logger) : ControllerBase
{
    private ICategoryService service = categoryService;
    private ILogger<CategoriesController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(CreateCategoryDto dto)
    {
        _logger.LogInformation("POST api/Categories {date}", DateTime.Now);
        return await service.AddCategoryAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCategory(int id, UpdateCategoryDto dto)
    {
        _logger.LogInformation("PUT api/Categories/{id} {date}", id, DateTime.Now);
        return await service.UpdateCategoryAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        _logger.LogInformation("DELETE api/Categories?id={id} {date}", id, DateTime.Now);
        return await service.DeleteCategoryAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryDto>> GetCategory(int id)
    {
        _logger.LogInformation("GET api/Categories/{id} {date}", id, DateTime.Now);
        return await service.GetCategoryAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<CategoryDto>>> GetCategories()
    {
        _logger.LogInformation("GET api/Categories {date}", DateTime.Now);
        return await service.GetCategoriesAsync();
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfCategories()
    {
        _logger.LogInformation("GET api/Categories/amount {date}", DateTime.Now);
        return await service.GetAmountOfCategoriesAsync();
    }

    [HttpGet("categories-with-products")]
    public async Task<ApiResponse<List<CategoryWithProducts>>> GetCategoriesWithProducts()
    {
        _logger.LogInformation("GET api/Categories/categories-with-products {date}", DateTime.Now);
        return await service.GetCategoriesWithProductsAsync();
    }
}