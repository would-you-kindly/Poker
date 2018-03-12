using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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
        public List<ServerPlayerInfo> involvedPlayers;
        int littleBlind = 10;
        int bigBlind = 20;
        int biggestRate;
        public bool playing;
        int bank;
        GameState state;
        CardDeck _deck;
        List<Card> cardsOnTable;
        bool mailslotConnected = false;
        int diller = 0;

        // Дескриптор мэйлслота для раздачи карт на стол (flop, turn, river)
        private Int32 mailslotHandle;
        private string mailslotName = "\\\\*\\mailslot\\ReceiveCardsMailslot";


        public Game(CardDeck deck)
        {
            involvedPlayers = new List<ServerPlayerInfo>();
            cardsOnTable = new List<Card>(5);
            cardsOnTable.Add(null);
            cardsOnTable.Add(null);
            cardsOnTable.Add(null);
            cardsOnTable.Add(null);
            cardsOnTable.Add(null);
            _deck = deck;
            playing = false;
        }

        public List<ServerPlayerInfo> StartNewGame(List<ServerPlayerInfo> involvedPlayers)
        {
            // Текущая раздача начата
            playing = true;
            state = GameState.FirtsBlind;

            // Проводим приготовляния перед началом игры
            foreach (var player in involvedPlayers)
            {
                player.isPlaying = true;
                player.yourMove = false;
                player.isWinner = false;
                player.currentRate = 0;
                player.diller = false;
                player.madeTurn = false;
                // Раздаем карты участвующим игрокам
                GiveCards(player);
            }

            // Запоминаем участвующих игроков в данной раздаче
            this.involvedPlayers = involvedPlayers;
            involvedPlayers[(diller + 0) % involvedPlayers.Count].diller = true;
            involvedPlayers[(diller + 1) % involvedPlayers.Count].currentRate = littleBlind;
            involvedPlayers[(diller + 2) % involvedPlayers.Count].currentRate = bigBlind;
            involvedPlayers[(diller + 3) % involvedPlayers.Count].yourMove = true;
            diller = (diller + 1) % involvedPlayers.Count;

            // Запоминаем наибольшую ставку на столе
            biggestRate = bigBlind;

            // Обнуляем сумму всех ставок
            bank = littleBlind + bigBlind;

            // Подключаемся к mailslot
            if (!mailslotConnected)
            {
                ConnectMailslot();
            }

            Console.WriteLine("New game started!");
            Console.WriteLine("The players are:");
            foreach (var player in involvedPlayers)
            {
                Console.WriteLine($"Player {player.name} with ${player.money}");
            }

            // Возвращаем обновленную информацию об игроках после старта игры
            return involvedPlayers;
        }

        private void GiveCards(ServerPlayerInfo player)
        {
            player.card1 = _deck.GetRandomCard();
            player.card2 = _deck.GetRandomCard();
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
                    mailslotConnected = true;
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
            _deck.Reset();
            for (int i = 0; i < cardsOnTable.Count; i++)
            {
                cardsOnTable[i] = null;
            }
            SendGameEnd();
            //Mailslot.CloseHandle(mailslotHandle);
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

            foreach (var player in involvedPlayers)
            {
                if (!player.madeTurn)
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

            involvedPlayers[playerIndex].madeTurn = true;

            // Проверяем, остался ли только один игрок в данной раздаче
            if (involvedPlayers.Count(p => p.isPlaying) == 1)
            {
                SetWinner(involvedPlayers.Where(p => p.isPlaying).First().seat);
                EndGame();
                return involvedPlayers;
            }

            // Проверяем, все ли сделали окончательные ставки в текущем круге
            if (ChechRatesFinished())
            {
                // Переводим игру в следующее состояние
                state = (GameState)((int)(state + 1) % (int)GameState.Count);

                foreach (var player in involvedPlayers)
                {
                    player.madeTurn = false;
                }

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
                        ComputeRates();
                        biggestRate = 0;
                        GiveTurn();
                        break;
                    case GameState.River:
                        ComputeRates();
                        biggestRate = 0;
                        GiveRiver();
                        break;
                    case GameState.Count:
                        // Определяем победителя
                        SetWinner(FindWinner());
                        EndGame();
                        break;
                    default:
                        break;
                }
            }

            return involvedPlayers;
        }

        private void SetWinner(int seat)
        {
            ServerPlayerInfo player = involvedPlayers.Find(p => p.seat == seat);
            player.isWinner = true;
            player.money += bank;
            Console.WriteLine($"Player {player.name} wins and takes {bank}");
        }

        private int FindWinner()
        {
            Dictionary<int, int> combinationsWeights = new Dictionary<int, int>();
            // Ищем максимальную комбинаю среди игроков, которые еще не скинули карты
            foreach (var player in involvedPlayers.Where(p => p.isPlaying))
            {
                combinationsWeights.Add(player.seat, new Combination(player.card1, player.card2,
                    cardsOnTable[0], cardsOnTable[1], cardsOnTable[2], cardsOnTable[3], cardsOnTable[4]).ComputeWeight());
            }

            var pair = combinationsWeights.Max();
            int winner = pair.Key;

            return winner;
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
                Console.WriteLine($"River is {river.ToString()}");
            }

            cardsOnTable[4] = river;
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

            cardsOnTable[3] = turn;
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

            cardsOnTable[0] = flop1;
            cardsOnTable[1] = flop2;
            cardsOnTable[2] = flop3;
        }

        // Отправляем несуществующую карту как признак окончания раздачи
        private void SendGameEnd()
        {
            // Количество реально записанных в мэйлслот байт
            uint bytesWritten = 0;

            Card endGame = new Card(CardSuit.Count, CardQuality.Count);

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream())
            {
                byte[] bytes = new byte[400];
                // Выдаем пятую карту (river)
                formatter.Serialize(memory, endGame);
                bytes = memory.ToArray();
                // Выполняем запись последовательности байт в мэйлслот
                Mailslot.WriteFile(mailslotHandle, bytes, Convert.ToUInt32(bytes.Length), ref bytesWritten, 0);
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
