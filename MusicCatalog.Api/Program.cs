using MusicCatalog.Domain.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MusicCatalogDbContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<MusicCatalogDbContext>();
    dbcontext.Database.EnsureCreated();
}

app.MapControllers();

app.Run();