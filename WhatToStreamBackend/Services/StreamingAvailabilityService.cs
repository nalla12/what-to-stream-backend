using System.Collections.Specialized;
using System.Text.Json;
using System.Web;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;

namespace WhatToStreamBackend.Services;

public class StreamingAvailabilityService(HttpClient http) : IStreamingAvailabilityService
{
    public ShowGenre[]? ShowGenres { get; set; }

    public async Task<object[]?> GetShowsByFilters(
        string countryCode,
        string showType,
        int? ratingMin = null,
        int? ratingMax = null,
        string? keyword = null,
        string? cursor = null
    )
    {
        string path = "shows/search/filters";
        object? resObject;
        object[]? showsFromRes;
        
        NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

        // Construct query string
            query["country"] = countryCode;
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
                showsFromRes = movieResults.Shows.Select(s => new Show
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
                    ImageSet = s.imageSet != null ? new ShowImageSet
                    {
                        VerticalPoster = s.imageSet.verticalPoster != null ? new VerticalImage()
                        {
                            W240 = s.imageSet.verticalPoster.w240,
                            W360 = s.imageSet.verticalPoster.w360,
                            W480 = s.imageSet.verticalPoster.w480,
                            W600 = s.imageSet.verticalPoster.w600,
                            W720 = s.imageSet.verticalPoster.w720
                        } : null,
                        HorizontalPoster = s.imageSet.horizontalPoster != null ? new HorizontalImage()
                        {
                            W360 = s.imageSet.horizontalPoster.w360,
                            W480 = s.imageSet.horizontalPoster.w480,
                            W720 = s.imageSet.horizontalPoster.w720,
                            W1080 = s.imageSet.horizontalPoster.w1080,
                            W1440 = s.imageSet.horizontalPoster.w1440
                        } : null,
                        VerticalBackdrop = s.imageSet.verticalBackdrop != null ? new VerticalImage()
                        {
                            W240 = s.imageSet.verticalBackdrop.w240,
                            W360 = s.imageSet.verticalBackdrop.w360,
                            W480 = s.imageSet.verticalBackdrop.w480,
                            W600 = s.imageSet.verticalBackdrop.w600,
                            W720 = s.imageSet.verticalBackdrop.w720
                        } : null,
                        HorizontalBackdrop = s.imageSet.horizontalBackdrop != null ? new HorizontalImage()
                        {
                            W360 = s.imageSet.horizontalBackdrop.w360,
                            W480 = s.imageSet.horizontalBackdrop.w480,
                            W720 = s.imageSet.horizontalBackdrop.w720,
                            W1080 = s.imageSet.horizontalBackdrop.w1080,
                            W1440 = s.imageSet.horizontalBackdrop.w1440
                        } : null
                    } : null,
                    ShowGenres = s.genres.Select(g => new ShowGenre
                    {
                        ShowId = s.id,
                        GenreId = g.id
                    }).ToArray(),
                    StreamingOptions = GetCountryInfoStreamingOption(s.streamingOptions, countryCode).Select(so => new StreamingOption
                    {
                        ShowId = s.id,
                        ServiceId = so.service.id,
                        CountryCode = countryCode,
                        Type = so.type,
                        Link = so.link,
                        VideoLink = so.videoLink,
                        Quality = so.quality,
                        ExpiresSoon = so.expiresSoon,
                        ExpiresOn = so.expiresOn,
                        AvailableSince = so.availableSince
                    }).ToArray(),
                }).ToArray();

                break;
            }
            case ShowsByFiltersResult<ShowsSeries> seriesResults:
            {
                // Process seriesResults
                showsFromRes = seriesResults.Shows.Select(s => new Show
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
                    ImageSet = s.imageSet != null ? new ShowImageSet
                    {
                        VerticalPoster = s.imageSet.verticalPoster != null ? new VerticalImage()
                        {
                            W240 = s.imageSet.verticalPoster.w240,
                            W360 = s.imageSet.verticalPoster.w360,
                            W480 = s.imageSet.verticalPoster.w480,
                            W600 = s.imageSet.verticalPoster.w600,
                            W720 = s.imageSet.verticalPoster.w720
                        } : null,
                        HorizontalPoster = s.imageSet.horizontalPoster != null ? new HorizontalImage()
                        {
                            W360 = s.imageSet.horizontalPoster.w360,
                            W480 = s.imageSet.horizontalPoster.w480,
                            W720 = s.imageSet.horizontalPoster.w720,
                            W1080 = s.imageSet.horizontalPoster.w1080,
                            W1440 = s.imageSet.horizontalPoster.w1440
                        } : null,
                        VerticalBackdrop = s.imageSet.verticalBackdrop != null ? new VerticalImage()
                        {
                            W240 = s.imageSet.verticalBackdrop.w240,
                            W360 = s.imageSet.verticalBackdrop.w360,
                            W480 = s.imageSet.verticalBackdrop.w480,
                            W600 = s.imageSet.verticalBackdrop.w600,
                            W720 = s.imageSet.verticalBackdrop.w720
                        } : null,
                        HorizontalBackdrop = s.imageSet.horizontalBackdrop != null ? new HorizontalImage()
                        {
                            W360 = s.imageSet.horizontalBackdrop.w360,
                            W480 = s.imageSet.horizontalBackdrop.w480,
                            W720 = s.imageSet.horizontalBackdrop.w720,
                            W1080 = s.imageSet.horizontalBackdrop.w1080,
                            W1440 = s.imageSet.horizontalBackdrop.w1440
                        } : null
                    } : null,
                    ShowGenres = s.genres.Select(g => new ShowGenre
                    {
                        ShowId = s.id,
                        GenreId = g.id
                    }).ToArray(),
                    StreamingOptions = GetCountryInfoStreamingOption(s.streamingOptions, countryCode).Select(so => new StreamingOption
                    {
                        ShowId = s.id,
                        ServiceId = so.service.id,
                        CountryCode = countryCode,
                        Type = so.type,
                        Link = so.link,
                        VideoLink = so.videoLink,
                        Quality = so.quality,
                        ExpiresSoon = so.expiresSoon,
                        ExpiresOn = so.expiresOn,
                        AvailableSince = so.availableSince
                    }).ToArray(),
                }).ToArray();

                break;
            }
            default:
                showsFromRes = [];
                break;
        }

        return showsFromRes;
    }
    
    public static CountryStreamingOption[]? GetCountryInfoStreamingOption(Dictionary<string, CountryStreamingOption[]> streamingOptions,string countryCode)
    {
        if (streamingOptions.TryGetValue(countryCode, out CountryStreamingOption[] cso))
        {
            return cso;
        }
        else
        {
            // Handle the case where the country code is not found
            return null; // or throw an exception or return a default value
        }
    }
}