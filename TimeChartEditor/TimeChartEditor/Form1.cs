using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace TimeChartEditor
{
    public partial class TimeChartMain : Form
    {
        private Dictionary<string, short> devices = new Dictionary<string, short>();
        private short readOutput;
        public TimeChartMain()
        {
            InitializeComponent();
        }
        #region "Additional initialization (including Form_Load processing)"
        /*The declaration of instance value for ACT controls************************/
        // When you use Dot controls by 'References', you should program as follows;
        private ActUtlTypeLib.ActUtlTypeClass lpcom_ReferencesUtlType;
        //private ActProgTypeLib.ActProgTypeClass lpcom_ReferencesProgType;
        private int i = 0;
        private bool errFlag = false;
        private int temp = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Create instance for ACT Controls*************************************/
            lpcom_ReferencesUtlType = new ActUtlTypeLib.ActUtlTypeClass();
            //lpcom_ReferencesProgType = new ActProgTypeLib.ActProgTypeClass();

            /* Set EventHandler for ACT Controls************************************/
            // Create EventHandler(ActProgType)
            //lpcom_ReferencesProgType.OnDeviceStatus +=
            //new ActProgTypeLib._IActProgTypeEvents_OnDeviceStatusEventHandler(ActProgType1_OnDeviceStatus);
            // Create EventHandler(ActUtlType)
            lpcom_ReferencesUtlType.OnDeviceStatus +=
                new ActUtlTypeLib._IActUtlTypeEvents_OnDeviceStatusEventHandler(ActUtlType1_OnDeviceStatus);
            /**************************************************************************/

        }
        #endregion
        #region "Processing of OnDeviceStatus for ActUtlType Controle"
        private void ActUtlType1_OnDeviceStatus(String szDevice, int iData, int iReturnCode)
        {
            System.String[] arrData;	        //Array for 'Data'
            //Assign the array for the read data.
            arrData = new System.String[txt_Data.Lines.Length + 1];

            //Copy the read data to the 'arrData'.
            Array.Copy(txt_Data.Lines, arrData, txt_Data.Lines.Length);

            //Add the content of new event to arrData.
            arrData[txt_Data.Lines.Length]
            = String.Format("OnDeviceStatus event by ActUtlType [{0}={1}]", szDevice, iData);

            //The new 'Data' is displayed.
            txt_Data.Lines = arrData;

            //The return code of the method is displayed by the hexadecimal.
            txt_ReturnCode.Text = String.Format("0x{0:x8}", iReturnCode);

        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblLog_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadTimeChart_Click(object sender, EventArgs e)
        {

        }

        private void btnMapping_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int iReturnCode;				//Return code
            int iNumberOfData = 1;			//Data for 'DeviceSize'
            short[] arrDeviceValue0;            //Data for 'DeviceValue'
            short[] arrDeviceValue1;		    //Data for 'DeviceValue'
            arrDeviceValue0 = new short[1];
            arrDeviceValue1 = new short[1];
            arrDeviceValue0[0] = 0;
            arrDeviceValue1[0] = 1;
            i = 0;
            //Set the value of 'LogicalStationNumber' to the property.
            lpcom_ReferencesUtlType.ActLogicalStationNumber = 0;
            //The Open method is executed.

            if (lpcom_ReferencesUtlType.Open() != 1)
            lpcom_ReferencesUtlType.Open();

            devices.Add("X0", 1);
            runToDevice(devices);
            Thread.Sleep(3100);

            //센서 등에 의해서 동작하는 경우 모듈을 따로 생성해서 해당 모듈 내의 RunToModule로 PLC 및 HMI 동작 구현
            ConveyorSensor conveyorSensor = new ConveyorSensor();
            conveyorSensor.RunToModule(lpcom_ReferencesUtlType);

        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            lpcom_ReferencesUtlType.Close();
            System.Windows.Forms.Application.Exit();
        }

        //device(ex. X0, Y0)의 value를 TimeChart의 명령에 따라서 동작 시켜줌 Value가 1인 경우 On, Value가 0인 경우 Off 
        private void runToDevice(Dictionary<string, short> devices)
        {
            foreach(var device in devices)
            {
                lpcom_ReferencesUtlType.WriteDeviceRandom2(device.Key, 1, device.Value);
                Thread.Sleep(1000);
                
                //device(ex. X0, Y0)의 현재 상태가 ON인지 OFF인지 가져올 수 있음 이 예시는 컨베이어 작동 램프(M1000)의 상태를 가져옴
                lpcom_ReferencesUtlType.ReadDeviceRandom2("M1000", 1, out readOutput);
                var a = readOutput;
            }
        }
        
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
      
            foreach (var device in devices)
            {
                myexcelWorksheet.Cells[rowNum, columnNum++] = device.Key;
                myexcelWorksheet.Cells[rowNum++, columnNum--] = device.Value;
            }
        }
    }
}