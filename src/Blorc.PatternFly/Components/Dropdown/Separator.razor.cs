﻿namespace Blorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public partial class Separator : BlorcComponentBase
    {
        public Separator()
        {
            Component = "div";

            CreateConverter()
                .Fixed("pf-c-dropdown__separator")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsDisabled)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Key
        {
            get { return GetPropertyValue<string>(nameof(Key)); }
            set { SetPropertyValue(nameof(Key), value); }
        }

        [Parameter]
        public string Component
        {
            get { return GetPropertyValue<string>(nameof(Component)); }
            set { SetPropertyValue(nameof(Component), value); }
        }

        [Parameter]
        public bool IsDisabled
        {
            get { return GetPropertyValue<bool>(nameof(IsDisabled)); }
            set { SetPropertyValue(nameof(IsDisabled), value); }
        }

        [Parameter]
        public bool IsHovered
        {
            get { return GetPropertyValue<bool>(nameof(IsHovered)); }
            set { SetPropertyValue(nameof(IsHovered), value); }
        }

        [Parameter]
        public string Href
        {
            get { return GetPropertyValue<string>(nameof(Href)); }
            set { SetPropertyValue(nameof(Href), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected RenderFragment CustomRender;

        private RenderFragment CreateComponent() => builder =>
        {
            builder.OpenElement(0, Component);

            builder.AddAttribute(1, "role", "separator");
            builder.AddAttribute(2, "class", Class);

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(3, "href", Href);
            }

            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();

            CustomRender = CreateComponent();
        }
    }
}
