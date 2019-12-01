﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnDefinition.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Table
{
    using System;

    public class ColumnDefinition
    {
        public string Label { get; set; }
        public string Key { get; set; }
        public int Idx { get; set; }

        public Predicate<object> FilterPredicate { get; set; }
    }
}
