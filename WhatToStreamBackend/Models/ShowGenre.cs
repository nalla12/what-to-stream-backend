using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatToStreamBackend.Models;

public class ShowGenre
{
    [Key, Column(Order = 0)]
    [MaxLength(50)]
    public string? ShowId { get; set; }

    [ForeignKey("ShowId")]
    public Show? Show { get; set; }

    [Key, Column(Order = 1)]
    [MaxLength(255)]
    public string? GenreId { get; set; }

    [ForeignKey("GenreId")]
    public Genre? Genre { get; set; }
}