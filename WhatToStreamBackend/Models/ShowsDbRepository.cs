namespace WhatToStreamBackend.Models;

public class ShowsDbRepository : IShowsDbRepository
{
    private readonly ShowsDbContext _db;

    public ShowsDbRepository(ShowsDbContext db)
    {
        _db = db;
    }
    
    public List<Show> GetAllShows()
    {
        // TODO: LINQ join show, genre, and streamingOptions tables
        return _db.Shows.ToList();
    }

    public Show? GetShowById(string id)
    {
        return _db.Shows.Find(id);
    }

    public Show? GetShowByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Show CreateShow(Show newShow)
    {
        _db.Shows.Add(newShow);
        _db.SaveChanges();
        return newShow;
    }

    public void UpdateShow(Show updatedShow)
    {
        Show? showInDb = _db.Shows.Find(updatedShow.Id);

        if (showInDb != null)
        {
            showInDb.Title = updatedShow.Title;
            _db.Shows.Update(showInDb);
            _db.SaveChanges();
        }
        
        /*
         _context.Entry(show).State = EntityState.Modified;

           try
           {
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!ShowExists(id))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }

           return NoContent();
         * 
         */
    }

    public void DeleteShow(Show showToDelete)
    {
        _db.Shows.Remove(showToDelete);
        _db.SaveChanges();
    }
}