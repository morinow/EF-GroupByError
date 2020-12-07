namespace SampleApp.Database
{
  using System;

  public class EntityTag
  {
    public Guid EntityId { get; set; }
    public Entity Entity { get; set; }
    public string Tag { get; set; }
  }
}