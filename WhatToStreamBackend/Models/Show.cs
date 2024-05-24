using System.ComponentModel.DataAnnotations;

namespace WhatToStreamBackend.Models;

public class Show
{
    [Key]
    [MaxLength(50)]
    public string? Id { get; set; }
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
    
    public List<Genre>? Genres { get; set; }
    // public List<string>? Directors { get; set; }
    // public List<string>? Creators { get; set; }
    // public List<string>? Cast { get; set; }
    public int? Rating { get; set; }
    public int? Minimum { get; set; }
    public int? Maximum { get; set; }
    public int? SeasonCount { get; set; }
    public int? EpisodeCount { get; set; }
    public ShowImageSet? ImageSet { get; set; }
    public StreamingOption? StreamingOptions { get; set; }
}