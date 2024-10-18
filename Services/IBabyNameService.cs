using BabyName.Entities;

namespace BabyName.Services;

public interface IBabyNameService
{
    Task<List<BabyNames>> GetTopNamesByYearAsync(int year);
    Task<List<BabyNames>> GetNameOccurrencesAsync(string name);
    Task<List<BabyNames>> GetTopNamesLastDecadeAsync();
}
