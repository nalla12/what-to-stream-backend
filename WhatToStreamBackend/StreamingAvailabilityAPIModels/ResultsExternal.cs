namespace WhatToStreamBackend.StreamingAvailabilityAPIModels;

public class ResultsExternal
{
    public string? Id { get; set; }
    public string? ShowType { get; set; }
    public string? ImdbId { get; set; }
    public string? TmdbId { get; set; }
    public string? Title { get; set; }
    public string? Overview { get; set; }
    public int? ReleaseYear { get; set; }
    public int? Rating { get; set; }
}