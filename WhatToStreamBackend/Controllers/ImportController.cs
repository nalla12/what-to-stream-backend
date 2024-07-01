using Microsoft.AspNetCore.Mvc;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Services;

namespace WhatToStreamBackend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ImportController(IStreamingAvailabilityService streamingAvailabilityService) : ControllerBase
{
    // Request shows from StreamingAvailability API
    // Get: import/getShowsByFilters
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Show>>> GetShowsByFilters(
        [FromQuery] string countryCode,
        [FromQuery] string showType,
        [FromQuery] int? ratingMin,
        [FromQuery] int? ratingMax,
        [FromQuery] string? keyword,
        [FromQuery] string? cursor)
    {
        try
        {
            var filteredShows = await streamingAvailabilityService.GetShowsByFilters(
                countryCode, showType, ratingMin, ratingMax, keyword, cursor);

            return Ok(filteredShows);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    // Get: import/getShowById/:id
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Show>>> GetShowById(
        string id, [FromQuery] string? countryCode)
    {
        try
        {
            var filteredShows = await streamingAvailabilityService.GetShowById(id, countryCode);

            return Ok(filteredShows);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}