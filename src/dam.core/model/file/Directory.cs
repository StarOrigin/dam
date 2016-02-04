using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.core.model.file
{
    public class Directory : FileBase
    {
        protected IEnumerable<FileBase> children;
        public virtual IEnumerable<FileBase> Children
        {
            get { if (children == null) children = new List<FileBase>(); return children; }
            set { children = value; }
        }
        public virtual IEnumerable<Directory> Directories
        {
            get
            {
                IEnumerable<FileBase> coll = Children;
                return coll.Where((x) => x is Directory) as IEnumerable<Directory>;
            }
        }
        public virtual IEnumerable<File> Files
        {
            get {
                IEnumerable<FileBase> coll = Children;
                return coll.Where((x) => x is File) as IEnumerable<File>;
            }
        }
    }
}
