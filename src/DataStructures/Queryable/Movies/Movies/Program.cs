﻿using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Movies.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMediator( options: options => options.ServiceLifetime = ServiceLifetime.Scoped);
builder.Services.AddDbContext<MovieDbContext>( options => options.UseSqlite(builder.Configuration.GetConnectionString("MovieDb")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

public partial class Program { }