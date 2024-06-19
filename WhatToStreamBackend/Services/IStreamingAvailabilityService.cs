using WhatToStreamBackend.Models.StreamingAvailabilityAPI;

namespace WhatToStreamBackend.Services;

public interface IStreamingAvailabilityService
{
    Task<ShowsByFiltersResult?> GetShowsByFilters(
        string? countryCode, 
        string? showType, 
        int? ratingMin,
        int? ratingMax,
        string? keyword,
        string? cursor
    );
}