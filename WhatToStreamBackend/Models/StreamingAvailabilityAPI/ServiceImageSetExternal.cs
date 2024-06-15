using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

// URLs for the images
public class ServiceImageSetExternal
{
    public int Id { get; set; }
    
    [JsonProperty(PropertyName = "lightThemeImage")]
    public string? LightThemeImage { get; set; }

    [JsonProperty(PropertyName = "darkThemeImage")]
    public string? DarkThemeImage { get; set; }

    [JsonProperty(PropertyName = "whiteImage")]
    public string? WhiteImage { get; set; }
}