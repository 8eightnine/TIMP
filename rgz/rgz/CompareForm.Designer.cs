namespace rgz
{
    partial class CompareForm
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
            this.components = new System.ComponentModel.Container();
            this.buttonShowSorts = new System.Windows.Forms.Button();
            this.panelInsertion = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBubble = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMerge = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelInsIter = new System.Windows.Forms.Label();
            this.labelBubIter = new System.Windows.Forms.Label();
            this.labelSelIter = new System.Windows.Forms.Label();
            this.labelMerIter = new System.Windows.Forms.Label();
            this.labelInsTimer = new System.Windows.Forms.Label();
            this.labelBubTimer = new System.Windows.Forms.Label();
            this.labelSelTimer = new System.Windows.Forms.Label();
            this.labelMergeTimer = new System.Windows.Forms.Label();
            this.timerIns = new System.Windows.Forms.Timer(this.components);
            this.timerBub = new System.Windows.Forms.Timer(this.components);
            this.timerSel = new System.Windows.Forms.Timer(this.components);
            this.timerMer = new System.Windows.Forms.Timer(this.components);
            this.textBoxArrSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelInsertion.SuspendLayout();
            this.panelBubble.SuspendLayout();
            this.panelSelection.SuspendLayout();
            this.panelMerge.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShowSorts
            // 
            this.buttonShowSorts.Location = new System.Drawing.Point(12, 9);
            this.buttonShowSorts.Name = "buttonShowSorts";
            this.buttonShowSorts.Size = new System.Drawing.Size(98, 23);
            this.buttonShowSorts.TabIndex = 4;
            this.buttonShowSorts.Text = "Сравнить";
            this.buttonShowSorts.UseVisualStyleBackColor = true;
            this.buttonShowSorts.Click += new System.EventHandler(this.buttonShowSorts_Click);
            // 
            // panelInsertion
            // 
            this.panelInsertion.Controls.Add(this.label1);
            this.panelInsertion.Location = new System.Drawing.Point(12, 38);
            this.panelInsertion.Name = "panelInsertion";
            this.panelInsertion.Size = new System.Drawing.Size(294, 177);
            this.panelInsertion.TabIndex = 5;
            this.panelInsertion.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInsertion_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Вставкой";
            // 
            // panelBubble
            // 
            this.panelBubble.Controls.Add(this.label2);
            this.panelBubble.Location = new System.Drawing.Point(312, 38);
            this.panelBubble.Name = "panelBubble";
            this.panelBubble.Size = new System.Drawing.Size(294, 177);
            this.panelBubble.TabIndex = 6;
            this.panelBubble.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBubble_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Пузырьком";
            // 
            // panelSelection
            // 
            this.panelSelection.Controls.Add(this.label3);
            this.panelSelection.Location = new System.Drawing.Point(12, 271);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(294, 177);
            this.panelSelection.TabIndex = 7;
            this.panelSelection.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSelection_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Выбором";
            // 
            // panelMerge
            // 
            this.panelMerge.Controls.Add(this.label4);
            this.panelMerge.Location = new System.Drawing.Point(312, 271);
            this.panelMerge.Name = "panelMerge";
            this.panelMerge.Size = new System.Drawing.Size(294, 177);
            this.panelMerge.TabIndex = 8;
            this.panelMerge.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMerge_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Слиянием";
            // 
            // labelInsIter
            // 
            this.labelInsIter.AutoSize = true;
            this.labelInsIter.Location = new System.Drawing.Point(26, 218);
            this.labelInsIter.Name = "labelInsIter";
            this.labelInsIter.Size = new System.Drawing.Size(84, 16);
            this.labelInsIter.TabIndex = 0;
            this.labelInsIter.Text = "Итерация: 0";
            // 
            // labelBubIter
            // 
            this.labelBubIter.AutoSize = true;
            this.labelBubIter.Location = new System.Drawing.Point(327, 218);
            this.labelBubIter.Name = "labelBubIter";
            this.labelBubIter.Size = new System.Drawing.Size(84, 16);
            this.labelBubIter.TabIndex = 9;
            this.labelBubIter.Text = "Итерация: 0";
            // 
            // labelSelIter
            // 
            this.labelSelIter.AutoSize = true;
            this.labelSelIter.Location = new System.Drawing.Point(26, 451);
            this.labelSelIter.Name = "labelSelIter";
            this.labelSelIter.Size = new System.Drawing.Size(84, 16);
            this.labelSelIter.TabIndex = 10;
            this.labelSelIter.Text = "Итерация: 0";
            // 
            // labelMerIter
            // 
            this.labelMerIter.AutoSize = true;
            this.labelMerIter.Location = new System.Drawing.Point(327, 451);
            this.labelMerIter.Name = "labelMerIter";
            this.labelMerIter.Size = new System.Drawing.Size(84, 16);
            this.labelMerIter.TabIndex = 11;
            this.labelMerIter.Text = "Итерация: 0";
            // 
            // labelInsTimer
            // 
            this.labelInsTimer.AutoSize = true;
            this.labelInsTimer.Location = new System.Drawing.Point(171, 218);
            this.labelInsTimer.Name = "labelInsTimer";
            this.labelInsTimer.Size = new System.Drawing.Size(71, 16);
            this.labelInsTimer.TabIndex = 12;
            this.labelInsTimer.Text = "Время: 0 с";
            // 
            // labelBubTimer
            // 
            this.labelBubTimer.AutoSize = true;
            this.labelBubTimer.Location = new System.Drawing.Point(493, 218);
            this.labelBubTimer.Name = "labelBubTimer";
            this.labelBubTimer.Size = new System.Drawing.Size(71, 16);
            this.labelBubTimer.TabIndex = 13;
            this.labelBubTimer.Text = "Время: 0 с";
            // 
            // labelSelTimer
            // 
            this.labelSelTimer.AutoSize = true;
            this.labelSelTimer.Location = new System.Drawing.Point(171, 451);
            this.labelSelTimer.Name = "labelSelTimer";
            this.labelSelTimer.Size = new System.Drawing.Size(71, 16);
            this.labelSelTimer.TabIndex = 14;
            this.labelSelTimer.Text = "Время: 0 с";
            // 
            // labelMergeTimer
            // 
            this.labelMergeTimer.AutoSize = true;
            this.labelMergeTimer.Location = new System.Drawing.Point(493, 451);
            this.labelMergeTimer.Name = "labelMergeTimer";
            this.labelMergeTimer.Size = new System.Drawing.Size(71, 16);
            this.labelMergeTimer.TabIndex = 15;
            this.labelMergeTimer.Text = "Время: 0 с";
            // 
            // timerIns
            // 
            this.timerIns.Tick += new System.EventHandler(this.timerIns_Tick);
            // 
            // timerBub
            // 
            this.timerBub.Tick += new System.EventHandler(this.timerBub_Tick);
            // 
            // timerSel
            // 
            this.timerSel.Tick += new System.EventHandler(this.timerSel_Tick);
            // 
            // timerMer
            // 
            this.timerMer.Tick += new System.EventHandler(this.timerMer_Tick);
            // 
            // textBoxArrSize
            // 
            this.textBoxArrSize.Location = new System.Drawing.Point(116, 10);
            this.textBoxArrSize.Name = "textBoxArrSize";
            this.textBoxArrSize.Size = new System.Drawing.Size(39, 22);
            this.textBoxArrSize.TabIndex = 16;
            this.textBoxArrSize.Text = "25";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Размер массива";
            // 
            // CompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 513);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxArrSize);
            this.Controls.Add(this.labelMergeTimer);
            this.Controls.Add(this.labelSelTimer);
            this.Controls.Add(this.labelBubTimer);
            this.Controls.Add(this.labelInsTimer);
            this.Controls.Add(this.labelMerIter);
            this.Controls.Add(this.labelSelIter);
            this.Controls.Add(this.labelBubIter);
            this.Controls.Add(this.labelInsIter);
            this.Controls.Add(this.panelMerge);
            this.Controls.Add(this.panelSelection);
            this.Controls.Add(this.panelBubble);
            this.Controls.Add(this.panelInsertion);
            this.Controls.Add(this.buttonShowSorts);
            this.Name = "CompareForm";
            this.Text = "CompareForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompareForm_FormClosed);
            this.Load += new System.EventHandler(this.CompareForm_Load);
            this.panelInsertion.ResumeLayout(false);
            this.panelInsertion.PerformLayout();
            this.panelBubble.ResumeLayout(false);
            this.panelBubble.PerformLayout();
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            this.panelMerge.ResumeLayout(false);
            this.panelMerge.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonShowSorts;
        private System.Windows.Forms.Panel panelInsertion;
        private System.Windows.Forms.Panel panelBubble;
        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.Panel panelMerge;
        private System.Windows.Forms.Label labelInsIter;
        private System.Windows.Forms.Label labelBubIter;
        private System.Windows.Forms.Label labelSelIter;
        private System.Windows.Forms.Label labelMerIter;
        private System.Windows.Forms.Label labelInsTimer;
        private System.Windows.Forms.Label labelBubTimer;
        private System.Windows.Forms.Label labelSelTimer;
        private System.Windows.Forms.Label labelMergeTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerIns;
        private System.Windows.Forms.Timer timerBub;
        private System.Windows.Forms.Timer timerSel;
        private System.Windows.Forms.Timer timerMer;
        private System.Windows.Forms.TextBox textBoxArrSize;
        private System.Windows.Forms.Label label5;
    }
}