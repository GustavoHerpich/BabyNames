using BabyName.Data;
using BabyName.Entities;
using Microsoft.EntityFrameworkCore;

namespace BabyName.Repositories.Impl;

public class BabyNameRepository(ApplicationDbContext _context) : IBabyNameRepository
{
    public async Task<List<BabyNames>> GetTopNamesByYearAsync(int year)
    {
        return await _context.BabyNames
            .Where(b => b.Year == year)
            .OrderByDescending(b => b.Births)
            .Take(5)
            .ToListAsync();
    }

    public async Task<List<BabyNames>> GetNameOccurrencesAsync(string name)
    {
        return await _context.BabyNames
            .Where(b => b.Name.ToLower() == name.ToLower()) // Usando ToLower para ignorar diferenças de maiúsculas/minúsculas
            .ToListAsync();
    }

    public async Task<List<BabyNames>> GetTopNamesLastDecadeAsync()
    {
        return await _context.BabyNames
            .Where(b => b.Year >= DateTime.Now.Year - 10)
            .GroupBy(b => new { b.Name, b.Gender })
            .Select(g => g.OrderByDescending(b => b.Births).FirstOrDefault())
            .ToListAsync();
    }
}
