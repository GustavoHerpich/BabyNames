using BabyName.Entities;
using BabyName.Repositories;

namespace BabyName.Services;

public class BabyNameService(IBabyNameRepository _babyNameRepository) : IBabyNameService
{
    public async Task<List<BabyNames>> GetTopNamesByYearAsync(int year)
    {
        return await _babyNameRepository.GetTopNamesByYearAsync(year);
    }

    public async Task<List<BabyNames>> GetNameOccurrencesAsync(string name)
    {
        return await _babyNameRepository.GetNameOccurrencesAsync(name);
    }

    public async Task<List<BabyNames>> GetTopNamesLastDecadeAsync()
    {
        return await _babyNameRepository.GetTopNamesLastDecadeAsync();
    }
}
