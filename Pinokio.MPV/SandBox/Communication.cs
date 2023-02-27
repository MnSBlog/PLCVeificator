using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    internal class Communication
    {
        private ActUtlTypeLib.ActUtlTypeClass _ipcomReferencesUtlType;
        public short[] id = new short[] { 0, 0, 0, 0};
        public short[] pw = new short[] { 0, 0, 0, 0};
        public Communication() 
        {
            _ipcomReferencesUtlType = new ActUtlTypeLib.ActUtlTypeClass();
        }

        private void Initialize()
        {
            _ipcomReferencesUtlType.ActLogicalStationNumber = 0;
            _ipcomReferencesUtlType.Close();
            if (_ipcomReferencesUtlType.Open() != 1)
                _ipcomReferencesUtlType.Open();
        }

        public void Login()
        {
            var input = Console.ReadLine();
            ASCIIEncoding ascii = new ASCIIEncoding();
            String decodedID = "";
            String decodedPW = "";

            Initialize();

            if (input == "로그인시도")
            {
                while (id[0] == 0 || pw[0] ==0) 
                {
                    _ipcomReferencesUtlType.ReadDeviceRandom2("D10\nD11\nD12\nD13", 4, out id[0]);
                    _ipcomReferencesUtlType.ReadDeviceRandom2("D30\nD31\nD32\nD33", 4, out pw[0]);
  
                }
            
                foreach (var bytes in id)
                {
                    var textID = BitConverter.GetBytes(bytes);
                    decodedID += ascii.GetString(textID);
                }
                foreach (var bytes in pw)
                {
                    var textPW = BitConverter.GetBytes(bytes);
                    decodedPW += ascii.GetString(textPW);
                }
                decodedID = decodedID.TrimEnd();
                decodedPW = decodedPW.TrimEnd();

                if(decodedID == "BS123" && decodedPW == "MNS3327")
                {
                    Console.WriteLine("로그인성공");
                }
                else
                    Console.WriteLine("로그인실패");
            }

        }
    }
}
