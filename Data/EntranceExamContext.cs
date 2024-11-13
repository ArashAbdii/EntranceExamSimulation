using EntranceExamSimulation.Models;

using Microsoft.EntityFrameworkCore;

namespace EntranceExamSimulation.Data;

public class EntranceExamContext : DbContext
{
    public DbSet<Queston> Questions { get; set; } = null!;
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=entranceExam;Integrated Security=True;MultipleActiveResultSets=True");
    }
}