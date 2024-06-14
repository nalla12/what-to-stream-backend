using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

public class StreamingOption
{
    [Key, Column(Order = 0)]
    public int Id { get; set; }
    
    [JsonIgnore]
    [Key, Required, Column(Order = 1)]
    [MaxLength(50)]
    public string ShowId { get; set; }

    [JsonIgnore]
    [ForeignKey("ShowId")]
    public Show Show { get; set; }
    
    [Key, Required, Column(Order = 2)]
    [MaxLength(255)]
    public string ServiceId { get; set; }

    [JsonProperty(PropertyName = "streamingService")]
    [ForeignKey("ServiceId")]
    public ServiceInfo StreamingService { get; set; }
    
    [Key, Required, Column(Order = 3)]
    [MaxLength(2)]
    public string CountryCode { get; set; }

    [JsonIgnore]
    [ForeignKey("CountryCode")]
    [MaxLength(50)]
    public Country? Country { get; set; }

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
    public long? ExpiresOn { get; set; }

    [JsonProperty(PropertyName = "availableSince")]
    public long? AvailableSince { get; set; }
}