using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;

namespace WhatToStreamBackend.Services;

public interface IStreamingAvailabilityService
{
    Task<IEnumerable<Show>?> GetShowsByFilters(
        string countryCode, 
        string showType, 
        int? ratingMin,
        int? ratingMax,
        string? keyword,
        string? cursor
    );

    Task<Show?> GetShowById(string id, string countryCode);
    
    Task<Dictionary<string, CountryServices>> GetAllStreamingServicesByCountry();
}