﻿// Type: Newtonsoft.Json.DefaultValueHandling
// Assembly: Newtonsoft.Json, Version=4.5.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: DB013E7B-84E7-4AE6-A132-56DC73318C48
// Assembly location: F:\Program Files (x86)\FEZ\Newtonsoft.Json.dll

using System;

namespace Newtonsoft.Json
{
  [Flags]
  public enum DefaultValueHandling
  {
    Include = 0,
    Ignore = 1,
    Populate = 2,
    IgnoreAndPopulate = Populate | Ignore,
  }
}
