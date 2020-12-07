namespace SampleApp.Services
{
  using System.Linq;
  using SampleApp.Database;

  public interface IEntityService
  {
    IQueryable<EntityDto> GetEntities(bool withTags = true);
  }
}