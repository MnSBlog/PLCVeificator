using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SandBox
{
    internal class Testbed
    {
        static Excel.Application excelApp = null;
        static Excel.Workbook workBook = null;
        static Excel.Worksheet workSheet = null;
        static void Main(string[] args)
        {

        }
        public void ecxelShapeRead()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  // 바탕화면 경로
            string path = Path.Combine(desktopPath, "TimeChart.xlsx");                              // 엑셀 파일 저장 경로

            excelApp = new Excel.Application();                             // 엑셀 어플리케이션 생성
            workBook = excelApp.Workbooks.Open(path);                       // 워크북 열기
            workSheet = workBook.Worksheets.get_Item(2) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기

            var image = workSheet.Shapes.Item(3);
        }
    }
}
