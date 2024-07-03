namespace WhatToStreamBackend.Models.Db;

public interface IShowsDbRepository
{
    Task<IEnumerable<Show>> GetAllShowsAsync(); 
    Task<Show?> GetShowByIdAsync(string id);
    Task<IEnumerable<Show>> GetShowsByTitle(string title);
    Task<IEnumerable<Show>> GetShowsByGenre(string genre);
    Task<Show> AddShowAsync(Show show);
    Task<Show> AddMultipleShowsAsync(IEnumerable<Show> shows);
    Task UpdateShowAsync(Show show);
    Task<string> DeleteShowAsync(string id); 
}