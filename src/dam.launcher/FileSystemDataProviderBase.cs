using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.launcher
{
    public abstract class FileSystemDataProviderBase
    {
        public abstract string[] GetLogicalDrives();
        public abstract string[] GetDirectories(string path);
        public abstract string[] GetFiles(string path);
        public abstract string GetDirectoryName(string path);
        public abstract string GetFileName(string path);
        public abstract string GetFileSize(string path);
        internal string GetFileSize(long size)
        {
            if (size >= 1024)
                return string.Format("{0:### ### ###} KB", size / 1024);
            return string.Format("{0} Bytes", size);
        }
    }
}
