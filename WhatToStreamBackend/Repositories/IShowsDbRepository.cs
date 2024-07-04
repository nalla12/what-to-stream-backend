using WhatToStreamBackend.Models.Db;

namespace WhatToStreamBackend.Repositories;

public interface IShowsDbRepository
{
    Task<IEnumerable<Show>> GetAllShowsAsync(); 
    Task<Show?> GetShowByIdAsync(string id);
    Task<IEnumerable<Show>> GetShowsByTitle(string title);
    Task<IEnumerable<Show>> GetShowsByGenre(string genre);
    Task<Show> AddShowAsync(Show show);
    Task<List<Show>> AddMultipleShowsAsync(IEnumerable<Show> shows);
    Task<ServiceDetails> AddMultipleServicesAsync(List<ServiceDetails> serviceDetails);
    Task<Country> AddMultipleCountriesAsync(List<Country> countries);
    Task UpdateShowAsync(Show show);
    Task<string> DeleteShowAsync(string id); 
}