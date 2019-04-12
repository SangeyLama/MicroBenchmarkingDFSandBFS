using System.Collections.Generic;


namespace IDSBenchMarking
{
    public class BreadthFirstSearch
    {
        public double IterativeSearch(Node root, bool target)
        {
            int nodesTraversed = 0;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                Node n = q.Dequeue();
                nodesTraversed++;
                if(n.Value == target)
                {
                    return nodesTraversed;
                }
                if(n.Children.Count > 0)
                {
                    q.Enqueue(n.Children[0]);
                    q.Enqueue(n.Children[1]);
                }
            }
            return nodesTraversed;
        }
    }
}
