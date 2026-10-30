using System.Data;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public async Task AddCategoryAsync(Category category)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"insert into categories (name) values(@name)";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", category.Name);
        await cmd.ExecuteNonQueryAsync();
        System.Console.WriteLine("Added successfully!");
    }

    public async Task DeleteCategoryAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"delete from categories where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        await cmd.ExecuteNonQueryAsync();
        System.Console.WriteLine("Deleted successfully");
    }



    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "SELECT id, name FROM categories";
        using var cmd = new NpgsqlCommand(query, connection);
        using var data = await cmd.ExecuteReaderAsync();
        var categories = new List<Category>();
        while (await data.ReadAsync())
        {
            var category = new Category();
            category.Id = data.GetInt32(0);
            category.Name = data.GetString(1);
            categories.Add(category);
        }
        return categories;
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "SELECT id, name FROM categories WHERE id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        using var data = await cmd.ExecuteReaderAsync();
        var category = new Category();
        while (await data.ReadAsync())
        {
            category.Id = data.GetInt32(0);
            category.Name = data.GetString(1);
        }
        return category;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"update categories set name = @name where id = @id";
        using var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@name", category.Name);
        cmd.Parameters.AddWithValue("@id", category.Id);
        await cmd.ExecuteNonQueryAsync();
        System.Console.WriteLine("Updated successfully");
    }
    public async Task<int> GetAmountOfCategoriesAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select count(*) from categories";
        return await connection.ExecuteScalarAsync<int>(query);
    }
}