using System;

namespace Boilerplate.Core.Traits
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        // DateTime? DeletedAt { get; set; }
    }
}
