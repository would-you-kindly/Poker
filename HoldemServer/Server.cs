using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
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
        const int maxPlayersCount = 6;
        // Информация об игроках
        List<ServerPlayerInfo> players;

        // Очередь сообщений для уведомления всех текущих клиентов о новом игроке
        MessageQueue queue;

        TcpListener listener;
        Socket tcpSocket;
        List<Thread> clients;
        bool work = true;

        public Server()
        {
            players = new List<ServerPlayerInfo>();
            listener = new TcpListener(Helper.port);
            clients = new List<Thread>();

            queue = new MessageQueue("FormatName:MULTICAST=234.1.1.1:8001");
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(ServerPlayerInfo) });

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

        public void ReceivePlayerInfo()
        {
            // Получаем информацию о клиенте
            byte[] bytes = new byte[1024];
            tcpSocket.Receive(bytes);
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream(bytes))
            {
                // TODO: В это месте упало в случайный момент времени почему-то
                PlayerInfo info = (PlayerInfo)formatter.Deserialize(memory);
                ServerPlayerInfo serverInfo = new ServerPlayerInfo(info.name, info.money, FindSeat());
                players.Add(serverInfo);
                Console.WriteLine($"Player {info.name} with ${info.money} connected");
            }
        }

        private int FindSeat()
        {
            int seat = 0;

            foreach (ServerPlayerInfo player in players)
            {
                if (player.seat == seat)
                {
                    seat++;
                }
                else
                {
                    return seat;
                }
            }

            return seat;
        }

        private void Receive()
        {
            ReceivePlayerInfo();
            SendServerPlayerInfo();


            Console.WriteLine(tcpSocket.LocalEndPoint);
            Console.WriteLine(tcpSocket.RemoteEndPoint);

            while (work)
            {

            }
        }

        private void SendServerPlayerInfo()
        {
            foreach (ServerPlayerInfo player in players)
            {
                queue.Send(player);
            }
        }
    }
}
