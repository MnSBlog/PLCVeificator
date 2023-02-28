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
using System.Windows.Forms.VisualStyles;

namespace Pinokio.MPV
{
    public partial class StartMenu : Form
    {
        SandBox.Communication communication = new SandBox.Communication();
        MainForm mainForm = new MainForm();
        VerifierForm verifierForm = new VerifierForm();
        public StartMenu()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string targetPath = WinFormUtils.OpenFileFinder("Excel Finder", "xlsx 파일(*.xlsx) | *.xlsx; | 모든 파일 (*.*) | *.*");
        //    if (targetPath != null)
        //    {
        //        // 여기서 dll로 *****
        //        Excel.Application excelAPP = new Excel.Application();
        //        Workbook excelFile = excelAPP.Workbooks.Open(targetPath);
        //        var sheetCount = excelFile.Worksheets.Count;
        //        // 확인용 텍스트 파일
        //        string txtPath = targetPath.Replace(".xlsx", ".txt");
        //        StreamWriter writer;
        //        writer = File.CreateText(txtPath);
        //        for (int i =1; i <= sheetCount; ++i)
        //        {
        //            var sheet = excelFile.Worksheets.get_Item(i) as Worksheet;
        //            if (sheet.Name.ToLower().Contains("time"))
        //            {
        //                // 타임차트인 경우에는 객체들을 불러온다.
        //                TimeChart timeChart = new TimeChart(sheet);
        //                int deviceCount = timeChart.GetDeviceNum();

        //                // 메인 차트에 그림그리기 ***** UI 영역
        //                Graphics graphics = pictureBox2.CreateGraphics();
        //                Pen drawPen = new Pen(Color.Black, 2.0f);
        //                int boxWidth = pictureBox2.Width - 100;
        //                int boxHeight = pictureBox2.Height - 50;
        //                int offset = 25;
        //                for (int j = 0; j < deviceCount; ++j)
        //                {
        //                    ChartSignal device = timeChart.GetDevice(j, true);

        //                    for (int k = 0; k < device.Data.Count; ++k)
        //                    {
        //                        ExcelObject signal = device.Data[k];
        //                        var x1 = signal.Left * boxWidth + offset;
        //                        var y1 = signal.Top * boxHeight + offset;
        //                        var x2 = (signal.Left + signal.Width) * boxWidth + offset;
        //                        var y2 = (signal.Top + signal.Height) * boxHeight + offset;
        //                        graphics.DrawLine(drawPen, x1, y1, x2, y2);
        //                    }
        //                }
        //                graphics.Dispose();
        //            }
        //        }
        //        writer.Close();
        //        excelFile.Close();
        //    }
        //    //     // 워크북 열기
        //    //workSheet = workBook.Worksheets.get_Item(2) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기
        //    //var image = workSheet.Shapes.Item(3);
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            communication.Login();
        }

        private void mainBtn_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            verifierForm.Hide();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {
            mainForm.TopLevel = verifierForm.TopLevel = false;
            this.Controls.Add(mainForm);
            this.Controls.Add(verifierForm);
            mainForm.Parent = this.centerPanel;
            verifierForm.Parent = this.centerPanel;

        }
        private void verifierBtn_Click(object sender, EventArgs e)
        {
            mainForm.Hide();
            verifierForm.Show();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
