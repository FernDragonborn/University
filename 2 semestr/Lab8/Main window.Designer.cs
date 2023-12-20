namespace Lab8
{
    partial class Lab8
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
            RectangleRadioButton = new RadioButton();
            TriangleRadioButton = new RadioButton();
            FigureLabel = new Label();
            aTextBox = new TextBox();
            aLabel = new Label();
            bTextBox = new TextBox();
            bLabel = new Label();
            cTextBox = new TextBox();
            cLabel = new Label();
            ResultLabel = new Label();
            ResultRichTextBox = new RichTextBox();
            AddButton = new Button();
            TaskLabel = new Label();
            ExecuteButton = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // RectangleRadioButton
            // 
            RectangleRadioButton.AutoSize = true;
            RectangleRadioButton.ForeColor = Color.FromArgb(212, 212, 212);
            RectangleRadioButton.Location = new Point(12, 113);
            RectangleRadioButton.Name = "RectangleRadioButton";
            RectangleRadioButton.Size = new Size(123, 24);
            RectangleRadioButton.TabIndex = 0;
            RectangleRadioButton.Text = "Прямокутник";
            RectangleRadioButton.UseVisualStyleBackColor = true;
            RectangleRadioButton.MouseUp += RectangleRadioButton_CheckedChanged;
            // 
            // TriangleRadioButton
            // 
            TriangleRadioButton.AutoSize = true;
            TriangleRadioButton.ForeColor = Color.FromArgb(212, 212, 212);
            TriangleRadioButton.Location = new Point(147, 113);
            TriangleRadioButton.Name = "TriangleRadioButton";
            TriangleRadioButton.Size = new Size(101, 24);
            TriangleRadioButton.TabIndex = 0;
            TriangleRadioButton.Text = "Трикутник";
            TriangleRadioButton.UseVisualStyleBackColor = true;
            TriangleRadioButton.MouseUp += TriangleRadioButton_CheckedChanged;
            // 
            // FigureLabel
            // 
            FigureLabel.AutoSize = true;
            FigureLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FigureLabel.ForeColor = Color.FromArgb(212, 212, 212);
            FigureLabel.Location = new Point(8, 80);
            FigureLabel.Name = "FigureLabel";
            FigureLabel.Size = new Size(82, 28);
            FigureLabel.TabIndex = 1;
            FigureLabel.Text = "Фігура:";
            // 
            // aTextBox
            // 
            aTextBox.AccessibleName = "";
            aTextBox.BackColor = Color.FromArgb(35, 35, 35);
            aTextBox.BorderStyle = BorderStyle.None;
            aTextBox.Cursor = Cursors.Hand;
            aTextBox.ForeColor = Color.FromArgb(212, 212, 212);
            aTextBox.Location = new Point(47, 156);
            aTextBox.Name = "aTextBox";
            aTextBox.Size = new Size(83, 20);
            aTextBox.TabIndex = 2;
            // 
            // aLabel
            // 
            aLabel.AutoSize = true;
            aLabel.ForeColor = Color.FromArgb(212, 212, 212);
            aLabel.Location = new Point(12, 156);
            aLabel.Name = "aLabel";
            aLabel.Size = new Size(31, 20);
            aLabel.TabIndex = 3;
            aLabel.Text = "a =";
            // 
            // bTextBox
            // 
            bTextBox.AccessibleName = "";
            bTextBox.BackColor = Color.FromArgb(35, 35, 35);
            bTextBox.BorderStyle = BorderStyle.None;
            bTextBox.Cursor = Cursors.Hand;
            bTextBox.ForeColor = Color.FromArgb(212, 212, 212);
            bTextBox.Location = new Point(182, 156);
            bTextBox.Name = "bTextBox";
            bTextBox.Size = new Size(83, 20);
            bTextBox.TabIndex = 2;
            // 
            // bLabel
            // 
            bLabel.AutoSize = true;
            bLabel.ForeColor = Color.FromArgb(212, 212, 212);
            bLabel.Location = new Point(147, 156);
            bLabel.Name = "bLabel";
            bLabel.Size = new Size(32, 20);
            bLabel.TabIndex = 3;
            bLabel.Text = "b =";
            // 
            // cTextBox
            // 
            cTextBox.AccessibleName = "";
            cTextBox.BackColor = Color.FromArgb(35, 35, 35);
            cTextBox.BorderStyle = BorderStyle.None;
            cTextBox.Cursor = Cursors.Hand;
            cTextBox.ForeColor = Color.FromArgb(212, 212, 212);
            cTextBox.Location = new Point(320, 156);
            cTextBox.Name = "cTextBox";
            cTextBox.Size = new Size(83, 20);
            cTextBox.TabIndex = 2;
            // 
            // cLabel
            // 
            cLabel.AutoSize = true;
            cLabel.ForeColor = Color.FromArgb(212, 212, 212);
            cLabel.Location = new Point(285, 156);
            cLabel.Name = "cLabel";
            cLabel.Size = new Size(30, 20);
            cLabel.TabIndex = 3;
            cLabel.Text = "c =";
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ResultLabel.ForeColor = Color.FromArgb(212, 212, 212);
            ResultLabel.Location = new Point(8, 238);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(110, 28);
            ResultLabel.TabIndex = 1;
            ResultLabel.Text = "Результат:";
            // 
            // ResultRichTextBox
            // 
            ResultRichTextBox.BackColor = Color.FromArgb(35, 35, 35);
            ResultRichTextBox.BorderStyle = BorderStyle.None;
            ResultRichTextBox.ForeColor = Color.FromArgb(212, 212, 212);
            ResultRichTextBox.Location = new Point(12, 275);
            ResultRichTextBox.Name = "ResultRichTextBox";
            ResultRichTextBox.ReadOnly = true;
            ResultRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            ResultRichTextBox.Size = new Size(391, 147);
            ResultRichTextBox.TabIndex = 4;
            ResultRichTextBox.Text = "";
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(82, 46, 42);
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AddButton.ForeColor = Color.FromArgb(212, 212, 212);
            AddButton.Location = new Point(285, 110);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(119, 29);
            AddButton.TabIndex = 5;
            AddButton.Text = "➕ Додати";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // TaskLabel
            // 
            TaskLabel.AutoSize = true;
            TaskLabel.ForeColor = Color.FromArgb(212, 212, 212);
            TaskLabel.Location = new Point(12, 23);
            TaskLabel.Name = "TaskLabel";
            TaskLabel.Size = new Size(341, 40);
            TaskLabel.TabIndex = 6;
            TaskLabel.Text = "Програма обчислює периметр фігури. \r\nЯкої саме можна обрати за допомогою кнопок";
            // 
            // ExecuteButton
            // 
            ExecuteButton.BackColor = Color.FromArgb(82, 46, 42);
            ExecuteButton.FlatAppearance.BorderSize = 0;
            ExecuteButton.FlatStyle = FlatStyle.Flat;
            ExecuteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ExecuteButton.ForeColor = Color.FromArgb(212, 212, 212);
            ExecuteButton.Location = new Point(277, 193);
            ExecuteButton.Name = "ExecuteButton";
            ExecuteButton.Size = new Size(125, 29);
            ExecuteButton.TabIndex = 5;
            ExecuteButton.Text = "✔ Виповнити";
            ExecuteButton.UseVisualStyleBackColor = false;
            ExecuteButton.Click += ExecuteButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(82, 46, 42);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(212, 212, 212);
            button1.Location = new Point(144, 193);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 5;
            button1.Text = "📃 Вивести";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ListButton_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(82, 46, 42);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.FromArgb(212, 212, 212);
            button2.Location = new Point(12, 193);
            button2.Name = "button2";
            button2.Size = new Size(125, 29);
            button2.TabIndex = 5;
            button2.Text = "❌ Очистити";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ClearButton_Click;
            // 
            // Lab8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(417, 437);
            Controls.Add(TaskLabel);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(ExecuteButton);
            Controls.Add(AddButton);
            Controls.Add(ResultRichTextBox);
            Controls.Add(cLabel);
            Controls.Add(bLabel);
            Controls.Add(aLabel);
            Controls.Add(cTextBox);
            Controls.Add(bTextBox);
            Controls.Add(aTextBox);
            Controls.Add(ResultLabel);
            Controls.Add(FigureLabel);
            Controls.Add(TriangleRadioButton);
            Controls.Add(RectangleRadioButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Lab8";
            Text = "Lab8 Астаф'єв";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton RectangleRadioButton;
        private RadioButton TriangleRadioButton;
        private Label FigureLabel;
        private TextBox aTextBox;
        private Label aLabel;
        private TextBox bTextBox;
        private Label bLabel;
        private TextBox cTextBox;
        private Label cLabel;
        private Label ResultLabel;
        private RichTextBox ResultRichTextBox;
        private Button AddButton;
        private Label TaskLabel;
        private Button ExecuteButton;
        private Button button1;
        private Button button2;
    }
}