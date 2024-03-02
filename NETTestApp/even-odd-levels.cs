using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class even_odd_levels
    {
        public static void TestEvenOddLevels()
        {
            TreeNode root = new TreeNode(1, new TreeNode(10, new TreeNode(3, new TreeNode(12, null, null), new TreeNode(8, null, null)), null), 
                                            new TreeNode(4, new TreeNode(7, new TreeNode(6, null, null), null), new TreeNode(9, null, new TreeNode(2, null, null))));
            even_odd_levels obj = new();
            Console.WriteLine($"IsEvenOddTree: {obj.IsEvenOddTree(root)}");
        }

        /// <summary>
        /// A binary tree is named Even-Odd if it meets the following conditions:
        /// The root of the binary tree is at level index 0, its children are at level index 1, their children are at level index 2, etc.
        /// For every even-indexed level, all nodes at the level have odd integer values in strictly increasing order(from left to right).
        /// For every odd-indexed level, all nodes at the level have even integer values in strictly decreasing order(from left to right).
        /// Given the root of a binary tree, return true if the binary tree is Even-Odd, otherwise return false.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsEvenOddTree(TreeNode root)
        {
            if (root == null)
                return false;

            Queue<TreeNode> q = new();
            q.Enqueue(root);

            int prev = 0;
            bool evenLevel = true;
            while (q.Count > 0)
            {
                //Console.WriteLine($"Curr queue size = {q.Count}; Curr node val = {q.Peek().val}");
                
                if (evenLevel)
                    prev = int.MinValue;
                else
                    prev = int.MaxValue;

                int qSize = q.Count;
                while (qSize > 0)
                {
                    TreeNode curr = q.Dequeue();
                    if (evenLevel)
                    {
                        if (curr.val <= prev || curr.val % 2 != 1)
                            return false;
                    }
                    else
                    {
                        if (curr.val >= prev || curr.val % 2 != 0)
                            return false;
                    }

                    prev = curr.val;

                    if (curr.left != null)
                        q.Enqueue(curr.left);
                    if (curr.right != null)
                        q.Enqueue(curr.right);

                    qSize--;
                }

                evenLevel = !evenLevel;
            }
            return true;
        }
    }
}


