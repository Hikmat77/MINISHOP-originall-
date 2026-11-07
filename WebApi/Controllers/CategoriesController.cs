using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private ICategoryService service = categoryService;

    [HttpGet]
    public async Task<ApiResponse<List<Category>>> GetCategories() => await service.GetCategoriesAsync();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Category>> GetCategory(int id) => await service.GetCategoryAsync(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategory(Category category) => await service.AddCategoryAsync(category);

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCategory(Category category) => await service.UpdateCategoryAsync(category);

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCategory(int id) => await service.DeleteCategoryAsync(id);

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfCategories() => await service.GetAmountOfCategoriesAsync();    
}