using BabyName.Entities;

namespace BabyName.Repositories;

public interface IBabyNameRepository
{
    Task<List<BabyNames>> GetTopNamesByYearAsync(int year);
    Task<List<BabyNames>> GetNameOccurrencesAsync(string name);
    Task<List<BabyNames>> GetTopNamesLastDecadeAsync();
}
