using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data1 = textBoxData1.Text;
            string data2 = textBoxData2.Text;

            // Створіть екземпляр другої форми, передаючи дані як параметри
            Form1 secondForm = new Form1(data1, data2);

            // Показати другу форму
            secondForm.Show();

        }

        
    }
}
