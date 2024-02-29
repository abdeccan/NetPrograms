using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class LeftMostBottomInTree
    {
        /// <summary>
        /// Given the root of a binary tree, return the leftmost value in the last row of the tree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            if (root == null)
                return 0;

            // do a BFS and add right child first and then left
            Queue<TreeNode> q = new();
            q.Enqueue(root);

            int result = -1;

            while (q.Count > 0)
            {
                TreeNode curr = q.Dequeue();
                if (curr == null)
                    break;
                result = curr.val;

                if (curr.right != null)
                    q.Enqueue(curr.right);
                if (curr.left != null)
                    q.Enqueue(curr.left);
            }
            return result;
        }
    }
}
