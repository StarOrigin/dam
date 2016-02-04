using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.launcher
{
    public class FileSystemHelper : FileSystemDataProviderBase
    {
        public override string[] GetLogicalDrives()
        {
            return Directory.GetLogicalDrives();
        }
        public override string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
        public override string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
        public override string GetDirectoryName(string path)
        {
            return new DirectoryInfo(path).Name;
        }
        public override string GetFileName(string path)
        {
            return new FileInfo(path).Name;
        }
        public override string GetFileSize(string path)
        {
            long size = new FileInfo(path).Length;
            return GetFileSize(size);
        }
    }
}
