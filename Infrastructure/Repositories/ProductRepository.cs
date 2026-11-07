using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository(AppDbContext appDbContext) : IProductRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddProductAsync(Product product)
    {
        using var connection = _context.Connection();
        var query = "insert into products (name, price, category_id) values (@name, @price, @categoryId)";
        var res = await connection.ExecuteAsync(query, product);
        return res > 0;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "delete from products where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select id, name, price, category_id as categoryid from products where id = @id";
        var product = await connection.QuerySingleAsync<Product>(query, new { id });
        return product;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        using var connection = _context.Connection();
        var query = "select id, name, price, category_id as categoryid from products";
        return (await connection.QueryAsync<Product>(query)).ToList();
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        var query = "select id, name, price, category_id as categoryid from products where category_id = @categoryId";
        return (await connection.QueryAsync<Product>(query, new { categoryId })).ToList();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        using var connection = _context.Connection();
        var query = "update products set name = @name, price = @price, category_id = @categoryId where id = @id";
        var res = await connection.ExecuteAsync(query, product);
        return res > 0;
    }

    public async Task<int> GetAmountOfProductsAsync()
    {
        using var connection = _context.Connection();
        var query = "select count(*) from products";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        var query = "select count(*) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<int>(query, new { categoryId });
    }

    public async Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        var query = "select min(price) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
    }

    public async Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        var query = "select max(price) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
    }

    public async Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        var query = "select avg(price) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
    }

    public async Task<decimal> GetTotalPriceOfProductsAsync()
    {
        using var connection = _context.Connection();
        var query = "select sum(price) from products";
        return await connection.ExecuteScalarAsync<decimal>(query);
    }
}
