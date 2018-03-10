using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game
    {
        List<ServerPlayerInfo> involvedPlayers;
        int littleBlind = 10;
        int bigBlind = 20;
        int biggestRate;
        bool playing;

        public Game()
        {
            involvedPlayers = new List<ServerPlayerInfo>();
        }

        public void StartNewGame(List<ServerPlayerInfo> involvedPlayers)
        {
            // Текущая раздача начата
            playing = true;
            // Запоминаем участвующих игроков в данной раздаче
            this.involvedPlayers = involvedPlayers;
            involvedPlayers[0].diller = true;
            involvedPlayers[1].currentRate = littleBlind;
            involvedPlayers[0].currentRate = bigBlind;
            involvedPlayers[1].yourMove = true;

            // Запоминаем наибольшую ставку на столе
            biggestRate = bigBlind;
        }

        public void EndGame()
        {
            playing = false;
            biggestRate = 0;
        }

        // Проверяем, закончили ли игроки делать ставки (у всех равны)
        public bool ChechRatesFinished()
        {
            for (int i = 0; i < involvedPlayers.Count - 1; i++)
            {
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
                    break;
                case TurnType.Check:
                    // Передаем ход следующему игроку
                    involvedPlayers[playerIndex].yourMove = false;
                    involvedPlayers[(playerIndex + 1) % involvedPlayers.Count].yourMove = false;
                    break;
                case TurnType.Call:
                    // Вычитаем ставку со счета игрока
                    involvedPlayers[playerIndex].money -= (biggestRate - involvedPlayers[playerIndex].currentRate);
                    // Сравниваем ставку с наибольшей ставкой на столе
                    involvedPlayers[playerIndex].currentRate = biggestRate;
                    // Передаем ход следующему игроку
                    involvedPlayers[playerIndex].yourMove = false;
                    involvedPlayers[(playerIndex + 1) % involvedPlayers.Count].yourMove = false;
                    break;
                case TurnType.Raise:
                    break;
                default:
                    break;
            }

            return involvedPlayers;
        }
    }
}
