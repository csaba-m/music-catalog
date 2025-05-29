namespace MusicCatalog;

public class SongRequest
{
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public int DurationSeconds { get; set; }
    public string? ISRC { get; set; }
}