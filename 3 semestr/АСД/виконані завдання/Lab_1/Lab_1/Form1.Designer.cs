namespace Lab_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DataT = new System.Windows.Forms.TextBox();
            this.DataL = new System.Windows.Forms.Label();
            this.додатиЕлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиОстаннійЕлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.інформаціяПроСтекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.інформаціяПроВаріантToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.виведенняРезультатуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.виведенняСтекуНаЕкранToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowElToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stackb = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataT
            // 
            this.DataT.Location = new System.Drawing.Point(348, 231);
            this.DataT.Name = "DataT";
            this.DataT.Size = new System.Drawing.Size(125, 27);
            this.DataT.TabIndex = 1;
            this.DataT.Visible = false;
            this.DataT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // DataL
            // 
            this.DataL.AutoSize = true;
            this.DataL.Location = new System.Drawing.Point(363, 208);
            this.DataL.Name = "DataL";
            this.DataL.Size = new System.Drawing.Size(93, 20);
            this.DataL.TabIndex = 2;
            this.DataL.Text = "Введіть дані";
            this.DataL.Visible = false;
            // 
            // додатиЕлементToolStripMenuItem
            // 
            this.додатиЕлементToolStripMenuItem.Name = "додатиЕлементToolStripMenuItem";
            this.додатиЕлементToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.додатиЕлементToolStripMenuItem.Text = "Додати елемент";
            this.додатиЕлементToolStripMenuItem.Click += new System.EventHandler(this.додатиЕлементToolStripMenuItem_Click);
            // 
            // видалитиОстаннійЕлементToolStripMenuItem
            // 
            this.видалитиОстаннійЕлементToolStripMenuItem.Name = "видалитиОстаннійЕлементToolStripMenuItem";
            this.видалитиОстаннійЕлементToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.видалитиОстаннійЕлементToolStripMenuItem.Text = "Видалити останній елемент";
            this.видалитиОстаннійЕлементToolStripMenuItem.Click += new System.EventHandler(this.видалитиОстаннійЕлементToolStripMenuItem_Click);
            // 
            // інформаціяПроСтекToolStripMenuItem
            // 
            this.інформаціяПроСтекToolStripMenuItem.Name = "інформаціяПроСтекToolStripMenuItem";
            this.інформаціяПроСтекToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
            this.інформаціяПроСтекToolStripMenuItem.Text = "Інформація про стек";
            this.інформаціяПроСтекToolStripMenuItem.Click += new System.EventHandler(this.інформаціяПроСтекToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиЕлементToolStripMenuItem,
            this.інформаціяПроВаріантToolStripMenuItem,
            this.видалитиОстаннійЕлементToolStripMenuItem,
            this.інформаціяПроСтекToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // інформаціяПроВаріантToolStripMenuItem
            // 
            this.інформаціяПроВаріантToolStripMenuItem.Name = "інформаціяПроВаріантToolStripMenuItem";
            this.інформаціяПроВаріантToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.інформаціяПроВаріантToolStripMenuItem.Text = "Інформація про варіант";
            this.інформаціяПроВаріантToolStripMenuItem.Click += new System.EventHandler(this.інформаціяПроВаріантToolStripMenuItem_Click);
            // 
            // menuStrip3
            // 
            this.menuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.виведенняРезультатуToolStripMenuItem,
            this.виведенняСтекуНаЕкранToolStripMenuItem,
            this.ShowElToolStripMenuItem,
            this.вихідToolStripMenuItem1});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(800, 28);
            this.menuStrip3.TabIndex = 5;
            this.menuStrip3.Text = "menuStrip3";
            this.menuStrip3.Visible = false;
            // 
            // виведенняРезультатуToolStripMenuItem
            // 
            this.виведенняРезультатуToolStripMenuItem.Name = "виведенняРезультатуToolStripMenuItem";
            this.виведенняРезультатуToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.виведенняРезультатуToolStripMenuItem.Text = "Найбільший елемент стеку";
            this.виведенняРезультатуToolStripMenuItem.Click += new System.EventHandler(this.виведенняРезультатуToolStripMenuItem_Click_1);
            // 
            // виведенняСтекуНаЕкранToolStripMenuItem
            // 
            this.виведенняСтекуНаЕкранToolStripMenuItem.Name = "виведенняСтекуНаЕкранToolStripMenuItem";
            this.виведенняСтекуНаЕкранToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.виведенняСтекуНаЕкранToolStripMenuItem.Text = "Виведення стеку на екран";
            this.виведенняСтекуНаЕкранToolStripMenuItem.Click += new System.EventHandler(this.виведенняСтекуНаЕкранToolStripMenuItem_Click);
            // 
            // ShowElToolStripMenuItem
            // 
            this.ShowElToolStripMenuItem.Name = "ShowElToolStripMenuItem";
            this.ShowElToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.ShowElToolStripMenuItem.Text = "Останній введений елемент";
            this.ShowElToolStripMenuItem.Click += new System.EventHandler(this.ShowElToolStripMenuItem_Click);
            // 
            // вихідToolStripMenuItem1
            // 
            this.вихідToolStripMenuItem1.Name = "вихідToolStripMenuItem1";
            this.вихідToolStripMenuItem1.Size = new System.Drawing.Size(60, 24);
            this.вихідToolStripMenuItem1.Text = "Вихід";
            this.вихідToolStripMenuItem1.Click += new System.EventHandler(this.вихідToolStripMenuItem1_Click);
            // 
            // stackb
            // 
            this.stackb.Location = new System.Drawing.Point(348, 309);
            this.stackb.Name = "stackb";
            this.stackb.Size = new System.Drawing.Size(125, 43);
            this.stackb.TabIndex = 6;
            this.stackb.Text = "Створити стек";
            this.stackb.UseVisualStyleBackColor = true;
            this.stackb.Click += new System.EventHandler(this.stackb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stackb);
            this.Controls.Add(this.menuStrip3);
            this.Controls.Add(this.DataL);
            this.Controls.Add(this.DataT);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторна робота 1 Пилипчук Олександр";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox DataT;
        private Label DataL;
        private ToolStripMenuItem додатиЕлементToolStripMenuItem;
        private ToolStripMenuItem видалитиОстаннійЕлементToolStripMenuItem;
        private ToolStripMenuItem інформаціяПроСтекToolStripMenuItem;
        private MenuStrip menuStrip1;
        private MenuStrip menuStrip3;
        private ToolStripMenuItem інформаціяПроВаріантToolStripMenuItem;
        private ToolStripMenuItem виведенняРезультатуToolStripMenuItem;
        private ToolStripMenuItem виведенняСтекуНаЕкранToolStripMenuItem;
        private ToolStripMenuItem вихідToolStripMenuItem1;
        private Button stackb;
        private ToolStripMenuItem ShowElToolStripMenuItem;
    }
}