using Newtonsoft.Json;

namespace WhatToStreamBackend.StreamingAvailabilityAPIModels;

// URLs for the images
public class ServiceImageSet
{
    public int Id { get; set; }
    
    [JsonProperty(PropertyName = "lightThemeImage")]
    public string? LightThemeImage { get; set; }

    [JsonProperty(PropertyName = "darkThemeImage")]
    public string? DarkThemeImage { get; set; }

    [JsonProperty(PropertyName = "whiteImage")]
    public string? WhiteImage { get; set; }
}