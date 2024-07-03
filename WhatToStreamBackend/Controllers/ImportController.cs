using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Services;

namespace WhatToStreamBackend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ImportController(IStreamingAvailabilityService streamingAvailabilityService, IShowsDbRepository showsDbRepository) : ControllerBase
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
            IEnumerable<Show>? filteredShows = await streamingAvailabilityService.GetShowsByFilters(
                countryCode, showType, ratingMin, ratingMax, keyword, cursor);
            
            await showsDbRepository.AddMultipleShowsAsync(filteredShows);
            
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
    public async Task<ActionResult<Show>> GetShowById(
        string id, [FromQuery] string countryCode)
    {
        try
        {
            Show? showById = await streamingAvailabilityService.GetShowById(id, countryCode);
            
            await showsDbRepository.AddShowAsync(showById);
            
            return CreatedAtAction(nameof(GetShowById), new { id = showById.Id }, showById);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("duplicate key") == true)
        {
            // Return a 409 Conflict response if the show ID already exists
            return Conflict(new { message = $"A show with ID {id} already exists." });
        }
    }
}