using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    class Woon
    {
        private string _myName = "Woon";
        const string dataTag = "U4";

        public string GetMyName()
        {
            return _myName;
        }

        private string[] ReadNotePad(string path)
        {
            string[] readValue = null;
            var memoryMap = @"C:\Users\MNS\Downloads\exercise_0227_1.txt";

            string[] textValue = System.IO.File.ReadAllLines(path);
            if (textValue.Length > 0)
            {

            }
            return readValue;
        }



    }
}

