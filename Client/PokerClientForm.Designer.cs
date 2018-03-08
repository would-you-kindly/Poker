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
            ((System.ComponentModel.ISupportInitialize)(this.pbTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarpet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRate)).BeginInit();
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
            this.rtbRate.Text = "10000";
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
            // PokerClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 582);
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
    }
}

