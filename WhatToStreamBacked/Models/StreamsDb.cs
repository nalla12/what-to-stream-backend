using Microsoft.EntityFrameworkCore;

namespace WhatToStreamBacked.Models;

public class StreamsDb : DbContext
{
    public StreamsDb(DbContextOptions<StreamsDb> options) : base(options) {}
    
    public virtual DbSet<Show> Shows { get; set; }
}