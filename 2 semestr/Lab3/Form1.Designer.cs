namespace Lab_3
{
    partial class Lab3
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
            TextBoxVectorSize = new TextBox();
            Header = new Label();
            LabelVectorSize = new Label();
            ListBoxRandomVector = new ListBox();
            ListBoxResult = new ListBox();
            ButtonCreateVector = new Button();
            ButtonGetResult = new Button();
            LabelDeleted = new Label();
            LabelDeletedCount = new Label();
            LabelSum = new Label();
            LabelRandomVector = new Label();
            LabelResultVector = new Label();
            LabelSumRes = new Label();
            SuspendLayout();
            // 
            // TextBoxVectorSize
            // 
            TextBoxVectorSize.Location = new Point(52, 120);
            TextBoxVectorSize.Name = "TextBoxVectorSize";
            TextBoxVectorSize.Size = new Size(125, 27);
            TextBoxVectorSize.TabIndex = 0;
            TextBoxVectorSize.TextChanged += TextBoxVectorSize_TextChanged;
            // 
            // Header
            // 
            Header.AutoSize = true;
            Header.Location = new Point(25, 9);
            Header.Name = "Header";
            Header.Size = new Size(531, 60);
            Header.TabIndex = 1;
            Header.Text = "Лабораторна робота 3 - динамічні масиви. Варіант 2\r\nЗавдання: Знайти добуток парних елементів масиву A = {a[i]}. Видалити із\r\nсередини початкового вектора випадкову (від 1 до 10) кількість елементів.";
            Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelVectorSize
            // 
            LabelVectorSize.AutoSize = true;
            LabelVectorSize.Location = new Point(27, 93);
            LabelVectorSize.Name = "LabelVectorSize";
            LabelVectorSize.Size = new Size(175, 20);
            LabelVectorSize.TabIndex = 2;
            LabelVectorSize.Text = "Введіть розмір вектора:";
            LabelVectorSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ListBoxRandomVector
            // 
            ListBoxRandomVector.FormattingEnabled = true;
            ListBoxRandomVector.ItemHeight = 20;
            ListBoxRandomVector.Location = new Point(245, 120);
            ListBoxRandomVector.Name = "ListBoxRandomVector";
            ListBoxRandomVector.Size = new Size(102, 304);
            ListBoxRandomVector.TabIndex = 3;
            // 
            // ListBoxResult
            // 
            ListBoxResult.FormattingEnabled = true;
            ListBoxResult.ItemHeight = 20;
            ListBoxResult.Location = new Point(426, 120);
            ListBoxResult.Name = "ListBoxResult";
            ListBoxResult.Size = new Size(102, 304);
            ListBoxResult.TabIndex = 4;
            // 
            // ButtonCreateVector
            // 
            ButtonCreateVector.Location = new Point(60, 160);
            ButtonCreateVector.Name = "ButtonCreateVector";
            ButtonCreateVector.Size = new Size(106, 48);
            ButtonCreateVector.TabIndex = 5;
            ButtonCreateVector.Text = "Формування вектору";
            ButtonCreateVector.UseVisualStyleBackColor = true;
            ButtonCreateVector.Click += CreateVectorButton_Click;
            // 
            // ButtonGetResult
            // 
            ButtonGetResult.Enabled = false;
            ButtonGetResult.Location = new Point(60, 220);
            ButtonGetResult.Name = "ButtonGetResult";
            ButtonGetResult.Size = new Size(106, 48);
            ButtonGetResult.TabIndex = 6;
            ButtonGetResult.Text = "Отримати результат";
            ButtonGetResult.UseVisualStyleBackColor = true;
            ButtonGetResult.Click += GetResultButton_Click;
            // 
            // LabelDeleted
            // 
            LabelDeleted.Location = new Point(10, 353);
            LabelDeleted.Name = "LabelDeleted";
            LabelDeleted.Size = new Size(206, 40);
            LabelDeleted.TabIndex = 7;
            LabelDeleted.Text = "Кількість видалених елементів:";
            LabelDeleted.TextAlign = ContentAlignment.MiddleCenter;
            LabelDeleted.Visible = false;
            // 
            // LabelDeletedCount
            // 
            LabelDeletedCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelDeletedCount.AutoSize = true;
            LabelDeletedCount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            LabelDeletedCount.Location = new Point(103, 398);
            LabelDeletedCount.Name = "LabelDeletedCount";
            LabelDeletedCount.Size = new Size(19, 25);
            LabelDeletedCount.TabIndex = 8;
            LabelDeletedCount.Text = "-";
            LabelDeletedCount.TextAlign = ContentAlignment.MiddleCenter;
            LabelDeletedCount.Visible = false;
            // 
            // LabelSum
            // 
            LabelSum.Location = new Point(36, 279);
            LabelSum.Name = "LabelSum";
            LabelSum.Size = new Size(150, 41);
            LabelSum.TabIndex = 9;
            LabelSum.Text = "Добуток парних елементів:";
            LabelSum.TextAlign = ContentAlignment.MiddleCenter;
            LabelSum.Visible = false;
            LabelSum.Click += LabelSum_Click;
            // 
            // LabelRandomVector
            // 
            LabelRandomVector.AutoSize = true;
            LabelRandomVector.Location = new Point(217, 77);
            LabelRandomVector.Name = "LabelRandomVector";
            LabelRandomVector.Size = new Size(158, 40);
            LabelRandomVector.TabIndex = 12;
            LabelRandomVector.Text = "Випадково\r\nсформований вектор";
            LabelRandomVector.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelResultVector
            // 
            LabelResultVector.AutoSize = true;
            LabelResultVector.Location = new Point(381, 77);
            LabelResultVector.Name = "LabelResultVector";
            LabelResultVector.Size = new Size(190, 40);
            LabelResultVector.TabIndex = 13;
            LabelResultVector.Text = "Вектор з\r\n видаленими елементами";
            LabelResultVector.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelSumRes
            // 
            LabelSumRes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelSumRes.AutoSize = true;
            LabelSumRes.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            LabelSumRes.Location = new Point(103, 320);
            LabelSumRes.Name = "LabelSumRes";
            LabelSumRes.Size = new Size(19, 25);
            LabelSumRes.TabIndex = 8;
            LabelSumRes.Text = "-";
            LabelSumRes.TextAlign = ContentAlignment.MiddleCenter;
            LabelSumRes.Visible = false;
            // 
            // Lab3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 442);
            Controls.Add(LabelResultVector);
            Controls.Add(LabelRandomVector);
            Controls.Add(LabelSum);
            Controls.Add(LabelSumRes);
            Controls.Add(LabelDeletedCount);
            Controls.Add(LabelDeleted);
            Controls.Add(ButtonGetResult);
            Controls.Add(ButtonCreateVector);
            Controls.Add(ListBoxResult);
            Controls.Add(ListBoxRandomVector);
            Controls.Add(LabelVectorSize);
            Controls.Add(Header);
            Controls.Add(TextBoxVectorSize);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Lab3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab3 Астаф'єв";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxVectorSize;
        private Label Header;
        private Label LabelVectorSize;
        private ListBox ListBoxRandomVector;
        private ListBox ListBoxResult;
        private Button ButtonCreateVector;
        private Button ButtonGetResult;
        private Label LabelDeleted;
        private Label LabelDeletedCount;
        private Label LabelSum;
        private Label LabelRandomVector;
        private Label LabelResultVector;
        private Label LabelSumRes;
    }
}