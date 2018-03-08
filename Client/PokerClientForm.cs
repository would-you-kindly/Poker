using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class PokerClientForm : Form
    {
        public PokerClientForm()
        {
            InitializeComponent();

            InitPictureBoxes();
            InitControls();
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

            // Включаем прозрачный фон у label мин. и макс. ставок
            //tbRate.Controls.Add(lblMinRaise);
            //tbRate.Controls.Add(lblMaxRaise);
            //lblMinRaise.BackColor = Color.Transparent;
            //lblMaxRaise.BackColor = Color.Transparent;
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
    }
}
