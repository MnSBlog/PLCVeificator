using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace TimeChartEditor
{
    internal class ImageProcessor
    {
        private Mat? _currentImage = null;

        public bool ReadImage(string filename)
        {
            try
            {
                _currentImage = Cv2.ImRead(filename);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsLoaded()
        {
            return _currentImage != null;
        }
    }
}
