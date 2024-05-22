namespace WhatToStreamBackend.Models;

public class ShowsResult
{
    public List<Show>? Shows { get; set; }
    public bool? HasMore { get; set; }
    public string? NextCursor { get; set; }
}