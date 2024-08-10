using ConferencePlanner;
using ConferencePlanner.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDbContext<ApplicationDbContext>(
        options => options.UseSqlite("Data Source=conferences.db")
    );

builder
    .Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

app.Run();
