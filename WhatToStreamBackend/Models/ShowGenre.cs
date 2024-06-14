using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

public class ShowGenre
{
    [JsonIgnore]
    [Key, Required, Column(Order = 0)]
    [MaxLength(50)]
    public string ShowId { get; set; }

    [JsonIgnore]
    [ForeignKey("ShowId")]
    public Show Show { get; set; }

    [JsonIgnore]
    [Key, Required, Column(Order = 1)]
    [MaxLength(255)]
    public string GenreId { get; set; }

    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }
}