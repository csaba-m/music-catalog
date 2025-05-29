using Microsoft.EntityFrameworkCore;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Domain.Persistance;

public class MusicCatalogDbContext : DbContext
{
    public DbSet<Label> Labels { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    
    public MusicCatalogDbContext(DbContextOptions<MusicCatalogDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=MusicCatalog.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Label>(b =>
        {
            b.HasKey(x => x.LabelId);
            
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            b.HasData(
                new Label { LabelId = 1, Name = "Universal Music Group" },
                new Label { LabelId = 2, Name = "Sony Music Entertainment" },
                new Label { LabelId = 3, Name = "Warner Music Group" },
                new Label { LabelId = 4, Name = "EMI Records" },
                new Label { LabelId = 5, Name = "Atlantic Records" }
                );

        });
        
        modelBuilder.Entity<Artist>(b =>
        {
            b.HasKey(x => x.ArtistId);
            
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            b.HasOne(x => x.Label)
                .WithOne()
                .HasForeignKey<Label>(x => x.LabelId);
            
            b.HasData(
                new Artist { ArtistId = 1, Name = "The Beatles", LabelId = 1 },
                new Artist { ArtistId = 2, Name = "Taylor Swift", LabelId = 2 },
                new Artist { ArtistId = 3, Name = "Ed Sheeran", LabelId = 3 },
                new Artist { ArtistId = 4, Name = "Adele", LabelId = 4 },
                new Artist { ArtistId = 5, Name = "Billie Eilish", LabelId = 5 },
                new Artist { ArtistId = 6, Name = "Drake", LabelId = 1 },
                new Artist { ArtistId = 7, Name = "Beyoncé", LabelId = 2 },
                new Artist { ArtistId = 8, Name = "Kendrick Lamar", LabelId = 3 },
                new Artist { ArtistId = 9, Name = "Lady Gaga", LabelId = 4 },
                new Artist { ArtistId = 10, Name = "Bruno Mars", LabelId = 5 }
                );

        });
        
        modelBuilder.Entity<Song>(b =>
        {
            b.HasKey(x => x.SongId);
            
            b.HasOne(x => x.Artist)
                .WithMany()
                .HasForeignKey(x => x.ArtistId);
            
            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);
            
            b.Property(x => x.ISRC)
                .IsRequired(false)
                .HasMaxLength(12);
            
            b.HasData(
                new Song { SongId = 1, Title = "Hey Jude", ArtistId = 1, DurationSeconds = 258, ISRC = "GBAYE0900001" },
                new Song { SongId = 2, Title = "Shake It Off", ArtistId = 2, DurationSeconds = 198, ISRC = "USUM71400001" },
                new Song { SongId = 3, Title = "Shape of You", ArtistId = 3, DurationSeconds = 314, ISRC = "GBUM71600001" },
                new Song { SongId = 4, Title = "Someone Like You", ArtistId = 4, DurationSeconds = 147, ISRC = "GBAYE1100001" },
                new Song { SongId = 5, Title = "Bad Guy", ArtistId = 5, DurationSeconds = 266, ISRC = "USUM71800001" },
                new Song { SongId = 6, Title = "God's Plan", ArtistId = 6, DurationSeconds = 225, ISRC = "USUM71700001" },
                new Song { SongId = 7, Title = "Formation", ArtistId = 7, DurationSeconds = 132, ISRC = "USUM71900001" },
                new Song { SongId = 8, Title = "HUMBLE.", ArtistId = 8, DurationSeconds = 111, ISRC = "USUM71900001" },
                new Song { SongId = 9, Title = "Poker Face", ArtistId = 9, DurationSeconds = 426, ISRC = "USUM71900001" },
                new Song { SongId = 10, Title = "Uptown Funk", ArtistId = 10, DurationSeconds = 231, ISRC = "USUM71500001" },
                new Song { SongId = 11, Title = "Let It Be", ArtistId = 1, DurationSeconds = 421, ISRC = "USUM71500001" },
                new Song { SongId = 12, Title = "Blank Space", ArtistId = 2, DurationSeconds = 120, ISRC = "USUM71500002" },
                new Song { SongId = 13, Title = "Castle on the Hill", ArtistId = 3, DurationSeconds = 240, ISRC = "GBUM71600002" }
            );

        });
    }
}