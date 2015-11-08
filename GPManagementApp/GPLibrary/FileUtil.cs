using System;
using System.IO;
using System.Reflection;


namespace GPLibrary

{
    public class FileUtil
    {
        public static Uri getLocation(string fileName,string folder)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = new DirectoryInfo(path).Parent.Parent.FullName;
            path = Path.Combine(path, folder);
            path = Path.Combine(path, fileName);
            return new Uri(path);
        }
    }
}
