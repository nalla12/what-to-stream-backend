using Microsoft.AspNetCore.Mvc;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;
using WhatToStreamBackend.Services;

namespace WhatToStreamBackend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ImportController(IStreamingAvailabilityService streamingAvailabilityService) : ControllerBase
{
    // Request shows from StreamingAvailability API
    [HttpGet]
    public async Task<ActionResult<object>> GetShowsByFilters()
    {
        try
        {
            var filteredShows = await streamingAvailabilityService.GetShowsByFilters(
                "dk", "movie", 70, null, null, null);

            return Ok(filteredShows);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}