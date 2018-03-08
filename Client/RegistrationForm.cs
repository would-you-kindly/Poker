using Model;
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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            PlayerInfo info = new PlayerInfo(tbName.Text, (int)nudMoney.Value);

            try
            {
                //PokerClientForm poker = new PokerClientForm(info);
            }
            catch
            {
                MessageBox.Show("Во время попытки присоединиться к серверу произошла ошибка. Попробуйте присоединиться еще раз.",
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
