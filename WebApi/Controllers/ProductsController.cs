using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(
    IProductService productService,
    ILogger<ProductsController> logger) : ControllerBase
{
    private IProductService service = productService;
    private ILogger<ProductsController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(CreateProductDto dto)
    {
        _logger.LogInformation("POST api/Products {date}", DateTime.Now);
        return await service.AddProductAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateProduct(int id, UpdateProductDto dto)
    {
        _logger.LogInformation("PUT api/Products/{id} {date}", id, DateTime.Now);
        return await service.UpdateProductAsync(id, dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        _logger.LogInformation("DELETE api/Products?id={id} {date}", id, DateTime.Now);
        return await service.DeleteProductAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ProductDto>> GetProduct(int id)
    {
        _logger.LogInformation("GET api/Products/{id} {date}", id, DateTime.Now);
        return await service.GetProductAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<ProductDto>>> GetProducts()
    {
        _logger.LogInformation("GET api/Products {date}", DateTime.Now);
        return await service.GetProductsAsync();
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ApiResponse<List<ProductDto>>> GetProductsByCategory(int categoryId)
    {
        _logger.LogInformation("GET api/Products/by-category/{categoryId} {date}", categoryId, DateTime.Now);
        return await service.GetProductsByCategoryAsync(categoryId);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfProducts()
    {
        _logger.LogInformation("GET api/Products/amount {date}", DateTime.Now);
        return await service.GetAmountOfProductsAsync();
    }

    [HttpGet("amount/{categoryId:int}")]
    public async Task<ApiResponse<int>> GetAmountOfProductsByCategory(int categoryId)
    {
        _logger.LogInformation("GET api/Products/amount/{categoryId} {date}", categoryId, DateTime.Now);
        return await service.GetAmountOfProductsByCategoryAsync(categoryId);
    }

    [HttpGet("min-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMinPrice(int categoryId)
    {
        _logger.LogInformation("GET api/Products/min-price/{categoryId} {date}", categoryId, DateTime.Now);
        return await service.GetMinPriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("max-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMaxPrice(int categoryId)
    {
        _logger.LogInformation("GET api/Products/max-price/{categoryId} {date}", categoryId, DateTime.Now);
        return await service.GetMaxPriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("average-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetAveragePrice(int categoryId)
    {
        _logger.LogInformation("GET api/Products/average-price/{categoryId} {date}", categoryId, DateTime.Now);
        return await service.GetAveragePriceOfProductByCategoryAsync(categoryId);
    }

    [HttpGet("total-price")]
    public async Task<ApiResponse<decimal>> GetTotalPrice()
    {
        _logger.LogInformation("GET api/Products/total-price {date}", DateTime.Now);
        return await service.GetTotalPriceOfProductsAsync();
    }
}
