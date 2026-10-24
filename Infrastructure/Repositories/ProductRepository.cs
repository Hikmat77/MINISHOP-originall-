using System.Data;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public void AddProduct(Product product)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"insert into products (name, price, category_id) values(@name, @price, @categoryId)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@price", product.Price);
        cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Added successfully!");
    }

    public void DeleteProduct(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"delete from products where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Deleted successfully");
    }

    public List<Product> GetProducts()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "SELECT id, name, price, category_id FROM products";
        using var cmd = new NpgsqlCommand(query, connection);
        using var data = cmd.ExecuteReader();
        var products = new List<Product>();
        while (data.Read())
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

    public List<Product> GetProductsByCategory(int categoryId)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "SELECT id, name, price, category_id FROM products WHERE category_id = @categoryId";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@categoryId", categoryId);
        using var data = cmd.ExecuteReader();
        var products = new List<Product>();
        while (data.Read())
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

    public Product GetProduct(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "SELECT id, name, price, category_id FROM products WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var data = cmd.ExecuteReader();
        var product = new Product();
        while (data.Read())
        {
            product.Id = data.GetInt32(0);
            product.Name = data.GetString(1);
            product.Price = data.GetDecimal(2);
            product.CategoryId = data.GetInt32(3);
        }
        return product;
    }

    public void UpdateProduct(Product product)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"update products set name = @name, price = @price, category_id = @categoryId where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", product.Name);
        cmd.Parameters.AddWithValue("@price", product.Price);
        cmd.Parameters.AddWithValue("@categoryId", product.CategoryId);
        cmd.Parameters.AddWithValue("@id", product.Id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Updated successfully");
    }
}