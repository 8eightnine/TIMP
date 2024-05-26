namespace rgz
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxSortType = new System.Windows.Forms.ComboBox();
            this.buttonSort = new System.Windows.Forms.Button();
            this.panelVisualize = new System.Windows.Forms.Panel();
            this.buttonRegenArr = new System.Windows.Forms.Button();
            this.textBoxArrElCnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelIterCnt = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSortType
            // 
            this.comboBoxSortType.FormattingEnabled = true;
            this.comboBoxSortType.Location = new System.Drawing.Point(131, 6);
            this.comboBoxSortType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSortType.Name = "comboBoxSortType";
            this.comboBoxSortType.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSortType.TabIndex = 0;
            this.comboBoxSortType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSortType_SelectedIndexChanged);
            this.comboBoxSortType.SelectedValueChanged += new System.EventHandler(this.comboBoxSortType_SelectedValueChanged);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(299, 3);
            this.buttonSort.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(164, 28);
            this.buttonSort.TabIndex = 1;
            this.buttonSort.Text = "Сортировать массив";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.ButtonSort_Click);
            // 
            // panelVisualize
            // 
            this.panelVisualize.Location = new System.Drawing.Point(16, 62);
            this.panelVisualize.Margin = new System.Windows.Forms.Padding(4);
            this.panelVisualize.Name = "panelVisualize";
            this.panelVisualize.Size = new System.Drawing.Size(1013, 492);
            this.panelVisualize.TabIndex = 2;
            this.panelVisualize.Paint += new System.Windows.Forms.PaintEventHandler(this.panelVisualize_Paint);
            // 
            // buttonRegenArr
            // 
            this.buttonRegenArr.Location = new System.Drawing.Point(355, 33);
            this.buttonRegenArr.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRegenArr.Name = "buttonRegenArr";
            this.buttonRegenArr.Size = new System.Drawing.Size(220, 28);
            this.buttonRegenArr.TabIndex = 3;
            this.buttonRegenArr.Text = "Перегенерировать массив";
            this.buttonRegenArr.UseVisualStyleBackColor = true;
            this.buttonRegenArr.Click += new System.EventHandler(this.buttonRegenArr_Click);
            // 
            // textBoxArrElCnt
            // 
            this.textBoxArrElCnt.Location = new System.Drawing.Point(248, 39);
            this.textBoxArrElCnt.Name = "textBoxArrElCnt";
            this.textBoxArrElCnt.Size = new System.Drawing.Size(100, 22);
            this.textBoxArrElCnt.TabIndex = 4;
            this.textBoxArrElCnt.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Тип сортировки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество элементов в массиве";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(932, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Итерация: ";
            // 
            // labelIterCnt
            // 
            this.labelIterCnt.AutoSize = true;
            this.labelIterCnt.Location = new System.Drawing.Point(1015, 45);
            this.labelIterCnt.Name = "labelIterCnt";
            this.labelIterCnt.Size = new System.Drawing.Size(14, 16);
            this.labelIterCnt.TabIndex = 8;
            this.labelIterCnt.Text = "0";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(892, 45);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(24, 16);
            this.labelTimer.TabIndex = 9;
            this.labelTimer.Text = "0 с";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(835, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Время:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.labelIterCnt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxArrElCnt);
            this.Controls.Add(this.buttonRegenArr);
            this.Controls.Add(this.panelVisualize);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.comboBoxSortType);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Sort Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBoxSortType;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Panel panelVisualize;
        private System.Windows.Forms.Button buttonRegenArr;
        private System.Windows.Forms.TextBox textBoxArrElCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelIterCnt;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
    }
}

