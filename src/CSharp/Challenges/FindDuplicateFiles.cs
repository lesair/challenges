using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Adds the minimum number of parentheses in any position to make it a balanced bracket sequence.
    ///     Source: Interview Cake
    ///     https://www.interviewcake.com/question/csharp/find-duplicate-files
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/find-duplicate-file-in-system/
    /// </summary>
    public static class FindDuplicateFiles
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(n), where n is the number of files scanned, not the files size.
        ///     Space complexity: O(n).
        /// </summary>
        public static IEnumerable<FilePaths> GetDuplicates(string path)
        {
            var hashSet = new HashSet<FileNode>();
            var directoriesQueue = new Queue<string>();
            while (directoriesQueue.Any() || !string.IsNullOrEmpty(path))
            {
                var fileEntries = new string[0];
                try
                {
                    fileEntries = Directory.GetFiles(path);
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine($"Warning: does not have permission to open path: \"{path}\". {e.Message}");
                }

                foreach (var fileEntry in fileEntries)
                {
                    FileNode fileNode = null;
                    try
                    {
                        fileNode = new FileNode(fileEntry);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Debug.WriteLine(
                            $"Warning: does not have permission to open file: \"{fileEntry}\". {e.Message}");
                    }
                    catch (IOException e)
                    {
                        Debug.WriteLine($"Warning: could not open file: \"{fileEntry}\". {e.Message}");
                    }

                    if (fileNode == null)
                        continue;

                    if (hashSet.Contains(fileNode))
                    {
                        string duplicatePath;
                        string originalPath;
                        hashSet.TryGetValue(fileNode, out var previousFileNode);
                        if (fileNode.FileInfo.CreationTime > previousFileNode.FileInfo.CreationTime)
                        {
                            duplicatePath = fileNode.FileInfo.FullName;
                            originalPath = previousFileNode.FileInfo.FullName;
                        }
                        else
                        {
                            originalPath = fileNode.FileInfo.FullName;
                            duplicatePath = previousFileNode.FileInfo.FullName;
                        }

                        yield return new FilePaths(duplicatePath, originalPath);
                    }
                    else
                    {
                        hashSet.Add(fileNode);
                    }
                }

                var directoryEntries = new string[0];
                try
                {
                    directoryEntries = Directory.GetDirectories(path);
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine($"Warning: does not have permission to open path: \"{path}\". {e.Message}");
                }

                foreach (var directoryEntry in directoryEntries) directoriesQueue.Enqueue(directoryEntry);

                if (!directoriesQueue.TryDequeue(out path))
                    path = string.Empty;
            }
        }
    }

    public class FilePaths
    {
        public FilePaths(string duplicatePath, string originalPath)
        {
            DuplicatePath = duplicatePath;
            OriginalPath = originalPath;
        }

        public string DuplicatePath { get; }

        public string OriginalPath { get; }

        public override string ToString()
        {
            return $"(original: {OriginalPath}, duplicate: {DuplicatePath})";
        }
    }

    public class FileNode : IEquatable<FileNode>
    {
        private readonly int _hashCode;

        public FileNode(string filePath)
        {
            byte[] bytes;
            FileInfo = new FileInfo(filePath);

            using var fileStream = new FileStream(FileInfo.FullName, FileMode.Open, FileAccess.Read);

            if (FileInfo.Length < ByteSampleLength)
            {
                bytes = new byte[FileInfo.Length];
                fileStream.Read(bytes, 0, (int) FileInfo.Length);
            }
            else
            {
                bytes = new byte[ByteSampleLength];
                var fragmentLength = ByteSampleLength / 3;
                fileStream.Read(bytes, 0, fragmentLength);
                fileStream.Seek((int) FileInfo.Length / 2 - fragmentLength / 2, SeekOrigin.Begin);
                fileStream.Read(bytes, fragmentLength, fragmentLength);
                fileStream.Seek(-fragmentLength, SeekOrigin.End);
                fileStream.Read(bytes, fragmentLength * 2, fragmentLength);
            }

            using var cryptoServiceProvider = new MD5CryptoServiceProvider();
            _hashCode = BitConverter.ToInt32(cryptoServiceProvider.ComputeHash(bytes));
        }

        private static int ByteSampleLength => 200;

        public FileInfo FileInfo { get; set; }

        public bool Equals(FileNode other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return FileInfo.Length == other.FileInfo.Length && _hashCode == other._hashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((FileNode) obj);
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }

        public static bool operator ==(FileNode left, FileNode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FileNode left, FileNode right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{FileInfo.Name} | {GetHashCode()} | {FileInfo.CreationTime}";
        }
    }
}