using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeChartEditor
{
    internal class WinFormUtils
    {
        public static string OpenFileFinder(string title, string extension)
        {
            // extension sample: // "그림 파일 (*.jpg, *.gif, *.bmp) | *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Title = title;
            Dialog.Filter = extension; 
            Dialog.RestoreDirectory = true;

            DialogResult dr = Dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                return Dialog.FileName;
            }
            else
            {
                return "";
            }
        }
    }
}
