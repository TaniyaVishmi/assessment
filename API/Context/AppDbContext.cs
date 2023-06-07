using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectManagementApp.API.Models;

namespace API.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    }


    public DbSet<User> Users { get; set; }
    public DbSet<Projects> Projects { get; set; }

    public DbSet<TaskManage> TaskManage { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().ToTable("users");
      modelBuilder.Entity<Projects>().ToTable("Projects");
      modelBuilder.Entity<TaskManage>().ToTable("Taskmanage");
    }

   
    

  
   
  

   //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   //  {
   //     optionsBuilder.UseSqlServer("Data Source=.;initial Catalog=projects; TrustServerCertificate=true;");
   //  }
    }
}
