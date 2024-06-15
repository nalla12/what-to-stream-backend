using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.Db;

// URLs for the images
public class ServiceImageSet
{
    [Key] public int Id { get; set; }
    
    [MaxLength(2000)]
    [JsonProperty(PropertyName = "lightThemeImage")]
    public string? LightThemeImage { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "darkThemeImage")]
    public string? DarkThemeImage { get; set; }

    [MaxLength(2000)]
    [JsonProperty(PropertyName = "whiteImage")]
    public string? WhiteImage { get; set; }
}