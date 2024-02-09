using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{    public class Node
    {
        readonly string Name;
        readonly int Value;
        public Node[] ChildNodes;

        public Node(string name, int id)
        {
            this.Name = name;
            this.Value = id;
        }

        public Node GetChildNode(string Name)
        {
            foreach (var node in ChildNodes)
            {
                if (node.Name == Name)
                    return node;
            }

            return null;
        }

        public bool AddChildNode(Node node)
        {
            Node tmpNode = GetChildNode(node.Name);
            if (tmpNode != null)
            {
                return false;
            }
            else
            {
                ChildNodes.Append(node);
                return true;
            }
        }
    }
}
