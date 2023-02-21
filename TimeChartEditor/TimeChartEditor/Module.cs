using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeChartEditor
{
    internal class Module
    {
        public string Name;
        public string Address;
        public short ReadValue;
        public short TrueValue;

        public short[] ReadValues;
        public short[] TrueValues;

        public Module() : this("", "", 0, 0)
        {
        }
        public Module(string name) : this(name, "", 0, 0)
        {
        }
        public Module(string name, string address, short value) : this(name, address, 0, value)
        {
        }
        public Module(string name, string address, short readValue, short trueValue)
        {
            Name = name;
            Address = address;
            ReadValue = readValue;
            TrueValue = trueValue;
        }

        public bool IsDifferent()
        {
            if (Address.Contains("T") || Address.Contains("C"))
            {
                return ReadValue < TrueValue;
            }
            else
            {
                return ReadValue != TrueValue;
            }
        }


    }

    internal class ModuleList
    {
        private List<Module> _myModules = new List<Module>();
        private Module _writeModule = new Module("Write");
        private Module _readModule = new Module("Read");
        public ModuleList()
        {
        }
        public ModuleList(List<Module> modules)
        {
            _myModules = modules;
            SetModule();

        }
        private void SetModule(List<Module>? modules = null)
        {
            if (modules != null)
            {
                _myModules = modules;
            }

            List<short> WriteArray = new List<short>();
            List<short> ReadArray = new List<short>();
            string WriteAddress = "";
            string ReadAddress = "";

            foreach (var module in _myModules)
            {
                if (module.Name.Contains("X"))
                {
                    if (WriteAddress.Length > 0)
                        WriteAddress += "\n";
                    WriteAddress += module.Address;
                    WriteArray.Add(module.TrueValue);
                }

                if (ReadAddress.Length > 0)
                    ReadAddress += "\n";
                ReadAddress += module.Address;
                ReadArray.Add(module.TrueValue);
            }

            _writeModule.Address = WriteAddress;
            _writeModule.TrueValues = WriteArray.ToArray();
            _readModule.Address = ReadAddress;
            _readModule.ReadValues = new short[_myModules.Count];
            _readModule.TrueValues = ReadArray.ToArray(); ;

        }
        public Dictionary<string, Module> GetModules()
        {
            Dictionary<string, Module> damper = new Dictionary<string, Module>();
            if (_writeModule.TrueValues.Length > 0)
            {
                damper.Add("Write", _writeModule);
            }
            damper.Add("Read", _readModule);
            return damper;
        }

        public List<Module>? IsDifferent(out int TimeGap)
        {
            List<Module> ErrorDevices = new List<Module>();
            TimeGap = 0;
            for (int i = 0; i < _readModule.TrueValues.Count(); i++)
            {
                if (_myModules[i].Address.Contains("T") || _myModules[i].Address.Contains("C"))
                {
                    if (_readModule.ReadValues[i] < _readModule.TrueValues[i])
                    {
                        _myModules[i].TrueValue = _readModule.TrueValues[i];
                        _myModules[i].ReadValue = _readModule.ReadValues[i];
                        if (TimeGap < (_readModule.TrueValues[i] - _readModule.ReadValues[i]))
                        {
                            TimeGap = _readModule.TrueValues[i] - _readModule.ReadValues[i];
                        }
                        ErrorDevices.Add(_myModules[i]);
                    }
                }
                else
                {
                    if (!_readModule.TrueValues[i].Equals(_readModule.ReadValues[i]))
                    {
                        _myModules[i].TrueValue = _readModule.TrueValues[i];
                        _myModules[i].ReadValue = _readModule.ReadValues[i];
                        ErrorDevices.Add(_myModules[i]);
                    }
                }

            }
            if (ErrorDevices.Count() > 0)
                return ErrorDevices;
            else
                return null;

        }

    }

}
