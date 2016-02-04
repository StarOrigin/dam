using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.core.model.file
{
    public class File : FileBase
    {
        public virtual string MimeType
        { get; set; }
        public virtual string Hash
        { get; set; }
    }
}
