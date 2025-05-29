namespace MusicCatalog;

public class SongResponse
{
    public int SongId { get; set; }
    public string Title { get; set; }
    public string ArtistName { get; set; }
    public string LabelName { get; set; }
    public int DurationSeconds { get; set; }
    public string? ISRC { get; set; }
}