using Microsoft.EntityFrameworkCore;

namespace WhatToStreamBackend.Models;

public class ShowsDbContext : DbContext
{
    public virtual DbSet<Show> Shows { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Genre> ShowGenres { get; set; }
    public virtual DbSet<ShowImageSet> ShowImageSets { get; set; }
    public virtual DbSet<VerticalImage> VerticalImages { get; set; }
    public virtual DbSet<HorizontalImage> HorizontalImages { get; set; }
    public virtual DbSet<StreamingOption> StreamingOptions { get; set; }
    public virtual DbSet<ServiceImageSet> ServiceImageSets { get; set; }
    public virtual DbSet<ServiceInfo> ServiceInfos { get; set; }
    
    public ShowsDbContext(DbContextOptions<ShowsDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure composite primary key for MovieGenre
        modelBuilder.Entity<ShowGenre>()
            .HasKey(mg => new { mg.ShowId, mg.GenreId });

        // Configure relationships
        modelBuilder.Entity<ShowGenre>()
            .HasOne(mg => mg.Show)
            .WithMany(m => m.ShowGenres)
            .HasForeignKey(mg => mg.ShowId);

        modelBuilder.Entity<ShowGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.ShowGenres)
            .HasForeignKey(mg => mg.GenreId);
        
        // Seed data
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = "action", Name = "Action"},
            new Genre { Id = "adventure", Name = "Adventure" },
            new Genre { Id = "animation", Name = "Animation" },
            new Genre { Id = "comedy", Name = "Comedy" },
            new Genre { Id = "crime", Name = "Crime" },
            new Genre { Id = "documentary", Name = "Documentary" },
            new Genre { Id = "drama", Name = "Drama" },
            new Genre { Id = "family", Name = "Family" },
            new Genre { Id = "fantasy", Name = "Fantasy" },
            new Genre { Id = "history", Name = "History" },
            new Genre { Id = "horror", Name = "Horror" },
            new Genre { Id = "music", Name = "Music" },
            new Genre { Id = "mystery", Name = "Mystery" },
            new Genre { Id = "news", Name = "News" },
            new Genre { Id = "reality", Name = "Reality" },
            new Genre { Id = "romance", Name = "Romance" },
            new Genre { Id = "scifi", Name = "Science Fiction" },
            new Genre { Id = "talk", Name = "Talk Show" },
            new Genre { Id = "thriller", Name = "Thriller" },
            new Genre { Id = "war", Name = "War" },
            new Genre { Id = "western", Name = "Western" }
        );
        
        modelBuilder.Entity<Show>().HasData(
            new Show
            {
                Id = "66",
                ItemType = "show",
                ShowType = "movie",
                ImdbId = "tt0111161",
                TmdbId = "movie/278",
                Title = "The Shawshank Redemption",
                Overview = "Red (Morgan Freeman) and Andy (Tim Robbins), both incarcerated at Shawshank prison, forge an unlikely bond that will span more than twenty years. Together they discover hope as the ultimate means of survival, in a poignant tale of the human spirit.",
                ReleaseYear = 1994,
                FirstAirYear = null,
                LastAirYear = null,
                OriginalTitle = "The Shawshank Redemption",
                Rating = 90,
                Minimum = null,
                Maximum = null,
                SeasonCount = null,
                EpisodeCount = null,
                ImageSet = null,
                StreamingOptions = null
            }
        );

        modelBuilder.Entity<ShowGenre>().HasData(
            new ShowGenre { GenreId = "drama", ShowId = "66" }
        );
    }
}