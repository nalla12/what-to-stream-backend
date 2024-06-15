using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.Db;

public class ServiceInfo
{
    [Key, Required]
    [MaxLength(255)]
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }
    
    [Required]
    [MaxLength(2000)]
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "homePage")]
    public string? HomePage { get; set; }

    [MaxLength(255)]
    [JsonProperty(PropertyName = "themeColorCode")]
    public string? ThemeColorCode { get; set; }

    [JsonProperty(PropertyName = "imageSet")]
    public ServiceImageSet? ImageSet { get; set; }
    
    [JsonIgnore]
    public ICollection<StreamingOption> StreamingOptions { get; set; } = new List<StreamingOption>();
}