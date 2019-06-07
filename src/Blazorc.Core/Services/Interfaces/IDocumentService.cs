﻿namespace Blazorc.Services
{
    using System.Threading.Tasks;
    using Blazorc.Dom.Injectors;
    using Interop;

    public interface IDocumentService
    {
        Task<Rect> GetBoundingClientRectById(string id);

        Task<Rect> GetOffsetBoundingClientRect(long x, long y);

        Task<Rect> GetBoundingClientRect(long x, long y);

        void InjectHead(IInjectorValueProvider injectorValueProvider);
    }
}
