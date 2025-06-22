using System;

namespace Boilerplate.Core.Traits
{
    public interface IUpdatable
    {
        DateTime UpdatedAt { get; set; }
    }
}
