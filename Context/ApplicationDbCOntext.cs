using FirstWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;


namespace FirstWebAppMVC.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Student> Students { get; set; }
}