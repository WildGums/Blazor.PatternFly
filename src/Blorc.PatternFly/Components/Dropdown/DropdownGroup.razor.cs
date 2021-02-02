﻿namespace Blorc.PatternFly.Components.Dropdown
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class DropdownGroup : BlorcComponentBase
    {
        public DropdownGroup()
        {
        }

        [Parameter]
        public string Label
        {
            get { return GetPropertyValue<string>(nameof(Label)); }
            set { SetPropertyValue(nameof(Label), value); }
        }

        [Parameter]
        public string Key
        {
            get { return GetPropertyValue<string>(nameof(Key)); }
            set { SetPropertyValue(nameof(Key), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
