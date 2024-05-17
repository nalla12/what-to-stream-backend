using Newtonsoft.Json;

namespace WhatToStreamBacked.Models;

public class ServiceImageSet
{
    [JsonProperty(PropertyName = "lightThemeImage")]
    public string? LightThemeImage { get; set; }

    [JsonProperty(PropertyName = "darkThemeImage")]
    public string? DarkThemeImage { get; set; }

    [JsonProperty(PropertyName = "whiteImage")]
    public string? WhiteImage { get; set; }
}