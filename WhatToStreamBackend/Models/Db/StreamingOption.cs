using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.Db;

public class StreamingOption
{
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    
    [Newtonsoft.Json.JsonIgnore]
    [Key, Required, Column(Order = 1)]
    [MaxLength(50)]
    public string ShowId { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    [ForeignKey("ShowId")]
    public Show Show { get; set; }
    
    [Key, Required, Column(Order = 2)]
    [MaxLength(255)]
    public string ServiceId { get; set; }

    [ForeignKey("ServiceId")]
    [JsonPropertyName("streamingService")]
    public ServiceInfo StreamingService { get; set; }
    
    [Key, Required, Column(Order = 3)]
    [MaxLength(2)]
    public string CountryCode { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    [ForeignKey("CountryCode")]
    [MaxLength(50)]
    public Country? Country { get; set; }

    [MaxLength(255)]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("link")]
    public string? Link { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("videoLink")]
    public string? VideoLink { get; set; }

    [MaxLength(255)]
    [JsonPropertyName("quality")]
    public string? Quality { get; set; }

    [JsonPropertyName("expiresSoon")]
    public bool? ExpiresSoon { get; set; }

    [JsonPropertyName("expiresOn")]
    public long? ExpiresOn { get; set; }

    [JsonPropertyName("availableSince")]
    public long? AvailableSince { get; set; }
}