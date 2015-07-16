using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class FileHandler
    {
        private string _contentPath;

        public FileHandler(string contentPath)
        {
            this._contentPath = contentPath;
        }

        internal bool DoesFileExists(string directory)
        {
            return File.Exists(_contentPath + directory);
        }

        internal byte[] ReadFile(string Path)
        {
            //return File.ReadAllBytes(path);

            byte[] content = File.ReadAllBytes(_contentPath + Path);
            return content;
        }
    }
}
