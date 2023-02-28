using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SandBox
{
    internal class SocketServer
    {
        IPEndPoint _ipep;
        public SocketServer()
        {
            _ipep = new IPEndPoint(IPAddress.Any, 0);
        }
        public async Task Initialize(int port)
        {
            _ipep = new IPEndPoint(IPAddress.Any, port);
            using (Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {

                server.Bind(_ipep);
                server.Listen(3);
                Console.WriteLine($"Server Start... Listen port {_ipep.Port}...");
                var task = new Task(() =>
                {
                   
                    while (true)
                    {
                       
                        var client = server.Accept();
                        new Task(() =>
                        {
                           
                            var ip = client.RemoteEndPoint as IPEndPoint;
                            client.Send(Encoding.ASCII.GetBytes("test\r\n>"));
                            var sb = new StringBuilder();
                            using (client)
                            {
                                while (true)
                                {
                                    var binary = new Byte[1024];
                                    client.Receive(binary);
                                    var data = Encoding.ASCII.GetString(binary);
                                    // 메시지 공백(\0)을 제거s
                                    sb.Append(data.Trim('\0'));
                                    // 메시지 총 내용이 2글자 이상이고 개행(\r\n)이 발생하면
                                    if (sb.Length > 2 && sb[sb.Length - 2] == '\r' && sb[sb.Length - 1] == '\n')
                                    {
                                        // 메시지 버퍼의 내용을 String으로 변환
                                        data = sb.ToString().Replace("\n", "").Replace("\r", "");
                                        // 메시지 내용이 공백이라면 계속 메시지 대기 상태로
                                        if (String.IsNullOrWhiteSpace(data))
                                        {
                                            continue;
                                        }
                                        // 메시지 내용이 exit라면 무한 루프 종료(즉, 서버 종료)
                                        if ("EXIT".Equals(data, StringComparison.OrdinalIgnoreCase))
                                        {
                                            break;
                                        }
                                        // 메시지 내용을 콘솔에 표시
                                        Console.WriteLine("Message = " + data);
                                        // 버퍼 초기화
                                        sb.Length = 0;
                                        // 메시지에 ECHO를 붙힘
                                        var sendMsg = Encoding.ASCII.GetBytes("ECHO : " + data + "\r\n>");
                                        // 클라이언트로 메시지 송신
                                        client.Send(sendMsg);
                                    }
                                }
                                // 콘솔 출력 - 접속 종료 메시지
                                Console.WriteLine($"Disconnected : (From: {ip.Address.ToString()}:{ip.Port}, Connection time: {DateTime.Now})");
                            }
                            // Task 실행
                        }).Start();
                    }
                });
                // Task 실행
                task.Start();
                // 대기
                await task;
            }
        }
    }
}
