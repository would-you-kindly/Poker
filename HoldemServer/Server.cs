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
        // Информация об игроках
        List<ServerPlayerInfo> players;

        // Колода карт 
        CardDeck deck;

        // Очередь сообщений для уведомления всех текущих клиентов о новом игроке
        MessageQueue queue;



        TcpListener listener;
        Socket tcpSocket;
        List<Thread> clients;
        bool work = true;

        public Server()
        {
            players = new List<ServerPlayerInfo>();
            deck = new CardDeck();
            listener = new TcpListener(Helper.port);
            clients = new List<Thread>();

            queue = new MessageQueue("FormatName:MULTICAST=234.1.1.1:8001");
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(List<ServerPlayerInfo>) });

            Console.WriteLine(Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].MapToIPv4());
        }

        public void Start()
        {
            listener.Start();
            while (work)
            {
                // Ждем подключения нового клиента
                tcpSocket = listener.AcceptSocket();
                clients.Add(new Thread(HandleClient));
                clients[clients.Count - 1].Start();
            }
        }

        public int ReceivePlayerInfo()
        {
            // Получаем информацию о новом подключившемся клиенте
            int seat = 0;
            byte[] bytes = new byte[1024];
            tcpSocket.Receive(bytes);
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream(bytes))
            {
                // TODO: В это месте упало в случайный момент времени почему-то
                PlayerInfo info = (PlayerInfo)formatter.Deserialize(memory);
                seat = FindSeat();
                ServerPlayerInfo serverInfo = new ServerPlayerInfo(info.name, info.money, info.endPoint, seat);
                players.Add(serverInfo);
                Console.WriteLine($"Player {info.name} with ${info.money} seat on {seat}");
            }

            return seat;
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

        private void HandleClient()
        {
            // Присоединение нового клиента
            int seat = ReceivePlayerInfo();
            GiveCards(seat);
            SendServerPlayerInfoByQueue();


            Console.WriteLine(tcpSocket.LocalEndPoint);
            Console.WriteLine(tcpSocket.RemoteEndPoint);

            // Обработка запросов клиента
            while (work)
            {
                // Получаем действия игрока (ходы)
                byte[] bytes = new byte[1024];
                // TODO: Если закрыть последнего клиента, говорит удаленный хост принудительо разорвал соединеие
                tcpSocket.Receive(bytes);
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream memory = new MemoryStream(bytes))
                {
                    Turn turn = (Turn)formatter.Deserialize(memory);

                    switch (turn.turnType)
                    {
                        case TurnType.Fold:
                            break;
                        case TurnType.Check:
                            break;
                        case TurnType.Call:
                            break;
                        case TurnType.Raise:
                            break;
                        case TurnType.Exit:
                            ServerPlayerInfo info = players.Find(player => player.seat == seat);
                            players.Remove(info);
                            Console.WriteLine($"Player {info.name} leaves game");
                            break;
                        default:
                            break;
                    }

                    SendServerPlayerInfoByQueue();
                }
            }
        }

        private void GiveCards(int seat)
        {
            // TODO: пока карты могут повторяться
            ServerPlayerInfo player = players.Find(p => p.seat == seat);
            player.card1 = deck.GetRandomCard();
            player.card2 = deck.GetRandomCard();
        }

        private void SendServerPlayerInfoByQueue()
        {
            queue.Send(players);
        }
    }
}
