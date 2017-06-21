using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartSMS.Web.Entities;

namespace SmartSMS.Web.Data
{
  public class SmartSmsContext : DbContext
  {
    private readonly IConfigurationRoot _config;
    private readonly IHostingEnvironment _env;

    public SmartSmsContext(DbContextOptions options, IConfigurationRoot config, IHostingEnvironment env) : base(options)
    {
      _config = config;
      _env = env;
    }

    public DbSet<Class> Classes { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<MessageDefinition> MessageDefinitions { get; set; }
    public DbSet<Sms> Smses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentMessage> StudentMessages { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Level>().HasMany(e=>e.Grades).WithOne(e=>e.Level).HasForeignKey(e=>e.LevelId).OnDelete(DeleteBehavior.Cascade);
      modelBuilder.Entity<Grade>().HasMany(e=>e.Classes).WithOne(e=>e.Grade).HasForeignKey(e=>e.GradeId).OnDelete(DeleteBehavior.Cascade);
      modelBuilder.Entity<Class>().HasMany(e=>e.Students).WithOne(e=>e.Class).HasForeignKey(e=>e.ClassId).OnDelete(DeleteBehavior.Cascade);
      modelBuilder.Entity<Student>().HasMany(e=>e.Messages).WithOne(e=>e.Student).HasForeignKey(e=>e.StudentId).OnDelete(DeleteBehavior.Cascade);
      modelBuilder.Entity<Student>().HasOne(e=>e.StudentInfo);
      modelBuilder.Entity<MessageDefinition>().HasMany(e=>e.Students).WithOne(e=>e.MessageDefinition).HasForeignKey(e=>e.MessageDefinitionId).OnDelete(DeleteBehavior.Cascade);
      modelBuilder.Entity<StudentMessage>().HasMany(e=>e.Smses).WithOne(e=>e.StudentMessage).HasForeignKey(e=>e.StudentMessageId).OnDelete(DeleteBehavior.SetNull);

      foreach (var entityType in modelBuilder.Model.GetEntityTypes())
      {
        modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn");
        modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
        modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
      }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlite(_config["ConnectionStrings:DbDefaultConnectionString"]);

      if (_env.IsDevelopment()) optionsBuilder.EnableSensitiveDataLogging(true);
    }

    public override int SaveChanges()
    {
      foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
      {
        if(!entry.IsKeySet) entry.Property("CreatedOn").CurrentValue = DateTime.Now;
        entry.Property("LastModified").CurrentValue = DateTime.Now;
      }
      return base.SaveChanges();
    }

  }
}
