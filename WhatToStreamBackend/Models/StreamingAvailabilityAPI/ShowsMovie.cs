namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowsMovie : ShowObjectFromApi
{
    public int? releaseYear { get; set; }
    public int? runtime { get; set; }
    public string[]? directors { get; set; }
}