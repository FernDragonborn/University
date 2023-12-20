namespace Lab_7
{
    partial class Lab_7
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
            menuStrip = new MenuStrip();
            генераціяДаннихToolStripMenuItem = new ToolStripMenuItem();
            згенеруватиДаніToolStripMenuItem = new ToolStripMenuItem();
            зКлавіатуриToolStripMenuItem = new ToolStripMenuItem();
            відкритиToolStripMenuItem = new ToolStripMenuItem();
            зберегтиToolStripMenuItem = new ToolStripMenuItem();
            результатToolStripMenuItem = new ToolStripMenuItem();
            ExecuteToolStripMenuItem = new ToolStripMenuItem();
            вихідToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            TaskLabel = new Label();
            InputTextBox = new TextBox();
            InputLabel = new Label();
            ChangedLabel = new Label();
            ElementQuantityLabel = new Label();
            ChangedTextBox = new TextBox();
            NegativeSumLabel = new Label();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { генераціяДаннихToolStripMenuItem, результатToolStripMenuItem, вихідToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(393, 28);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // генераціяДаннихToolStripMenuItem
            // 
            генераціяДаннихToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { згенеруватиДаніToolStripMenuItem, зКлавіатуриToolStripMenuItem, відкритиToolStripMenuItem, зберегтиToolStripMenuItem });
            генераціяДаннихToolStripMenuItem.Name = "генераціяДаннихToolStripMenuItem";
            генераціяДаннихToolStripMenuItem.Size = new Size(144, 24);
            генераціяДаннихToolStripMenuItem.Text = "Введення данних";
            // 
            // згенеруватиДаніToolStripMenuItem
            // 
            згенеруватиДаніToolStripMenuItem.Name = "згенеруватиДаніToolStripMenuItem";
            згенеруватиДаніToolStripMenuItem.Size = new Size(217, 26);
            згенеруватиДаніToolStripMenuItem.Text = "Згенерувати дані";
            згенеруватиДаніToolStripMenuItem.Click += CreateDataToolStripMenuItem_Click;
            // 
            // зКлавіатуриToolStripMenuItem
            // 
            зКлавіатуриToolStripMenuItem.Name = "зКлавіатуриToolStripMenuItem";
            зКлавіатуриToolStripMenuItem.Size = new Size(217, 26);
            зКлавіатуриToolStripMenuItem.Text = "З клавіатури";
            зКлавіатуриToolStripMenuItem.Click += KeyboardEnterToolStripMenuItem_Click;
            // 
            // відкритиToolStripMenuItem
            // 
            відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            відкритиToolStripMenuItem.Size = new Size(217, 26);
            відкритиToolStripMenuItem.Text = "Відкрити файл bin";
            відкритиToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // зберегтиToolStripMenuItem
            // 
            зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            зберегтиToolStripMenuItem.Size = new Size(217, 26);
            зберегтиToolStripMenuItem.Text = "Зберегти bin";
            зберегтиToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // результатToolStripMenuItem
            // 
            результатToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExecuteToolStripMenuItem });
            результатToolStripMenuItem.Name = "результатToolStripMenuItem";
            результатToolStripMenuItem.Size = new Size(89, 24);
            результатToolStripMenuItem.Text = "Результат";
            // 
            // ExecuteToolStripMenuItem
            // 
            ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem";
            ExecuteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            ExecuteToolStripMenuItem.Size = new Size(219, 26);
            ExecuteToolStripMenuItem.Text = "Виповнити";
            ExecuteToolStripMenuItem.Click += ExecuteToolStripMenuItem_Click;
            // 
            // вихідToolStripMenuItem
            // 
            вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            вихідToolStripMenuItem.Size = new Size(60, 24);
            вихідToolStripMenuItem.Text = "Вихід";
            вихідToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // TaskLabel
            // 
            TaskLabel.AutoSize = true;
            TaskLabel.Location = new Point(9, 33);
            TaskLabel.Name = "TaskLabel";
            TaskLabel.Size = new Size(375, 80);
            TaskLabel.TabIndex = 1;
            TaskLabel.Text = "Прочитати з файла цілі чотирибайтні елементи (Int),\r\nпідрахувати загальну кількість елементів файла,\r\nа також замінити у файлі усі непарні елементи\r\nна модуль суми компонентів файла;";
            TaskLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(13, 148);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.ReadOnly = true;
            InputTextBox.Size = new Size(374, 27);
            InputTextBox.TabIndex = 2;
            InputTextBox.Visible = false;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Location = new Point(12, 125);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(120, 20);
            InputLabel.TabIndex = 3;
            InputLabel.Text = "Вміст bin файлу:";
            InputLabel.Visible = false;
            // 
            // ChangedLabel
            // 
            ChangedLabel.AutoSize = true;
            ChangedLabel.Location = new Point(13, 188);
            ChangedLabel.Name = "ChangedLabel";
            ChangedLabel.Size = new Size(287, 20);
            ChangedLabel.TabIndex = 4;
            ChangedLabel.Text = "Вміст зміненого двійкового (bin) файлу:";
            ChangedLabel.Visible = false;
            // 
            // ElementQuantityLabel
            // 
            ElementQuantityLabel.AutoSize = true;
            ElementQuantityLabel.Location = new Point(13, 250);
            ElementQuantityLabel.Name = "ElementQuantityLabel";
            ElementQuantityLabel.Size = new Size(258, 20);
            ElementQuantityLabel.TabIndex = 5;
            ElementQuantityLabel.Text = "Загальна кількість елементів файлу:";
            ElementQuantityLabel.Visible = false;
            // 
            // ChangedTextBox
            // 
            ChangedTextBox.Location = new Point(12, 211);
            ChangedTextBox.Name = "ChangedTextBox";
            ChangedTextBox.ReadOnly = true;
            ChangedTextBox.Size = new Size(375, 27);
            ChangedTextBox.TabIndex = 6;
            ChangedTextBox.Visible = false;
            // 
            // NegativeSumLabel
            // 
            NegativeSumLabel.AutoSize = true;
            NegativeSumLabel.Location = new Point(13, 285);
            NegativeSumLabel.Name = "NegativeSumLabel";
            NegativeSumLabel.Size = new Size(337, 20);
            NegativeSumLabel.TabIndex = 7;
            NegativeSumLabel.Text = "Сума, на яку будуть замінені додатні елементи:\r\n";
            NegativeSumLabel.Visible = false;
            // 
            // Lab_7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 314);
            Controls.Add(NegativeSumLabel);
            Controls.Add(ChangedTextBox);
            Controls.Add(ElementQuantityLabel);
            Controls.Add(ChangedLabel);
            Controls.Add(InputLabel);
            Controls.Add(InputTextBox);
            Controls.Add(TaskLabel);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip;
            Name = "Lab_7";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab7 Астаф'єв";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem результатToolStripMenuItem;
        private ToolStripMenuItem вихідToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private Label TaskLabel;
        private TextBox InputTextBox;
        private Label InputLabel;
        private Label ChangedLabel;
        private Label ElementQuantityLabel;
        private TextBox ChangedTextBox;
        private ToolStripMenuItem ExecuteToolStripMenuItem;
        private ToolStripMenuItem генераціяДаннихToolStripMenuItem;
        private ToolStripMenuItem зКлавіатуриToolStripMenuItem;
        private ToolStripMenuItem відкритиToolStripMenuItem;
        private ToolStripMenuItem зберегтиToolStripMenuItem;
        public SaveFileDialog saveFileDialog;
        private ToolStripMenuItem згенеруватиДаніToolStripMenuItem;
        private Label NegativeSumLabel;
    }
}