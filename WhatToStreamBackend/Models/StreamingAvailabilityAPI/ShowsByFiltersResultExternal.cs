namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowsByFiltersResultExternal
{
    public ShowExternal[] shows { get; set; } = [];
    public bool? hasMore { get; set; }
    public string? nextCursor { get; set; }
}