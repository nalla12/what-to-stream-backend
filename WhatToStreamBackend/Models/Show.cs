using System.ComponentModel.DataAnnotations;

namespace WhatToStreamBackend.Models;

public class Show
{
    [Key, Required]
    [MaxLength(50)]
    public string Id { get; set; }
    [MaxLength(50)]
    public string? ItemType { get; set; }
    [MaxLength(50)]
    public string? ShowType { get; set; }
    [MaxLength(255)]
    public string? ImdbId { get; set; }
    [MaxLength(255)]
    public string? TmdbId { get; set; }
    [MaxLength(400)]
    public string? Title { get; set; }
    [MaxLength(8000)]
    public string? Overview { get; set; }
    public int? ReleaseYear { get; set; }
    public int? FirstAirYear { get; set; }
    public int? LastAirYear { get; set; }
    [MaxLength(400)]
    public string? OriginalTitle { get; set; }
    public ICollection<ShowGenre> ShowGenres { get; set; } = new List<ShowGenre>();
    
    public int? Rating { get; set; }
    public int? Minimum { get; set; }
    public int? Maximum { get; set; }
    public int? SeasonCount { get; set; }
    public int? EpisodeCount { get; set; }
    public ShowImageSet? ImageSet { get; set; }
    public ICollection<StreamingOption>? StreamingOptions { get; set; } = new List<StreamingOption>();
}