using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WhatToStreamBackend.Models.Db;

namespace WhatToStreamBackend.Repositories;

public class ShowsDbRepository : IShowsDbRepository
{
    private readonly ShowsDbContext _db;
    private readonly IIncludableQueryable<Show, ServiceDetails> _completeShows;

    public ShowsDbRepository(ShowsDbContext db)
    {
        _db = db;
        _completeShows = _db.Shows
            .Include(s => s.ShowGenres)
                .ThenInclude(sg => sg.Genre)
            .Include(s => s.StreamingOptions)
                .ThenInclude(so => so.ServiceDetails);
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
    
    public async Task<List<Show>> AddMultipleShowsAsync(IEnumerable<Show> shows)
    {
        // TODO: handle if the shows already exist in the database
        _db.Shows.AddRange(shows);
        await _db.SaveChangesAsync();
        // TODO: only return the added shows
        return await _completeShows.ToListAsync();
    }
    
    public async Task<ServiceDetails> AddMultipleServicesAsync(List<ServiceDetails> serviceDetails)
    {
        _db.ServiceDetails.AddRange(serviceDetails);
        await _db.SaveChangesAsync();
        return _db.ServiceDetails.First();
    }
    
    public async Task<Country> AddMultipleCountriesAsync(List<Country> countries)
    {
        _db.Countries.AddRange(countries);
        await _db.SaveChangesAsync();
        return _db.Countries.First();
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
    
    public async Task<string> DeleteAllShowsAsync()
    {
        // Retrieve the show including related entities
        var shows = await _db.Shows
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
            .ToListAsync();

        foreach (var show in shows)
        {
            _db.ShowGenres.RemoveRange(show.ShowGenres);
            _db.StreamingOptions.RemoveRange(show.StreamingOptions);

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

        }
        
        // Finally remove all shows
        _db.Shows.RemoveRange(shows);

        await _db.SaveChangesAsync();
        
        return $"All shows deleted successfully";
    }
}