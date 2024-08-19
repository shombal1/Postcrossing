using Microsoft.AspNetCore.HttpOverrides;
using Postcrossing.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configure = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStorage(configure.GetConnectionString("DataBase")!);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();

