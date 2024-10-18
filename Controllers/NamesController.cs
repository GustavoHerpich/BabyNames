using BabyName.Entities;
using BabyName.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabyName.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NamesController(IBabyNameService _babyNameService) : ControllerBase
{
    [HttpGet("{year}")]
    [Authorize]
    public async Task<ActionResult<List<BabyNames>>> GetTopNamesByYear(int year)
    {
        var names = await _babyNameService.GetTopNamesByYearAsync(year);
        if (names == null || !names.Any())
        {
            return NotFound($"No names found for the year {year}");
        }

        return Ok(new
        {
            Year = year,
            TopNames = names.Select(n => new { n.Name, n.Births })
        });
    }

    [HttpGet("occurrences/{name}")]
    [Authorize]
    public async Task<ActionResult<List<BabyNames>>> GetNameOccurrences(string name)
    {
        var occurrences = await _babyNameService.GetNameOccurrencesAsync(name);
        if (occurrences == null || !occurrences.Any())
        {
            return NotFound($"No occurrences found for the name {name}");
        }

        var result = occurrences.GroupBy(o => o.Year)
            .Select(g => new { Year = g.Key, Occurrences = g.Sum(o => o.Births) });

        return Ok(new
        {
            Name = name,
            Years = result
        });
    }

    [HttpGet("last-decade")]
    [Authorize]
    public async Task<ActionResult<List<BabyNames>>> GetTopNamesLastDecade()
    {
        var names = await _babyNameService.GetTopNamesLastDecadeAsync();
        if (names == null || !names.Any())
        {
            return NotFound("No names found for the last decade");
        }

        var boys = names.Where(n => n.Gender == 'M').Select(n => new { n.Name, n.Births });
        var girls = names.Where(n => n.Gender == 'F').Select(n => new { n.Name, n.Births });

        return Ok(new
        {
            Boys = boys,
            Girls = girls
        });
    }
}
