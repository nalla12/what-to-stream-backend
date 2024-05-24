using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

public class StreamingOption
{
    [JsonProperty(PropertyName = "service")]
    public ServiceInfo Service { get; set; }

    [MaxLength(255)]
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "link")]
    public string? Link { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "videoLink")]
    public string? VideoLink { get; set; }

    [MaxLength(255)]
    [JsonProperty(PropertyName = "quality")]
    public string? Quality { get; set; }

    [JsonProperty(PropertyName = "expiresSoon")]
    public bool? ExpiresSoon { get; set; }

    [JsonProperty(PropertyName = "expiresOn")]
    public int? ExpiresOn { get; set; }

    [JsonProperty(PropertyName = "availableSince")]
    public int? AvailableSince { get; set; }
}