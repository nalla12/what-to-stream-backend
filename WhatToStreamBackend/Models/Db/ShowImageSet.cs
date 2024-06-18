using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WhatToStreamBackend.Models.Db;

public class ShowImageSet
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("verticalPoster")]
    public VerticalImage? VerticalPoster { get; set; }
    
    [JsonPropertyName("horizontalPoster")]
    public HorizontalImage? HorizontalPoster { get; set; }
    
    [JsonPropertyName("verticalBackdrop")]
    public VerticalImage? VerticalBackdrop { get; set; }
    
    [JsonPropertyName("horizontalBackdrop")]
    public HorizontalImage? HorizontalBackdrop { get; set; }
    
}