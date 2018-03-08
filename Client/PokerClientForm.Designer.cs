using System.Windows.Forms;

namespace Client
{
    partial class PokerClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokerClientForm));
            this.pbTable = new System.Windows.Forms.PictureBox();
            this.pbCarpet = new System.Windows.Forms.PictureBox();
            this.btnRaise = new System.Windows.Forms.Button();
            this.tbRate = new System.Windows.Forms.TrackBar();
            this.rtbRate = new System.Windows.Forms.RichTextBox();
            this.btnCallCheck = new System.Windows.Forms.Button();
            this.btnFold = new System.Windows.Forms.Button();
            this.pbFlop3 = new System.Windows.Forms.PictureBox();
            this.pbFlop2 = new System.Windows.Forms.PictureBox();
            this.pbFlop1 = new System.Windows.Forms.PictureBox();
            this.pbTurn = new System.Windows.Forms.PictureBox();
            this.pbRiver = new System.Windows.Forms.PictureBox();
            this.pbPlayer1 = new System.Windows.Forms.PictureBox();
            this.pbPlayer2 = new System.Windows.Forms.PictureBox();
            this.pbPlayer3 = new System.Windows.Forms.PictureBox();
            this.pbPlayer4 = new System.Windows.Forms.PictureBox();
            this.pbPlayer5 = new System.Windows.Forms.PictureBox();
            this.pbPlayer6 = new System.Windows.Forms.PictureBox();
            this.lblPlayer1Money = new System.Windows.Forms.Label();
            this.lblPlayer1Name = new System.Windows.Forms.Label();
            this.lblPlayer2Name = new System.Windows.Forms.Label();
            this.lblPlayer2Money = new System.Windows.Forms.Label();
            this.lblPlayer3Name = new System.Windows.Forms.Label();
            this.lblPlayer3Money = new System.Windows.Forms.Label();
            this.lblPlayer6Name = new System.Windows.Forms.Label();
            this.lblPlayer6Money = new System.Windows.Forms.Label();
            this.lblPlayer5Name = new System.Windows.Forms.Label();
            this.lblPlayer5Money = new System.Windows.Forms.Label();
            this.lblPlayer4Name = new System.Windows.Forms.Label();
            this.lblPlayer4Money = new System.Windows.Forms.Label();
            this.pbPlayer1Diller = new System.Windows.Forms.PictureBox();
            this.pbPlayer2Diller = new System.Windows.Forms.PictureBox();
            this.pbPlayer3Diller = new System.Windows.Forms.PictureBox();
            this.pbPlayer4Diller = new System.Windows.Forms.PictureBox();
            this.pbPlayer5Diller = new System.Windows.Forms.PictureBox();
            this.pbPlayer6Diller = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarpet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1Diller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2Diller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer3Diller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer4Diller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer5Diller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer6Diller)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTable
            // 
            this.pbTable.Image = ((System.Drawing.Image)(resources.GetObject("pbTable.Image")));
            this.pbTable.Location = new System.Drawing.Point(0, 0);
            this.pbTable.Name = "pbTable";
            this.pbTable.Size = new System.Drawing.Size(720, 460);
            this.pbTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTable.TabIndex = 0;
            this.pbTable.TabStop = false;
            // 
            // pbCarpet
            // 
            this.pbCarpet.Image = ((System.Drawing.Image)(resources.GetObject("pbCarpet.Image")));
            this.pbCarpet.Location = new System.Drawing.Point(0, 460);
            this.pbCarpet.Name = "pbCarpet";
            this.pbCarpet.Size = new System.Drawing.Size(720, 122);
            this.pbCarpet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCarpet.TabIndex = 1;
            this.pbCarpet.TabStop = false;
            // 
            // btnRaise
            // 
            this.btnRaise.BackColor = System.Drawing.Color.Maroon;
            this.btnRaise.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRaise.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRaise.ForeColor = System.Drawing.SystemColors.Info;
            this.btnRaise.Location = new System.Drawing.Point(588, 517);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(120, 53);
            this.btnRaise.TabIndex = 2;
            this.btnRaise.Text = "Raise";
            this.btnRaise.UseVisualStyleBackColor = false;
            // 
            // tbRate
            // 
            this.tbRate.BackColor = System.Drawing.Color.DarkRed;
            this.tbRate.Location = new System.Drawing.Point(462, 466);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(246, 45);
            this.tbRate.TabIndex = 3;
            this.tbRate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // rtbRate
            // 
            this.rtbRate.BackColor = System.Drawing.Color.DarkRed;
            this.rtbRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbRate.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbRate.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbRate.Location = new System.Drawing.Point(336, 466);
            this.rtbRate.Name = "rtbRate";
            this.rtbRate.Size = new System.Drawing.Size(120, 45);
            this.rtbRate.TabIndex = 5;
            this.rtbRate.Text = "0";
            // 
            // btnCallCheck
            // 
            this.btnCallCheck.BackColor = System.Drawing.Color.Maroon;
            this.btnCallCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCallCheck.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCallCheck.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCallCheck.Location = new System.Drawing.Point(462, 517);
            this.btnCallCheck.Name = "btnCallCheck";
            this.btnCallCheck.Size = new System.Drawing.Size(120, 53);
            this.btnCallCheck.TabIndex = 6;
            this.btnCallCheck.Text = "Check";
            this.btnCallCheck.UseVisualStyleBackColor = false;
            // 
            // btnFold
            // 
            this.btnFold.BackColor = System.Drawing.Color.Maroon;
            this.btnFold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFold.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFold.ForeColor = System.Drawing.SystemColors.Info;
            this.btnFold.Location = new System.Drawing.Point(336, 517);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(120, 53);
            this.btnFold.TabIndex = 7;
            this.btnFold.Text = "Fold";
            this.btnFold.UseVisualStyleBackColor = false;
            // 
            // pbFlop3
            // 
            this.pbFlop3.Location = new System.Drawing.Point(338, 198);
            this.pbFlop3.Name = "pbFlop3";
            this.pbFlop3.Size = new System.Drawing.Size(44, 64);
            this.pbFlop3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFlop3.TabIndex = 8;
            this.pbFlop3.TabStop = false;
            // 
            // pbFlop2
            // 
            this.pbFlop2.Location = new System.Drawing.Point(284, 198);
            this.pbFlop2.Name = "pbFlop2";
            this.pbFlop2.Size = new System.Drawing.Size(44, 64);
            this.pbFlop2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFlop2.TabIndex = 8;
            this.pbFlop2.TabStop = false;
            // 
            // pbFlop1
            // 
            this.pbFlop1.Location = new System.Drawing.Point(230, 198);
            this.pbFlop1.Name = "pbFlop1";
            this.pbFlop1.Size = new System.Drawing.Size(44, 64);
            this.pbFlop1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFlop1.TabIndex = 8;
            this.pbFlop1.TabStop = false;
            // 
            // pbTurn
            // 
            this.pbTurn.Location = new System.Drawing.Point(392, 198);
            this.pbTurn.Name = "pbTurn";
            this.pbTurn.Size = new System.Drawing.Size(44, 64);
            this.pbTurn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTurn.TabIndex = 8;
            this.pbTurn.TabStop = false;
            // 
            // pbRiver
            // 
            this.pbRiver.Location = new System.Drawing.Point(446, 198);
            this.pbRiver.Name = "pbRiver";
            this.pbRiver.Size = new System.Drawing.Size(44, 64);
            this.pbRiver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRiver.TabIndex = 8;
            this.pbRiver.TabStop = false;
            // 
            // pbPlayer1
            // 
            this.pbPlayer1.Location = new System.Drawing.Point(212, 101);
            this.pbPlayer1.Name = "pbPlayer1";
            this.pbPlayer1.Size = new System.Drawing.Size(40, 40);
            this.pbPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer1.TabIndex = 9;
            this.pbPlayer1.TabStop = false;
            // 
            // pbPlayer2
            // 
            this.pbPlayer2.Location = new System.Drawing.Point(340, 101);
            this.pbPlayer2.Name = "pbPlayer2";
            this.pbPlayer2.Size = new System.Drawing.Size(40, 40);
            this.pbPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer2.TabIndex = 9;
            this.pbPlayer2.TabStop = false;
            // 
            // pbPlayer3
            // 
            this.pbPlayer3.Location = new System.Drawing.Point(467, 101);
            this.pbPlayer3.Name = "pbPlayer3";
            this.pbPlayer3.Size = new System.Drawing.Size(40, 40);
            this.pbPlayer3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer3.TabIndex = 9;
            this.pbPlayer3.TabStop = false;
            // 
            // pbPlayer4
            // 
            this.pbPlayer4.Location = new System.Drawing.Point(467, 319);
            this.pbPlayer4.Name = "pbPlayer4";
            this.pbPlayer4.Size = new System.Drawing.Size(40, 40);
            this.pbPlayer4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer4.TabIndex = 9;
            this.pbPlayer4.TabStop = false;
            // 
            // pbPlayer5
            // 
            this.pbPlayer5.Location = new System.Drawing.Point(338, 319);
            this.pbPlayer5.Name = "pbPlayer5";
            this.pbPlayer5.Size = new System.Drawing.Size(40, 40);
            this.pbPlayer5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer5.TabIndex = 9;
            this.pbPlayer5.TabStop = false;
            // 
            // pbPlayer6
            // 
            this.pbPlayer6.Location = new System.Drawing.Point(212, 319);
            this.pbPlayer6.Name = "pbPlayer6";
            this.pbPlayer6.Size = new System.Drawing.Size(40, 40);
            this.pbPlayer6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer6.TabIndex = 9;
            this.pbPlayer6.TabStop = false;
            // 
            // lblPlayer1Money
            // 
            this.lblPlayer1Money.AutoSize = true;
            this.lblPlayer1Money.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer1Money.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1Money.Location = new System.Drawing.Point(209, 144);
            this.lblPlayer1Money.Name = "lblPlayer1Money";
            this.lblPlayer1Money.Size = new System.Drawing.Size(15, 18);
            this.lblPlayer1Money.TabIndex = 10;
            this.lblPlayer1Money.Text = "0";
            // 
            // lblPlayer1Name
            // 
            this.lblPlayer1Name.AutoSize = true;
            this.lblPlayer1Name.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer1Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1Name.Location = new System.Drawing.Point(209, 162);
            this.lblPlayer1Name.Name = "lblPlayer1Name";
            this.lblPlayer1Name.Size = new System.Drawing.Size(53, 18);
            this.lblPlayer1Name.TabIndex = 10;
            this.lblPlayer1Name.Text = "Player1";
            // 
            // lblPlayer2Name
            // 
            this.lblPlayer2Name.AutoSize = true;
            this.lblPlayer2Name.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer2Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2Name.Location = new System.Drawing.Point(337, 162);
            this.lblPlayer2Name.Name = "lblPlayer2Name";
            this.lblPlayer2Name.Size = new System.Drawing.Size(53, 18);
            this.lblPlayer2Name.TabIndex = 11;
            this.lblPlayer2Name.Text = "Player2";
            // 
            // lblPlayer2Money
            // 
            this.lblPlayer2Money.AutoSize = true;
            this.lblPlayer2Money.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer2Money.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2Money.Location = new System.Drawing.Point(337, 144);
            this.lblPlayer2Money.Name = "lblPlayer2Money";
            this.lblPlayer2Money.Size = new System.Drawing.Size(15, 18);
            this.lblPlayer2Money.TabIndex = 12;
            this.lblPlayer2Money.Text = "0";
            // 
            // lblPlayer3Name
            // 
            this.lblPlayer3Name.AutoSize = true;
            this.lblPlayer3Name.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer3Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer3Name.Location = new System.Drawing.Point(464, 162);
            this.lblPlayer3Name.Name = "lblPlayer3Name";
            this.lblPlayer3Name.Size = new System.Drawing.Size(53, 18);
            this.lblPlayer3Name.TabIndex = 13;
            this.lblPlayer3Name.Text = "Player3";
            // 
            // lblPlayer3Money
            // 
            this.lblPlayer3Money.AutoSize = true;
            this.lblPlayer3Money.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer3Money.ForeColor = System.Drawing.Color.White;
            this.lblPlayer3Money.Location = new System.Drawing.Point(464, 144);
            this.lblPlayer3Money.Name = "lblPlayer3Money";
            this.lblPlayer3Money.Size = new System.Drawing.Size(15, 18);
            this.lblPlayer3Money.TabIndex = 14;
            this.lblPlayer3Money.Text = "0";
            // 
            // lblPlayer6Name
            // 
            this.lblPlayer6Name.AutoSize = true;
            this.lblPlayer6Name.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer6Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer6Name.Location = new System.Drawing.Point(209, 298);
            this.lblPlayer6Name.Name = "lblPlayer6Name";
            this.lblPlayer6Name.Size = new System.Drawing.Size(53, 18);
            this.lblPlayer6Name.TabIndex = 15;
            this.lblPlayer6Name.Text = "Player6";
            // 
            // lblPlayer6Money
            // 
            this.lblPlayer6Money.AutoSize = true;
            this.lblPlayer6Money.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer6Money.ForeColor = System.Drawing.Color.White;
            this.lblPlayer6Money.Location = new System.Drawing.Point(209, 280);
            this.lblPlayer6Money.Name = "lblPlayer6Money";
            this.lblPlayer6Money.Size = new System.Drawing.Size(15, 18);
            this.lblPlayer6Money.TabIndex = 16;
            this.lblPlayer6Money.Text = "0";
            // 
            // lblPlayer5Name
            // 
            this.lblPlayer5Name.AutoSize = true;
            this.lblPlayer5Name.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer5Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer5Name.Location = new System.Drawing.Point(337, 298);
            this.lblPlayer5Name.Name = "lblPlayer5Name";
            this.lblPlayer5Name.Size = new System.Drawing.Size(53, 18);
            this.lblPlayer5Name.TabIndex = 17;
            this.lblPlayer5Name.Text = "Player5";
            // 
            // lblPlayer5Money
            // 
            this.lblPlayer5Money.AutoSize = true;
            this.lblPlayer5Money.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer5Money.ForeColor = System.Drawing.Color.White;
            this.lblPlayer5Money.Location = new System.Drawing.Point(337, 280);
            this.lblPlayer5Money.Name = "lblPlayer5Money";
            this.lblPlayer5Money.Size = new System.Drawing.Size(15, 18);
            this.lblPlayer5Money.TabIndex = 18;
            this.lblPlayer5Money.Text = "0";
            // 
            // lblPlayer4Name
            // 
            this.lblPlayer4Name.AutoSize = true;
            this.lblPlayer4Name.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer4Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer4Name.Location = new System.Drawing.Point(464, 298);
            this.lblPlayer4Name.Name = "lblPlayer4Name";
            this.lblPlayer4Name.Size = new System.Drawing.Size(53, 18);
            this.lblPlayer4Name.TabIndex = 19;
            this.lblPlayer4Name.Text = "Player4";
            // 
            // lblPlayer4Money
            // 
            this.lblPlayer4Money.AutoSize = true;
            this.lblPlayer4Money.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayer4Money.ForeColor = System.Drawing.Color.White;
            this.lblPlayer4Money.Location = new System.Drawing.Point(464, 280);
            this.lblPlayer4Money.Name = "lblPlayer4Money";
            this.lblPlayer4Money.Size = new System.Drawing.Size(15, 18);
            this.lblPlayer4Money.TabIndex = 20;
            this.lblPlayer4Money.Text = "0";
            // 
            // pbPlayer1Diller
            // 
            this.pbPlayer1Diller.Location = new System.Drawing.Point(258, 101);
            this.pbPlayer1Diller.Name = "pbPlayer1Diller";
            this.pbPlayer1Diller.Size = new System.Drawing.Size(25, 20);
            this.pbPlayer1Diller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer1Diller.TabIndex = 21;
            this.pbPlayer1Diller.TabStop = false;
            // 
            // pbPlayer2Diller
            // 
            this.pbPlayer2Diller.Location = new System.Drawing.Point(386, 101);
            this.pbPlayer2Diller.Name = "pbPlayer2Diller";
            this.pbPlayer2Diller.Size = new System.Drawing.Size(25, 20);
            this.pbPlayer2Diller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer2Diller.TabIndex = 21;
            this.pbPlayer2Diller.TabStop = false;
            // 
            // pbPlayer3Diller
            // 
            this.pbPlayer3Diller.Location = new System.Drawing.Point(513, 101);
            this.pbPlayer3Diller.Name = "pbPlayer3Diller";
            this.pbPlayer3Diller.Size = new System.Drawing.Size(25, 20);
            this.pbPlayer3Diller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer3Diller.TabIndex = 21;
            this.pbPlayer3Diller.TabStop = false;
            // 
            // pbPlayer4Diller
            // 
            this.pbPlayer4Diller.Location = new System.Drawing.Point(436, 339);
            this.pbPlayer4Diller.Name = "pbPlayer4Diller";
            this.pbPlayer4Diller.Size = new System.Drawing.Size(25, 20);
            this.pbPlayer4Diller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer4Diller.TabIndex = 21;
            this.pbPlayer4Diller.TabStop = false;
            // 
            // pbPlayer5Diller
            // 
            this.pbPlayer5Diller.Location = new System.Drawing.Point(307, 339);
            this.pbPlayer5Diller.Name = "pbPlayer5Diller";
            this.pbPlayer5Diller.Size = new System.Drawing.Size(25, 20);
            this.pbPlayer5Diller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer5Diller.TabIndex = 21;
            this.pbPlayer5Diller.TabStop = false;
            // 
            // pbPlayer6Diller
            // 
            this.pbPlayer6Diller.Location = new System.Drawing.Point(181, 339);
            this.pbPlayer6Diller.Name = "pbPlayer6Diller";
            this.pbPlayer6Diller.Size = new System.Drawing.Size(25, 20);
            this.pbPlayer6Diller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayer6Diller.TabIndex = 21;
            this.pbPlayer6Diller.TabStop = false;
            // 
            // PokerClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 582);
            this.Controls.Add(this.pbPlayer6Diller);
            this.Controls.Add(this.pbPlayer5Diller);
            this.Controls.Add(this.pbPlayer4Diller);
            this.Controls.Add(this.pbPlayer3Diller);
            this.Controls.Add(this.pbPlayer2Diller);
            this.Controls.Add(this.pbPlayer1Diller);
            this.Controls.Add(this.lblPlayer4Name);
            this.Controls.Add(this.lblPlayer4Money);
            this.Controls.Add(this.lblPlayer5Name);
            this.Controls.Add(this.lblPlayer5Money);
            this.Controls.Add(this.lblPlayer6Name);
            this.Controls.Add(this.lblPlayer6Money);
            this.Controls.Add(this.lblPlayer3Name);
            this.Controls.Add(this.lblPlayer3Money);
            this.Controls.Add(this.lblPlayer2Name);
            this.Controls.Add(this.lblPlayer2Money);
            this.Controls.Add(this.lblPlayer1Name);
            this.Controls.Add(this.lblPlayer1Money);
            this.Controls.Add(this.pbPlayer6);
            this.Controls.Add(this.pbPlayer5);
            this.Controls.Add(this.pbPlayer4);
            this.Controls.Add(this.pbPlayer3);
            this.Controls.Add(this.pbPlayer2);
            this.Controls.Add(this.pbPlayer1);
            this.Controls.Add(this.pbRiver);
            this.Controls.Add(this.pbTurn);
            this.Controls.Add(this.pbFlop1);
            this.Controls.Add(this.pbFlop2);
            this.Controls.Add(this.pbFlop3);
            this.Controls.Add(this.btnFold);
            this.Controls.Add(this.btnCallCheck);
            this.Controls.Add(this.rtbRate);
            this.Controls.Add(this.tbRate);
            this.Controls.Add(this.btnRaise);
            this.Controls.Add(this.pbCarpet);
            this.Controls.Add(this.pbTable);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PokerClientForm";
            this.Text = "Покер";
            ((System.ComponentModel.ISupportInitialize)(this.pbTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarpet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer1Diller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer2Diller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer3Diller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer4Diller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer5Diller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer6Diller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTable;
        private System.Windows.Forms.PictureBox pbCarpet;
        private System.Windows.Forms.Button btnRaise;
        private System.Windows.Forms.TrackBar tbRate;
        private System.Windows.Forms.RichTextBox rtbRate;
        private System.Windows.Forms.Button btnCallCheck;
        private System.Windows.Forms.Button btnFold;
        private System.Windows.Forms.PictureBox pbFlop3;
        private System.Windows.Forms.PictureBox pbFlop2;
        private System.Windows.Forms.PictureBox pbFlop1;
        private System.Windows.Forms.PictureBox pbTurn;
        private System.Windows.Forms.PictureBox pbRiver;
        private PictureBox pbPlayer1;
        private PictureBox pbPlayer2;
        private PictureBox pbPlayer3;
        private PictureBox pbPlayer4;
        private PictureBox pbPlayer5;
        private PictureBox pbPlayer6;
        private Label lblPlayer1Money;
        private Label lblPlayer1Name;
        private Label lblPlayer2Name;
        private Label lblPlayer2Money;
        private Label lblPlayer3Name;
        private Label lblPlayer3Money;
        private Label lblPlayer6Name;
        private Label lblPlayer6Money;
        private Label lblPlayer5Name;
        private Label lblPlayer5Money;
        private Label lblPlayer4Name;
        private Label lblPlayer4Money;
        private PictureBox pbPlayer1Diller;
        private PictureBox pbPlayer2Diller;
        private PictureBox pbPlayer3Diller;
        private PictureBox pbPlayer4Diller;
        private PictureBox pbPlayer5Diller;
        private PictureBox pbPlayer6Diller;
    }
}

