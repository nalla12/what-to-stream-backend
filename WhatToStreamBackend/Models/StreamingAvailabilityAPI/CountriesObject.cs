namespace WhatToStreamBackend.Models.StreamingAvailabilityAPI;

public class CountriesObject
{
    public Dictionary<string, CountryServices> countryServices { get; set; }
}

public class CountryServices
{
    public string countryCode { get; set; }
    public string name { get; set; }
    public Service[] services { get; set; }
}