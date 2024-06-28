namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowsSeries : ShowObjectFromApi
{
    public int? firstAirYear { get; set; }
    public int? lastAirYear { get; set; }
    public int? seasonCount { get; set; }
    public int? episodeCount { get; set; }
    public string[]? creators { get; set; }
}