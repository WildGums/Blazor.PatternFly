﻿namespace Blorc.PatternFly.Components.Pagination
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class Pagination : BlorcComponentBase
    {
        public Pagination()
        {
            CreateConverter()
                .Fixed("pf-c-pagination")
                .If(() => IsCompact, "pf-m-compact")
                .Watch(() => IsCompact)
                .Update(() => Class);

            CreateConverter()
                .Fixed("pf-c-options-menu")
                .If(() => IsOptionsExpanded, "pf-m-expanded")
                .Watch(() => IsOptionsExpanded)
                .Update(() => OptionsClass);

            CreateConverter()
                .Fixed("pf-c-options-menu__toggle pf-m-plain pf-m-text")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsDisabled)
                .Update(() => OptionsToogleClass);

            IsOptionsExpanded = false;
            IsCompact = false;
            IsDisabled = false;
        }

        public string Class
        {
            get;
            set;
        }

        public int CurrentPage
        {
            get
            {
                return PageIndex + 1;
            }

            set
            {
                PageIndex = value - 1;
            }
        }

        [Parameter]
        public bool IsCompact
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsCompact));
            }

            set
            {
                SetPropertyValue(nameof(IsCompact), value);
            }
        }

        [Parameter]
        public bool IsDisabled
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsDisabled));
            }

            set
            {
                SetPropertyValue(nameof(IsDisabled), value);
            }
        }

        public bool IsOptionsExpanded
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsOptionsExpanded));
            }

            set
            {
                SetPropertyValue(nameof(IsOptionsExpanded), value);
            }
        }

        [Parameter]
        public int ItemsCount
        {
            get
            {
                return GetPropertyValue<int>(nameof(ItemsCount));
            }

            set
            {
                SetPropertyValue(nameof(ItemsCount), value);
            }
        }

        [Parameter]
        public int ItemsPerPage
        {
            get
            {
                return GetPropertyValue<int>(nameof(ItemsPerPage));
            }

            set
            {
                SetPropertyValue(nameof(ItemsPerPage), value);
            }
        }

        [Parameter]
        public IEnumerable<int> ItemsPerPageOptions
        {
            get
            {
                return GetPropertyValue<IEnumerable<int>>(nameof(ItemsPerPageOptions));
            }

            set
            {
                SetPropertyValue(nameof(ItemsPerPageOptions), value);
            }
        }

        [Parameter]
        public EventHandler<PaginationStateChangedEventArgs> OnStateChanged { get; set; }

        public string OptionsClass
        {
            get;
            set;
        }

        public string OptionsToogleClass
        {
            get;
            set;
        }

        public int PageFirstItemIndex
        {
            get { return PageIndex * ItemsPerPage; }
        }

        [Parameter]
        public int PageIndex
        {
            get
            {
                return GetPropertyValue<int>(nameof(PageIndex));
            }

            set
            {
                SetPropertyValue(nameof(PageIndex), value);
            }
        }

        public int PageLastItemIndex
        {
            get { return (PageIndex + 1) * ItemsPerPage - 1; }
        }

        public int PagesCount
        {
            get
            {
                return (ItemsCount - 1) / ItemsPerPage + 1;
            }
        }

        public PaginationVariant Variant
        {
            get
            {
                return GetPropertyValue<PaginationVariant>(nameof(Variant));
            }

            set
            {
                SetPropertyValue(nameof(Variant), value);
            }
        }

        protected string GetOptionClass(int option)
        {
            return IsOptionSelected(option) ? "pf-m-selected pf-c-options-menu__menu-item" : "pf-c-options-menu__menu-item";
        }

        protected bool IsOptionSelected(int option)
        {
            return option == ItemsPerPage;
        }

        protected void OnFirstPageButtonPressed()
        {
            PageIndex = 0;
        }

        protected void OnLastPageButtonPressed()
        {
            PageIndex = PagesCount - 1;
        }

        protected void OnNextPageButtonPressed()
        {
            PageIndex++;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (ItemsPerPageOptions is not null && ItemsPerPageOptions.Any())
            {
                var itemsPerPage = ItemsPerPageOptions.First();
                if (ItemsPerPage == 0)
                {
                    ItemsPerPage = itemsPerPage;
                    PageIndex = 0;
                }
            }
        }

        protected void OnPrevPageButtonPressed()
        {
            PageIndex--;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsOptionsExpanded) && IsOptionsExpanded)
            {
                StateHasChanged();
            }
            else if (e.PropertyName == nameof(PageIndex))
            {
                RaisePaginationStateChanged(new PaginationStateChangedEventArgs(PageIndex, PageFirstItemIndex, ItemsPerPage));
                StateHasChanged();
            }
        }

        protected virtual void RaisePaginationStateChanged(PaginationStateChangedEventArgs e)
        {
            OnStateChanged?.Invoke(this, e);
        }

        protected void SetItemsPerPage(int option)
        {
            ItemsPerPage = option;
            IsOptionsExpanded = false;
            if (PageIndex != 0)
            {
                PageIndex = 0;
            }
            else
            {
                RaisePaginationStateChanged(new PaginationStateChangedEventArgs(PageIndex, PageFirstItemIndex, ItemsPerPage));
                StateHasChanged();
            }
        }
    }
}
