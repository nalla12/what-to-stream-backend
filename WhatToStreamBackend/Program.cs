using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WhatToStreamBackend.Models;
using WhatToStreamBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(
    options => {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
    }
);

builder.Services.AddDbContext<ShowsDbContext>(
opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ShowsDb"))
);

builder.Services.AddScoped<IShowsDbRepository, ShowsDbRepository>();

// HttpClient to be consumed by the actual API Service
builder.Services.AddHttpClient<IStreamingAvailabilityService, StreamingAvailabilityService>(client => {
    client.BaseAddress = new Uri("https://streaming-availability.p.rapidapi.com/");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "streaming-availability.p.rapidapi.com");
    // TODO: add key to appsettings
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "d93a557296mshb9ca7af3a795686p19a102jsn52e4cd558573"); 
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();