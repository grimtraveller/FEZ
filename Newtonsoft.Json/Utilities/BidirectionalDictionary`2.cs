﻿// Type: Newtonsoft.Json.Utilities.BidirectionalDictionary`2
// Assembly: Newtonsoft.Json, Version=4.5.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
// MVID: DB013E7B-84E7-4AE6-A132-56DC73318C48
// Assembly location: F:\Program Files (x86)\FEZ\Newtonsoft.Json.dll

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Newtonsoft.Json.Utilities
{
  internal class BidirectionalDictionary<TFirst, TSecond>
  {
    private readonly IDictionary<TFirst, TSecond> _firstToSecond;
    private readonly IDictionary<TSecond, TFirst> _secondToFirst;
    private readonly string _duplicateFirstErrorMessage;
    private readonly string _duplicateSecondErrorMessage;

    public BidirectionalDictionary()
      : this((IEqualityComparer<TFirst>) EqualityComparer<TFirst>.Default, (IEqualityComparer<TSecond>) EqualityComparer<TSecond>.Default)
    {
    }

    public BidirectionalDictionary(IEqualityComparer<TFirst> firstEqualityComparer, IEqualityComparer<TSecond> secondEqualityComparer)
      : this(firstEqualityComparer, secondEqualityComparer, "Duplicate item already exists for '{0}'.", "Duplicate item already exists for '{0}'.")
    {
    }

    public BidirectionalDictionary(IEqualityComparer<TFirst> firstEqualityComparer, IEqualityComparer<TSecond> secondEqualityComparer, string duplicateFirstErrorMessage, string duplicateSecondErrorMessage)
    {
      this._firstToSecond = (IDictionary<TFirst, TSecond>) new Dictionary<TFirst, TSecond>(firstEqualityComparer);
      this._secondToFirst = (IDictionary<TSecond, TFirst>) new Dictionary<TSecond, TFirst>(secondEqualityComparer);
      this._duplicateFirstErrorMessage = duplicateFirstErrorMessage;
      this._duplicateSecondErrorMessage = duplicateSecondErrorMessage;
    }

    public void Set(TFirst first, TSecond second)
    {
      TSecond second1;
      if (this._firstToSecond.TryGetValue(first, out second1) && !second1.Equals((object) second))
        throw new ArgumentException(StringUtils.FormatWith(this._duplicateFirstErrorMessage, (IFormatProvider) CultureInfo.InvariantCulture, (object) first));
      TFirst first1;
      if (this._secondToFirst.TryGetValue(second, out first1) && !first1.Equals((object) first))
        throw new ArgumentException(StringUtils.FormatWith(this._duplicateSecondErrorMessage, (IFormatProvider) CultureInfo.InvariantCulture, (object) second));
      this._firstToSecond.Add(first, second);
      this._secondToFirst.Add(second, first);
    }

    public bool TryGetByFirst(TFirst first, out TSecond second)
    {
      return this._firstToSecond.TryGetValue(first, out second);
    }

    public bool TryGetBySecond(TSecond second, out TFirst first)
    {
      return this._secondToFirst.TryGetValue(second, out first);
    }
  }
}
