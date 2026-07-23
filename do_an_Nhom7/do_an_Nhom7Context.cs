using Microsoft.EntityFrameworkCore;

public class do_an_Nhom7Context(DbContextOptions<do_an_Nhom7Context> options) : DbContext(options)
{
    public DbSet<do_an_Nhom7.Models.Student> Student { get; set; } = default!;
}
