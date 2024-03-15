namespace WinFormsApp3
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
            textBoxData1 = new TextBox();
            textBoxData2 = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxData1
            // 
            textBoxData1.Location = new Point(213, 92);
            textBoxData1.Name = "textBoxData1";
            textBoxData1.Size = new Size(100, 23);
            textBoxData1.TabIndex = 0;
            // 
            // textBoxData2
            // 
            textBoxData2.Location = new Point(338, 92);
            textBoxData2.Name = "textBoxData2";
            textBoxData2.Size = new Size(100, 23);
            textBoxData2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(273, 155);
            button1.Name = "button1";
            button1.Size = new Size(118, 36);
            button1.TabIndex = 2;
            button1.Text = "Продовжити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 63);
            label1.Name = "label1";
            label1.Size = new Size(167, 15);
            label1.TabIndex = 3;
            label1.Text = "Введіть розмірність матриці :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 127);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Рядки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(363, 127);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 5;
            label3.Text = "Стовпці";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(319, 95);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 6;
            label4.Text = "х";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 325);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(textBoxData2);
            Controls.Add(textBoxData1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxData1;
        private TextBox textBoxData2;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}