using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using ConferencePlanner.GraphQL;
using ConferencePlanner.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddPooledDbContextFactory<ApplicationDbContext>(
        options => options.UseSqlite("Data Source=conferences.db")
    );

builder
    .Services
    .AddGraphQLServer()
    .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<SpeakerType>()
    .AddDataLoader<SpeakerByIdDataLoader>()
    .AddDataLoader<SessionByIdDataLoader>()
    .ModifyRequestOptions(options => options.IncludeExceptionDetails = true);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

app.Run();
