namespace SampleApp.Database
{
  using System;
  using Microsoft.EntityFrameworkCore;

  public class SampleDbContext : DbContext
  {
    public SampleDbContext(DbContextOptions<SampleDbContext> options)
      : base(options)
    {
    }

    public virtual DbSet<Entity> Entities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Entity>(entity =>
      {
        entity.HasKey(e => e.Id);
        entity.HasIndex(e => e.Name);
        entity.ToTable("Entities");

        entity.HasData(new Entity
                       {
                         Id = new Guid("6b1af7ea-da35-42d4-b4ad-cfa7e22f853d"),
                         Name = "Entity1"
                       },
                       new Entity
                       {
                         Id = new Guid("6c83c7ab-1475-4e93-b3e2-38124c9d74f9"),
                         Name = "Entity2"
                       },
                       new Entity
                       {
                         Id = new Guid("1233abb0-ba31-4ac7-80ea-14d6328543ad"),
                         Name = "Entity3"
                       });
      });

      modelBuilder.Entity<EntityTag>(entity =>
      {
        entity.HasKey(e => new {e.EntityId, e.Tag});
        entity.HasOne(e => e.Entity).WithMany(e => e.Tags).HasForeignKey(e => e.EntityId);
        entity.ToTable("EntityTags");

        entity.HasData(new EntityTag
                       {
                         EntityId = new Guid("6b1af7ea-da35-42d4-b4ad-cfa7e22f853d"),
                         Tag = "Tag1"
                       },
                       new EntityTag
                       {
                         EntityId = new Guid("6b1af7ea-da35-42d4-b4ad-cfa7e22f853d"),
                         Tag = "Tag2"
                       }, new EntityTag
                       {
                         EntityId = new Guid("6c83c7ab-1475-4e93-b3e2-38124c9d74f9"),
                         Tag = "Tag1"
                       },
                       new EntityTag
                       {
                         EntityId = new Guid("6c83c7ab-1475-4e93-b3e2-38124c9d74f9"),
                         Tag = "Tag2"
                       }, new EntityTag
                       {
                         EntityId = new Guid("1233abb0-ba31-4ac7-80ea-14d6328543ad"),
                         Tag = "Tag1"
                       },
                       new EntityTag
                       {
                         EntityId = new Guid("1233abb0-ba31-4ac7-80ea-14d6328543ad"),
                         Tag = "Tag2"
                       });
      });
    }
  }
}