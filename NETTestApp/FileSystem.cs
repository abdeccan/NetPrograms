using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    public class TrieFileSystem
    {
        class TrieNode
        {
            public readonly string Path;
            public int Value = -1;
            public Dictionary<string, TrieNode> ChildNodes = new();
            public TrieNode(string path)
            {
                Path = path;
            }
        }

        TrieNode root;

        public TrieFileSystem()
        {
            root = new("/");
        }

        public bool CreatePath(string path, int value)
        {
            TrieNode node = root;
            string[] tokens = path.Split('/');
            for (int index = 1; index < tokens.Length; index++)
            {
                if (!node.ChildNodes.ContainsKey(tokens[index]))
                {
                    if (index == tokens.Length - 1)
                    {
                        // we need to create this path
                        TrieNode newNode = new TrieNode(tokens[index]);
                        node.ChildNodes.Add(tokens[index], newNode);
                        //   node = newNode;
                    }
                    else
                    {
                        // the parent path is not there in the map, return false
                        return false;
                    }
                }

                node = node.ChildNodes[tokens[index]];
            }

            if (node.Value != -1)
                return false; // already the path existed before we created, so return false
            else
            {
                node.Value = value;
                return true;
            }
        }

        public int Get(string path)
        {
            TrieNode node = root;
            if (node.Path == path) return node.Value;

            string[] tokens = path.Split('/');
            for (int index = 1; index < tokens.Length; index++)
            {
                if (!node.ChildNodes.ContainsKey(tokens[index]))
                {
                    return -1;
                }

                node = node.ChildNodes[tokens[index]];
            }
            return node.Value;
        }
    }
    public class HashMapFileSystem
    {
        Dictionary<string, int> PathValues = new Dictionary<string, int>(); 
        public HashMapFileSystem()
        {
        
        }

        public bool CreatePath(string path, int value)
        {
            if (PathValues.ContainsKey(path))
                return false;

            string pathPrefix = path.Substring(0, path.LastIndexOf('/'));

            if (string.IsNullOrEmpty(pathPrefix) || PathValues.ContainsKey(pathPrefix))
            {
                PathValues[path] = value;
                return true;
            }

            return false;
        }
    
        public int Get(string path)
        {
            int value = 0;
            if(PathValues.TryGetValue(path, out value))
                return value;

            return -1;
        }
    }
}
