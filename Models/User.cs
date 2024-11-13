
using System.ComponentModel.DataAnnotations;

namespace EntranceExamSimulation.Models;

public class Teacher
{
    [Key]
    public int User_id { get; set; }
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public string Course_category { get; set; } = string.Empty;
    [Required]
    public bool? isTeacher { get; set; } = true;
}


public class Student
{
    [Key]
    public int User_id { get; set; }
    [Required]
    public string FullName { get; set; } = string.Empty;
}