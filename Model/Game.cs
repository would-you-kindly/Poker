using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum GameState
    {
        // Первый сбор ставок
        FirtsBlind,
        // После выдачи первых трех карт
        Flop,
        // После выдачи четвертой карты
        Turn,
        // После выдачи пятой карты
        River,

        Count
    }

    public class Game
    {
        List<ServerPlayerInfo> involvedPlayers;
        int littleBlind = 10;
        int bigBlind = 20;
        int biggestRate;
        bool playing;
        int bank;
        GameState state;
        CardDeck _deck;

        // Дескриптор мэйлслота для раздачи карт на стол (flop, turn, river)
        private Int32 mailslotHandle;
        private string mailslotName = "\\\\*\\mailslot\\ReceiveCardsMailslot";



        public Game(CardDeck deck)
        {
            involvedPlayers = new List<ServerPlayerInfo>();
            _deck = deck;
        }

        public List<ServerPlayerInfo> StartNewGame(List<ServerPlayerInfo> involvedPlayers)
        {
            // Текущая раздача начата
            playing = true;
            state = GameState.FirtsBlind;

            // Говорим, что в начале игры все участвуют в раздаче
            foreach (var player in involvedPlayers)
            {
                player.isPlaying = true;
            }

            // Запоминаем участвующих игроков в данной раздаче
            this.involvedPlayers = involvedPlayers;
            involvedPlayers[0 % involvedPlayers.Count].diller = true;
            involvedPlayers[1 % involvedPlayers.Count].currentRate = littleBlind;
            involvedPlayers[2 % involvedPlayers.Count].currentRate = bigBlind;
            involvedPlayers[3 % involvedPlayers.Count].yourMove = true;

            // Запоминаем наибольшую ставку на столе
            biggestRate = bigBlind;

            // Обнуляем сумму всех ставок
            bank = 0;

            // Подключаемся к mailslot
            ConnectMailslot();

            // Возвращаем обновленную информацию об игроках после старта игры
            return involvedPlayers;
        }

        private void ConnectMailslot()
        {
            try
            {
                // Подключаемся для выполнения широковещательной передачи
                mailslotHandle = Mailslot.CreateFile(mailslotName,
                    Types.EFileAccess.GenericWrite, Types.EFileShare.Write, 0, Types.ECreationDisposition.CreateAlways, 0, 0);
                if (mailslotHandle != -1)
                {
                    Console.WriteLine("Соединение с мейлслотом прошло успешно");
                }
                else
                {
                    Console.WriteLine("Не удалось подключиться к мейлслоту");
                }
            }
            catch
            {
                Console.WriteLine("Не удалось подключиться к мейлслоту");
            }
        }

        public void EndGame()
        {
            playing = false;
            biggestRate = 0;
            bank = 0;
            Mailslot.CloseHandle(mailslotHandle);     // закрываем дескриптор мэйлслота
        }

        // Проверяем, закончили ли игроки делать ставки (у всех равны)
        public bool ChechRatesFinished()
        {
            // Проверяем равенство ставок у еще играющих игроков
            for (int i = 0; i < involvedPlayers.Count - 1; i++)
            {
                if (!involvedPlayers[i].isPlaying)
                {
                    continue;
                }
                if (involvedPlayers[i].currentRate != involvedPlayers[i + 1].currentRate)
                {
                    return false;
                }
            }

            return true;
        }

        public List<ServerPlayerInfo> MakeTurn(int seat, Turn turn)
        {
            int playerIndex = involvedPlayers.FindIndex(p => p.seat == seat);

            switch (turn.turnType)
            {
                case TurnType.Fold:
                    // Говорим, что игрок больше не участвует в данной раздаче
                    involvedPlayers[playerIndex].isPlaying = false;
                    // Передаем ход следующему все еще играющему игроку игроку
                    involvedPlayers[playerIndex].yourMove = false;
                    do
                    {
                        playerIndex = (playerIndex + 1) % involvedPlayers.Count;
                    } while (!involvedPlayers[playerIndex].isPlaying);
                    involvedPlayers[playerIndex].yourMove = true;
                    break;
                case TurnType.Check:
                    // Передаем ход следующему все еще играющему игроку игроку
                    involvedPlayers[playerIndex].yourMove = false;
                    do
                    {
                        playerIndex = (playerIndex + 1) % involvedPlayers.Count;
                    } while (!involvedPlayers[playerIndex].isPlaying);
                    involvedPlayers[playerIndex].yourMove = true;
                    break;
                case TurnType.Call:
                    // Вычитаем ставку со счета игрока
                    if (biggestRate == 0)
                    {
                        biggestRate = bigBlind;
                    }
                    involvedPlayers[playerIndex].money -= (biggestRate - involvedPlayers[playerIndex].currentRate);
                    // Сравниваем ставку с наибольшей ставкой на столе
                    involvedPlayers[playerIndex].currentRate = biggestRate;
                    // Передаем ход следующему все еще играющему игроку игроку
                    involvedPlayers[playerIndex].yourMove = false;
                    do
                    {
                        playerIndex = (playerIndex + 1) % involvedPlayers.Count;
                    } while (!involvedPlayers[playerIndex].isPlaying);
                    involvedPlayers[playerIndex].yourMove = true;
                    break;
                case TurnType.Raise:
                    // Запоминаем, что после повышения ставки текущая становится самой большой на столе
                    biggestRate = turn.money.Value;
                    // Вычитаем ставку со счета игрока
                    involvedPlayers[playerIndex].money -= (biggestRate - involvedPlayers[playerIndex].currentRate);
                    // Сравниваем ставку с наибольшей ставкой на столе
                    involvedPlayers[playerIndex].currentRate = biggestRate;
                    // Передаем ход следующему все еще играющему игроку игроку
                    involvedPlayers[playerIndex].yourMove = false;
                    do
                    {
                        playerIndex = (playerIndex + 1) % involvedPlayers.Count;
                    } while (!involvedPlayers[playerIndex].isPlaying);
                    involvedPlayers[playerIndex].yourMove = true;
                    break;
                default:
                    break;
            }

            if (ChechRatesFinished())
            {
                // Переводим игру в следующее состояние
                state = (GameState)((int)(state + 1) % (int)GameState.Count);

                switch (state)
                {
                    case GameState.FirtsBlind:
                        // Ничего не делаем
                        break;
                    case GameState.Flop:
                        // Считаем все ставки (банк)
                        ComputeRates();
                        // Обнуляем наибольшую ставку
                        biggestRate = 0;
                        // Раздаем первые три карты (flop)
                        GiveFlop();
                        break;
                    case GameState.Turn:
                        // Считаем все ставки (банк)
                        ComputeRates();
                        // Обнуляем наибольшую ставку
                        biggestRate = 0;
                        // Раздаем четвертую карту (turn)
                        GiveTurn();
                        break;
                    case GameState.River:
                        // Считаем все ставки (банк)
                        ComputeRates();
                        // Обнуляем наибольшую ставку
                        biggestRate = 0;
                        // Раздаем пятую карту (river)
                        GiveRiver();
                        break;
                    case GameState.Count:
                        break;
                    default:
                        break;
                }
            }

            return involvedPlayers;
        }

        private void GiveRiver()
        {
            // Количество реально записанных в мэйлслот байт
            uint bytesWritten = 0;

            Card river = _deck.GetRandomCard();

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream())
            {
                byte[] bytes = new byte[400];
                // Выдаем пятую карту (river)
                formatter.Serialize(memory, river);
                bytes = memory.ToArray();
                // Выполняем запись последовательности байт в мэйлслот
                Mailslot.WriteFile(mailslotHandle, bytes, Convert.ToUInt32(bytes.Length), ref bytesWritten, 0);
                Console.WriteLine($"Turn is {river.ToString()}");
            }
        }

        private void GiveTurn()
        {
            // Количество реально записанных в мэйлслот байт
            uint bytesWritten = 0;

            Card turn = _deck.GetRandomCard();

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream())
            {
                byte[] bytes = new byte[400];
                // Выдаем червертую карту (turn)
                formatter.Serialize(memory, turn);
                bytes = memory.ToArray();
                // Выполняем запись последовательности байт в мэйлслот
                Mailslot.WriteFile(mailslotHandle, bytes, Convert.ToUInt32(bytes.Length), ref bytesWritten, 0);
                Console.WriteLine($"Turn is {turn.ToString()}");
            }
        }

        private void GiveFlop()
        {
            Card flop1 = _deck.GetRandomCard();
            Card flop2 = _deck.GetRandomCard();
            Card flop3 = _deck.GetRandomCard();

            BinaryFormatter formatter = new BinaryFormatter();

            // Выдаем первую карту flop'а
            using (MemoryStream memory = new MemoryStream())
            {
                // Количество реально записанных в мэйлслот байт
                uint bytesWritten = 0;
                byte[] bytes = new byte[400];

                formatter.Serialize(memory, flop1);
                bytes = memory.ToArray();
                // Выполняем запись последовательности байт в мэйлслот
                Mailslot.WriteFile(mailslotHandle, bytes, Convert.ToUInt32(bytes.Length), ref bytesWritten, 0);
                Console.WriteLine($"Flop1 is {flop1.ToString()}");
            }

            // Выдаем вторую карту flop'а
            using (MemoryStream memory = new MemoryStream())
            {
                uint bytesWritten = 0;
                byte[] bytes = new byte[400];
                formatter.Serialize(memory, flop2);
                bytes = memory.ToArray();
                Mailslot.WriteFile(mailslotHandle, bytes, Convert.ToUInt32(bytes.Length), ref bytesWritten, 0);
                Console.WriteLine($"Flop2 is {flop2.ToString()}");
            }

            // Выдаем третью карту flop'а
            using (MemoryStream memory = new MemoryStream())
            {
                uint bytesWritten = 0;
                byte[] bytes = new byte[400];
                formatter.Serialize(memory, flop3);
                bytes = memory.ToArray();
                Mailslot.WriteFile(mailslotHandle, bytes, Convert.ToUInt32(bytes.Length), ref bytesWritten, 0);
                Console.WriteLine($"Flop3 is {flop3.ToString()}");
            }
        }

        private void ComputeRates()
        {
            foreach (var player in involvedPlayers)
            {
                bank += player.currentRate;
            }
        }
    }
}
