namespace PP1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            buttonCountN = new RadioButton();
            buttonAccuracyE = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            textBoxX = new TextBox();
            labelNAndE = new Label();
            textBoxNAndE = new TextBox();
            label8 = new Label();
            labelResult = new Label();
            button1 = new Button();
            button2 = new Button();
            label9 = new Label();
            labelIterations = new Label();
            label11 = new Label();
            labelControl = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(94, 15);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(326, 35);
            label1.TabIndex = 0;
            label1.Text = "Розрахункова робота №1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(177, 50);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(157, 35);
            label2.TabIndex = 0;
            label2.Text = "Варіант №2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label1_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Screenshot_1;
            pictureBox1.Location = new Point(87, 101);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(342, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 224);
            label3.Name = "label3";
            label3.Size = new Size(229, 28);
            label3.TabIndex = 2;
            label3.Text = "Оберіть режим роботи:";
            label3.Click += label3_Click;
            // 
            // buttonCountN
            // 
            buttonCountN.AutoSize = true;
            buttonCountN.Location = new Point(258, 228);
            buttonCountN.Name = "buttonCountN";
            buttonCountN.Size = new Size(106, 24);
            buttonCountN.TabIndex = 3;
            buttonCountN.TabStop = true;
            buttonCountN.Text = "Кількість N";
            buttonCountN.UseVisualStyleBackColor = true;
            buttonCountN.CheckedChanged += buttonCountN_CheckedChanged;
            // 
            // buttonAccuracyE
            // 
            buttonAccuracyE.AutoSize = true;
            buttonAccuracyE.Location = new Point(379, 228);
            buttonAccuracyE.Name = "buttonAccuracyE";
            buttonAccuracyE.Size = new Size(101, 24);
            buttonAccuracyE.TabIndex = 3;
            buttonAccuracyE.TabStop = true;
            buttonAccuracyE.Text = "Точність Е";
            buttonAccuracyE.UseVisualStyleBackColor = true;
            buttonAccuracyE.CheckedChanged += buttonAccuracyE_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 263);
            label4.Name = "label4";
            label4.Size = new Size(144, 28);
            label4.TabIndex = 4;
            label4.Text = "Введіть змінні:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 305);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 5;
            label5.Text = "X = ";
            // 
            // textBoxX
            // 
            textBoxX.Location = new Point(51, 301);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(105, 27);
            textBoxX.TabIndex = 6;
            textBoxX.UseWaitCursor = true;
            textBoxX.TextChanged += textBox1_TextChanged;
            // 
            // labelNAndE
            // 
            labelNAndE.Anchor = AnchorStyles.None;
            labelNAndE.Location = new Point(178, 305);
            labelNAndE.Name = "labelNAndE";
            labelNAndE.Size = new Size(38, 20);
            labelNAndE.TabIndex = 5;
            labelNAndE.Text = "N = ";
            labelNAndE.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxNAndE
            // 
            textBoxNAndE.Location = new Point(212, 301);
            textBoxNAndE.Name = "textBoxNAndE";
            textBoxNAndE.Size = new Size(105, 27);
            textBoxNAndE.TabIndex = 6;
            textBoxNAndE.UseWaitCursor = true;
            textBoxNAndE.TextChanged += textBox1_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(18, 340);
            label8.Name = "label8";
            label8.Size = new Size(103, 28);
            label8.TabIndex = 4;
            label8.Text = "Результат:";
            label8.Click += label8_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelResult.Location = new Point(119, 340);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(20, 28);
            labelResult.TabIndex = 4;
            labelResult.Text = "-";
            labelResult.Click += label8_Click;
            // 
            // button1
            // 
            button1.Location = new Point(22, 446);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "Обчислити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(381, 446);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 7;
            button2.Text = "Вихід";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(18, 371);
            label9.Name = "label9";
            label9.Size = new Size(133, 28);
            label9.TabIndex = 4;
            label9.Text = "К-ть ітерацій:";
            label9.Click += label8_Click;
            // 
            // labelIterations
            // 
            labelIterations.AutoSize = true;
            labelIterations.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIterations.Location = new Point(144, 371);
            labelIterations.Name = "labelIterations";
            labelIterations.Size = new Size(20, 28);
            labelIterations.TabIndex = 4;
            labelIterations.Text = "-";
            labelIterations.Click += label8_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(18, 404);
            label11.Name = "label11";
            label11.Size = new Size(200, 28);
            label11.TabIndex = 4;
            label11.Text = "Контрольний вираз:";
            label11.Click += label8_Click;
            // 
            // labelControl
            // 
            labelControl.AutoSize = true;
            labelControl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelControl.Location = new Point(211, 404);
            labelControl.Name = "labelControl";
            labelControl.Size = new Size(20, 28);
            labelControl.TabIndex = 4;
            labelControl.Text = "-";
            labelControl.Click += label8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 489);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBoxNAndE);
            Controls.Add(labelNAndE);
            Controls.Add(textBoxX);
            Controls.Add(label5);
            Controls.Add(labelControl);
            Controls.Add(labelIterations);
            Controls.Add(labelResult);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(buttonAccuracyE);
            Controls.Add(buttonCountN);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        private RadioButton buttonCountN;
        private RadioButton buttonAccuracyE;
        private Label label4;
        private Label label5;
        private TextBox textBoxX;
        private Label labelNAndE;
        private TextBox textBoxNAndE;
        private Label label8;
        private Label labelResult;
        private Button button1;
        private Button button2;
        private Label label9;
        private Label labelIterations;
        private Label label11;
        private Label labelControl;
    }
}