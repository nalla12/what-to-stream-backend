using Newtonsoft.Json;

namespace WhatToStreamBackend.StreamingAvailabilityAPIModels;

// URLs for the images
public class VerticalImage
{
    public int Id { get; set; }
    
    [JsonProperty(PropertyName = "w240")]
    public string? W240 { get; set; }

    [JsonProperty(PropertyName = "w360")]
    public string? W360 { get; set; }

    [JsonProperty(PropertyName = "w480")]
    public string? W480 { get; set; }

    [JsonProperty(PropertyName = "w600")]
    public string? W600 { get; set; }

    [JsonProperty(PropertyName = "w720")]
    public string? W720 { get; set; }
}