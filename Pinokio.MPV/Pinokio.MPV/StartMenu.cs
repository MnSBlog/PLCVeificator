using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeChartEditor;
using static Pinokio.MPV.TimeChart;
using Excel = Microsoft.Office.Interop.Excel;
using SandBox;
using Font = System.Drawing.Font;
using Microsoft.Office.Core;

namespace Pinokio.MPV
{
    public partial class StartMenu : Form
    {
        SandBox.Communication communication = new SandBox.Communication();
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetPath = WinFormUtils.OpenFileFinder("Excel Finder", "xlsx 파일(*.xlsx) | *.xlsx; | 모든 파일 (*.*) | *.*");
            if (targetPath != null)
            {
                // 여기서 dll로 *****
                Excel.Application excelAPP = new Excel.Application();
                Workbook excelFile = excelAPP.Workbooks.Open(targetPath);
                var sheetCount = excelFile.Worksheets.Count;
                // 확인용 텍스트 파일
                string txtPath = targetPath.Replace(".xlsx", ".txt");
                StreamWriter writer;
                writer = File.CreateText(txtPath);
                for (int i =1; i <= sheetCount; ++i)
                {
                    var sheet = excelFile.Worksheets.get_Item(i) as Worksheet;
                    if (sheet.Name.ToLower().Contains("time"))
                    {
                        // 타임차트인 경우에는 객체들을 불러온다.
                        TimeChart timeChart = new TimeChart(sheet);
                        int deviceCount = timeChart.GetDeviceNum();

                        // 메인 차트에 그림그리기 ***** UI 영역
                        Graphics graphics = pictureBox2.CreateGraphics();
                        Pen drawPen = new Pen(Color.Black, 2.0f);
                        Pen signalPen = new Pen(Color.Red, 2.0f);
                        int boxWidth = (int)(pictureBox2.Width * 0.6f);
                        int titleSpace = (int)(pictureBox2.Width * 0.3f);
                        int boxHeight = (int)(pictureBox2.Height * 0.8f);
                        int heightOffset = (int)(pictureBox2.Height * 0.1f);
                        using (Font font = new Font("Times New Roman", 22))
                        {
                            graphics.DrawString(timeChart.Scenario, font, Brushes.Black, (int)(boxWidth * 0.7f), (int)(boxHeight * 0.02f));
                            for (int j = 0; j < deviceCount; ++j)
                            {
                                ChartSignal device = timeChart.GetDevice(j, true);
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
                                graphics.DrawLine(drawPen, x2, y2, pictureBox2.Width, y2);
                            }
                        }
                        graphics.Dispose();
                    }
                }
                writer.Close();
                excelFile.Close();
            }
            //     // 워크북 열기
            //workSheet = workBook.Worksheets.get_Item(2) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기
            //var image = workSheet.Shapes.Item(3);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            communication.Login();
        }
    }
}
