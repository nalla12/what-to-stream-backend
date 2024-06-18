using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.Db;

public class Genre
{
    [Key]
    [MaxLength(255)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [MaxLength(255)]
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [Newtonsoft.Json.JsonIgnore]
    public ICollection<ShowGenre> ShowGenres { get; } = new List<ShowGenre>();
}