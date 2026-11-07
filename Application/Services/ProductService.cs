using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private IProductRepository repository = productRepository;

    public async Task<ApiResponse<bool>> AddProductAsync(Product product)
    {
        var res = await repository.AddProductAsync(product);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
    {
        var res = await repository.DeleteProductAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<Product>> GetProductAsync(int id)
    {
        var res = await repository.GetProductAsync(id);
        return new ApiResponse<Product>(HttpStatusCode.OK, "Product with given id.", res);
    }

    public async Task<ApiResponse<List<Product>>> GetProductsAsync()
    {
        var res = await repository.GetProductsAsync();
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "List of products.", res);
    }

    public async Task<ApiResponse<List<Product>>> GetProductsByCategoryAsync(int categoryId)
    {
        var res = await repository.GetProductsByCategoryAsync(categoryId);
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "List of products by category.", res);
    }

    public async Task<ApiResponse<bool>> UpdateProductAsync(Product product)
    {
        var res = await repository.UpdateProductAsync(product);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<int>> GetAmountOfProductsAsync()
    {
        var res = await repository.GetAmountOfProductsAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of products.", res);
    }

    public async Task<ApiResponse<int>> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        var res = await repository.GetAmountOfProductsByCategoryAsync(categoryId);
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of products by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        var res = await repository.GetMinPriceOfProductByCategoryAsync(categoryId);
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Min price of product by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        var res = await repository.GetMaxPriceOfProductByCategoryAsync(categoryId);
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Max price of product by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        var res = await repository.GetAveragePriceOfProductByCategoryAsync(categoryId);
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Average price of product by category.", res);
    }

    public async Task<ApiResponse<decimal>> GetTotalPriceOfProductsAsync()
    {
        var res = await repository.GetTotalPriceOfProductsAsync();
        return new ApiResponse<decimal>(HttpStatusCode.OK, "Total price of products.", res);
    }
}