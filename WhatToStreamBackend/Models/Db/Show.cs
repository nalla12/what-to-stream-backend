using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.Db;

public class Show
{
    [Key, Required]
    [MaxLength(50)]
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [MaxLength(50)]
    [JsonPropertyName("itemType")]
    public string? ItemType { get; set; }
    
    [MaxLength(50)]
    [JsonPropertyName("showType")]
    public string? ShowType { get; set; }
    
    [MaxLength(255)]
    [JsonPropertyName("imdbId")]
    public string? ImdbId { get; set; }
    
    [MaxLength(255)]
    [JsonPropertyName("tmdbId")]
    public string? TmdbId { get; set; }
    
    [MaxLength(400)]
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [MaxLength(8000)]
    [JsonPropertyName("overview")]
    public string? Overview { get; set; }
    
    [JsonPropertyName("releaseYear")]
    public int? ReleaseYear { get; set; }
    
    [JsonPropertyName("firstAirYear")]
    public int? FirstAirYear { get; set; }
    
    [JsonPropertyName("lastAirYear")]
    public int? LastAirYear { get; set; }
    
    [MaxLength(400)]
    [JsonPropertyName("originalTitle")]
    public string? OriginalTitle { get; set; }
    
    [JsonPropertyName("genres")]
    public ICollection<ShowGenre> ShowGenres { get; set; }
        = new List<ShowGenre>();
    
    [JsonPropertyName("rating")]
    public int? Rating { get; set; }
    
    [JsonPropertyName("seasonCount")]
    public int? SeasonCount { get; set; }
    
    [JsonPropertyName("episodeCount")]
    public int? EpisodeCount { get; set; }
    
    [JsonPropertyName("imageSet")]
    public ShowImageSet? ImageSet { get; set; }
    
    [JsonPropertyName("streamingOptions")]
    public ICollection<StreamingOption>? StreamingOptions { get; set; } 
        = new List<StreamingOption>();
}