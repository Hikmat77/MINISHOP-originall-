using System.Data;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class CategoryRepository(AppDbContext appDbContext) : ICategoryRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddCategoryAsync(Category category)
    {
        using var connection = _context.Connection();
        var query = "insert into categories (name) values (@name)";
        var res = await connection.ExecuteAsync(query, category);
        return res > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "delete from categories where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<int> GetAmountOfCategoriesAsync()
    {
        using var connection = _context.Connection();
        var query = "select count(*) from categories";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from categories";
        return (await connection.QueryAsync<Category>(query)).ToList();
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from categories where id = @id";
        var category = await connection.QuerySingleAsync<Category>(query, new { id });
        return category;
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        using var connection = _context.Connection();
        var query = "update categories set name = @name where id = @id";
        var res = await connection.ExecuteAsync(query, category);
        return res > 0;
    }
}