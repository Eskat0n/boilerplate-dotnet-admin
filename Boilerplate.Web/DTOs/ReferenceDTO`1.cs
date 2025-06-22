using System.Diagnostics.CodeAnalysis;

namespace Boilerplate.Web.DTOs
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ReferenceDTO<T>
    {
        public ReferenceDTO()
        {
        }

        public ReferenceDTO(T id, string name)
        {
            Id = id;
            Name = name;
        }

        public T Id { get; set; } = default!;
        public string Name { get; set; } = null!;
    }
}
