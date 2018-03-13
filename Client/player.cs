using Model;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    class Player
    {
        public TcpClient client;

        public PlayerInfo info;
        //int rate;
        //bool isDiller;

        public Player()
        {
            // Подключаем нового клиента к серверу
            client = new TcpClient();
            client.Connect("", Helper.port);
            //client.Client.ReceiveBufferSize = int.MaxValue;
            //client.Client.SendBufferSize = int.MaxValue;

            // Отправляем на сервер информацию о себе
            info = new PlayerInfo(Helper.GetName(), 1000, client.Client.LocalEndPoint.ToString());
            SendPlayerInfo();
        }

        private void SendPlayerInfo()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream())
            {
                formatter.Serialize(memory, info);
                Stream stream = client.GetStream();
                byte[] bytes = memory.ToArray();
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public Turn Fold()
        {
            return new Turn(TurnType.Fold);
        }

        public Turn Check()
        {
            return new Turn(TurnType.Check);
        }

        public Turn Call()
        {
            return new Turn(TurnType.Call);
        }

        public Turn Raise(int money)
        {
            return new Turn(TurnType.Raise, money);
        }

        public Turn Exit()
        {
            return new Turn(TurnType.Exit);
        }
    }
}
