using Newtonsoft.Json;

namespace WhatToStreamBackend.Models;

public class ShowImageSet
{
    [JsonProperty(PropertyName = "verticalPoster")]
    public VerticalImage? VerticalPoster { get; set; }
    [JsonProperty(PropertyName = "horizontalPoster")]
    public HorizontalImage? HorizontalPoster { get; set; }
    [JsonProperty(PropertyName = "verticalBackdrop")]
    public VerticalImage? VerticalBackdrop { get; set; }
    [JsonProperty(PropertyName = "horizontalBackdrop")]
    public HorizontalImage? HorizontalBackdrop { get; set; }
}