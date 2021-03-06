﻿namespace Blorc.PatternFly.Components.Table
{
    using System.ComponentModel;

    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public partial class Row : BlorcComponentBase
    {
        private const string DefaultHighlightStyle = "border-left: 3px solid var(--pf-global--primary-color--100);";
        public string Style
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(HighlightStyle))
                {
                    return HighlightStyle;
                }

                if (!IsHighlighted)
                {
                    return string.Empty;
                }

                return !string.IsNullOrWhiteSpace(ContainerTable?.CustomHighlightStyle) ? ContainerTable?.CustomHighlightStyle : DefaultHighlightStyle;
            }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

        [CascadingParameter]
        public Table ContainerTable { get; set; }

        [Parameter]
        public string HighlightStyle
        {
            get
            {
                return GetPropertyValue<string>(nameof(HighlightStyle));
            }

            set
            {
                SetPropertyValue(nameof(HighlightStyle), value);
            }
        }


        [Parameter]
        public bool IsHighlighted
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsHighlighted));
            }

            set
            {
                SetPropertyValue(nameof(IsHighlighted), value);
            }
        }

        [Parameter]
        public object Record { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (ContainerTable is not null)
            {
                if (ContainerTable.HighlightPredicate is not null && Record is not null)
                {
                    IsHighlighted = ContainerTable.HighlightPredicate(Record);
                }

                if (ContainerTable.HighlightStyleFunc is not null && Record is not null)
                {
                    HighlightStyle = ContainerTable.HighlightStyleFunc(Record);
                }

                StateHasChanged();
            }

            if (Record is INotifyPropertyChanged propertyChanged)
            {
                propertyChanged.PropertyChanged += OnPropertyChangedOnPropertyChanged;
            }
        }


        private void OnPropertyChangedOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (ContainerTable.IsSortedBy(args.PropertyName))
            {
                if (Record is INotifyPropertyChanged propertyChanged)
                {
                    propertyChanged.PropertyChanged -= OnPropertyChangedOnPropertyChanged;
                }

                ContainerTable.Refresh();
            }
            else
            {
                StateHasChanged();
            }
        }
    }
}
