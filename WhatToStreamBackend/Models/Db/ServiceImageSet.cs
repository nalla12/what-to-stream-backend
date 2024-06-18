using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.Db;

// URLs for the images
public class ServiceImageSet
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [MaxLength(2000)]
    [JsonPropertyName("lightThemeImage")]
    public string? LightThemeImage { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("darkThemeImage")]
    public string? DarkThemeImage { get; set; }

    [MaxLength(2000)]
    [JsonPropertyName("whiteImage")]
    public string? WhiteImage { get; set; }
}