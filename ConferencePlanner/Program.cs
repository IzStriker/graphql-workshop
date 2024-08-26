using ConferencePlanner.Data;
using ConferencePlanner.DataLoader;
using ConferencePlanner.Mutations;
using ConferencePlanner.Queries;
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
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<SpeakerQueries>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<SpeakerMutations>()
    .AddType<AttendeeType>()
    .AddType<SessionType>()
    .AddType<SpeakerType>()
    .AddType<TrackType>()
    .AddGlobalObjectIdentification() // instead of add relay support
    .AddDataLoader<SpeakerByIdDataLoader>()
    .AddDataLoader<SessionByIdDataLoader>()
    .ModifyRequestOptions(options => options.IncludeExceptionDetails = true);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

app.Run();
