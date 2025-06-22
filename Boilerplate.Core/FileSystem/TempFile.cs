using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Boilerplate.Core.FileSystem
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class TempFile : IDisposable
    {
        public TempFile()
            : this(".tmp")
        {
        }

        public TempFile(string extension)
        {
            Name = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Guid.NewGuid().ToString("D"), extension));
        }

        public string Name { get; }

        public long Length => Info.Length;

        public FileInfo Info => new(Name);

        public void Dispose()
        {
            if (File.Exists(Name))
                File.Delete(Name);
        }
    }
}