using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.Db;

public class Country
{
    [Key, Required]
    [MaxLength(2)]
    public string? CountryCode { get; set; }
    
    [MaxLength(255)]
    public string? Name { get; set; }
    
    [JsonIgnore]
    public ICollection<StreamingOption>? StreamingOptions { get; set; } = new List<StreamingOption>();
}