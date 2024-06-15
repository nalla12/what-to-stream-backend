using Newtonsoft.Json;

namespace WhatToStreamBackend.StreamingAvailabilityAPIModels;

public class ShowImageSetExternal
{
    [JsonProperty(PropertyName = "verticalPoster")]
    public VerticalImageExternal? VerticalPoster { get; set; }
    [JsonProperty(PropertyName = "horizontalPoster")]
    public HorizontalImageExternal? HorizontalPoster { get; set; }
    [JsonProperty(PropertyName = "verticalBackdrop")]
    public VerticalImageExternal? VerticalBackdrop { get; set; }
    [JsonProperty(PropertyName = "horizontalBackdrop")]
    public HorizontalImageExternal? HorizontalBackdrop { get; set; }
}