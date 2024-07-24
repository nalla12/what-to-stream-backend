using WhatToStreamBackend.Models.Db;

namespace WhatToStreamBackend.Services;

public interface IStreamingAvailabilityService
{
    Task<IEnumerable<Show>?> GetShowsByFilters(
        string countryCode, 
        string showType, 
        int? ratingMin,
        int? ratingMax,
        string? keyword,
        string? cursor,
        int? pages
    );

    Task<Show?> GetShowById(string id, string countryCode);

    Task<List<ServiceDetails>> GetAllStreamingServicesByCountry();
    Task<List<Country>> GetListOfCountries();
}