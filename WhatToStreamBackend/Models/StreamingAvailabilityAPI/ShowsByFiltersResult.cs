using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowsByFiltersResult<T> where T : ShowObjectFromApi
{
    [JsonPropertyName("shows")]
    public T[] Shows { get; set; } = [];
    
    [JsonPropertyName("hasMore")]
    public bool? HasMore { get; set; }
    
    [JsonPropertyName("nextCursor")]
    public string? NextCursor { get; set; }
}