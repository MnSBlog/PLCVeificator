using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;

namespace TimeChartEditor
{
    internal class SimEngine
    {
        private int _pivot = 0;
        private int _eventInterval = 0;
        private EventHandler _eventable;
        private Dictionary<int, List<Module>> _errorDictionary = new Dictionary<int, List<Module>>();
        /*The declaration of instance value for ACT controls************************/
        // When you use Dot controls by 'References', you should program as follows;
        private ActUtlTypeLib.ActUtlTypeClass _ipcomReferencesUtlType;
        //private ActProgTypeLib.ActProgTypeClass lpcom_ReferencesProgType;
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
            Initialize(interval);
            var key = _eventable.GetKeys();
            var address = _eventable.GetAddress();
            key.Remove("");
            address.Remove("");
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < _eventable.GetEventsLength(); ++i)
            {
                stopwatch.Restart();
                _pivot = i; // 자동 모두에서는 Pivot 의미 없음
                var component_value = _eventable.GetEvents(_pivot);
                // 구조 맞추는 작업
                List<Module> batch = new List<Module>();
                for (int j = 0; j < component_value.Count; ++j)
                {
                    Module module = new Module(key[j], address[j], (short)component_value[j]);

                    batch.Add(module);
                }
                runToDevice(_pivot, batch);

                stopwatch.Stop();
                var ProcessTime = stopwatch.ElapsedMilliseconds;
                if (ProcessTime > interval)
                {
                    // 검증불가 Code: ERR
                    return;
                }
                if (_pivot > 0)
                    Thread.Sleep(_eventInterval - (int)ProcessTime);
            }
            _errorDictionary.Clear();
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
        private void runToDevice(int step, List<Module> modules)
        {
            ModuleList PlcDevices = new ModuleList(modules);
            var batch = PlcDevices.GetModules();
            if (batch.ContainsKey("Write"))
            {
                var WriteDevice = batch["Write"];
                _ipcomReferencesUtlType.WriteDeviceRandom2(WriteDevice.Address, WriteDevice.TrueValues.Length, ref WriteDevice.TrueValues[0]);
            }
            var ReadDevice = batch["Read"];
            _ipcomReferencesUtlType.ReadDeviceRandom2(ReadDevice.Address, ReadDevice.ReadValues.Length, out ReadDevice.ReadValues[0]);
            int TimeGap = 0;
            var Check = PlcDevices.IsDifferent(out TimeGap);
            while (TimeGap != 0)
            {
                Thread.Sleep((TimeGap * 100) - 2);
                _ipcomReferencesUtlType.ReadDeviceRandom2(ReadDevice.Address, ReadDevice.ReadValues.Length, out ReadDevice.ReadValues[0]);
                Check = PlcDevices.IsDifferent(out TimeGap);
            }
            if (Check != null)
                _errorDictionary.Add(step, Check);
        }

        private void SetEvents(EventHandler table)
        {
            _eventable = table;
        }
        private void Initialize(int interval)
        {
            Steps = 0;
            Tnow = 0f;
            _eventInterval = interval-1;
            Reset();
        }
        private void Reset()
        {
            _ipcomReferencesUtlType.Close();
            if (_ipcomReferencesUtlType.Open() != 1)
                _ipcomReferencesUtlType.Open();

            _ipcomReferencesUtlType.ActLogicalStationNumber = 0;
            _pivot = 0;
            _errorDictionary.Clear();
        }
        private void NextEvent()
        {
        }
        public void NeedCalibration()
        {

        }
    }
}
