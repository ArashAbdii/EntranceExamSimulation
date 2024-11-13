using System.ComponentModel.DataAnnotations;


namespace EntranceExamSimulation.Models;


public class Queston
{
    [Key]
    public int Question_id { get; set; }
    [Required]
    public string? Question { get; set; } = null;
    [Required]
    public string? Answer1 { get; set; } = null;
    [Required]
    public string? Answer2 { get; set; } = null;
    [Required]
    public string? Answer3 { get; set; } = null;
    [Required]
    public string? Answer4 { get; set; } = null;
    public int CorrectAnswer { get; set; }
}
