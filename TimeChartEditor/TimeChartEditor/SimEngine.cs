using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TimeChartEditor
{
    internal class SimEngine
    {
        private int _pivot = 0;
        private int _eventInterval = 0;
        private EventHandler _eventable;
        /*The declaration of instance value for ACT controls************************/
        // When you use Dot controls by 'References', you should program as follows;
        private ActUtlTypeLib.ActUtlTypeClass _ipcomReferencesUtlType;
        //private ActProgTypeLib.ActProgTypeClass lpcom_ReferencesProgType;
        private int i = 0;
        private bool errFlag = false;
        private int temp = 0;

        public int Steps = 0;
        public float Tnow = 0.0f;
        public SimEngine(EventHandler eventTable)
        {
            SetEvents(eventTable);
            /* Create instance for ACT Controls*************************************/
            _ipcomReferencesUtlType = new ActUtlTypeLib.ActUtlTypeClass();
            //lpcom_ReferencesProgType = new ActProgTypeLib.ActProgTypeClass();

            /* Set EventHandler for ACT Controls************************************/
            // Create EventHandler(ActProgType)
            //lpcom_ReferencesProgType.OnDeviceStatus +=
            //new ActProgTypeLib._IActProgTypeEvents_OnDeviceStatusEventHandler(ActProgType1_OnDeviceStatus);
            // Create EventHandler(ActUtlType)
            //_ipcomReferencesUtlType.OnDeviceStatus +=
            //    new ActUtlTypeLib._IActUtlTypeEvents_OnDeviceStatusEventHandler(ActUtlType1_OnDeviceStatus);
            /**************************************************************************/
        }
        ~SimEngine()
        {
            _ipcomReferencesUtlType.Close();
        }
        #region "Additional initialization (including Form_Load processing)"

        #endregion
        #region "Processing of OnDeviceStatus for ActUtlType Controle"
        //private void ActUtlType1_OnDeviceStatus(String szDevice, int iData, int iReturnCode)
        //{
        //    System.String[] arrData;	        //Array for 'Data'
        //    Assign the array for the read data.
        //    arrData = new System.String[txt_Data.Lines.Length + 1];

        //    Copy the read data to the 'arrData'.
        //    Array.Copy(txt_Data.Lines, arrData, txt_Data.Lines.Length);

        //    Add the content of new event to arrData.
        //    arrData[txt_Data.Lines.Length]
        //    = String.Format("OnDeviceStatus event by ActUtlType [{0}={1}]", szDevice, iData);

        //    The new 'Data' is displayed.
        //    txt_Data.Lines = arrData;

        //    The return code of the method is displayed by the hexadecimal.
        //    txt_ReturnCode.Text = String.Format("0x{0:x8}", iReturnCode);

        //}
        #endregion
        public void RunAuto(int interval)
        {
            Initialize(_eventInterval);
            var components = _eventable.GetKeys();
            components.Remove("");
            
            for (int i = 0; i < _eventable.GetEventsLength(); ++i)
            {
                _pivot = i; // 자동 모두에서는 Pivot 의미 없음
                var component_value = _eventable.GetEvents(_pivot);
                // 구조 맞추는 작업
                Dictionary<string, short> batch = new Dictionary<string, short>();
                for (int j = 0; j < component_value.Count; ++j)
                {
                    batch.Add(components[j], (short)component_value[j]);
                }
                runToDevice(batch);
                Thread.Sleep(_eventInterval);
            }
        }
        public void RunManual()
        {
        }
        public void Pause()
        {
        }
        public void Stop()
        {
        }
        public void Release()
        {
        }
        private void runToDevice(Dictionary<string, short> devices)
        {
            short _readOutput;
            foreach (var device in devices)
            {
                _ipcomReferencesUtlType.WriteDeviceRandom2(device.Key, 1, device.Value);
                Thread.Sleep(1000);

                //device(ex. X0, Y0)의 현재 상태가 ON인지 OFF인지 가져올 수 있음 이 예시는 컨베이어 작동 램프(M1000)의 상태를 가져옴
                _ipcomReferencesUtlType.ReadDeviceRandom2("M1000", 1, out _readOutput);
                var a = _readOutput;
            }
        }

        private void SetEvents(EventHandler table)
        {
            _eventable = table;
        }
        private void Initialize(int interval)
        {
            Steps = 0;
            Tnow = 0f;
            _eventInterval = interval;
            Reset();
        }
        private void Reset()
        {
            _ipcomReferencesUtlType.Close();
            if (_ipcomReferencesUtlType.Open() != 1)
                _ipcomReferencesUtlType.Open();

            _ipcomReferencesUtlType.ActLogicalStationNumber = 0;
            //센서 등에 의해서 동작하는 경우 모듈을 따로 생성해서 해당 모듈 내의 RunToModule로 PLC 및 HMI 동작 구현
            ConveyorSensor conveyorSensor = new ConveyorSensor();
            conveyorSensor.RunToModule(_ipcomReferencesUtlType); // 이게 왜 구현되어 있는지 알아봐야함
            _pivot = 0;
        }
        private void NextEvent()
        {
        }
    }
}
