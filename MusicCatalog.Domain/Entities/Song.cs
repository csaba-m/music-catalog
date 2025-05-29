namespace MusicCatalog.Domain.Entities;

public class Song
{
    public int SongId { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    
    public string Title { get; set; }
    
    public int DurationSeconds { get; set; }
    public string? ISRC { get; set; }
}