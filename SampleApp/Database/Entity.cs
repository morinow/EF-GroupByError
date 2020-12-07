namespace SampleApp.Database
{
  using System;
  using System.Collections.Generic;

  public class Entity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<EntityTag> Tags { get; set; }
  }
}