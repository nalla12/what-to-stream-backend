using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

// URLs for the images
public class HorizontalImage
{
    [Key] public int Id { get; set; }
    
    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w360")]
    public string? W360 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w480")]
    public string? W480 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w720")]
    public string? W720 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w1080")]
    public string? W1080 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w1440")]
    public string? W1440 { get; set; }
}