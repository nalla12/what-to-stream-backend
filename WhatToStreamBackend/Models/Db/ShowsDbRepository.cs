using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace WhatToStreamBackend.Models.Db;

public class ShowsDbRepository : IShowsDbRepository
{
    private readonly ShowsDbContext _db;
    private readonly IIncludableQueryable<Show, ServiceInfo> _completeShows;

    public ShowsDbRepository(ShowsDbContext db)
    {
        _db = db;
        _completeShows = _db.Shows
            .Include(s => s.ShowGenres)
                .ThenInclude(sg => sg.Genre)
            .Include(s => s.StreamingOptions)
                .ThenInclude(so => so.StreamingService);
    }

    public async Task<IEnumerable<Show>> GetAllShowsAsync()
    {
        return await _completeShows.ToListAsync();
    }

    public async Task<Show?> GetShowByIdAsync(string id)
    {
        return await _completeShows.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Show>> GetShowsByTitle(string title)
    {
        return await _completeShows
            .Where(s => s.Title == title)
            .ToListAsync();
    }

    public async Task<IEnumerable<Show>> GetShowsByGenre(string genre)
    {
        return await _db.Shows
            .Include(s => s.ShowGenres)
                .ThenInclude(sg => sg.Genre)
            .Where(s => s.ShowGenres.Any(sg => sg.Genre.Name == genre))
            .ToListAsync();
    }

    public async Task<Show> CreateShowAsync(Show show)
    {
        _db.Shows.Add(show);
        await _db.SaveChangesAsync();
        return show;
    }

    // TODO: make it possible to update only the supplied properties and not make them null
    public async Task UpdateShowAsync(Show show)
    {
        _db.Entry(show).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteShowAsync(string id)
    {
        var show = await _db.Shows.FindAsync(id);
        if (show != null)
        {
            _db.Shows.Remove(show);
            await _db.SaveChangesAsync();
        }
    }
}