using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.core.model.file
{
    public class Partition : Directory
    {
        public override Directory Parent
        {
            get { return null; }
        }
        public override string Path
        {
            get { return Name + System.IO.Path.AltDirectorySeparatorChar; }
        }
    }
}
