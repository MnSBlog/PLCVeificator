using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest
{
    internal class Communication
    {
        private ActUtlTypeLib.ActUtlTypeClass _ipcomReferencesUtlType;
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
            string id;
            string pw;

            Initialize();
            var input = Console.ReadLine();

            if(input == "로그인시도")
            {
                while(id !=null && pw != null) 
                {
                    _ipcomReferencesUtlType.ReadDeviceRandom2('D0', 1, out id);
                    _ipcomReferencesUtlType.ReadDeviceRandom2('D20', 1, out pw);
                }

                Console.WriteLine("로그인성공");
            }

        }
    }
}
