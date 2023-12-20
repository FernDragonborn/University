namespace Lab8
{
    partial class Form2
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
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(35, 35, 35);
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.ForeColor = Color.FromArgb(212, 212, 212);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(12, 56);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(150, 120);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(82, 46, 42);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(212, 212, 212);
            button1.Location = new Point(72, 234);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "Form2";
            Text = "Прибрати фігуру";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
    }
}