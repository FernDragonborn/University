namespace Lab_4
{
    partial class Lab_4
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
            dataGridCreated = new DataGridView();
            dataGridDeleted = new DataGridView();
            LabelHeader = new Label();
            labelMatrixRank = new Label();
            textBoxMatrixRank = new TextBox();
            buttonCreateMatrix = new Button();
            buttonDeleteElements = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridCreated).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridDeleted).BeginInit();
            SuspendLayout();
            // 
            // dataGridCreated
            // 
            dataGridCreated.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCreated.Location = new Point(12, 85);
            dataGridCreated.Name = "dataGridCreated";
            dataGridCreated.RowHeadersWidth = 51;
            dataGridCreated.RowTemplate.Height = 29;
            dataGridCreated.Size = new Size(300, 188);
            dataGridCreated.TabIndex = 0;
            // 
            // dataGridDeleted
            // 
            dataGridDeleted.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDeleted.Location = new Point(334, 85);
            dataGridDeleted.Name = "dataGridDeleted";
            dataGridDeleted.RowHeadersWidth = 51;
            dataGridDeleted.RowTemplate.Height = 29;
            dataGridDeleted.Size = new Size(300, 188);
            dataGridDeleted.TabIndex = 0;
            // 
            // LabelHeader
            // 
            LabelHeader.AutoSize = true;
            LabelHeader.Location = new Point(42, 9);
            LabelHeader.Name = "LabelHeader";
            LabelHeader.Size = new Size(298, 20);
            LabelHeader.TabIndex = 1;
            LabelHeader.Text = "Видалити всі елементи, що дорівнюють 0";
            // 
            // labelMatrixRank
            // 
            labelMatrixRank.AutoSize = true;
            labelMatrixRank.Location = new Point(42, 45);
            labelMatrixRank.Name = "labelMatrixRank";
            labelMatrixRank.Size = new Size(365, 20);
            labelMatrixRank.TabIndex = 1;
            labelMatrixRank.Text = "Введіть кількість рядків та стовпців матриці (2 - 15)";
            // 
            // textBoxMatrixRank
            // 
            textBoxMatrixRank.Location = new Point(413, 42);
            textBoxMatrixRank.Name = "textBoxMatrixRank";
            textBoxMatrixRank.Size = new Size(125, 27);
            textBoxMatrixRank.TabIndex = 2;
            textBoxMatrixRank.TextChanged += textBoxMatrixRank_TextChanged;
            // 
            // buttonCreateMatrix
            // 
            buttonCreateMatrix.Location = new Point(92, 290);
            buttonCreateMatrix.Name = "buttonCreateMatrix";
            buttonCreateMatrix.Size = new Size(112, 57);
            buttonCreateMatrix.TabIndex = 3;
            buttonCreateMatrix.Text = "Формування\r\nматриці";
            buttonCreateMatrix.UseVisualStyleBackColor = true;
            buttonCreateMatrix.Click += buttonCreateMatrix_Click;
            // 
            // buttonDeleteElements
            // 
            buttonDeleteElements.Enabled = false;
            buttonDeleteElements.Location = new Point(433, 290);
            buttonDeleteElements.Name = "buttonDeleteElements";
            buttonDeleteElements.Size = new Size(97, 57);
            buttonDeleteElements.TabIndex = 3;
            buttonDeleteElements.Text = "Отримання результату";
            buttonDeleteElements.UseVisualStyleBackColor = true;
            buttonDeleteElements.Click += DeleteElements_button_Click;
            // 
            // Lab_4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 362);
            Controls.Add(buttonDeleteElements);
            Controls.Add(buttonCreateMatrix);
            Controls.Add(textBoxMatrixRank);
            Controls.Add(labelMatrixRank);
            Controls.Add(LabelHeader);
            Controls.Add(dataGridDeleted);
            Controls.Add(dataGridCreated);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Lab_4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ЛР4 Астаф'єв";
            ((System.ComponentModel.ISupportInitialize)dataGridCreated).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridDeleted).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridCreated;
        private DataGridView dataGridDeleted;
        private Label LabelHeader;
        private Label labelMatrixRank;
        private TextBox textBoxMatrixRank;
        private Button buttonCreateMatrix;
        private Button buttonDeleteElements;
    }
}