using Newtonsoft.Json;

namespace WhatToStreamBacked.Models;

public class Genre
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
}