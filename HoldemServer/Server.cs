using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HoldemServer
{
    class Server
    {
        TcpListener listener;
        Socket tcpSocket;
        List<Thread> clients;
        bool work = true;

        public Server()
        {
            listener = new TcpListener(Helper.port);
            clients = new List<Thread>();
            Console.WriteLine(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].MapToIPv4());
        }

        public void Start()
        {
            listener.Start();
            while (work)
            {
                // Ждем подключения нового клиента
                tcpSocket = listener.AcceptSocket();
                clients.Add(new Thread(Receive));
                clients[clients.Count - 1].Start();
            }
        }

        private void Receive()
        {
            byte[] bytes = new byte[1024];
            // Ждем ответа от клиента
            tcpSocket.Receive(bytes);
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream(bytes))
            {
                PlayerInfo info = (PlayerInfo)formatter.Deserialize(memory);
                Console.WriteLine($"Player {info.name} with ${info.money} connected");
            }

            while (work)
            {
                
            }
        }
    }
}
