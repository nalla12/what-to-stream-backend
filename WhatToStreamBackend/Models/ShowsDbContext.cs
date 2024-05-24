using Microsoft.EntityFrameworkCore;

namespace WhatToStreamBackend.Models;

public class ShowsDbContext : DbContext
{
    public ShowsDbContext(DbContextOptions<ShowsDbContext> options) : base(options) {}
    
    public virtual DbSet<Show> Shows { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<ShowImageSet> ShowImageSets { get; set; }
    public virtual DbSet<VerticalImage> VerticalImages { get; set; }
    public virtual DbSet<HorizontalImage> HorizontalImages { get; set; }
    public virtual DbSet<StreamingOption> StreamingOptions { get; set; }
    public virtual DbSet<ServiceImageSet> ServiceImageSets { get; set; }
    public virtual DbSet<ServiceInfo> ServiceInfos { get; set; }
    
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Show>().HasData(
            new Show { CID = 1, Name = "Mark Marksen", City = "Aalborg", Phone = 74562819, Email = "asdf@email.com"},
            new Show { CID = 2, Name = "Freja Frejsen", City = "Esbjerg", Phone = 74579819}
        );
        modelBuilder.Entity<Genre>().HasData(
            new Genre { PID = 1, Name = "Gule Handsker", Price = 50},
            new Genre { PID = 2, Name = "Laptop", Price = 5000}
        );
        modelBuilder.Entity<Order>().HasData(
            new Order { OID = 1, CID = 1, PID = 1, Quantity = 2, OrderDate = DateTime.Now }
        );
    }*/
}