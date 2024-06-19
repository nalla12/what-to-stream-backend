using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowsByFiltersGenres
{
    [JsonPropertyName("shows")]
    public ShowGenres[] Shows { get; set; } = [];
}

public class ShowGenres
{
    public string id { get; set; }
    public Genres[] genres { get; set; }
}
