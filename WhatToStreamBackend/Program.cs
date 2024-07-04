using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WhatToStreamBackend.Models.Db;
using WhatToStreamBackend.Repositories;
using WhatToStreamBackend.Services;

var builder = WebApplication.CreateBuilder(args);
string? baseUrl = builder.Configuration["StreamingAvailabilityAPI:BaseUrl"];
string? authHeaderName = builder.Configuration["StreamingAvailabilityAPI:AuthHeaderName"];
string? apiKey = builder.Configuration["StreamingAvailabilityAPI:ApiKey"];

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson
(
    options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    }
);

builder.Services.AddDbContext<ShowsDbContext>
(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ShowsDb"))
);

builder.Services.AddScoped<IShowsDbRepository, ShowsDbRepository>();

// HttpClient to be consumed by the API Service
builder.Services.AddHttpClient<IStreamingAvailabilityService, StreamingAvailabilityService>
(
    client => 
    {
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Add(authHeaderName, apiKey);
    }
);

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