namespace Lab_5
{
    partial class Lab_5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lab_5));
            InputTextBox = new TextBox();
            TaskLabel = new Label();
            InputLabel = new Label();
            ResultLabel = new Label();
            ResultRichTextBox = new RichTextBox();
            DataToolStripMenuItem = new ToolStripMenuItem();
            ввестиТекстToolStripMenuItem = new ToolStripMenuItem();
            очиститиПолеВведенняToolStripMenuItem = new ToolStripMenuItem();
            очиститиПолеРезультатуToolStripMenuItem = new ToolStripMenuItem();
            очиститиВСЕToolStripMenuItem = new ToolStripMenuItem();
            DoShowDebugMessageToolStripMenuItem = new ToolStripMenuItem();
            ExecutionToolStripMenuItem = new ToolStripMenuItem();
            ExecuteToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            MinimizeToolStripMenuItem = new ToolStripMenuItem();
            CloseToolStripMenuItem = new ToolStripMenuItem();
            stripMenu = new MenuStrip();
            stripMenu.SuspendLayout();
            SuspendLayout();
            // 
            // InputTextBox
            // 
            InputTextBox.Location = new Point(18, 139);
            InputTextBox.Name = "InputTextBox";
            InputTextBox.Size = new Size(487, 27);
            InputTextBox.TabIndex = 0;
            InputTextBox.KeyDown += TextBoxInputPhrase_KeyDown;
            InputTextBox.KeyPress += TextBoxInputPhrase_KeyPress;
            InputTextBox.KeyUp += TextBoxInputPhrase_KeyUp;
            // 
            // TaskLabel
            // 
            TaskLabel.AutoSize = true;
            TaskLabel.Location = new Point(17, 34);
            TaskLabel.Name = "TaskLabel";
            TaskLabel.Size = new Size(509, 80);
            TaskLabel.TabIndex = 1;
            TaskLabel.Text = resources.GetString("TaskLabel.Text");
            TaskLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Location = new Point(12, 116);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(138, 20);
            InputLabel.TabIndex = 2;
            InputLabel.Text = "Початковий рядок";
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(16, 173);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(75, 20);
            ResultLabel.TabIndex = 3;
            ResultLabel.Text = "Результат";
            ResultLabel.Visible = false;
            // 
            // ResultRichTextBox
            // 
            ResultRichTextBox.Location = new Point(16, 196);
            ResultRichTextBox.Name = "ResultRichTextBox";
            ResultRichTextBox.ReadOnly = true;
            ResultRichTextBox.Size = new Size(489, 173);
            ResultRichTextBox.TabIndex = 5;
            ResultRichTextBox.Text = "";
            ResultRichTextBox.Visible = false;
            // 
            // DataToolStripMenuItem
            // 
            DataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ввестиТекстToolStripMenuItem, очиститиПолеВведенняToolStripMenuItem, очиститиПолеРезультатуToolStripMenuItem, очиститиВСЕToolStripMenuItem, DoShowDebugMessageToolStripMenuItem });
            DataToolStripMenuItem.Name = "DataToolStripMenuItem";
            DataToolStripMenuItem.Size = new Size(135, 24);
            DataToolStripMenuItem.Text = "Введення даних";
            // 
            // ввестиТекстToolStripMenuItem
            // 
            ввестиТекстToolStripMenuItem.Name = "ввестиТекстToolStripMenuItem";
            ввестиТекстToolStripMenuItem.Size = new Size(399, 26);
            ввестиТекстToolStripMenuItem.Text = "Ввести текст";
            ввестиТекстToolStripMenuItem.Click += InputTextToolStripMenuItem_Click;
            // 
            // очиститиПолеВведенняToolStripMenuItem
            // 
            очиститиПолеВведенняToolStripMenuItem.Name = "очиститиПолеВведенняToolStripMenuItem";
            очиститиПолеВведенняToolStripMenuItem.Size = new Size(399, 26);
            очиститиПолеВведенняToolStripMenuItem.Text = "Очистити поле введення";
            очиститиПолеВведенняToolStripMenuItem.Click += ClearInputTextBoxToolStripMenuItem_Click;
            // 
            // очиститиПолеРезультатуToolStripMenuItem
            // 
            очиститиПолеРезультатуToolStripMenuItem.Name = "очиститиПолеРезультатуToolStripMenuItem";
            очиститиПолеРезультатуToolStripMenuItem.Size = new Size(399, 26);
            очиститиПолеРезультатуToolStripMenuItem.Text = "Очистити поле результату";
            очиститиПолеРезультатуToolStripMenuItem.Click += ClearResultTextBoxToolStripMenuItem_Click;
            // 
            // очиститиВСЕToolStripMenuItem
            // 
            очиститиВСЕToolStripMenuItem.Name = "очиститиВСЕToolStripMenuItem";
            очиститиВСЕToolStripMenuItem.Size = new Size(399, 26);
            очиститиВСЕToolStripMenuItem.Text = "Очистити все";
            очиститиВСЕToolStripMenuItem.Click += ClearAllToolStripMenuItem_Click;
            // 
            // DoShowDebugMessageToolStripMenuItem
            // 
            DoShowDebugMessageToolStripMenuItem.Name = "DoShowDebugMessageToolStripMenuItem";
            DoShowDebugMessageToolStripMenuItem.Size = new Size(399, 26);
            DoShowDebugMessageToolStripMenuItem.Text = "Режим відладки (показувати повідомлення)";
            DoShowDebugMessageToolStripMenuItem.Click += DoShowDebugMessageToolStripMenuItem_Click;
            // 
            // ExecutionToolStripMenuItem
            // 
            ExecutionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ExecuteToolStripMenuItem });
            ExecutionToolStripMenuItem.Name = "ExecutionToolStripMenuItem";
            ExecutionToolStripMenuItem.Size = new Size(112, 24);
            ExecutionToolStripMenuItem.Text = "Оброблення";
            // 
            // ExecuteToolStripMenuItem
            // 
            ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem";
            ExecuteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            ExecuteToolStripMenuItem.Size = new Size(224, 26);
            ExecuteToolStripMenuItem.Text = "Обробити";
            ExecuteToolStripMenuItem.Click += ExecuteToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MinimizeToolStripMenuItem, CloseToolStripMenuItem });
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(60, 24);
            ExitToolStripMenuItem.Text = "Вихід";
            // 
            // MinimizeToolStripMenuItem
            // 
            MinimizeToolStripMenuItem.Name = "MinimizeToolStripMenuItem";
            MinimizeToolStripMenuItem.Size = new Size(155, 26);
            MinimizeToolStripMenuItem.Text = "Згорнути";
            MinimizeToolStripMenuItem.Click += MinimizeToolStripMenuItem_Click;
            // 
            // CloseToolStripMenuItem
            // 
            CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            CloseToolStripMenuItem.Size = new Size(155, 26);
            CloseToolStripMenuItem.Text = "Закрити";
            CloseToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // stripMenu
            // 
            stripMenu.ImageScalingSize = new Size(20, 20);
            stripMenu.Items.AddRange(new ToolStripItem[] { DataToolStripMenuItem, ExecutionToolStripMenuItem, ExitToolStripMenuItem });
            stripMenu.Location = new Point(0, 0);
            stripMenu.MdiWindowListItem = DataToolStripMenuItem;
            stripMenu.Name = "stripMenu";
            stripMenu.Size = new Size(517, 28);
            stripMenu.TabIndex = 4;
            stripMenu.Text = "menuStrip1";
            // 
            // Lab_5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 378);
            ControlBox = false;
            Controls.Add(ResultRichTextBox);
            Controls.Add(ResultLabel);
            Controls.Add(InputLabel);
            Controls.Add(TaskLabel);
            Controls.Add(InputTextBox);
            Controls.Add(stripMenu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = stripMenu;
            Name = "Lab_5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab5 Астаф'єв";
            stripMenu.ResumeLayout(false);
            stripMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputTextBox;
        private Label TaskLabel;
        private Label InputLabel;
        private Label ResultLabel;
        private RichTextBox ResultRichTextBox;
        private ToolStripMenuItem DataToolStripMenuItem;
        private ToolStripMenuItem ввестиТекстToolStripMenuItem;
        private ToolStripMenuItem очиститиПолеВведенняToolStripMenuItem;
        private ToolStripMenuItem очиститиПолеРезультатуToolStripMenuItem;
        private ToolStripMenuItem очиститиВСЕToolStripMenuItem;
        private ToolStripMenuItem ExecutionToolStripMenuItem;
        private ToolStripMenuItem ExecuteToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem MinimizeToolStripMenuItem;
        private ToolStripMenuItem CloseToolStripMenuItem;
        private MenuStrip stripMenu;
        private ToolStripMenuItem DoShowDebugMessageToolStripMenuItem;
    }
}