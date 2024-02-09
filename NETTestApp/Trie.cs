using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class TrieNode
    {
        public bool _isLeaf = false;

        public Dictionary<char, TrieNode> map = new();
        public TrieNode() { 
            
        }
    }
    internal class Trie
    {
        TrieNode rootNode;
        public Trie()
        {
            rootNode = new();
        }

        public bool Search(string s)
        {
            TrieNode currNode = rootNode;
            foreach (char c in s)
            { 
                if(!currNode.map.ContainsKey(c))
                    return false;

                currNode = currNode.map[c];
            }
            if(currNode._isLeaf)
                return true;
            else
                return false;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode currNode = rootNode;
            foreach (char c in prefix)
            {
                if (!currNode.map.ContainsKey(c))
                    return false;

                currNode = currNode.map[c];
            }
            return true;
        }

        public void Insert(string word)
        {
            var currNode = rootNode;
            foreach (var c in word)
            {
                if (currNode.map.ContainsKey(c))
                    currNode = currNode.map[c];
                else
                {
                    currNode.map[c] = new TrieNode();
                    currNode = currNode.map[c];
                }
            }
            currNode._isLeaf = true;
        }
    }
}
