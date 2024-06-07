using WhatToStreamBackend.StreamingAvailabilityAPIModels;

namespace WhatToStreamBackend.Services;

public interface IStreamingAvailabilityService
{
    Task<IEnumerable<Show>> GetShowsByFilters(
        string? countryCode, 
        string? showType, 
        List<Genre>? genres,
        int? ratingMin,
        int? ratingMax,
        string? keyword,
        string? cursor
    );
}