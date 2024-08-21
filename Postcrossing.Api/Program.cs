using Microsoft.AspNetCore.HttpOverrides;
using Postcrossing.Api.Middleware;
using Postcrossing.Domain.DependencyInjection;
using Postcrossing.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configure = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddPostcrossingDomain()
    .AddStorage(configure.GetConnectionString("DataBase")!);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandingMiddleware>();

app.MapControllers();
app.Run();

