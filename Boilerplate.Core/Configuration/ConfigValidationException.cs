using System;

namespace Boilerplate.Core.Configuration
{
    public class ConfigValidationException : Exception
    {
        public ConfigValidationException(string name)
            : base($"Environment variable {name} is required")
        {
        }
    }
}