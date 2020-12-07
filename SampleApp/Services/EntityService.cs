namespace SampleApp.Services
{
  using System.Linq;
  using SampleApp.Database;

  public class EntityService : IEntityService
  {
    private readonly SampleDbContext context;

    public EntityService(SampleDbContext context)
    {
      this.context = context;
    }

    public IQueryable<EntityDto> GetEntities(bool withTags = true)
    {
      if (withTags)
      {
        return this.context.Entities
                   .Select(e => new EntityDto
                   {
                     Id = e.Id,
                     Name = e.Name,
                     Tags = e.Tags.Select(t => t.Tag)
                   });
      }
      else
      {
        return this.context.Entities
                   .Select(e => new EntityDto
                   {
                     Id = e.Id,
                     Name = e.Name
                   });
      }
    }
  }
}