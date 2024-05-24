using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

public class Genre
{
    [Key]
    [MaxLength(255)]
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }

    [MaxLength(255)]
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; set; }
}