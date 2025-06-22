using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Boilerplate.Core.FileSystem
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class TempDirectory : IDisposable
    {
        public TempDirectory()
        {
            Directory.CreateDirectory(Name);
        }

        public string Name { get; } = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("D"));

        public IEnumerable<string> EnumerateFiles(string? searchPattern = null) =>
            Directory.EnumerateFiles(Name, searchPattern ?? "*", SearchOption.AllDirectories);

        public string[] GetFiles(string? searchPattern = null) =>
            Directory.GetFiles(Name, searchPattern ?? "*", SearchOption.AllDirectories);

        public void Dispose()
        {
            if (Directory.Exists(Name))
                Directory.Delete(Name, true);
        }
    }
}
