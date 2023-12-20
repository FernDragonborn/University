using Label = System.Windows.Forms.Label;

namespace lab6
{
    partial class Lab6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lab6));
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            відкритиToolStripMenuItem = new ToolStripMenuItem();
            зберегтиРезультатToolStripMenuItem = new ToolStripMenuItem();
            вихідToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            Task_lable = new Label();
            openFileDialog_input = new OpenFileDialog();
            save_result_FileDialog = new SaveFileDialog();
            PathToFileLabel = new Label();
            TaskLabel = new Label();
            openFileButton = new Button();
            saveFileButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, вихідToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(521, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { відкритиToolStripMenuItem, зберегтиРезультатToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // відкритиToolStripMenuItem
            // 
            відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            відкритиToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            відкритиToolStripMenuItem.Size = new Size(276, 26);
            відкритиToolStripMenuItem.Text = "Відкрити файл";
            відкритиToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // зберегтиРезультатToolStripMenuItem
            // 
            зберегтиРезультатToolStripMenuItem.Name = "зберегтиРезультатToolStripMenuItem";
            зберегтиРезультатToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            зберегтиРезультатToolStripMenuItem.Size = new Size(276, 26);
            зберегтиРезультатToolStripMenuItem.Text = "Зберегти результат";
            зберегтиРезультатToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // вихідToolStripMenuItem
            // 
            вихідToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            вихідToolStripMenuItem.Size = new Size(59, 24);
            вихідToolStripMenuItem.Text = "Close";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(224, 26);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // Task_lable
            // 
            Task_lable.AutoSize = true;
            Task_lable.Location = new Point(7, 37);
            Task_lable.Name = "Task_lable";
            Task_lable.Size = new Size(0, 20);
            Task_lable.TabIndex = 1;
            Task_lable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // openFileDialog_input
            // 
            openFileDialog_input.FileName = "openFileDialog_input";
            // 
            // PathToFileLabel
            // 
            PathToFileLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PathToFileLabel.AutoEllipsis = true;
            PathToFileLabel.AutoSize = true;
            PathToFileLabel.Cursor = Cursors.WaitCursor;
            PathToFileLabel.Location = new Point(12, 163);
            PathToFileLabel.Name = "PathToFileLabel";
            PathToFileLabel.Size = new Size(101, 20);
            PathToFileLabel.TabIndex = 2;
            PathToFileLabel.Text = "work with file:";
            PathToFileLabel.TextAlign = ContentAlignment.MiddleCenter;
            PathToFileLabel.Visible = false;
            // 
            // TaskLabel
            // 
            TaskLabel.AutoSize = true;
            TaskLabel.Location = new Point(12, 37);
            TaskLabel.Name = "TaskLabel";
            TaskLabel.Size = new Size(509, 80);
            TaskLabel.TabIndex = 3;
            TaskLabel.Text = resources.GetString("TaskLabel.Text");
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(12, 126);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(94, 29);
            openFileButton.TabIndex = 4;
            openFileButton.Text = "open file";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += Button1_Click;
            // 
            // saveFileButton
            // 
            saveFileButton.Location = new Point(125, 126);
            saveFileButton.Name = "saveFileButton";
            saveFileButton.Size = new Size(94, 29);
            saveFileButton.TabIndex = 4;
            saveFileButton.Text = "save result";
            saveFileButton.UseVisualStyleBackColor = true;
            saveFileButton.Click += SaveFileButton_Click;
            // 
            // Lab6
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 208);
            Controls.Add(saveFileButton);
            Controls.Add(openFileButton);
            Controls.Add(TaskLabel);
            Controls.Add(PathToFileLabel);
            Controls.Add(Task_lable);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Name = "Lab6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab6_1 Астаф'єв";
            DragDrop += DragNDrop;
            DragEnter += DragNDrop_Animate;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem відкритиToolStripMenuItem;
        private ToolStripMenuItem зберегтиРезультатToolStripMenuItem;
        private ToolStripMenuItem вихідToolStripMenuItem;
        private Label Task_lable;
        private OpenFileDialog openFileDialog_input;
        private SaveFileDialog save_result_FileDialog;
        private Label PathToFileLabel;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Label TaskLabel;
        private Button openFileButton;
        private Button saveFileButton;
    }
}