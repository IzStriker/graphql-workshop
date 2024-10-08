using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.Data;

public class Track
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string? Name { get; set; }

    public ICollection<Session> Sessions { get; set; } = [];
}
