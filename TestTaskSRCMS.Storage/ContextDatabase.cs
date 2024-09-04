using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.Core.Models;

namespace TestTaskSRCMS.Storage;

public class ContextDatabase : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Office> Office { get; set; }

    public ContextDatabase(DbContextOptions<ContextDatabase> options)
       : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Administrator admin = new Administrator { Id = 1};
        //modelBuilder.Entity<Administrator>().HasData(new Administrator[] { admin });
        //base.OnModelCreating(modelBuilder);
    }
}
