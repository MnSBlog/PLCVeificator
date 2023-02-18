namespace TimeChartEditor
{
    public partial class TimeChartMain : Form
    {
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

            //lpcom_ReferencesUtlType.WriteDeviceRandom2("M1001", iNumberOfData, ref arrDeviceValue1[0]);

            iReturnCode = lpcom_ReferencesUtlType.WriteDeviceRandom2("X0", iNumberOfData, ref arrDeviceValue1[0]);
            Thread.Sleep(3100);

            for (int j = 0; j < 6; j++)
            {
                iReturnCode = lpcom_ReferencesUtlType.WriteDeviceRandom2("X2", iNumberOfData, ref arrDeviceValue1[0]);
                Thread.Sleep(1000);
                iReturnCode = lpcom_ReferencesUtlType.WriteDeviceRandom2("X2", iNumberOfData, ref arrDeviceValue0[0]);
                Thread.Sleep(1000);
            }

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
            Application.Exit();
        }
    }
}