using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace SandBox
{
    internal class SocketClient
    {
        IPEndPoint _ipep;

        public SocketClient()
        {
            _ipep = new IPEndPoint(IPAddress.Any, 0);
        }
     


    }
}
