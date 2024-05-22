using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

public class StreamingOption
{
    [JsonProperty(PropertyName = "service")]
    public ServiceInfo Service { get; set; }

    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [JsonProperty(PropertyName = "link")]
    public string? Link { get; set; }

    [JsonProperty(PropertyName = "videoLink")]
    public string? VideoLink { get; set; }

    [JsonProperty(PropertyName = "quality")]
    public string? Quality { get; set; }

    [JsonProperty(PropertyName = "expiresSoon")]
    public bool? ExpiresSoon { get; set; }

    [JsonProperty(PropertyName = "expiresOn")]
    public int? ExpiresOn { get; set; }

    [JsonProperty(PropertyName = "availableSince")]
    public int? AvailableSince { get; set; }
}