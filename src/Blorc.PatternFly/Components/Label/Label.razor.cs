﻿namespace Blorc.PatternFly.Components.Label
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Label : BlorcComponentBase
    {
        public Label()
        {

        }

        public string Class
        {
            get
            {
                var value = string.Empty;

                if (IsCompact)
                {
                    value += "pf-m-compact";
                }

                return value;
            }
        }

        [Parameter]
        public bool IsCompact { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
