using System.Collections.Generic;

namespace IDSBenchMarking
{
    public class DepthFirstSearch
    {
        public double IterativeSearch(Node parent, bool target)
        {
            int nodesTraversed = 0;
            Stack<Node> s = new Stack<Node>();
            s.Push(parent);
            while (s.Count > 0)
            {
                Node n = s.Pop();
                nodesTraversed++;
                if (n.Value == target)
                {
                    return nodesTraversed;
                }
                if (n.Children.Count > 0)
                {
                    s.Push(n.Children[1]);
                    s.Push(n.Children[0]);                                      
                }
            }
            return nodesTraversed;
        }
    }
}
