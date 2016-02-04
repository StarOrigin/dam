using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.core.model.file
{
    public class FileBase
    {
        public virtual string Name
        { get; set; }
        public virtual string CreateTime
        { get; set; }
        public virtual string UpdateTime
        { get; set; }
        public virtual Directory Parent
        { get; set; }
        public virtual string Path
        {
            get { return Parent.Path + System.IO.Path.DirectorySeparatorChar + Name; }
        }




        public string ItemType
        {
            get
            {
                if (this is Partition) return "Drive";
                if (this is Directory) return "Folder";
                if (this is File) return "File";
                return null;
            }
        }
        public string Size { get; set; }
    }
}
