namespace WhatToStreamBacked.Models;

public class Show
{
    public string? ItemType { get; set; }
    public string? ShowType { get; set; }
    public string? Id { get; set; }
    public string? ImdbId { get; set; }
    public string? TmdbId { get; set; }
    public string? Title { get; set; }
    public string? Overview { get; set; }
    public int? ReleaseYear { get; set; }
    public int? FirstAirYear { get; set; }
    public int? LastAirYear { get; set; }
    public string? OriginalTitle { get; set; }
    public List<Genre>? Genres { get; set; }
    public List<string>? Directors { get; set; }
    public List<string>? Creators { get; set; }
    public List<string>? Cast { get; set; }
    public int? Rating { get; set; }
    public int? Minimum { get; set; }
    public int? Maximum { get; set; }
    public int? SeasonCount { get; set; }
    public int? EpisodeCount { get; set; }
    public ShowImageSet? ImageSet { get; set; }
    public StreamingOption? StreamingOptions { get; set; }
}