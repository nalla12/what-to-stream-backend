using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WhatToStreamBackend.Models.Db;

public class ShowGenre
{
    [Key, Column(Order = 0)]
    [MaxLength(50)]
    [JsonPropertyName("showId")]
    public string ShowId { get; set; }

    [ForeignKey("ShowId")]
    [Newtonsoft.Json.JsonIgnore]
    public Show? Show { get; set; }

    [Key, Column(Order = 1)]
    [MaxLength(255)]
    [JsonPropertyName("genreId")]
    public string GenreId { get; set; }

    [ForeignKey("GenreId")]
    [Newtonsoft.Json.JsonIgnore]
    public Genre? Genre { get; set; }
}