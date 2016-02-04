using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.core.model
{
    public class Photo
    {
        public virtual string Name { get; set; }
        public virtual string Mark { get; set; }
        public virtual string Album { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Size { get; set; }
        public virtual string Hash { get; set; }
    }
}
