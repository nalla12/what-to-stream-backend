using System.Collections.Specialized;
using System.Text.Json;
using System.Web;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;

namespace WhatToStreamBackend.Services;

public class StreamingAvailabilityService(HttpClient http) : IStreamingAvailabilityService
{
    public ShowGenre[]? ShowGenres { get; set; }

    public async Task<object?> GetShowsByFilters(
        string countryCode,
        string showType,
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

        // Deserialize the response body
        await using Stream resStream = await res.Content.ReadAsStreamAsync();
        object? resObject;

        if (showType == "movie")
        {
            resObject = await JsonSerializer
                .DeserializeAsync<ShowsByFiltersResult<ShowsMovie>>(resStream);
        } 
        else if (showType == "series")
        {
            resObject = await JsonSerializer
                .DeserializeAsync<ShowsByFiltersResult<ShowsSeries>>(resStream);
        }
        else
        {
            throw new ArgumentException("Invalid show type");
        }

        switch (resObject)
        {
            // Map object to database models
            case ShowsByFiltersResult<ShowsMovie> movieResults:
            {
                // Process movieResults
                Show[]? shows = movieResults.Shows.Select(s => new Show
                {
                    Id = s.id,
                    ItemType = s.itemType,
                    ShowType = s.showType,
                    ImdbId = s.imdbId,
                    TmdbId = s.tmdbId,
                    Title = s.title,
                    OriginalTitle = s.originalTitle,
                    Overview = s.overview,
                    ReleaseYear = s.releaseYear,
                    Rating = s.rating,
                    Runtime = s.runtime,
                    ImageSet = null,
                    ShowGenres = null,
                    StreamingOptions = null
                }).ToArray();
        
                /*this.ShowGenres = movieResults.Shows
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
            }*/

                return shows;
            }
            case ShowsByFiltersResult<ShowsSeries> seriesResults:
            {
                // Process seriesResults
                Show[]? shows = seriesResults.Shows.Select(s => new Show
                {
                    Id = s.id,
                    ItemType = s.itemType,
                    ShowType = s.showType,
                    ImdbId = s.imdbId,
                    TmdbId = s.tmdbId,
                    Title = s.title,
                    OriginalTitle = s.originalTitle,
                    Overview = s.overview,
                    FirstAirYear = s.firstAirYear,
                    LastAirYear = s.lastAirYear,
                    Rating = s.rating,
                    SeasonCount = s.seasonCount,
                    EpisodeCount = s.episodeCount,
                    ImageSet = null,
                    ShowGenres = null,
                    StreamingOptions = null
                }).ToArray();
            
                return shows;
            }
            default:
                return resObject;
        }
    }
}