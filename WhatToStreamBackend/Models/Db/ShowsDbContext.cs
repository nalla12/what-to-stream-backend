using Microsoft.EntityFrameworkCore;

namespace WhatToStreamBackend.Models.Db;

public class ShowsDbContext : DbContext
{
    public virtual DbSet<Show> Shows { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<ShowGenre> ShowGenres { get; set; }
    public virtual DbSet<ShowImageSet> ShowImageSets { get; set; }
    public virtual DbSet<VerticalImage> VerticalImages { get; set; }
    public virtual DbSet<HorizontalImage> HorizontalImages { get; set; }
    public virtual DbSet<ServiceImageSet> ServiceImageSets { get; set; }
    public virtual DbSet<StreamingOption> StreamingOptions { get; set; }
    public virtual DbSet<ServiceInfo> ServiceInfos { get; set; }
    public virtual DbSet<Country> Countries { get; set; }
    
    public ShowsDbContext(DbContextOptions<ShowsDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure composite primary key for ShowGenre
        modelBuilder.Entity<ShowGenre>()
            .HasKey(sg => new { sg.ShowId, sg.GenreId });

        // Configure relationships
        modelBuilder.Entity<ShowGenre>()
            .HasOne(sg => sg.Show)
            .WithMany(s => s.ShowGenres)
            .HasForeignKey(sg => sg.ShowId);

        modelBuilder.Entity<ShowGenre>()
            .HasOne(sg => sg.Genre)
            .WithMany(g => g.ShowGenres)
            .HasForeignKey(sg => sg.GenreId);
        
        // Configure composite primary key for StreamingOption
        modelBuilder.Entity<StreamingOption>()
            .HasKey(so => new { so.ShowId, so.ServiceId, so.CountryCode });

        // Configure relationships
        modelBuilder.Entity<StreamingOption>()
            .HasOne(so => so.Show)
            .WithMany(m => m.StreamingOptions)
            .HasForeignKey(so => so.ShowId);

        modelBuilder.Entity<StreamingOption>()
            .HasOne(so => so.StreamingService)
            .WithMany(g => g.StreamingOptions)
            .HasForeignKey(so => so.ServiceId);
        
        modelBuilder.Entity<StreamingOption>()
            .HasOne(so => so.Country)
            .WithMany(g => g.StreamingOptions)
            .HasForeignKey(so => so.CountryCode);
        
        // Seed data
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
                SeasonCount = null,
                EpisodeCount = null,
                ImageSet = null,
            },
            new Show
            {
                Id = "968",
                ItemType = "show",
                ShowType = "series",
                ImdbId = "tt14169960",
                TmdbId = "tv/99966",
                Title = "All of Us Are Dead",
                Overview = "A high school becomes ground zero for a zombie virus outbreak. Trapped students must fight their way out — or turn into one of the rabid infected.",
                FirstAirYear = 2022,
                LastAirYear = 2022,
                OriginalTitle = "지금 우리 학교는",
                Rating = 76,
                SeasonCount = 2,
                EpisodeCount = 12,
                ImageSet = null,
            }
        );
        
        modelBuilder.Entity<ShowGenre>().HasData(
            new ShowGenre { GenreId = "drama", ShowId = "66" },
            new ShowGenre { GenreId = "drama", ShowId = "968" },
            new ShowGenre { GenreId = "action", ShowId = "968" },
            new ShowGenre { GenreId = "fantasy", ShowId = "968" }
        );
        
        modelBuilder.Entity<StreamingOption>().HasData(
            new StreamingOption { ShowId = "66", CountryCode = "dk", ServiceId = "netflix"},
            new StreamingOption { ShowId = "66", CountryCode = "us", ServiceId = "netflix"},
            new StreamingOption { ShowId = "66", CountryCode = "us", ServiceId = "disney"},
            new StreamingOption { ShowId = "968", CountryCode = "dk", ServiceId = "netflix", Link = "https://www.netflix.com/title/81237994/", ExpiresSoon = false, AvailableSince = 1693809875},
            new StreamingOption { ShowId = "968", CountryCode = "us", ServiceId = "netflix", Link = "https://www.netflix.com/title/81237994/", ExpiresSoon = true, AvailableSince = 1648576144}
        );
        
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

        modelBuilder.Entity<Country>().HasData(
            new Country { CountryCode = "dk", Name = "Denmark"},
            new Country { CountryCode = "gb", Name = "United Kingdom"},
            new Country { CountryCode = "us", Name = "United States"},
            new Country { CountryCode = "jp", Name = "Japan"},
            new Country { CountryCode = "kr", Name = "South Korea"},
            new Country { CountryCode = "se", Name = "Sweden"}
        );
        
        modelBuilder.Entity<ServiceInfo>().HasData(
            new ServiceInfo
            {
                Id = "apple", 
                Name = "Apple TV", 
                HomePage = "https://tv.apple.com", 
                ThemeColorCode = "#000000"
            },
            new ServiceInfo
            {
                Id = "netflix", 
                Name = "Netflix", 
                HomePage = "https://netflix.com", 
                ThemeColorCode = "#E50914"
            },
            new ServiceInfo
            {
                Id = "prime", 
                Name = "Prime Video", 
                HomePage = "https://www.primevideo.com/", 
                ThemeColorCode = "#00A8E1"
            },
            new ServiceInfo
            {
                Id = "disney", 
                Name = "Disney+", 
                HomePage = "https://www.disneyplus.com/", 
                ThemeColorCode = "#01137c"
            }
        );
    }
}