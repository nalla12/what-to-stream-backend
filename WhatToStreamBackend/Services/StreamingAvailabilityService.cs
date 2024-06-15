using System.Text.Json;
using System.Web;
using WhatToStreamBackend.StreamingAvailabilityAPIModels;

namespace WhatToStreamBackend.Services;

public class StreamingAvailabilityService : IStreamingAvailabilityService
{
    private readonly HttpClient _http;
    public StreamingAvailabilityService(HttpClient http)
    {
        _http = http;
    }

    public async Task<ShowsByFiltersResultExternal> GetShowsByFilters(
        string? countryCode = null,
        string? showType = null,
        int? ratingMin = null,
        int? ratingMax = null,
        string? keyword = null,
        string? cursor = null
    )
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        if (!string.IsNullOrEmpty(countryCode))
            query["country"] = countryCode;

        if (!string.IsNullOrEmpty(showType))
            query["show_type"] = showType;

        if (ratingMin.HasValue)
            query["rating_min"] = ratingMin.Value.ToString();
        
        if (ratingMax.HasValue)
            query["rating_max"] = ratingMax.Value.ToString();
        
        if (!string.IsNullOrEmpty(keyword))
            query["keyword"] = keyword;
        
        if (!string.IsNullOrEmpty(cursor))
            query["cursor"] = cursor;
        
        // The GET request response
        var res = await _http.GetAsync(
            $"shows/search/filters?{query}");
        res.EnsureSuccessStatusCode();

        // Deserialize the response body, ShowsResult Model created to handle the response
        await using var resStream = await res.Content.ReadAsStreamAsync();
        var resObject = await JsonSerializer.DeserializeAsync<ShowsByFiltersResultExternal>(resStream);

        return resObject;
    }
}