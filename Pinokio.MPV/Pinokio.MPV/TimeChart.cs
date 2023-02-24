using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pinokio.MPV
{
    internal class TimeChart
    {
        public string Scenario;
        private List<ChartSignal> _devices = new List<ChartSignal>();

        public TimeChart(Worksheet ws)
        {
            RecognizeSignalFromExcel(ws);
        }
        private void RecognizeSignalFromExcel(Worksheet sheet)
        {
            // 타임차트인 경우에는 객체들을 불러온다.
            List<float> samples = new List<float>();
            List<ExcelObject> lines = new List<ExcelObject>();
            for (int j = 1; sheet.Shapes.Count >= j; ++j)
            {
                ExcelObject line = new ExcelObject();
                var shape = sheet.Shapes.Item(j);
                line.Name = shape.Name;
                line.Width = shape.Width;
                line.Top = shape.Top;
                line.Left = shape.Left;
                line.Rotation = shape.Rotation;
                if (line.Name.ToLower().Contains("straight"))
                {
                    if (line.Width > 0.0)
                    {
                        samples.Add(line.Top);
                        lines.Add(line);
                    }
                }
            }
            // 스케일링과 정렬 그리고 각 디바이스별 군집을 구한다.
            var scaled = MathUtils.ScaleNumbers(samples);
            var sorted = scaled
                .Select((x, i) => new KeyValuePair<float, int>(x, i))
                .OrderBy(x => x.Key)
                .ToList();
            List<float>sortedNumber = sorted.Select(x => x.Key).ToList();
            List<int> originalIndex = sorted.Select(x => x.Value).ToList();
            var clusters = GetCluster(sortedNumber);

            // 군집단위의 Device를 생성하여 타임차트의 신호를 넣는다.
            for (int i = 0; i < clusters.Count(); ++i)
            {
                var cluster = clusters[i];
                int index = originalIndex[i];
                ExcelObject line = lines[index];
                if (_devices.Count <= cluster)
                    _devices.Add(new ChartSignal());
                _devices[cluster].Data.Add(line);
            }
        }
        public ChartSignal GetDevice(int index)
        {
            return _devices[index];
        }

        private static int[] GetCluster(List<float> numbers)
        {
            var std = MathUtils.CalculateVariance(numbers);
            int clusterIndex = 0;
            float origin = numbers[0];
            int[] clusters = new int[numbers.Count];
            clusters[0] = clusterIndex;
            for (int i = 1; i < numbers.Count; i++)
            {
                float num = numbers[i];
                if (num > origin + std)
                {
                    clusterIndex += 1;
                    origin = num;
                }
                clusters[i] = clusterIndex;
            }
            return clusters;
        }
        public class ChartSignal
        {
            public string Name { get; set; }
            public List<ExcelObject> Data = new List<ExcelObject>();

        }

        public struct ExcelObject
        { 
            public string Name;
            public float Width;
            public float Height;
            public float Top;
            public float Left;
            public float Rotation;
        }
    }
}
