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
            string targetPath = WinFormUtils.OpenFileFinder("Ladder Finder", "csv ����(*.csv) | *.csv; | ��� ���� (*.*) | *.*");
            if (targetPath == "")
            {

            }
            else
            {
                string imagePath = WinFormUtils.OpenFileFinder("Reference Image Finder", "�׸� ���� (*.jpg, *.gif, *.bmp, *.png) | *.jpg; *.gif; *.bmp; *.png; | ��� ���� (*.*) | *.*");
                
                Image img = Image.FromFile(imagePath);
                pbLadderChart.Image = img; // ���� �� �� ����
            }
        }

        private void lblLog_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadTimeChart_Click(object sender, EventArgs e)
        {
            string TargetPath = WinFormUtils.OpenFileFinder("Time Chart Finder", "�׸� ���� (*.jpg, *.gif, *.bmp, *.png) | *.jpg; *.gif; *.bmp; *.png; | ��� ���� (*.*) | *.*");
            if (TargetPath == "")
            {

            }
            else
            {
                bool result = _imageProcessor.ReadImage(TargetPath);
                if (result)
                {
                    Image img = Image.FromFile(TargetPath);
                    pbTimeChart.Image = img; // ���� �� �� ����

                    string YamlPath = WinFormUtils.OpenFileFinder("yaml", "YAML ���� (*.yaml) | *.yaml;");
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
            // timechart������� PLC ���� �� ������ �߻��� �κ� üũ����(?)
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        //device(ex. X0, Y0)�� value�� TimeChart�� ��ɿ� ���� ���� ������ Value�� 1�� ��� On, Value�� 0�� ��� Off 

        
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
        
        // ��Ʈ�� TimeChart ��� (key, value) �ۼ�
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