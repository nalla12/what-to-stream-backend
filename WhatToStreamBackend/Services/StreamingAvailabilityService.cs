using System.Collections.Specialized;
using System.Text.Json;
using System.Web;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Models.StreamingAvailabilityAPI;

namespace WhatToStreamBackend.Services;

public class StreamingAvailabilityService(HttpClient http) : IStreamingAvailabilityService
{
    public async Task<IEnumerable<Show>?> GetShowsByFilters(
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
        
        // TODO: handle pagination
        // TODO: remove addon from the response so they are not imported to the Db

        if (showType == "movie")
        {
            var movieResults = await JsonSerializer
                .DeserializeAsync<ShowsByFiltersResult<ShowsMovie>>(resStream);
            
            return movieResults.Shows.Select(s => 
                MapDbShowFromMovieObject(s, countryCode)).ToArray();
        } 
        
        if (showType == "series")
        {
            var seriesResults = await JsonSerializer
                .DeserializeAsync<ShowsByFiltersResult<ShowsSeries>>(resStream);
            
            return seriesResults.Shows.Select(s => 
                MapDbShowFromSeriesObject(s, countryCode)).ToArray();
        }
        
        throw new ArgumentException("Invalid show type");
    }

    public async Task<Show?> GetShowById(string id, string countryCode)
    {
        string path = $"shows/{id}";

        NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
        query["country"] = countryCode;

        // The GET request response
        HttpResponseMessage res = await http.GetAsync($"{path}?{query}");
        res.EnsureSuccessStatusCode();

        // Find the showType
        string jsonAsString = await res.Content.ReadAsStringAsync();
        string showType = ReadShowTypeFromJsonString(jsonAsString);
        
        // Deserialize the response body
        await using Stream resStream = await res.Content.ReadAsStreamAsync();

        // Deserialize the response body
        if (showType == "movie")
        {
            var movie = await JsonSerializer.DeserializeAsync<ShowsMovie>(resStream);
            return MapDbShowFromMovieObject(movie, countryCode);
        }
        
        if (showType == "series")
        {
            var series = await JsonSerializer.DeserializeAsync<ShowsSeries>(resStream);
            return MapDbShowFromSeriesObject(series, countryCode);
        }
        
        throw new ArgumentException("Invalid show type");
    }
    
    public async Task<List<ServiceDetails>> GetAllStreamingServicesByCountry()
    {
        string path = "countries";
        
        HttpResponseMessage res = await http.GetAsync(path);
        res.EnsureSuccessStatusCode();

        // Deserialize the response body
        await using Stream resStream = await res.Content.ReadAsStreamAsync();
        var servicesByCountry = await JsonSerializer.DeserializeAsync<Dictionary<string, CountryServices>>(resStream);

        if (servicesByCountry == null)
            throw new Exception("Failed to deserialize the API response.");
        
        var services = new List<ServiceDetails>();

        foreach (var entry in servicesByCountry)
        {
            var country = entry.Value.countryCode;
            var servicesList = entry.Value.services;

            var details = servicesList.Select(s => new ServiceDetails
            {
                Id = s.id,
                Name = s.name,
                CountryCode = country,
                HomePage = s.homePage,
                ThemeColorCode = s.themeColorCode,
                ImageSet = s.imageSet != null
                    ? new ServiceImageSet
                    {
                        LightThemeImage = s.imageSet.lightThemeImage,
                        DarkThemeImage = s.imageSet.darkThemeImage,
                        WhiteImage = s.imageSet.whiteImage
                    }
                    : null
            });
            
            services.AddRange(details);
        }
        
        return services;
    }
    
    public async Task<List<Country>> GetListOfCountries()
    {
        string path = "countries";
        
        HttpResponseMessage res = await http.GetAsync(path);
        res.EnsureSuccessStatusCode();

        // Deserialize the response body
        await using Stream resStream = await res.Content.ReadAsStreamAsync();
        var servicesByCountry = await JsonSerializer.DeserializeAsync<Dictionary<string, CountryServices>>(resStream);
        
        if (servicesByCountry == null)
            throw new Exception("Failed to deserialize the API response.");
        
        var countries = new List<Country>();

        foreach (var entry in servicesByCountry)
        {
            countries.Add(new Country
            {
                CountryCode = entry.Key,
                Name = entry.Value.name
            });
        }
        
        return countries;
    }

    // TODO: maybe handle if there's multiple countries. For now make countryCode mandatory.
    private static CountryStreamingOption[] ExtractCountryStreamingOption(
                    Dictionary<string, CountryStreamingOption[]> streamingOptions, string countryCode)
    {
        if (streamingOptions.TryGetValue(countryCode, out CountryStreamingOption[] cso))
        {
            return cso.Where(option => option.type != "addon").ToArray();
        }

        return [];
    }

    private string ReadShowTypeFromJsonString(string jsonAsString)
    {
        var options = new JsonDocumentOptions
        {
            AllowTrailingCommas = true
        };
        
        using JsonDocument doc = JsonDocument.Parse(jsonAsString, options);
        JsonElement root = doc.RootElement;

        if (root.TryGetProperty("showType", out JsonElement showTypeElement))
        {
            return showTypeElement.GetString();
        }
        else
        {
            throw new JsonException("Show type not found in JSON");
        }
    }

    private Show MapDbShowFromMovieObject(ShowsMovie movieObject, string countryCode)
    {
        return new Show
        {
            Id = movieObject.id,
            ItemType = movieObject.itemType,
            ShowType = movieObject.showType,
            ImdbId = movieObject.imdbId,
            TmdbId = movieObject.tmdbId,
            Title = movieObject.title,
            OriginalTitle = movieObject.originalTitle,
            Overview = movieObject.overview,
            ReleaseYear = movieObject.releaseYear,
            Rating = movieObject.rating,
            Runtime = movieObject.runtime,
            ImageSet = movieObject.imageSet != null
                ? new ShowImageSet
                {
                    VerticalPoster = movieObject.imageSet.verticalPoster != null
                        ? new VerticalImage()
                        {
                            W240 = movieObject.imageSet.verticalPoster.w240,
                            W360 = movieObject.imageSet.verticalPoster.w360,
                            W480 = movieObject.imageSet.verticalPoster.w480,
                            W600 = movieObject.imageSet.verticalPoster.w600,
                            W720 = movieObject.imageSet.verticalPoster.w720
                        }
                        : null,
                    HorizontalPoster = movieObject.imageSet.horizontalPoster != null
                        ? new HorizontalImage()
                        {
                            W360 = movieObject.imageSet.horizontalPoster.w360,
                            W480 = movieObject.imageSet.horizontalPoster.w480,
                            W720 = movieObject.imageSet.horizontalPoster.w720,
                            W1080 = movieObject.imageSet.horizontalPoster.w1080,
                            W1440 = movieObject.imageSet.horizontalPoster.w1440
                        }
                        : null,
                    VerticalBackdrop = movieObject.imageSet.verticalBackdrop != null
                        ? new VerticalImage()
                        {
                            W240 = movieObject.imageSet.verticalBackdrop.w240,
                            W360 = movieObject.imageSet.verticalBackdrop.w360,
                            W480 = movieObject.imageSet.verticalBackdrop.w480,
                            W600 = movieObject.imageSet.verticalBackdrop.w600,
                            W720 = movieObject.imageSet.verticalBackdrop.w720
                        }
                        : null,
                    HorizontalBackdrop = movieObject.imageSet.horizontalBackdrop != null
                        ? new HorizontalImage()
                        {
                            W360 = movieObject.imageSet.horizontalBackdrop.w360,
                            W480 = movieObject.imageSet.horizontalBackdrop.w480,
                            W720 = movieObject.imageSet.horizontalBackdrop.w720,
                            W1080 = movieObject.imageSet.horizontalBackdrop.w1080,
                            W1440 = movieObject.imageSet.horizontalBackdrop.w1440
                        }
                        : null
                }
                : null,
            ShowGenres = movieObject.genres.Select(g => new ShowGenre
            {
                ShowId = movieObject.id,
                GenreId = g.id
            }).ToArray(),
            StreamingOptions = ExtractCountryStreamingOption(movieObject.streamingOptions, countryCode)
                .Select(so =>
                new StreamingOption
                {
                    ShowId = movieObject.id,
                    ServiceId = so.service.id,
                    CountryId = countryCode,
                    Type = so.type,
                    Link = so.link,
                    VideoLink = so.videoLink,
                    Quality = so.quality,
                    ExpiresSoon = so.expiresSoon,
                    ExpiresOn = so.expiresOn,
                    AvailableSince = so.availableSince
                }).ToArray()
        };
    }

    private Show MapDbShowFromSeriesObject(ShowsSeries seriesObject, string countryCode)
    {
        return new Show
        {
            Id = seriesObject.id,
            ItemType = seriesObject.itemType,
            ShowType = seriesObject.showType,
            ImdbId = seriesObject.imdbId,
            TmdbId = seriesObject.tmdbId,
            Title = seriesObject.title,
            OriginalTitle = seriesObject.originalTitle,
            Overview = seriesObject.overview,
            FirstAirYear = seriesObject.firstAirYear,
            LastAirYear = seriesObject.lastAirYear,
            Rating = seriesObject.rating,
            SeasonCount = seriesObject.seasonCount,
            EpisodeCount = seriesObject.episodeCount,
            ImageSet = seriesObject.imageSet != null
                ? new ShowImageSet
                {
                    VerticalPoster = seriesObject.imageSet.verticalPoster != null
                        ? new VerticalImage()
                        {
                            W240 = seriesObject.imageSet.verticalPoster.w240,
                            W360 = seriesObject.imageSet.verticalPoster.w360,
                            W480 = seriesObject.imageSet.verticalPoster.w480,
                            W600 = seriesObject.imageSet.verticalPoster.w600,
                            W720 = seriesObject.imageSet.verticalPoster.w720
                        }
                        : null,
                    HorizontalPoster = seriesObject.imageSet.horizontalPoster != null
                        ? new HorizontalImage()
                        {
                            W360 = seriesObject.imageSet.horizontalPoster.w360,
                            W480 = seriesObject.imageSet.horizontalPoster.w480,
                            W720 = seriesObject.imageSet.horizontalPoster.w720,
                            W1080 = seriesObject.imageSet.horizontalPoster.w1080,
                            W1440 = seriesObject.imageSet.horizontalPoster.w1440
                        }
                        : null,
                    VerticalBackdrop = seriesObject.imageSet.verticalBackdrop != null
                        ? new VerticalImage()
                        {
                            W240 = seriesObject.imageSet.verticalBackdrop.w240,
                            W360 = seriesObject.imageSet.verticalBackdrop.w360,
                            W480 = seriesObject.imageSet.verticalBackdrop.w480,
                            W600 = seriesObject.imageSet.verticalBackdrop.w600,
                            W720 = seriesObject.imageSet.verticalBackdrop.w720
                        }
                        : null,
                    HorizontalBackdrop = seriesObject.imageSet.horizontalBackdrop != null
                        ? new HorizontalImage()
                        {
                            W360 = seriesObject.imageSet.horizontalBackdrop.w360,
                            W480 = seriesObject.imageSet.horizontalBackdrop.w480,
                            W720 = seriesObject.imageSet.horizontalBackdrop.w720,
                            W1080 = seriesObject.imageSet.horizontalBackdrop.w1080,
                            W1440 = seriesObject.imageSet.horizontalBackdrop.w1440
                        }
                        : null
                }
                : null,
            ShowGenres = seriesObject.genres.Select(g => new ShowGenre
            {
                ShowId = seriesObject.id,
                GenreId = g.id
            }).ToArray(),
            StreamingOptions = ExtractCountryStreamingOption(seriesObject.streamingOptions, countryCode)
                .Select(so =>
                new StreamingOption
                {
                    ShowId = seriesObject.id,
                    ServiceId = so.service.id,
                    CountryId = countryCode,
                    Type = so.type,
                    Link = so.link,
                    VideoLink = so.videoLink,
                    Quality = so.quality,
                    ExpiresSoon = so.expiresSoon,
                    ExpiresOn = so.expiresOn,
                    AvailableSince = so.availableSince
                }).ToArray(),
        };
    }
}