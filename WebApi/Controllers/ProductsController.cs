using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    private IProductService service = productService;

    [HttpGet]
    public async Task<ApiResponse<List<Product>>> GetProducts() => await service.GetProductsAsync();

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Product>> GetProduct(int id) => await service.GetProductAsync(id);

    [HttpPost]
    public async Task<ApiResponse<bool>> AddProduct(Product product) => await service.AddProductAsync(product);

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateProduct(Product product) => await service.UpdateProductAsync(product);

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteProduct(int id) => await service.DeleteProductAsync(id);

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ApiResponse<List<Product>>> GetProductsByCategory(int categoryId) => await service.GetProductsByCategoryAsync(categoryId);

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAmountOfProducts() => await service.GetAmountOfProductsAsync();

    [HttpGet("amount/{categoryId:int}")]
    public async Task<ApiResponse<int>> GetAmountOfProductsByCategory(int categoryId) => await service.GetAmountOfProductsByCategoryAsync(categoryId);

    [HttpGet("min-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMinPrice(int categoryId) => await service.GetMinPriceOfProductByCategoryAsync(categoryId);

    [HttpGet("max-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetMaxPrice(int categoryId) => await service.GetMaxPriceOfProductByCategoryAsync(categoryId);

    [HttpGet("average-price/{categoryId:int}")]
    public async Task<ApiResponse<decimal>> GetAveragePrice(int categoryId) => await service.GetAveragePriceOfProductByCategoryAsync(categoryId);

    [HttpGet("total-price")]
    public async Task<ApiResponse<decimal>> GetTotalPrice() => await service.GetTotalPriceOfProductsAsync();
}