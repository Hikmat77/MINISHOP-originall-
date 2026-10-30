using System.Data;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task AddProductAsync(Product product)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"insert into products (name, price, category_id) values(@name, @price, @categoryId)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@price", product.Price);
        cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
        await cmd.ExecuteNonQueryAsync();
        System.Console.WriteLine("Added successfully!");
    }

    public async Task DeleteProductAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"delete from products where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        await cmd.ExecuteNonQueryAsync();
        System.Console.WriteLine("Deleted successfully");
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "SELECT id, name, price, category_id FROM products";
        using var cmd = new NpgsqlCommand(query, connection);
        using var data = await cmd.ExecuteReaderAsync();
        var products = new List<Product>();
        while (await data.ReadAsync())
        {
            var product = new Product();
            product.Id = data.GetInt32(0);
            product.Name = data.GetString(1);
            product.Price = data.GetDecimal(2);
            product.CategoryId = data.GetInt32(3);
            products.Add(product);
        }
        return products;
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "SELECT id, name, price, category_id FROM products WHERE category_id = @categoryId";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@categoryId", categoryId);
        using var data = await cmd.ExecuteReaderAsync();
        var products = new List<Product>();
        while (await data.ReadAsync())
        {
            var product = new Product();
            product.Id = data.GetInt32(0);
            product.Name = data.GetString(1);
            product.Price = data.GetDecimal(2);
            product.CategoryId = data.GetInt32(3);
            products.Add(product);
        }
        return products;
    }

    public async Task<Product> GetProductAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "SELECT id, name, price, category_id FROM products WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var data = await cmd.ExecuteReaderAsync();
        var product = new Product();
        while (await data.ReadAsync())
        {
            product.Id = data.GetInt32(0);
            product.Name = data.GetString(1);
            product.Price = data.GetDecimal(2);
            product.CategoryId = data.GetInt32(3);
        }
        return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"update products set name = @name, price = @price, category_id = @categoryId where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@price", product.Price);
        cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
        cmd.Parameters.AddWithValue("@id", product.Id);
        await cmd.ExecuteNonQueryAsync();
        System.Console.WriteLine("Updated successfully");
    }

    public async Task<int> GetAmountOfProductsAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select count(*) from products";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select count(*) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<int>(query, new { categoryId });
    }

    public async Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select min(price) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
    }

    public async Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select max(price) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
    }

    public async Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select avg(price) from products where category_id = @categoryId";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
    }

    public async Task<decimal> GetTotalPriceOfProductsAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select sum(price) from products";
        return await connection.ExecuteScalarAsync<decimal>(query);
    }
}