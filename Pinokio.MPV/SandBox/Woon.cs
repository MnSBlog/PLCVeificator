using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SandBox
{
    class Woon
    {
        private string _myName = "Woon";
        const string loginTag = "L1";
        const string idTag = "B1 ID";
        const string pwTag = "B2 PW";
        const string workerTag = "B3 WORKER";
        const string dataTag = "U4 DATA";
        Excel.Application excelApp = null;
        Excel.Workbook workBook = null;
        Excel.Worksheet workSheet = null;
        private List<string[]> ExcelList = new List<string[]>();
        private string txtPath = null;
        private LangMatcher _matcher = new LangMatcher();

        public string GetMyName()
        {
            return _myName;
        }
        public Woon()
        {

        }

        public void ReadNotePad()
        {
            txtPath = @"C:\Users\MNS\Downloads\exercise_0227_1.txt";
            StreamReader SR = new StreamReader(txtPath);
            string line;                                            //한 줄씩 읽은 후, 그 값을 저장시킬 변수
            string result = "";//전체 라인을 저장시킬 변수
            string tag = "";
            while ((line = SR.ReadLine()) != null)                  //line변수에 SR에서 한줄을 읽은 걸 저장, 읽은 줄이 null이 아닐때까지 반복
            {
                // 가장 높은 레벨이 있는지 탐색
                if (line.Contains("<L"))
                    tag = "L";
                else if (line.Contains("<B"))
                    tag = "B";
                else if (line.Contains("<U"))
                    tag = "U";
                else
                    continue;
                _matcher.AddTerm(line, tag);
            }
            var CIMMAP = _matcher.ShowAll();
            var whatis = _matcher.GetItem(tags: new List<string> { "L2", "B3" });
            var test = 1;

        }

        public void ExcelLoad()
        {
            // 이름을 인식하여 순서대로 디바이스에 기입한다.
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);  // 바탕화면 경로
            string path = Path.Combine(desktopPath, "memoryMap.xlsx");                              // 엑셀 파일 저장 경로
            excelApp = new Excel.Application();                             // 엑셀 어플리케이션 생성
            workBook = excelApp.Workbooks.Open(path);                       // 워크북 열기
            workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기
            Excel.Range range = workSheet.UsedRange;
            object[,] data = (object[,])range.Value;
            for (int r = 1; r <= data.GetLength(0); r++)
            {
                int length = data.GetLength(1);
                string[] arr = new string[length];

                for (int c = 1; c <= length; c++)
                {
                    if (data[r, c] == null)
                    {
                        continue;
                    }
                    else if (data[r, c] is string)
                    {
                        arr[c - 1] = data[r, c] as string;
                    }
                    else
                    {
                        arr[c - 1] = data[r, c].ToString();
                    }
                }

                ExcelList.Add(arr);
            }
        }

        public void MemoryMatching()
        {
            foreach (var data in ExcelList)
            {
                if (data.Contains(loginTag))
                {
                    break;
                }
            }
        }



    }
}

