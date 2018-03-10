using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class Player
    {
        public TcpClient client;

        PlayerInfo info;
        //int rate;
        //bool isDiller;

        public Player()
        {
            // Подключаем нового клиента к серверу
            client = new TcpClient();
            client.Connect("", Helper.port);

            // Отправляем на сервер информацию о себе
            info = new PlayerInfo("sdf", new Random().Next(1000));
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
            MessageBox.Show(client.Client.LocalEndPoint.ToString());
            return new Turn(TurnType.Fold);
        }

        public Turn Check()
        {
            return new Turn(TurnType.Check);
        }

        public Turn Call(int money)
        {
            return new Turn(TurnType.Call, money);
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
