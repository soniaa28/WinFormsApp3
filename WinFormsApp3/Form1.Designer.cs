namespace WinFormsApp3
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
            dataGridViewMatrix = new DataGridView();
            x1 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            X4 = new DataGridViewTextBoxColumn();
            X5 = new DataGridViewTextBoxColumn();
            dataGridViewVector = new DataGridView();
            v = new DataGridViewTextBoxColumn();
            textBoxSolution = new TextBox();
            dataGridViewUpperTriangular = new DataGridView();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            button4 = new Button();
            button1 = new Button();
            button2 = new Button();
            textBoxfile1 = new TextBox();
            textBoxfile2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVector).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpperTriangular).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMatrix
            // 
            dataGridViewMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMatrix.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            dataGridViewMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMatrix.Columns.AddRange(new DataGridViewColumn[] { x1, Column1, Column2, X4, X5 });
            dataGridViewMatrix.Location = new Point(34, 36);
            dataGridViewMatrix.Name = "dataGridViewMatrix";
            dataGridViewMatrix.Size = new Size(343, 174);
            dataGridViewMatrix.TabIndex = 0;
            // 
            // x1
            // 
            x1.HeaderText = "X1";
            x1.Name = "x1";
            // 
            // Column1
            // 
            Column1.HeaderText = "X2";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "X3";
            Column2.Name = "Column2";
            // 
            // X4
            // 
            X4.HeaderText = "X4";
            X4.Name = "X4";
            // 
            // X5
            // 
            X5.HeaderText = "X5";
            X5.Name = "X5";
            // 
            // dataGridViewVector
            // 
            dataGridViewVector.AllowUserToOrderColumns = true;
            dataGridViewVector.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVector.Columns.AddRange(new DataGridViewColumn[] { v });
            dataGridViewVector.Location = new Point(409, 36);
            dataGridViewVector.Name = "dataGridViewVector";
            dataGridViewVector.Size = new Size(144, 174);
            dataGridViewVector.TabIndex = 4;
            // 
            // v
            // 
            v.HeaderText = "V";
            v.Name = "v";
            // 
            // textBoxSolution
            // 
            textBoxSolution.Location = new Point(349, 280);
            textBoxSolution.Name = "textBoxSolution";
            textBoxSolution.Size = new Size(490, 23);
            textBoxSolution.TabIndex = 5;
            textBoxSolution.Click += buttonSolve_Click;
            // 
            // dataGridViewUpperTriangular
            // 
            dataGridViewUpperTriangular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUpperTriangular.Columns.AddRange(new DataGridViewColumn[] { Column3, Column4, Column5, Column6, Column7 });
            dataGridViewUpperTriangular.Location = new Point(43, 252);
            dataGridViewUpperTriangular.Name = "dataGridViewUpperTriangular";
            dataGridViewUpperTriangular.Size = new Size(240, 150);
            dataGridViewUpperTriangular.TabIndex = 7;
            // 
            // Column3
            // 
            Column3.HeaderText = "X1";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "X2";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "X3";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "X4";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "X5";
            Column7.Name = "Column7";
            // 
            // button4
            // 
            button4.Location = new Point(61, 429);
            button4.Name = "button4";
            button4.Size = new Size(207, 23);
            button4.TabIndex = 9;
            button4.Text = "Декомпонована матриця";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(588, 36);
            button1.Name = "button1";
            button1.Size = new Size(90, 23);
            button1.TabIndex = 2;
            button1.Text = "Обчислити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonSolve_Click;
            // 
            // button2
            // 
            button2.Location = new Point(616, 140);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // textBoxfile1
            // 
            textBoxfile1.Location = new Point(600, 105);
            textBoxfile1.Name = "textBoxfile1";
            textBoxfile1.Size = new Size(100, 23);
            textBoxfile1.TabIndex = 11;
            // 
            // textBoxfile2
            // 
            textBoxfile2.Location = new Point(739, 105);
            textBoxfile2.Name = "textBoxfile2";
            textBoxfile2.Size = new Size(100, 23);
            textBoxfile2.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(922, 644);
            Controls.Add(textBoxfile2);
            Controls.Add(textBoxfile1);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(dataGridViewUpperTriangular);
            Controls.Add(textBoxSolution);
            Controls.Add(dataGridViewVector);
            Controls.Add(button1);
            Controls.Add(dataGridViewMatrix);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVector).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUpperTriangular).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewMatrix;
        private DataGridView dataGridViewVector;
        private TextBox textBoxSolution;
        private DataGridView dataGridViewUpperTriangular;
        private DataGridView dataGridViewLowerTriangular;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private Button button4;
        private DataGridViewTextBoxColumn x1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn X4;
        private DataGridViewTextBoxColumn X5;
        private DataGridViewTextBoxColumn v;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Button button1;
        private Button button2;
        private TextBox textBoxfile1;
        private TextBox textBoxfile2;
    }
}
