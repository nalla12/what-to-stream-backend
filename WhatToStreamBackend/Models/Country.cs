using System.ComponentModel.DataAnnotations;

namespace WhatToStreamBackend.Models;

public class Country
{
    [Key, Required]
    [MaxLength(2)]
    public string CountryCode { get; set; }
    [MaxLength(255)]
    public string? Name { get; set; }
    
    public ICollection<StreamingOption> StreamingOptions { get; set; } = new List<StreamingOption>();
}