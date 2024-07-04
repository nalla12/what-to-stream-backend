using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Repositories;
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
            
            var showsAddedToDb = await showsDbRepository.AddMultipleShowsAsync(filteredShows);
            
            return Ok(showsAddedToDb);
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

    [HttpGet]
    public async Task<ActionResult<List<ServiceDetails>>> GetAllStreamingServicesByCountry()
    {
        var serviceList = await streamingAvailabilityService.GetAllStreamingServicesByCountry();
        await showsDbRepository.AddMultipleServicesAsync(serviceList);

        return Ok(serviceList);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Country>>> GetListOfCountries()
    {
        var countriesList = await streamingAvailabilityService.GetListOfCountries();
        await showsDbRepository.AddMultipleCountriesAsync(countriesList);

        return Ok(countriesList);
    }
}