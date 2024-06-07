namespace WhatToStreamBackend.Models;

public class ShowsDbRepository : IShowsDbRepository
{
    private readonly ShowsDbContext _db;
    
    public List<Show> GetAllShows()
    {
        throw new NotImplementedException();
    }

    public Show? GetShowById(string id)
    {
        throw new NotImplementedException();
    }

    public Show? GetShowByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Show CreateShow(Show newShow)
    {
        throw new NotImplementedException();
    }

    public Show UpdateShow(Show updatedShow)
    {
        throw new NotImplementedException();
    }

    public void DeleteShow(Show poorShow)
    {
        throw new NotImplementedException();
    }
}