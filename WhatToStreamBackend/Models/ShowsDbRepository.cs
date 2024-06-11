using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WhatToStreamBackend.Models;

public class ShowsDbRepository : IShowsDbRepository
{
    private readonly ShowsDbContext _db;

    public ShowsDbRepository(ShowsDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Show>> GetAllShowsAsync()
    {
        // TODO: LINQ join show, genre, and streamingOptions tables
        return await _db.Shows
            .Include(s => s.ShowGenres)
            .ThenInclude(sg => sg.Genre)
            .ToListAsync();
    }

    public async Task<Show?> GetShowByIdAsync(string id)
    {
        return await _db.Shows
            .Include(s => s.ShowGenres)
            .ThenInclude(sg => sg.Genre)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Show>> GetShowsByTitle(string title)
    {
        return await _db.Shows
            .Include(s => s.ShowGenres)
            .ThenInclude(sg => sg.Genre)
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