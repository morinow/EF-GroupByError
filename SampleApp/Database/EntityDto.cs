﻿namespace SampleApp.Database
{
  using System;
  using System.Collections.Generic;

  public class EntityDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<string> Tags { get; set; }
  }
}