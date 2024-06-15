using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhatToStreamBackend.StreamingAvailabilityAPIModels;

public class GenreExternal
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
}