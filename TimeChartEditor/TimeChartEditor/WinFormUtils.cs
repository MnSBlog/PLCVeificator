using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

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
    internal class FileController
    {
        static FileController()
        {
            Instance = new FileController();
        }

        private FileController()
        {

        }

        public static FileController Instance { get; }

        public void Serialize<T>(string fileName, T value)
        {
            var builder = new SerializerBuilder().Build();

            using (var stream = File.Create(fileName))
            {
                using (var writer = new StreamWriter(stream))
                {
                    builder.Serialize(writer, value);
                }
            }
        }

        public T DeSerialize<T>(string fileName) where T : class
        {
            var builder = new DeserializerBuilder().Build();

            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    return builder.Deserialize(reader, typeof(T)) as T;
                }
            }
        }
    }
}
