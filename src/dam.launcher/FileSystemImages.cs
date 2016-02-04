using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace org.starorigin.dam.launcher
{
    public class FileSystemImages
    {
        private static BitmapImage fileImage;
        public static BitmapImage FileImage
        { get { if (fileImage == null) fileImage = LoadImage("File"); return fileImage; } }
        private static BitmapImage diskImage;
        public static BitmapImage DiskImage
        { get { if (diskImage == null) diskImage = LoadImage("Local_Disk"); return diskImage; } }
        private static BitmapImage closedFolderImage;
        public static BitmapImage ClosedFolderImage
        {
            get
            {
                if (closedFolderImage == null) closedFolderImage = LoadImage("Folder_Closed");
                return closedFolderImage;
            }
        }
        private static BitmapImage openedFolderImage;
        public static BitmapImage OpenedFolderImage
        {
            get
            {
                if (openedFolderImage == null)
                    openedFolderImage = LoadImage("Folder_Opened");
                return openedFolderImage;
            }
        }
        private static BitmapImage LoadImage(string imageName)
        {
            return new BitmapImage(new Uri("/images/" + imageName + ".png", UriKind.Relative));
        }
    }
}
