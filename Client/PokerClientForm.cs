﻿using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class PokerClientForm : Form
    {
        Player player;
        bool work = true;

        MessageQueue queue;
        string multicastAddress = "234.1.1.1:8000";
        string path = ".\\private$\\MulticastTest" + new Random().Next(10000);

        public PokerClientForm()
        {
            InitializeComponent();
            InitPictureBoxes();
            InitControls();

            InitMessageQueue();

            StartGame();
        }

        private void InitMessageQueue()
        {
            if (MessageQueue.Exists(path))
            {
                // Здесь создается только переменная в данной программе
                queue = new MessageQueue(path);
            }
            else
            {
                // А здесь и переменная и очередь сообщений во внешней службе
                queue = MessageQueue.Create(path);
            }

            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(List<ServerPlayerInfo>) });
            queue.MulticastAddress = multicastAddress;
        }

        private void StartGame()
        {
            player = new Player();

            // Получаем информацию об игроках на сервере
            Thread threadPlayerInfo = new Thread(ReceiveServerPlayerInfo);
            threadPlayerInfo.Start();

            // Получаем карты (flop, turn, river)
            Thread threadCards = new Thread(ReceiveCards);
            threadCards.Start();
        }

        private void ReceiveCards()
        {
            int ClientHandleMailSlot;   // дескриптор мэйлслота
            ClientHandleMailSlot = Mailslot.CreateMailslot("\\\\.\\mailslot\\ReceiveCardsMailslot", 0, Types.MAILSLOT_WAIT_FOREVER, 0);
            Card card = new Card();     // прочитанное сообщение
            Card prevCard = new Card(); // для проверки в случае, когда отправляется одно и то же сообщение несколько раз
            int MailslotSize = 0;       // максимальный размер сообщения
            int lpNextSize = 0;         // размер следующего сообщения
            int MessageCount = 0;       // количество сообщений в мэйлслоте
            uint realBytesReaded = 0;   // количество реально прочитанных из мэйлслота байтов

            while (work)
            {
                Mailslot.GetMailslotInfo(ClientHandleMailSlot, MailslotSize, ref lpNextSize, ref MessageCount, 0);
                if (MessageCount > 0)
                {
                    for (int i = 0; i < MessageCount; i++)
                    {
                        byte[] bytes = new byte[400];                       // буфер прочитанных из мэйлслота байтов
                        Mailslot.FlushFileBuffers(ClientHandleMailSlot);    // "принудительная" запись данных, расположенные в буфере операционной системы, в файл мэйлслота
                        Mailslot.ReadFile(ClientHandleMailSlot, bytes, 400, ref realBytesReaded, 0);      // считываем последовательность байтов из мэйлслота в буфер buff
                        BinaryFormatter formatter = new BinaryFormatter();
                        using (MemoryStream memory = new MemoryStream(bytes))
                        {
                            card = (Card)formatter.Deserialize(memory);
                            if (card != prevCard)
                            {
                                prevCard = card;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        Invoke(new MethodInvoker(() =>
                        {
                            // Выдаем карты на flop'е
                            if (pbFlop1.Image == null)
                            {
                                pbFlop1.Image = Image.FromFile("../../Images/Cards/" + card.suit.ToString() + card.quality.ToString() + ".png");
                                return;
                            }
                            if (pbFlop2.Image == null)
                            {
                                pbFlop2.Image = Image.FromFile("../../Images/Cards/" + card.suit.ToString() + card.quality.ToString() + ".png");
                                return;
                            }
                            if (pbFlop3.Image == null)
                            {
                                pbFlop3.Image = Image.FromFile("../../Images/Cards/" + card.suit.ToString() + card.quality.ToString() + ".png");
                                return;
                            }
                            // Выдаем карты на turn'е
                            if (pbTurn.Image == null)
                            {
                                pbTurn.Image = Image.FromFile("../../Images/Cards/" + card.suit.ToString() + card.quality.ToString() + ".png");
                                return;
                            }
                            // Выдаем карты на river'е
                            if (pbRiver.Image == null)
                            {
                                pbRiver.Image = Image.FromFile("../../Images/Cards/" + card.suit.ToString() + card.quality.ToString() + ".png");
                                return;
                            }
                        }));

                        Thread.Sleep(500);
                    }
                }
            }
        }

        private void ReceiveServerPlayerInfo()
        {
            System.Messaging.Message message = new System.Messaging.Message();
            while (work)
            {
                try
                {
                    // Получаем информацию об игроках с сервера для обновления клиентов
                    message = queue.Receive();
                }
                catch (Exception exc)
                {
                    // Игнорируем исключение
                }

                if (message == null)
                {
                    continue;
                }
                else
                {
                    // Заполняем стол информацией об игроках
                    var players = (List<ServerPlayerInfo>)message.Body;
                    SeatPlayers(players);
                    message.Dispose();
                }
            }
        }

        private void SwitchButtons(bool on)
        {
            if (on)
            {
                try
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        tbRate.Visible = true;
                        rtbRate.Visible = true;
                        btnFold.Visible = true;
                        btnCallCheck.Visible = true;
                        btnRaise.Visible = true;
                        lblMinRaise.Visible = true;
                        lblMaxRaise.Visible = true;
                    }));
                }
                catch
                {
                    //
                }
            }
            else
            {
                try
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        tbRate.Visible = false;
                        rtbRate.Visible = false;
                        btnFold.Visible = false;
                        btnCallCheck.Visible = false;
                        btnRaise.Visible = false;
                        lblMinRaise.Visible = false;
                        lblMaxRaise.Visible = false;
                    }));
                }
                catch
                {
                    //
                }
            }
        }

        // Обновляем информацию об игроках на столе
        private void SeatPlayers(List<ServerPlayerInfo> players)
        {
            // Заполняем стол
            for (int i = 0; i < Helper.maxPlayers; i++)
            {
                ServerPlayerInfo player = players.Find(p => p.seat == i);
                if (player != null)
                {
                    UpdateTable(player);
                }
                else
                {
                    CleanSeat(i);
                }
            }

            // Включаем/выключаем кнопки
            ServerPlayerInfo me = players.Find(p => p.endPoint == player.info.endPoint);
            if (me.yourMove)
            {
                SwitchButtons(true);
            }
            else
            {
                SwitchButtons(false);
            }
        }

        private void UpdateTable(ServerPlayerInfo info)
        {
            switch (info.seat)
            {
                case 0:
                    try
                    {
                        // Для решения проблемы попытки обращения к элементу созданному в другом потоке используем MethodInvoker
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer1Name.Text = info.name;
                            lblPlayer1Money.Text = info.money.ToString();
                            pbPlayer1Card1.Image = SetCard1(info);
                            pbPlayer1Card2.Image = SetCard2(info);
                            lblPlayer1Rate.Text = info.currentRate.ToString();
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 1:
                    try
                    {
                        // TODO: Тут было исключение с потоками при отключении одного из клиентов
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer2Name.Text = info.name;
                            lblPlayer2Money.Text = info.money.ToString();
                            pbPlayer2Card1.Image = SetCard1(info);
                            pbPlayer2Card2.Image = SetCard2(info);
                            lblPlayer2Rate.Text = info.currentRate.ToString();
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 2:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer3Name.Text = info.name;
                            lblPlayer3Money.Text = info.money.ToString();
                            pbPlayer3Card1.Image = SetCard1(info);
                            pbPlayer3Card2.Image = SetCard2(info);
                            lblPlayer3Rate.Text = info.currentRate.ToString();
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 3:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer4Name.Text = info.name;
                            lblPlayer4Money.Text = info.money.ToString();
                            pbPlayer4Card1.Image = SetCard1(info);
                            pbPlayer4Card2.Image = SetCard2(info);
                            lblPlayer4Rate.Text = info.currentRate.ToString();
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 4:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer5Name.Text = info.name;
                            lblPlayer5Money.Text = info.money.ToString();
                            pbPlayer5Card1.Image = SetCard1(info);
                            pbPlayer5Card2.Image = SetCard2(info);
                            lblPlayer5Rate.Text = info.currentRate.ToString();
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 5:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer6Name.Text = info.name;
                            lblPlayer6Money.Text = info.money.ToString();
                            pbPlayer6Card1.Image = SetCard1(info);
                            pbPlayer6Card2.Image = SetCard2(info);
                            lblPlayer6Rate.Text = info.currentRate.ToString();
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                default:
                    break;
            }
        }

        private void CleanSeat(int seat)
        {
            switch (seat)
            {
                case 0:
                    // Для решения проблемы попытки обращения к элементу созданному в другом потоке
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer1Name.Text = "";
                            lblPlayer1Money.Text = "";
                            pbPlayer1Card1.Image = null;
                            pbPlayer1Card2.Image = null;
                            lblPlayer1Rate.Text = "";
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 1:
                    // TODO: Тут было исключение с потоками при отключении одного из клиентов
                    // Доступ кликвидированному объекту невохзможен
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer2Name.Text = "";
                            lblPlayer2Money.Text = "";
                            pbPlayer2Card1.Image = null;
                            pbPlayer2Card2.Image = null;
                            lblPlayer2Rate.Text = "";
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 2:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer3Name.Text = "";
                            lblPlayer3Money.Text = "";
                            pbPlayer3Card1.Image = null;
                            pbPlayer3Card2.Image = null;
                            lblPlayer3Rate.Text = "";
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 3:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer4Name.Text = "";
                            lblPlayer4Money.Text = "";
                            pbPlayer4Card1.Image = null;
                            pbPlayer4Card2.Image = null;
                            lblPlayer4Rate.Text = "";
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 4:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer5Name.Text = "";
                            lblPlayer5Money.Text = "";
                            pbPlayer5Card1.Image = null;
                            pbPlayer5Card2.Image = null;
                            lblPlayer5Rate.Text = "";
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                case 5:
                    try
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            lblPlayer6Name.Text = "";
                            lblPlayer6Money.Text = "";
                            pbPlayer6Card1.Image = null;
                            pbPlayer6Card2.Image = null;
                            lblPlayer6Rate.Text = "";
                        }));
                    }
                    catch (Exception exc)
                    {

                    }
                    break;
                default:
                    break;
            }
        }

        private Image SetCard1(ServerPlayerInfo info)
        {
            string filename = "";
            // Устанавливаем карты так, чтобы клиент мог видеть только свои
            if (info.endPoint.Equals(player.client.Client.LocalEndPoint.ToString()))
            {
                filename = "../../Images/Cards/" + info.card1.suit.ToString() + info.card1.quality.ToString() + ".png";
            }
            else
            {
                filename = "../../Images/Cards/Back.png";
            }
            return Image.FromFile(filename);
        }

        private Image SetCard2(ServerPlayerInfo info)
        {
            string filename = "";
            // Устанавливаем карты так, чтобы клиент мог видеть только свои
            if (info.endPoint.Equals(player.client.Client.LocalEndPoint.ToString()))
            {
                filename = "../../Images/Cards/" + info.card2.suit.ToString() + info.card2.quality.ToString() + ".png";
            }
            else
            {
                filename = "../../Images/Cards/Back.png";
            }
            return Image.FromFile(filename);
        }

        private void InitControls()
        {
            rtbRate.SelectionAlignment = HorizontalAlignment.Center;

            // Включаем прозрачный фон у label игроков
            pbTable.Controls.Add(lblPlayer1Money);
            pbTable.Controls.Add(lblPlayer2Money);
            pbTable.Controls.Add(lblPlayer3Money);
            pbTable.Controls.Add(lblPlayer4Money);
            pbTable.Controls.Add(lblPlayer5Money);
            pbTable.Controls.Add(lblPlayer6Money);
            pbTable.Controls.Add(lblPlayer1Name);
            pbTable.Controls.Add(lblPlayer2Name);
            pbTable.Controls.Add(lblPlayer3Name);
            pbTable.Controls.Add(lblPlayer4Name);
            pbTable.Controls.Add(lblPlayer5Name);
            pbTable.Controls.Add(lblPlayer6Name);
            lblPlayer1Money.BackColor = Color.Transparent;
            lblPlayer2Money.BackColor = Color.Transparent;
            lblPlayer3Money.BackColor = Color.Transparent;
            lblPlayer4Money.BackColor = Color.Transparent;
            lblPlayer5Money.BackColor = Color.Transparent;
            lblPlayer6Money.BackColor = Color.Transparent;
            lblPlayer1Name.BackColor = Color.Transparent;
            lblPlayer2Name.BackColor = Color.Transparent;
            lblPlayer3Name.BackColor = Color.Transparent;
            lblPlayer4Name.BackColor = Color.Transparent;
            lblPlayer5Name.BackColor = Color.Transparent;
            lblPlayer6Name.BackColor = Color.Transparent;

            // Включаем прозрачный фон у label информации
            pbTable.Controls.Add(lblTimeToTurn);
            pbTable.Controls.Add(lblPlace);
            pbTable.Controls.Add(lblMaxCombination);
            lblTimeToTurn.BackColor = Color.Transparent;
            lblPlace.BackColor = Color.Transparent;
            lblMaxCombination.BackColor = Color.Transparent;

            // Включаем прозрачный фон у label ставок игроков
            pbTable.Controls.Add(lblPlayer1Rate);
            pbTable.Controls.Add(lblPlayer2Rate);
            pbTable.Controls.Add(lblPlayer3Rate);
            pbTable.Controls.Add(lblPlayer4Rate);
            pbTable.Controls.Add(lblPlayer5Rate);
            pbTable.Controls.Add(lblPlayer6Rate);
            lblPlayer1Rate.BackColor = Color.Transparent;
            lblPlayer2Rate.BackColor = Color.Transparent;
            lblPlayer3Rate.BackColor = Color.Transparent;
            lblPlayer4Rate.BackColor = Color.Transparent;
            lblPlayer5Rate.BackColor = Color.Transparent;
            lblPlayer6Rate.BackColor = Color.Transparent;

            // Включаем прозрачный фон у label банка
            pbTable.Controls.Add(lblBank);
            lblBank.BackColor = Color.Transparent;
        }

        private void InitPictureBoxes()
        {
            // Включаем прозрачный фон у карт на раздаче
            pbTable.Controls.Add(pbFlop1);
            pbTable.Controls.Add(pbFlop2);
            pbTable.Controls.Add(pbFlop3);
            pbTable.Controls.Add(pbTurn);
            pbTable.Controls.Add(pbRiver);
            pbFlop1.BackColor = Color.Transparent;
            pbFlop2.BackColor = Color.Transparent;
            pbFlop3.BackColor = Color.Transparent;
            pbTurn.BackColor = Color.Transparent;
            pbRiver.BackColor = Color.Transparent;

            // Включаем прозрачный фон у карт игроков
            pbTable.Controls.Add(pbPlayer1Card1);
            pbTable.Controls.Add(pbPlayer1Card2);
            pbTable.Controls.Add(pbPlayer2Card1);
            pbTable.Controls.Add(pbPlayer2Card2);
            pbTable.Controls.Add(pbPlayer3Card1);
            pbTable.Controls.Add(pbPlayer3Card2);
            pbTable.Controls.Add(pbPlayer4Card1);
            pbTable.Controls.Add(pbPlayer4Card2);
            pbTable.Controls.Add(pbPlayer5Card1);
            pbTable.Controls.Add(pbPlayer5Card2);
            pbTable.Controls.Add(pbPlayer6Card1);
            pbTable.Controls.Add(pbPlayer6Card2);
            pbPlayer1Card1.BackColor = Color.Transparent;
            pbPlayer1Card2.BackColor = Color.Transparent;
            pbPlayer2Card1.BackColor = Color.Transparent;
            pbPlayer2Card2.BackColor = Color.Transparent;
            pbPlayer3Card1.BackColor = Color.Transparent;
            pbPlayer3Card2.BackColor = Color.Transparent;
            pbPlayer4Card1.BackColor = Color.Transparent;
            pbPlayer4Card2.BackColor = Color.Transparent;
            pbPlayer5Card1.BackColor = Color.Transparent;
            pbPlayer5Card2.BackColor = Color.Transparent;
            pbPlayer6Card1.BackColor = Color.Transparent;
            pbPlayer6Card2.BackColor = Color.Transparent;


            // Включаем прозрачный фон у игроков
            pbTable.Controls.Add(pbPlayer1);
            pbTable.Controls.Add(pbPlayer2);
            pbTable.Controls.Add(pbPlayer3);
            pbTable.Controls.Add(pbPlayer4);
            pbTable.Controls.Add(pbPlayer5);
            pbTable.Controls.Add(pbPlayer6);
            pbPlayer1.BackColor = Color.Transparent;
            pbPlayer2.BackColor = Color.Transparent;
            pbPlayer3.BackColor = Color.Transparent;
            pbPlayer4.BackColor = Color.Transparent;
            pbPlayer5.BackColor = Color.Transparent;
            pbPlayer6.BackColor = Color.Transparent;

            // Включаем прозрачный фон у фишки диллера
            pbTable.Controls.Add(pbPlayer1Diller);
            pbTable.Controls.Add(pbPlayer2Diller);
            pbTable.Controls.Add(pbPlayer3Diller);
            pbTable.Controls.Add(pbPlayer4Diller);
            pbTable.Controls.Add(pbPlayer5Diller);
            pbTable.Controls.Add(pbPlayer6Diller);
            pbPlayer1Diller.BackColor = Color.Transparent;
            pbPlayer2Diller.BackColor = Color.Transparent;
            pbPlayer3Diller.BackColor = Color.Transparent;
            pbPlayer4Diller.BackColor = Color.Transparent;
            pbPlayer5Diller.BackColor = Color.Transparent;
            pbPlayer6Diller.BackColor = Color.Transparent;
        }

        private void PokerClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Turn turn = player.Exit();
            SendPlayerTurn(turn);
            work = false;
            queue.Purge();
            MessageQueue.Delete(queue.Path);
        }

        private void SendPlayerTurn(Turn turn)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memory = new MemoryStream())
            {
                formatter.Serialize(memory, turn);
                Stream stream = player.client.GetStream();
                byte[] bytes = memory.ToArray();
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnFold_Click(object sender, EventArgs e)
        {
            Turn turn = player.Fold();
            SendPlayerTurn(turn);
        }

        private void btnCallCheck_Click(object sender, EventArgs e)
        {
            Turn turn = player.Call();
            SendPlayerTurn(turn);
        }

        private void btnRaise_Click(object sender, EventArgs e)
        {
            Turn turn = player.Raise(int.Parse(rtbRate.Text.Trim()));
            SendPlayerTurn(turn);
        }
    }
}
