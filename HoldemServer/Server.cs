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

        // Очередь сообщений для широковещательного уведомления
        MessageQueue queue;

        // Игра (текущая раздача)
        Game game;

        TcpListener listener;
        Socket tcpSocket;
        List<Thread> clients;
        bool work = true;

        public Server()
        {
            players = new List<ServerPlayerInfo>();
            deck = new CardDeck();
            game = new Game(deck);

            listener = new TcpListener(Helper.port);
            clients = new List<Thread>();

            queue = new MessageQueue("FormatName:MULTICAST=234.1.1.1:8000");
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

                // Начинаем новую раздачу, когда за столом окажется минимум два игрока
                // TODO: зависает при присоединении третьего, нужно сдеать в отдельном потоке
                if (clients.Count >= 2 && !game.playing)
                {
                    Thread.Sleep(3000);
                    var involvedPlayers = game.StartNewGame(new List<ServerPlayerInfo>(players));
                    UpdatePlayersFromInvolved(involvedPlayers);
                    SendServerPlayerInfoByQueue();
                }
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
            for (int i = 0; i < Helper.maxPlayers; i++)
            {
                if (players.Find(p => p.seat == i) == null)
                {
                    return i;
                }
            }

            return 0;
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
                        case TurnType.Check:
                        case TurnType.Call:
                        case TurnType.Raise:
                            // Получаем обновленную информацию об участвовавших в раздаче игроках
                            var involvedPlayers = game.MakeTurn(seat, turn);
                            UpdatePlayersFromInvolved(involvedPlayers);
                            break;
                        case TurnType.Exit:
                            game.involvedPlayers.Find(p => p.seat == seat).isPlaying = false;
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

        private void UpdatePlayersFromInvolved(List<ServerPlayerInfo> involvedPlayers)
        {
            for (int i = 0; i < players.Count; i++)
            {
                int seat = players[i].seat;
                ServerPlayerInfo player = involvedPlayers.Find(p => p.seat == seat);
                if (player != null)
                {
                    players[i] = player;
                }
            }
        }

        private void GiveCards(int seat)
        {
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
