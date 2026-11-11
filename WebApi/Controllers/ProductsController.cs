using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private IProductService service = productService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto dto)
    {
        return await service.AddProductAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateProduct(int id, UpdateProductDto dto)
    {
        return await service.UpdateProductAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        return await service.DeleteProductAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ProductDto>> GetProduct(int id)
    {
        return await service.GetProductAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<ProductDto>>> GetProducts()
    {
        return await service.GetProductsAsync();
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ApiResponse<List<ProductDto>>> GetProductsByCategory(int categoryId)
    {
        return await service.GetProductsByCategoryAsync(categoryId);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfProducts()
    {
        return await service.GetAmountOfProductsAsync();
    }

    [HttpGet("amount/{categoryId:int}")]
    public async Task<ApiResponse<int>> GetAmountOfProductsByCategory(int categoryId)
    {
        return await service.GetAmountOfProductsByCategoryAsync(categoryId);
    }

    [HttpGet("min-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMinPrice(int categoryId)
    {
        return await service.GetMinPriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("max-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMaxPrice(int categoryId)
    {
        return await service.GetMaxPriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("average-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetAveragePrice(int categoryId)
    {
        return await service.GetAveragePriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("total-price")]
    public async Task<ApiResponse<decimal>> GetTotalPrice()
    {
        return await service.GetTotalPriceOfProductsAsync();
    }
}
