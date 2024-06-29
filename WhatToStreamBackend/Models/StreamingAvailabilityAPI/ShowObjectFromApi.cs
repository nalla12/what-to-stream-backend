namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class ShowObjectFromApi
{
    public string itemType { get; set; }
    public string showType { get; set; }
    public string id { get; set; }
    public string imdbId { get; set; }
    public string tmdbId { get; set; }
    public string title { get; set; }
    public string overview { get; set; }
    public string? originalTitle { get; set; }
    public Genres[] genres { get; set; }
    public string[]? cast { get; set; }
    public int? rating { get; set; } // min 0, max 100
    public ImageSet? imageSet { get; set; }
    public Dictionary<string, CountryStreamingOption[]>? streamingOptions { get; set; }
}

public class Genres
{
    public string id { get; set; }
    public string name { get; set; }
}

public class ImageSet
{
    public VerticalPoster verticalPoster { get; set; }
    public HorizontalPoster horizontalPoster { get; set; }
    public VerticalBackdrop verticalBackdrop { get; set; }
    public HorizontalBackdrop horizontalBackdrop { get; set; }
}

public class VerticalPoster
{
    public string w240 { get; set; }
    public string w360 { get; set; }
    public string w480 { get; set; }
    public string w600 { get; set; }
    public string w720 { get; set; }
}

public class HorizontalPoster
{
    public string w360 { get; set; }
    public string w480 { get; set; }
    public string w720 { get; set; }
    public string w1080 { get; set; }
    public string w1440 { get; set; }
}

public class VerticalBackdrop
{
    public string w240 { get; set; }
    public string w360 { get; set; }
    public string w480 { get; set; }
    public string w600 { get; set; }
    public string w720 { get; set; }
}

public class HorizontalBackdrop
{
    public string w360 { get; set; }
    public string w480 { get; set; }
    public string w720 { get; set; }
    public string w1080 { get; set; }
    public string w1440 { get; set; }
}

public class CountryStreamingOption
{
    public Service service { get; set; }
    public string type { get; set; }
    public string link { get; set; }
    public string videoLink { get; set; }
    public string quality { get; set; }
    public bool expiresSoon { get; set; }
    public long? expiresOn { get; set; }
    public long availableSince { get; set; }
    public Addon addon { get; set; }
    public Price price { get; set; }
}

public class Service
{
    public string id { get; set; }
    public string name { get; set; }
    public string homePage { get; set; }
    public string themeColorCode { get; set; }
    public ImageSet1 imageSet { get; set; }
}

public class ImageSet1
{
    public string lightThemeImage { get; set; }
    public string darkThemeImage { get; set; }
    public string whiteImage { get; set; }
}

public class Locale
{
    public string language { get; set; }
}

public class Addon
{
    public string id { get; set; }
    public string name { get; set; }
    public string homePage { get; set; }
    public string themeColorCode { get; set; }
    public ImageSet2 imageSet { get; set; }
}

public class ImageSet2
{
    public string lightThemeImage { get; set; }
    public string darkThemeImage { get; set; }
    public string whiteImage { get; set; }
}

public class Price
{
    public string amount { get; set; }
    public string currency { get; set; }
    public string formatted { get; set; }
}

