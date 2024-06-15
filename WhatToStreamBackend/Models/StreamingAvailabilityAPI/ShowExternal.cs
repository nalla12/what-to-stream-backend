namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowExternal
{
    public string? id { get; set; }
    public string? itemType { get; set; }
    public string? showType { get; set; }
    public string? imdbId { get; set; }
    public string? tmdbId { get; set; }
    public string? title { get; set; }
    public string? overview { get; set; }
    public int? releaseYear { get; set; }
    public int? firstAirYear { get; set; }
    public int? lastAirYear { get; set; }
    public string? originalTitle { get; set; }
    public List<GenreExternal>? genres { get; set; }
    public List<string>? directors { get; set; }
    public List<string>? creators { get; set; }
    public List<string>? cast { get; set; }
    public int? rating { get; set; }
    public int? minimum { get; set; }
    public int? maximum { get; set; }
    public int? seasonCount { get; set; }
    public int? episodeCount { get; set; }
    public ShowImageSetExternal? imageSet { get; set; }
    public Dictionary<string, StreamingOptionExternal[]>? streamingOptions { get; set; }
}