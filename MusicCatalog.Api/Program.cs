using MusicCatalog.Domain.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MusicCatalogDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var dbcontext = app.Services.GetRequiredService<MusicCatalogDbContext>();
dbcontext.Database.EnsureCreated();

app.MapControllers();

app.Run();