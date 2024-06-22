using System.Collections.Specialized;
using System.Text.Json;
using System.Web;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;

namespace WhatToStreamBackend.Services;

public class StreamingAvailabilityService(HttpClient http) : IStreamingAvailabilityService
{
    public ShowGenre[]? ShowGenres { get; set; }

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

        ShowsByFiltersResult? resObject = await JsonSerializer
            .DeserializeAsync<ShowsByFiltersResult>(resStream);

        // Map object to database models
        this.ShowGenres = resObject?.Shows
            .SelectMany(s => s.genres.Select(g => new ShowGenre
            {
                ShowId = s.id,
                GenreId = g.id
            }))
            .ToArray();

        if (this.ShowGenres != null)
        {
            foreach (var showGenre in this.ShowGenres)
            {
                Console.WriteLine($"ShowId: {showGenre.ShowId}, GenreId: {showGenre.GenreId}");
            }
        }

        return resObject;
    }
}