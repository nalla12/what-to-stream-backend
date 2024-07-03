using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.Db;

public class ServiceDetails
{
    [Key, Column(Order = 0)]
    [MaxLength(255)]
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [MaxLength(2000)]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [Key, Column(Order = 1)]
    [MaxLength(2)]
    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }

    [ForeignKey("CountryCode")]
    [MaxLength(50)]
    [Newtonsoft.Json.JsonIgnore]
    public Country? Country { get; set; }

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