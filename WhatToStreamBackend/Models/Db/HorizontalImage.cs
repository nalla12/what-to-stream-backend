using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.Db;

// URLs for the images
public class HorizontalImage
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [MaxLength(2000)]
    [JsonPropertyName("w360")]
    public string? W360 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w480")]
    public string? W480 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w720")]
    public string? W720 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w1080")]
    public string? W1080 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w1440")]
    public string? W1440 { get; set; }
}