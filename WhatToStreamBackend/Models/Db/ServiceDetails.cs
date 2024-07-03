using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.Db;

public class ServiceDetails
{
    [Key, Required]
    [MaxLength(255)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    [Required]
    [MaxLength(2000)]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("homePage")]
    public string? HomePage { get; set; }

    [MaxLength(255)]
    [JsonPropertyName("themeColorCode")]
    public string? ThemeColorCode { get; set; }

    [JsonPropertyName("imageSet")]
    public ServiceImageSet? ImageSet { get; set; }
    
    [Newtonsoft.Json.JsonIgnore]
    public ICollection<StreamingOption> StreamingOptions { get; set; } = new List<StreamingOption>();
}