using System.Data;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Category category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"insert into categories (name) values(@name)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", category.Name);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Added successfully!");
    }

    public void DeleteCategory(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"delete from categories where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Deleted successfully");
    }

    public List<Category> GetCategories()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "SELECT id, name FROM categories";
        using var cmd = new NpgsqlCommand(query, connection);
        using var data = cmd.ExecuteReader();
        var categories = new List<Category>();
        while (data.Read())
        {
            var category = new Category();
            category.Id = data.GetInt32(0);
            category.Name = data.GetString(1);
            categories.Add(category);
        }
        return categories;
    }

    public Category GetCategory(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "SELECT id, name FROM categories WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var data = cmd.ExecuteReader();
        var category = new Category();
        while (data.Read())
        {
            category.Id = data.GetInt32(0);
            category.Name = data.GetString(1);
        }
        return category;
    }

    public void UpdateCategory(Category category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = $"update categories set name = @name where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", category.Name);
        cmd.Parameters.AddWithValue("@id", category.Id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Updated successfully");
    }
}