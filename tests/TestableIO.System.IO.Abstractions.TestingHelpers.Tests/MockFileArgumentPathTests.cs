﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32.SafeHandles;
using NUnit.Framework;

namespace System.IO.Abstractions.TestingHelpers.Tests;

public class MockFileArgumentPathTests
{
    private static IEnumerable<Action<IFile>> GetFileSystemActionsForArgumentNullException()
    {
        yield return fs => fs.AppendAllLines(null, new[] { "does not matter" });
        yield return fs => fs.AppendAllLines(null, new[] { "does not matter" }, Encoding.ASCII);
        yield return fs => fs.AppendAllText(null, "does not matter");
        yield return fs => fs.AppendAllText(null, "does not matter", Encoding.ASCII);
        yield return fs => fs.AppendText(null);
        yield return fs => fs.WriteAllBytes(null, new byte[] { 0 });
        yield return fs => fs.WriteAllLines(null, new[] { "does not matter" });
        yield return fs => fs.WriteAllLines(null, new[] { "does not matter" }, Encoding.ASCII);
        yield return fs => fs.WriteAllLines(null, new[] { "does not matter" }.ToArray());
        yield return fs => fs.WriteAllLines(null, new[] { "does not matter" }.ToArray(), Encoding.ASCII);
        yield return fs => fs.Create(null);
        yield return fs => fs.Delete(null);
        yield return fs => fs.GetCreationTime((string)null);
        yield return fs => fs.GetCreationTimeUtc((string)null);
        yield return fs => fs.GetLastAccessTime((string)null);
        yield return fs => fs.GetLastAccessTimeUtc((string)null);
        yield return fs => fs.GetLastWriteTime((string)null);
        yield return fs => fs.GetLastWriteTimeUtc((string)null);
        yield return fs => fs.WriteAllText(null, "does not matter");
        yield return fs => fs.WriteAllText(null, "does not matter", Encoding.ASCII);
        yield return fs => fs.Open(null, FileMode.OpenOrCreate);
        yield return fs => fs.Open(null, FileMode.OpenOrCreate, FileAccess.Read);
        yield return fs => fs.Open(null, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Inheritable);
        yield return fs => fs.OpenRead(null);
        yield return fs => fs.OpenText(null);
        yield return fs => fs.OpenWrite(null);
        yield return fs => fs.ReadAllBytes(null);
        yield return fs => fs.ReadAllLines(null);
        yield return fs => fs.ReadAllLines(null, Encoding.ASCII);
        yield return fs => fs.ReadAllText(null);
        yield return fs => fs.ReadAllText(null, Encoding.ASCII);
        yield return fs => fs.ReadLines(null);
        yield return fs => fs.ReadLines(null, Encoding.ASCII);
        yield return fs => fs.SetAttributes((string)null, FileAttributes.Archive);
        yield return fs => fs.GetAttributes((string)null);
        yield return fs => fs.SetCreationTime((string)null, DateTime.Now);
        yield return fs => fs.SetCreationTimeUtc((string)null, DateTime.Now);
        yield return fs => fs.SetLastAccessTime((string)null, DateTime.Now);
        yield return fs => fs.SetLastAccessTimeUtc((string)null, DateTime.Now);
        yield return fs => fs.SetLastWriteTime((string)null, DateTime.Now);
        yield return fs => fs.SetLastWriteTimeUtc((string)null, DateTime.Now);
#pragma warning disable CA1416
        yield return fs => fs.Decrypt(null);
        yield return fs => fs.Encrypt(null);
#pragma warning restore CA1416
    }

    [TestCaseSource(nameof(GetFileSystemActionsForArgumentNullException))]
    public async Task Operations_ShouldThrowArgumentNullExceptionIfPathIsNull(Action<IFile> action)
    {
        // Arrange
        var fileSystem = new MockFileSystem();

        // Act
        Action wrapped = () => action(fileSystem.File);

        // Assert
        var exception = await That(wrapped).Throws<ArgumentNullException>();
        await That(exception.ParamName).IsEqualTo("path");
    }
}