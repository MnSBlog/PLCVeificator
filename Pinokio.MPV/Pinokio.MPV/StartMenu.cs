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
using Excel = Microsoft.Office.Interop.Excel;

namespace Pinokio.MPV
{
    public partial class StartMenu : Form
    {
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
                        var test = timeChart.GetDevice(1);
                        var test2 = 1;
                    }
                }
                writer.Close();
                excelFile.Close();
            }
            //     // 워크북 열기
            //workSheet = workBook.Worksheets.get_Item(2) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기
            //var image = workSheet.Shapes.Item(3);
        }
    }
}
