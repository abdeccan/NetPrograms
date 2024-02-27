using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    //public class TreeNode
    //{
    //    public int val;
    //    public TreeNode left;
    //    public TreeNode right;
    //    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    //    {
    //        this.val = val;
    //        this.left = left;
    //        this.right = right;
    //    }
    //}
    internal class DiameterBinTree
    {
        public static void TestDiameterBinTree()
        {
            TreeNode root = new TreeNode(1, new TreeNode(2, null, null), new TreeNode(3, null, null));
            DiameterBinTree diaTree = new();
            Console.WriteLine($"Diameter is {diaTree.DiameterOfBinaryTree(root)}");
        }

        int findHeight(TreeNode node, ref int dia)
        {
            if (node == null)
                return 0;

            int leftHeight = findHeight(node.left, ref dia);
            int rightHeight = findHeight(node.right, ref dia);

            dia = Math.Max(dia, leftHeight + rightHeight);

            return Math.Max(leftHeight, rightHeight) + 1;
        }
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int dia = 0;

            int h = findHeight(root, ref dia);

            return dia;
        }
    }
}
