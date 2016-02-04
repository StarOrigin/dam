using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.starorigin.dam.core.model
{
    public class Catalog
    {
        public virtual string Name
        { get; set; }
        public virtual bool BuiltIn
        { get; set; }
        public virtual Catalog Parent
        { get; set; }
    }
}
