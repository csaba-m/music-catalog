namespace MusicCatalog.Domain.Entities;

public class Artist
{
    public int ArtistId { get; set; }
    public int LabelId { get; set; }
    public Label Label { get; set; }
    public string Name { get; set; }
}