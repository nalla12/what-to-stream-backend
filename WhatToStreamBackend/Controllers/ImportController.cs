using Microsoft.AspNetCore.Mvc;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;
using WhatToStreamBackend.Services;

namespace WhatToStreamBackend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ImportController : ControllerBase
{
    private readonly IStreamingAvailabilityService _streamingAvailabilityService;

    public ImportController(IStreamingAvailabilityService streamingAvailabilityService)
    {
        _streamingAvailabilityService = streamingAvailabilityService;
    }
    
    // Request shows from StreamingAvailability API
    [HttpGet]
    public async Task<ActionResult<ShowsByFiltersResultExternal>> GetShowsByFilters()
    {
        var filteredShows = await _streamingAvailabilityService.GetShowsByFilters(
            "dk", "movie", 65, null, null, null);

        return Ok(filteredShows);
    }
}