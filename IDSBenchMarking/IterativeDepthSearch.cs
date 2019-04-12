using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSBenchMarking
{
    public class IterativeDepthSearch
    {
        public void IDS(Node root, bool target, int maxDepth)
        {
            for(int limitedDepth =0; limitedDepth <= maxDepth; limitedDepth++)
            {
  
            }
        }

        public bool FindNode(Node parent, bool target, int depthToSearch)
        {
            int nodesTraversed = 0;
            int currentDepth = 0;

            Stack<Node> s = new Stack<Node>();
            s.Push(parent);
            currentDepth++;
            while(s.Count > 0)
            {
                Node n = s.Pop();
                currentDepth--;
                nodesTraversed++;
                if (n.Value == target)
                {
                    Console.WriteLine($"Found target: {target} at node: {nodesTraversed}");
                    return true;
                }
                else
                {
                    Console.WriteLine(nodesTraversed);
                }
                if (n.Children.Count > 0)
                {
                    s.Push(n.Children[1]);
                    s.Push(n.Children[0]);
                }
            }
            return false;
        }
    }
}
