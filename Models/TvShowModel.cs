using System.ComponentModel.DataAnnotations;
namespace TvShows.Models;
public class TvshowModel 
{
    // Properties
    [Required(ErrorMessage = "Ange en titel, max 50 tecken")]
    [MaxLength(50)]
    public required string Title { get; set; }
    [Required]
    public required string Genre { get; set; }
    [Required]
    public required int Rating { get; set; }
    [Required(ErrorMessage = "Ange en kommentar, max 150 tecken")]
    [MaxLength(150)]
    public required string Review { get; set; }

}