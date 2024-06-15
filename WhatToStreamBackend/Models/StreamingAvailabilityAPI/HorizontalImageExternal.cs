using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

// URLs for the images
public class HorizontalImageExternal
{
    public int Id { get; set; }
    
    [JsonProperty(PropertyName = "w360")]
    public string? W360 { get; set; }

    [JsonProperty(PropertyName = "w480")]
    public string? W480 { get; set; }

    [JsonProperty(PropertyName = "w720")]
    public string? W720 { get; set; }

    [JsonProperty(PropertyName = "w1080")]
    public string? W1080 { get; set; }

    [JsonProperty(PropertyName = "w1440")]
    public string? W1440 { get; set; }
}