using System.ComponentModel.DataAnnotations;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ReleaseDate { get; set; }
    public float? Rate { get; set; }
}