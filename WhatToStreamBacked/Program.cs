using WhatToStreamBacked.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpClient to be consumed by the actual API Service
builder.Services.AddHttpClient<IStreamingAvailabilityService, StreamingAvailabilityService>(client => {
    client.BaseAddress = new Uri("https://streaming-availability.p.rapidapi.com/");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "streaming-availability.p.rapidapi.com");
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "key"); // TODO: add key
});

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