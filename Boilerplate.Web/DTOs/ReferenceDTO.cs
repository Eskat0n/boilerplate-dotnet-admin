using System.Diagnostics.CodeAnalysis;
using Boilerplate.Core.Traits;

namespace Boilerplate.Web.DTOs
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ReferenceDTO
    {
        public static ReferenceDTO<TId> Create<TId>(IReferencable<TId> entity) =>
            new() { Id = entity.Id, Name = entity.GetName() };

        public static ReferenceDTO<TId>? From<TId>(IReferencable<TId>? entity) =>
            entity != null ? Create(entity) : null;
    }
}