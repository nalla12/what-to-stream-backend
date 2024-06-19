using System.Collections.Specialized;
using System.Text.Json;
using System.Web;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;

namespace WhatToStreamBackend.Services;

public class StreamingAvailabilityService(HttpClient http) : IStreamingAvailabilityService
{
    public async Task<ShowsByFiltersResult?> GetShowsByFilters(
        string? countryCode = null,
        string? showType = null,
        int? ratingMin = null,
        int? ratingMax = null,
        string? keyword = null,
        string? cursor = null
    )
    {
        string path = "shows/search/filters";
        NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

        // Construct query string
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
        HttpResponseMessage res = await http.GetAsync($"{path}?{query}");
        res.EnsureSuccessStatusCode();

        // Deserialize the response body, ShowsResult Model created to handle the response
        await using Stream resStream = await res.Content.ReadAsStreamAsync();
        
        ShowsByFiltersResult? showsObject = await JsonSerializer
            .DeserializeAsync<ShowsByFiltersResult>(resStream);
        
        ShowsByFiltersGenres? genresObject = await JsonSerializer
            .DeserializeAsync<ShowsByFiltersGenres>(resStream);

        // TODO: idea: save to class properties and access from a different method 
        return showsObject;
    }
}