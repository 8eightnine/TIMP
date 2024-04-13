namespace Client
{
    partial class MainForm
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
            this.directoryView = new System.Windows.Forms.ListBox();
            this.ClientOutput = new System.Windows.Forms.RichTextBox();
            this.ServerOutput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // directoryView
            // 
            this.directoryView.FormattingEnabled = true;
            this.directoryView.ItemHeight = 16;
            this.directoryView.Items.AddRange(new object[] {
            " "});
            this.directoryView.Location = new System.Drawing.Point(12, 99);
            this.directoryView.Name = "directoryView";
            this.directoryView.Size = new System.Drawing.Size(326, 452);
            this.directoryView.TabIndex = 0;
            // 
            // ClientOutput
            // 
            this.ClientOutput.Location = new System.Drawing.Point(372, 99);
            this.ClientOutput.Name = "ClientOutput";
            this.ClientOutput.Size = new System.Drawing.Size(262, 452);
            this.ClientOutput.TabIndex = 1;
            this.ClientOutput.Text = "";
            // 
            // ServerOutput
            // 
            this.ServerOutput.Location = new System.Drawing.Point(640, 99);
            this.ServerOutput.Name = "ServerOutput";
            this.ServerOutput.Size = new System.Drawing.Size(262, 452);
            this.ServerOutput.TabIndex = 2;
            this.ServerOutput.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Клиент";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(637, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сервер";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(325, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Корневые иректории";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Содержимое";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.HotPink;
            this.ClientSize = new System.Drawing.Size(914, 580);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerOutput);
            this.Controls.Add(this.ClientOutput);
            this.Controls.Add(this.directoryView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "LR10";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox directoryView;
        private System.Windows.Forms.RichTextBox ClientOutput;
        private System.Windows.Forms.RichTextBox ServerOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

