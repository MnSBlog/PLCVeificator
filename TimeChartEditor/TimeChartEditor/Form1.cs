using Excel = Microsoft.Office.Interop.Excel;


namespace TimeChartEditor
{
    public partial class TimeChartMain : Form
    {
        private ImageProcessor _imageProcessor = new ImageProcessor();
        private EventHandler _eventHandler;
        private Dictionary<string, short> _devices = new Dictionary<string, short>();

        public TimeChartMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string targetPath = WinFormUtils.OpenFileFinder("Ladder Finder", "csv 파일(*.csv) | *.csv; | 모든 파일 (*.*) | *.*");
            if (targetPath == "")
            {

            }
            else
            {
                string imagePath = WinFormUtils.OpenFileFinder("Reference Image Finder", "그림 파일 (*.jpg, *.gif, *.bmp, *.png) | *.jpg; *.gif; *.bmp; *.png; | 모든 파일 (*.*) | *.*");
                
                Image img = Image.FromFile(imagePath);
                pbLadderChart.Image = img; // 에러 날 수 있음
            }
        }

        private void lblLog_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadTimeChart_Click(object sender, EventArgs e)
        {
            string TargetPath = WinFormUtils.OpenFileFinder("Time Chart Finder", "그림 파일 (*.jpg, *.gif, *.bmp, *.png) | *.jpg; *.gif; *.bmp; *.png; | 모든 파일 (*.*) | *.*");
            if (TargetPath == "")
            {

            }
            else
            {
                bool result = _imageProcessor.ReadImage(TargetPath);
                if (result)
                {
                    Image img = Image.FromFile(TargetPath);
                    pbTimeChart.Image = img; // 에러 날 수 있음

                    string YamlPath = WinFormUtils.OpenFileFinder("yaml", "YAML 파일 (*.yaml) | *.yaml;");
                    _eventHandler = new EventHandler(YamlPath);
                }
            }
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            string ocrCode = _imageProcessor.GetOCR();
            var test = ocrCode.ToLower();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //The Open method is executed.
            SimEngine engine = new SimEngine(_eventHandler);
            engine.RunAuto(500);
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            // timechart기반으로 PLC 검증 시 오류가 발생한 부분 체크해줌(?)
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //device(ex. X0, Y0)의 value를 TimeChart의 명령에 따라서 동작 시켜줌 Value가 1인 경우 On, Value가 0인 경우 Off 

        
        //private void createTimeChart()
        //{
        //    Excel.Application myexcelApplication = new Excel.Application();
        //    if (myexcelApplication != null)
        //    {
        //        Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Add();
        //        Excel.Worksheet myexcelWorksheet = (Excel.Worksheet)myexcelWorkbook.Sheets.Add();

        //        myexcelWorksheet.Cells[1, 1] = "Device";
        //        myexcelWorksheet.Cells[1, 2] = "Value";

        //        myexcelApplication.ActiveWorkbook.SaveAs(@"C:\abc.xls", Excel.XlFileFormat.xlWorkbookNormal);

        //        myexcelWorkbook.Close();
        //        myexcelApplication.Quit();
        //    }
        //}
        
        // 시트에 TimeChart 기반 (key, value) 작성
        private void writeTimeChart()
        {
            Excel.Worksheet myexcelWorksheet = new Excel.Worksheet();
            int rowNum = 2;
            int columnNum = 2;
            myexcelWorksheet.Cells[1, 1] = "Device";
            myexcelWorksheet.Cells[1, 2] = "Value";
      
            foreach (var device in _devices)
            {
                myexcelWorksheet.Cells[rowNum, columnNum++] = device.Key;
                myexcelWorksheet.Cells[rowNum++, columnNum--] = device.Value;
            }
        }
    }
}