namespace WhatToStreamBackend.Models;

public interface IShowsDbRepository
{
    List<Show> GetAllShows(); // Get 
    Show? GetShowById(string id); // Get
    Show? GetShowByTitle(string title); // Get
    Show CreateShow(Show newShow); // Post
    void UpdateShow(Show updatedShow); // Put or Patch
    void DeleteShow(Show poorShow); // Delete 
}