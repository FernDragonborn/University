using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace Lab8
{
    partial class NotificationWindow
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

        object[] a = new object[2];

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        void PreInit(string Text, Point position)
        {
            a[0] = Text;
            a[1] = position;
        }
        private void InitializeComponent()
        {

            NotifyLabel = new Label();
            SuspendLayout();
            // 
            // NotifyLabel
            // 
            NotifyLabel.Dock = DockStyle.Fill;
            NotifyLabel.Location = new Point(0, 0);
            NotifyLabel.Name = "NotifyLabel";
            NotifyLabel.Size = new Size(138, 113);
            NotifyLabel.TabIndex = 0;
            NotifyLabel.Text = "label1";
            // 
            // NotificationWindow
            // 
            string s = (string)a[0];
            Point point = (Point)a[1];
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            int width = 8 * Text.Length + 10; //magic number: 12px is 9pt (scale of text). +10 is for boudaries
            this.ClientSize = new System.Drawing.Size(width, 16);
            this.Text = "Form1";
            //AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(NotifyLabel);
            FormBorderStyle = FormBorderStyle.None;
            ResumeLayout(false);
        }

        //private void InitializeComponent()
        //{
        //string s = (string)a[0];
        //Point point = (Point)a[1];
        //    this.components = new System.ComponentModel.Container();
        //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //int width = 12 * Text.Length + 10; //magic number: 12px is 9pt (scale of text). +10 is for boudaries
        //    this.ClientSize = new System.Drawing.Size(width, 16);
        //this.Text = "Form1";
        //}

        #endregion

        private Label NotifyLabel;
    }
}