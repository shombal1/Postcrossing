using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Postcrossing.Storage;
using Postcrossing.Storage.Models.Address;

namespace Postcrossing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController : ControllerBase
{
    [HttpPost]
    [Route("All")]
    public async Task<IActionResult> Get(
        [FromServices] PostcrossingDbContext dbContext,
        [FromBody] string nameCountry,
        CancellationToken cancellationToken)
    {
        
        // Dictionary<string, Dictionary<string, HashSet<string>>> miniDataBase =
        //     JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, HashSet<string>>>>(
        //         await System.IO.File.ReadAllTextAsync(
        //             "D:\\Programs\\VisualStudio\\Projects\\ExelReader\\MiniDataBase25.txt", cancellationToken))!;
        //
        //
        // miniDataBase.Remove("-,-");
        //
        // foreach (var (codeAndCountryName, districts) in miniDataBase)
        // {
        //     string[] codeAndCountry = codeAndCountryName.Split(",").ToArray();
        //
        //     string code = codeAndCountry[0];
        //     string countryName = codeAndCountry[1];
        //
        //     var county = dbContext.Countries.Add(new CountyEntity() { Code = code, Name = countryName }).Entity;
        //     await dbContext.SaveChangesAsync(cancellationToken);
        //     foreach (var (districtName, cities) in districts)
        //     {
        //         if (districtName == "-") continue;
        //
        //         var district = dbContext.Districts
        //             .Add(new DistrictEntity() { CountyId = county.Id, Name = districtName }).Entity;
        //         await dbContext.SaveChangesAsync(cancellationToken);
        //         foreach (var cityName in cities)
        //         {
        //             if (cityName == "-") continue;
        //
        //             dbContext.Cities.Add(new CityEntity() { DistrictId = district.Id, Name = cityName });
        //         }
        //
        //         await dbContext.SaveChangesAsync(cancellationToken);
        //         if (dbContext.Cities.Count(c => c.DistrictId == district.Id) == 0)
        //         {
        //             dbContext.Districts.Remove(district);
        //             await dbContext.SaveChangesAsync(cancellationToken);
        //         }
        //     }
        //
        //     if (dbContext.Districts.Count(c => c.CountyId == county.Id) == 0)
        //     {
        //         dbContext.Countries.Remove(county);
        //         await dbContext.SaveChangesAsync(cancellationToken);
        //     }
        // }
        //
        // await dbContext.SaveChangesAsync(cancellationToken);

        
        
        return Ok("Ashkāsham");
    }
}