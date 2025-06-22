using System;

namespace Boilerplate.Core.Configuration
{
    public abstract class ConfigBase
    {
        protected static string GetRequired(string name) =>
            Environment.GetEnvironmentVariable(name) ?? throw new ConfigValidationException(name);

        protected static string? GetOptional(string name) =>
            Environment.GetEnvironmentVariable(name);
    }
}