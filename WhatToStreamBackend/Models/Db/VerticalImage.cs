using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.Db;

// URLs for the images
public class VerticalImage
{
    [Key] public int Id { get; set; }
    
    [MaxLength(2000)]
    [JsonPropertyName("w240")]
    public string? W240 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w360")]
    public string? W360 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w480")]
    public string? W480 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w600")]
    public string? W600 { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("w720")]
    public string? W720 { get; set; }
}