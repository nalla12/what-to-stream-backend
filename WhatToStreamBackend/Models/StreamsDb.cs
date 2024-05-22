using Microsoft.EntityFrameworkCore;

namespace WhatToStreamBackend.Models;

public class StreamsDb : DbContext
{
    public StreamsDb(DbContextOptions<StreamsDb> options) : base(options) {}
    
    public virtual DbSet<Show> Shows { get; set; }
}