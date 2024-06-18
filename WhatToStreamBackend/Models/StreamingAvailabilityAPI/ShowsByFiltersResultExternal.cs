using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowsByFiltersResultExternal
{
    [JsonPropertyName("shows")]
    public ShowExternal[] Shows { get; set; } = [];
    
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }
    
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }
}