using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Tesseract;

namespace TimeChartEditor
{
    internal class ImageProcessor
    {
        private string? _imagePath = null;

        public bool ReadImage(string filename)
        {
            try
            {
                //Mat temp = Cv2.ImRead(filename, ImreadModes.Color);
                _imagePath = filename;
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }
        public bool IsLoaded()
        {
            return (string.IsNullOrEmpty(_imagePath) == false);
        }
        public string? GetOCR()
        {
            if (!IsLoaded())
                return null;

            using (var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndLstm))
            {
                using (var img = Pix.LoadFromFile(_imagePath))
                {
                    using (var page = ocr.Process(img))
                    {
                        var texts = page.GetText();
                        return texts;
                    }
                }
            }
        }
    }
}
