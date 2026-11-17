using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository(AppDbContext appDbContext) : IProductRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product is null)
        {
            return false;
        }

        _context.Products.Remove(product);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) ?? new Product();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _context.Products.AsNoTracking().Where(x => x.CategoryId == categoryId).ToListAsync();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
        if (existingProduct is null)
        {
            return false;
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.CategoryId = product.CategoryId;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<int> GetAmountOfProductsAsync()
    {
        return await _context.Products.CountAsync();
    }

    public async Task<int> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        return await _context.Products.CountAsync(x => x.CategoryId == categoryId);
    }

    public async Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).MinAsync(x => (decimal?)x.Price) ?? 0m;
    }

    public async Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).MaxAsync(x => (decimal?)x.Price) ?? 0m;
    }

    public async Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        return await _context.Products.Where(x => x.CategoryId == categoryId).AverageAsync(x => (decimal?)x.Price) ?? 0m;
    }

    public async Task<decimal> GetTotalPriceOfProductsAsync()
    {
        return await _context.Products.SumAsync(x => (decimal?)x.Price) ?? 0m;
    }
}
