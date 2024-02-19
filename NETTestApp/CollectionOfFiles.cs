using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    /// <summary>
    /// Given a list of [FileName, FileSize, [Collection]] - Collection is optional, i.e., a collection can have 1 or more files. Same file can be a part of more than 1 collection.
    /// How would you design a system
    /// To calculate total size of files processed.
    /// To calculate Top K collections based on size.
    /// Example input:
    /// file1.txt 100 null
    /// file2.txt 200 collection1
    /// file3.txt 200 collection1,collection2
    /// file4.txt 300 collection2
    /// file5.txt 100 null
    /// 
    /// Output:

    /// Total size of files processed: 900
    /// Top 2 collections:
    /// - collection1 : 400
    /// - collection2 : 300
    /// </summary>
    internal class CollectionOfFiles
    {
        Dictionary<string, int> FileSizeMapping = new();
        Dictionary<string, int> CollectionSizeMapping = new();
        int TotalFileSize = 0;
        public CollectionOfFiles(string[] bulkInput)
        {
            /// Example input:
            /// file1.txt 100 null
            /// file2.txt 200 collection1
            /// file3.txt 200 collection1,collection2
            /// file4.txt 300 collection2
            /// file5.txt 100 null

            foreach (string s in bulkInput)
            {

                string[] tokens = s.Split(new char[] { ' ' });

                if (tokens.Length == 0) continue;

                // tokens[0] is file name, tokens[1] is size, tokens[2] if not null is list of collections
                int size = Convert.ToInt32(tokens[1]);
                FileSizeMapping.Add(tokens[0], size);
                TotalFileSize += size;
                if (tokens.Length > 2)
                {
                    // this means there are collections associated
                    string[] collections = tokens[2].Split(new char[] { ',' });
                    if (collections.Length > 0)
                    {
                        foreach (string c in collections)
                        {
                            if (CollectionSizeMapping.ContainsKey(c))
                            {
                                CollectionSizeMapping[c] += size;
                            }
                            else
                            {
                                CollectionSizeMapping.Add(c, size);
                            }
                        }
                    }
                }
            }

        }

        public int GetTotalFileSize()
        {
            return TotalFileSize;
        }
        public List<Tuple<string, int>> GetTopKCollections(int k)
        {
            List<Tuple<string, int>> TopKCollections = new();
            
            foreach (var kvp in CollectionSizeMapping.OrderByDescending(kvp => kvp.Value))
            {
                TopKCollections.Add(Tuple.Create(kvp.Key, kvp.Value));
                if (TopKCollections.Count == k) break;
            }

            return TopKCollections;
        }
    }
}
