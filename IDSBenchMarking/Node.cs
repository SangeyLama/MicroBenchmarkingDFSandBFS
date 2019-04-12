using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSBenchMarking
{
    public class Node
    {
        public bool Value { get; set; }
        public List<Node> Children { get; set; }
    }
}
