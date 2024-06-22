using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatToStreamBackend.Models.Db;

public class ShowGenre
{
    [Key, Required, Column(Order = 0)]
    [MaxLength(50)]
    [Newtonsoft.Json.JsonIgnore]
    public string ShowId { get; set; }

    [ForeignKey("ShowId")]
    [Newtonsoft.Json.JsonIgnore]
    public Show Show { get; set; }

    [Key, Required, Column(Order = 1)]
    [MaxLength(255)]
    [Newtonsoft.Json.JsonIgnore]
    public string GenreId { get; set; }

    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }
}