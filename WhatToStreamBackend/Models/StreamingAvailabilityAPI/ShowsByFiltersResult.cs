using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowsByFiltersResult
{
    [JsonPropertyName("shows")]
    public ShowsByFiltersComplete[] Shows { get; set; } = [];
    
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }
    
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }
}