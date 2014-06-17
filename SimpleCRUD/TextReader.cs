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

        public string ReadFirstLine()
        {
            string returnString = readStream.ReadLine();
            return returnString;
        }

        public void AddText()
        {
            readStream = new StreamReader(filePath);
        }

        public bool IsEndStream()
        {
            return readStream.EndOfStream;
        }

        public void CloseStream()
        {
            if (readStream.BaseStream != null)
            {
                readStream.Close();
            }
        }

    }
}
