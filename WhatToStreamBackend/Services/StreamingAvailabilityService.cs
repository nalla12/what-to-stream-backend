using System.Text.Json;
using WhatToStreamBackend.StreamingAvailabilityAPIModels;

namespace WhatToStreamBackend.Services;

public class StreamingAvailabilityService : IStreamingAvailabilityService
{
    private readonly HttpClient _http;
    public StreamingAvailabilityService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<Show>> GetShowsByFilters(
        string? countryCode,
        string? showType,
        List<Genre>? genres,
        int? ratingMin,
        int? ratingMax,
        string? keyword,
        string? cursor
    )
    {
        // The GET request response
        var res = await _http.GetAsync(
            $"shows/search/filters?country={countryCode}"
            );
        res.EnsureSuccessStatusCode();

        // Deserialize the response body, ShowsResult Model created to handle the response
        using var resStream = await res.Content.ReadAsStreamAsync();
        var resObject = await JsonSerializer.DeserializeAsync<ShowsByFiltersResult>(resStream);

        return resObject.Shows;
    }
}