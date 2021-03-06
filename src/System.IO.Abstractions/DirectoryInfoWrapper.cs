﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.AccessControl;

namespace System.IO.Abstractions
{
    [Serializable]
    public class DirectoryInfoWrapper : DirectoryInfoBase
    {
        private readonly DirectoryInfo instance;

        public DirectoryInfoWrapper(IFileSystem fileSystem, DirectoryInfo instance) : base(fileSystem)
        {
            this.instance = instance ?? throw new ArgumentNullException(nameof(instance));
        }

        public override void Delete()
        {
            instance.Delete();
        }

        public override void Refresh()
        {
            instance.Refresh();
        }

        public override FileAttributes Attributes
        {
            get { return instance.Attributes; }
            set { instance.Attributes = value; }
        }

        public override DateTime CreationTime
        {
            get { return instance.CreationTime; }
            set { instance.CreationTime = value; }
        }

        public override DateTime CreationTimeUtc
        {
            get { return instance.CreationTimeUtc; }
            set { instance.CreationTimeUtc = value; }
        }

        public override bool Exists
        {
            get { return instance.Exists; }
        }

        public override string Extension
        {
            get { return instance.Extension; }
        }

        public override string FullName
        {
            get { return instance.FullName; }
        }

        public override DateTime LastAccessTime
        {
            get { return instance.LastAccessTime; }
            set { instance.LastAccessTime = value; }
        }

        public override DateTime LastAccessTimeUtc
        {
            get { return instance.LastAccessTimeUtc; }
            set { instance.LastAccessTimeUtc = value; }
        }

        public override DateTime LastWriteTime
        {
            get { return instance.LastWriteTime; }
            set { instance.LastWriteTime = value; }
        }

        public override DateTime LastWriteTimeUtc
        {
            get { return instance.LastWriteTimeUtc; }
            set { instance.LastWriteTimeUtc = value; }
        }

        public override string Name
        {
            get { return instance.Name; }
        }

        public override void Create()
        {
            instance.Create();
        }

        [SupportedOSPlatform("windows")]
        public override void Create(DirectorySecurity directorySecurity)
        {
            instance.Create(directorySecurity);
        }

        public override IDirectoryInfo CreateSubdirectory(string path)
        {
            return new DirectoryInfoWrapper(FileSystem, instance.CreateSubdirectory(path));
        }

        public override void Delete(bool recursive)
        {
            instance.Delete(recursive);
        }

        public override IEnumerable<IDirectoryInfo> EnumerateDirectories()
        {
            return instance.EnumerateDirectories().Select(directoryInfo => new DirectoryInfoWrapper(FileSystem, directoryInfo));
        }

        public override IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern)
        {
            return instance.EnumerateDirectories(searchPattern).Select(directoryInfo => new DirectoryInfoWrapper(FileSystem, directoryInfo));
        }

        public override IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            return instance.EnumerateDirectories(searchPattern, searchOption).Select(directoryInfo => new DirectoryInfoWrapper(FileSystem, directoryInfo));
        }

#if FEATURE_ENUMERATION_OPTIONS
        public override IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return instance.EnumerateDirectories(searchPattern, enumerationOptions).Select(directoryInfo => new DirectoryInfoWrapper(FileSystem, directoryInfo));
        }
#endif

        public override IEnumerable<IFileInfo> EnumerateFiles()
        {
            return instance.EnumerateFiles().Select(fileInfo => new FileInfoWrapper(FileSystem, fileInfo));
        }

        public override IEnumerable<IFileInfo> EnumerateFiles(string searchPattern)
        {
            return instance.EnumerateFiles(searchPattern).Select(fileInfo => new FileInfoWrapper(FileSystem, fileInfo));
        }

        public override IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            return instance.EnumerateFiles(searchPattern, searchOption).Select(fileInfo => new FileInfoWrapper(FileSystem, fileInfo));
        }

#if FEATURE_ENUMERATION_OPTIONS
        public override IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return instance.EnumerateFiles(searchPattern, enumerationOptions).Select(fileInfo => new FileInfoWrapper(FileSystem, fileInfo));
        }
#endif

        public override IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos()
        {
            return instance.EnumerateFileSystemInfos().WrapFileSystemInfos(FileSystem);
        }

        public override IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern)
        {
            return instance.EnumerateFileSystemInfos(searchPattern).WrapFileSystemInfos(FileSystem);
        }

        public override IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            return instance.EnumerateFileSystemInfos(searchPattern, searchOption).WrapFileSystemInfos(FileSystem);
        }

#if FEATURE_ENUMERATION_OPTIONS
        public override IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return instance.EnumerateFileSystemInfos(searchPattern, enumerationOptions).WrapFileSystemInfos(FileSystem);
        }
#endif

        [SupportedOSPlatform("windows")]
        public override DirectorySecurity GetAccessControl()
        {
            return instance.GetAccessControl();
        }

        [SupportedOSPlatform("windows")]
        public override DirectorySecurity GetAccessControl(AccessControlSections includeSections)
        {
            return instance.GetAccessControl(includeSections);
        }

        public override IDirectoryInfo[] GetDirectories()
        {
            return instance.GetDirectories().WrapDirectories(FileSystem);
        }

        public override IDirectoryInfo[] GetDirectories(string searchPattern)
        {
            return instance.GetDirectories(searchPattern).WrapDirectories(FileSystem);
        }

        public override IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption)
        {
            return instance.GetDirectories(searchPattern, searchOption).WrapDirectories(FileSystem);
        }

#if FEATURE_ENUMERATION_OPTIONS
        public override IDirectoryInfo[] GetDirectories(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return instance.GetDirectories(searchPattern, enumerationOptions).WrapDirectories(FileSystem);
        }
#endif

        public override IFileInfo[] GetFiles()
        {
            return instance.GetFiles().WrapFiles(FileSystem);
        }

        public override IFileInfo[] GetFiles(string searchPattern)
        {
            return instance.GetFiles(searchPattern).WrapFiles(FileSystem);
        }

        public override IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            return instance.GetFiles(searchPattern, searchOption).WrapFiles(FileSystem);
        }

#if FEATURE_ENUMERATION_OPTIONS
        public override IFileInfo[] GetFiles(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return instance.GetFiles(searchPattern, enumerationOptions).WrapFiles(FileSystem);
        }
#endif

        public override IFileSystemInfo[] GetFileSystemInfos()
        {
            return instance.GetFileSystemInfos().WrapFileSystemInfos(FileSystem);
        }

        public override IFileSystemInfo[] GetFileSystemInfos(string searchPattern)
        {
            return instance.GetFileSystemInfos(searchPattern).WrapFileSystemInfos(FileSystem);
        }

        public override IFileSystemInfo[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            return instance.GetFileSystemInfos(searchPattern, searchOption).WrapFileSystemInfos(FileSystem);
        }

#if FEATURE_ENUMERATION_OPTIONS
        public override IFileSystemInfo[] GetFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions)
        {
            return instance.GetFileSystemInfos(searchPattern, enumerationOptions).WrapFileSystemInfos(FileSystem);
        }
#endif

        public override void MoveTo(string destDirName)
        {
            instance.MoveTo(destDirName);
        }

        [SupportedOSPlatform("windows")]
        public override void SetAccessControl(DirectorySecurity directorySecurity)
        {
            instance.SetAccessControl(directorySecurity);
        }

        public override IDirectoryInfo Parent
        {
            get
            {
                if (instance.Parent == null)
                {
                    return null;
                }
                else
                {
                    return new DirectoryInfoWrapper(FileSystem, instance.Parent);
                }
            }
        }

        public override IDirectoryInfo Root
        {
            get { return new DirectoryInfoWrapper(FileSystem, instance.Root); }
        }

        public override string ToString()
        {
            return instance.ToString();
        }
    }
}
