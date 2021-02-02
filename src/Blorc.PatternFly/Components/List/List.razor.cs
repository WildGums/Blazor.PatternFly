﻿namespace Blorc.PatternFly.Components.List
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class List : BlorcComponentBase
    {
        public List()
        {

        }

        public string Class
        {
            get
            {
                var items = new List<string>();

                switch (Variant)
                {
                    case ListVariant.Simple:
                        break;

                    case ListVariant.Inline:
                        items.Add("pf-m-inline");
                        break;

                    case ListVariant.Grid:
                        break;
                }


                return string.Join(" ", items);
            }
        }

        [Parameter]
        public ListVariant Variant { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
