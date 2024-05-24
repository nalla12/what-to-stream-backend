using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

// URLs for the images
public class VerticalImage
{
    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w240")]
    public string? W240 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w360")]
    public string? W360 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w480")]
    public string? W480 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w600")]
    public string? W600 { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "w720")]
    public string? W720 { get; set; }
}