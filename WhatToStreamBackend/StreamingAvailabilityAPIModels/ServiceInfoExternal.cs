using Newtonsoft.Json;

namespace WhatToStreamBackend.StreamingAvailabilityAPIModels;

public class ServiceInfoExternal
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }
    
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [JsonProperty(PropertyName = "homePage")]
    public string? HomePage { get; set; }

    [JsonProperty(PropertyName = "themeColorCode")]
    public string? ThemeColorCode { get; set; }

    [JsonProperty(PropertyName = "imageSet")]
    public ServiceImageSetExternal? ImageSet { get; set; }
}