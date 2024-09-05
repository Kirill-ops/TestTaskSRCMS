using Microsoft.EntityFrameworkCore;
using TestTaskSRCMS.Core.Models;
using TestTaskSRCMS.Storage.Entities;

namespace TestTaskSRCMS.Storage;

public class ContextDatabase : DbContext
{
    public DbSet<EntityDoctor> Doctors { get; set; }
    public DbSet<EntityPatient> Patients { get; set; }
    public DbSet<EntitySpecialization> Specializations { get; set; }
    public DbSet<EntityDistrict> Districts { get; set; }
    public DbSet<EntityOffice> Offices { get; set; }

    public ContextDatabase(DbContextOptions<ContextDatabase> options)
       : base(options)
    {
        Database.EnsureCreated();
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<EntityDistrict>().HasData([new(Guid.NewGuid(), 0)]);
    //    base.OnModelCreating(modelBuilder);
    //}
}
