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

    public async Task<Show> AddShowAsync(Show show)
    {
        _db.Shows.Add(show);
        await _db.SaveChangesAsync();
        return show;
    }
    
    public async Task<Show> AddMultipleShowsAsync(IEnumerable<Show> shows)
    {
        _db.Shows.AddRange(shows);
        await _db.SaveChangesAsync();
        return shows.First();
    }

    public async Task CreateOrUpdateShowAsync(Show show)
    {
        var existingShow = await _db.Shows.FindAsync(show.Id);
        if (existingShow == null)
        {
            _db.Shows.Add(show);
        }
        else
        {
            _db.Entry(existingShow).CurrentValues.SetValues(show);
        }
        await _db.SaveChangesAsync();
    }
    
    // TODO: make it possible to update only the supplied properties and not make them null
    public async Task UpdateShowAsync(Show show)
    {
        _db.Entry(show).State = EntityState.Modified;
        await _db.SaveChangesAsync();
    }

    public async Task<string> DeleteShowAsync(string id)
    {
        // Retrieve the show including related entities
        var show = await _db.Shows
            .Include(s => s.ShowGenres)
            .Include(s => s.StreamingOptions)
            .Include(s => s.ImageSet)
            .ThenInclude(i => i.VerticalPoster)
            .Include(s => s.ImageSet)
            .ThenInclude(i => i.HorizontalPoster)
            .Include(s => s.ImageSet)
            .ThenInclude(i => i.VerticalBackdrop)
            .Include(s => s.ImageSet)
            .ThenInclude(i => i.HorizontalBackdrop)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (show != null)
        {
            // Delete all genre associations for the show
            _db.ShowGenres.RemoveRange(show.ShowGenres);

            // Delete all streaming options associations for the show
            _db.StreamingOptions.RemoveRange(show.StreamingOptions);

            // If the show has an associated ImageSet, delete it along with its images
            if (show.ImageSet != null)
            {
                if (show.ImageSet.VerticalPoster != null)
                    _db.VerticalImages.Remove(show.ImageSet.VerticalPoster);
                if (show.ImageSet.HorizontalPoster != null)
                    _db.HorizontalImages.Remove(show.ImageSet.HorizontalPoster);
                if (show.ImageSet.VerticalBackdrop != null)
                    _db.VerticalImages.Remove(show.ImageSet.VerticalBackdrop);
                if (show.ImageSet.HorizontalBackdrop != null)
                    _db.HorizontalImages.Remove(show.ImageSet.HorizontalBackdrop);

                _db.ShowImageSets.Remove(show.ImageSet);
            }

            // Remove the show itself
            _db.Shows.Remove(show);

            await _db.SaveChangesAsync();
            
            return $"Show {id} deleted successfully";
        }

        return "Not found";
    }
}