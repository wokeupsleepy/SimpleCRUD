using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleCRUD
{
    class TextReader
    {
        public string filePath { get; set; }
        public StreamReader readStream { get; set; }

        public string readFirstLine()
        {
            string returnString = readStream.ReadLine();
            return returnString;
        }

        public void addText()
        {
            readStream = new StreamReader(filePath);
        }

        public bool isEndStream()
        {
            return readStream.EndOfStream;
        }

        public void closeStream()
        {
            if (readStream.BaseStream != null)
            {
                readStream.Close();
            }
        }

    }
}
