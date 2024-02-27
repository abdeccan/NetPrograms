using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    internal class SameTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p == null && q != null || q == null && p != null)
                return false;

            if (p.left == null && q.left == null && p.right == null && q.right == null)
                return p.val == q.val;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right) && (p.val == q.val);
        }

        public static void TestSameTree()
        {
            TreeNode p = new TreeNode(1, new TreeNode(2, null, null), new TreeNode(3, null, null));
            TreeNode q = new TreeNode(1, new TreeNode(2, null, null), new TreeNode(3, null, null));
            SameTree test = new();
            
            Console.WriteLine($"IsSameTree returned: {test.IsSameTree(p, q)}");
        }


    }
}
