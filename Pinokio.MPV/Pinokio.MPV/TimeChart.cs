using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace Pinokio.MPV
{
    public class TimeChart
    {
        public string Scenario = "Time Chart X Scenario";
        public Graphics graphics = null;
        private List<ChartSignal> _devices = new List<ChartSignal>();
        private (float Min, float Max) _widthRange = (float.PositiveInfinity, float.NegativeInfinity);
        private (float Min, float Max) _heightRange = (float.PositiveInfinity, float.NegativeInfinity);

        private const int _parent = 2;
        private const int _value = 3;
        public TimeChart(Worksheet ws)
        {
            RecognizeSignalFromExcel(ws);
        }
        public ChartSignal GetDevice(int index, bool normalized = false)
        {
            if (normalized == false)
            {
                return _devices[index];
            }
            else
            {
                ChartSignal chartSignal = new ChartSignal();
                var device = _devices[index];

                chartSignal.Parent = device.Parent;
                chartSignal.Name = device.Name;
                var data = device.Data;
                float heightGap = _heightRange.Max - _heightRange.Min;
                float widthGap = _widthRange.Max - _widthRange.Min;
                for (int i = 0; i < data.Count; ++i)
                {
                    ExcelObject signal = new ExcelObject
                    {
                        Name = data[i].Name,
                        Rotation = data[i].Rotation,
                        Top = (data[i].Top - _heightRange.Min) / heightGap,
                        Left = (data[i].Left - _widthRange.Min) / widthGap,
                        Width = data[i].Width / widthGap,
                        Height = data[i].Height / heightGap
                    };
                    if (signal.Width < 0) signal.Width = 0;
                    if (signal.Height < 0) signal.Height = 0;
                    //chartSignal.CenterHeight = ((data[i].Top + data[i].Height) / 2.0f - _heightRange.Min) / heightGap;
                    chartSignal.CenterHeight = signal.Top;
                    chartSignal.Data.Add(signal);
                }
                return chartSignal;
            }
        }
        public int GetDeviceNum()
        {
            return _devices.Count;
        }
        public Graphics DrawPanel(PictureBox pb)
        {
            Graphics graphics = pb.CreateGraphics();
            Pen drawPen = new Pen(Color.Black, 2.0f);
            Pen signalPen = new Pen(Color.Red, 2.0f);
            int boxWidth = (int)(pb.Width * 0.6f);
            int titleSpace = (int)(pb.Width * 0.3f);
            int boxHeight = (int)(pb.Height * 0.8f);
            int heightOffset = (int)(pb.Height * 0.1f);
            using (Font font = new Font("Times New Roman", 22))
            {
                graphics.DrawString(Scenario, font, Brushes.Black, (int)(boxWidth * 0.7f), (int)(boxHeight * 0.02f));
                for (int j = 0; j < _devices.Count; ++j)
                {
                    ChartSignal device = GetDevice(j, true);
                    device.CenterHeight = device.CenterHeight * boxHeight + heightOffset;
                    graphics.DrawString(device.Parent, font, Brushes.Black, (int)(titleSpace * 0.3f), device.CenterHeight);
                    graphics.DrawString(device.Name, font, Brushes.DarkRed, (int)(titleSpace * 0.7f), device.CenterHeight);
                    float x1 = 0f;
                    float y1 = 0f;
                    float x2 = 0f;
                    float y2 = 0f;
                    for (int k = 0; k < device.Data.Count; ++k)
                    {
                        ExcelObject signal = device.Data[k];
                        x1 = signal.Left * boxWidth + titleSpace;
                        y1 = signal.Top * boxHeight + heightOffset;
                        x2 = signal.Width * boxWidth + x1;
                        y2 = signal.Height * boxHeight + y1;
                        graphics.DrawLine(signalPen, x1, y1, x2, y2);

                        if (k - 1 < 0)
                        {
                            graphics.DrawLine(drawPen, titleSpace, y2, x1, y2);
                        }
                        else
                        {
                            ExcelObject oldSignal = device.Data[k - 1];
                            var pen = signalPen;
                            var oldY = oldSignal.Top * boxHeight + heightOffset;
                            var oldX = oldSignal.Left * boxWidth + titleSpace;
                            if (k % 2 != 1)
                            {
                                oldY = oldSignal.Height * boxHeight + oldY;
                                pen = drawPen;
                            }
                            graphics.DrawLine(pen, oldX, oldY, x1, oldY);
                        }
                    }
                    graphics.DrawLine(drawPen, x2, y2, pb.Width, y2);
                }
            }
            return graphics;
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
                line.Height = shape.Height;
                line.Top = shape.Top;
                line.Left = shape.Left;
                line.Rotation = shape.Rotation;
                if (line.Name.ToLower().Contains("straight"))
                {
                    if (line.Height > 0.0)
                    {
                        samples.Add(line.Top);
                        lines.Add(line);
                    }
                }
                UpdateMinMax(line);
            }

            // 스케일링과 정렬 그리고 각 디바이스별 군집을 구한다.
            var scaled = MathUtils.ScaleNumbers(samples);
            var sorted = scaled
                .Select((x, i) => new KeyValuePair<float, int>(x, i))
                .OrderBy(x => x.Key)
                .ToList();
            List<float> sortedNumber = sorted.Select(x => x.Key).ToList();
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
            // 이름을 인식하여 순서대로 디바이스에 기입한다.
            List<ChartSignal> temp = new List<ChartSignal>();
            Range range = sheet.UsedRange;
            object[,] data = (object[,])range.Value;
            string nowParent = "";
            for (int r = 1; r <= data.GetLength(0); r++)
            {
                int length = data.GetLength(1);
                for (int c = 1; c <= length; c++)
                {
                    string name = "";
                    if (data[r, c] == null)
                    {
                        continue;
                    }
                    else if (data[r, c] is string)
                    {
                        name = data[r, c] as string;
                    }
                    else
                    {
                        name = data[r, c].ToString();
                    }
                    if (c == _parent)
                    {
                        nowParent = name;
                    }
                    else
                    {
                        ChartSignal dummy = new ChartSignal();
                        dummy.Parent = nowParent;
                        dummy.Name = name;
                        temp.Add(dummy);
                    }
                }
            }
            // 최종적으로 이름을 부여
            for (int i = 0; i < _devices.Count; ++i)
            {
                var device = _devices[i];
                var tag = temp[i];
                device.Name = tag.Name;
                device.Parent = tag.Parent;
                // 이름부여 하면서 Data 오름차순 정렬
                var originData = device.Data;
                var sortedData = device.Data.Select((x, v) => new KeyValuePair<ExcelObject, int>(x, v)).OrderBy(x => x.Key.Left).ToList();
                device.Data = sortedData.Select(x => x.Key).ToList();
                _devices[i] = device;
            }
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
        private void UpdateMinMax(ExcelObject data)
        {
            if (data.Left < _widthRange.Min)
                _widthRange.Min = data.Left;
            if (data.Left + data.Width > _widthRange.Max)
                _widthRange.Max = data.Left + data.Width;
            if (data.Top < _heightRange.Min)
                _heightRange.Min = data.Top;
            if (data.Top + data.Height > _heightRange.Max)
                _heightRange.Max = data.Top + data.Height;
        }
        public class ChartSignal
        {
            public string Name { get; set; }
            public string Parent { get; set; }
            public float CenterHeight { get; set; }
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
