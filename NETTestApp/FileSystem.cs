using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    public class FileSystem
    {
        Dictionary<string, int> PathValues = new Dictionary<string, int>(); 
        public FileSystem()
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
