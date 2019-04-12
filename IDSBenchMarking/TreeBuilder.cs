using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDSBenchMarking
{
    public class TreeBuilder
    {
        private int expectedNoOfNodesAtMaxDepth;
        private int currentNoOfNodesAtMaxDepth;
        public Node CreateTree(int maxDepth, int currentDepth)
        {
            expectedNoOfNodesAtMaxDepth = (int)Math.Pow(2, (double)maxDepth);
            Node root = new Node { Value = false, Children = new List<Node>() };
            if (currentDepth == 0)
            {
                currentDepth++;
                root.Children.Add(CreateTree(maxDepth, currentDepth));
                root.Children.Add(CreateTree(maxDepth, currentDepth));
            }
            else if (currentDepth != maxDepth)
            {
                Node parent = new Node { Value = false, Children = new List<Node>() };
                currentDepth++;
                parent.Children.Add(CreateTree(maxDepth, currentDepth));
                parent.Children.Add(CreateTree(maxDepth, currentDepth));
                return parent;
            }
            else if (currentDepth == maxDepth)
            {
                currentNoOfNodesAtMaxDepth++;
                if(currentNoOfNodesAtMaxDepth == expectedNoOfNodesAtMaxDepth)
                {
                    return new Node { Value = true, Children = new List<Node>() };
                }
                return new Node { Value = false, Children = new List<Node>() };
            }
            expectedNoOfNodesAtMaxDepth = 0;
            currentNoOfNodesAtMaxDepth = 0;
            return root;

        }
    }
}
