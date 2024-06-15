using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class GenreExternal
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
}