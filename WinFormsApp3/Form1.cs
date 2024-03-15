namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private SLAR slar; // ���� ����� ��� ���������� ��'���� SLAR
        public string data1;
        public string data2;

        public Form1(string _data1, string _data2)
        {
            InitializeComponent();
            slar = null; // ���������� ���� slar �� null
            data1 = _data1;
            data2 = _data2;
            dataGridViewMatrix.RowCount = int.Parse(data1) + 1;
            dataGridViewMatrix.ColumnCount = int.Parse(data2);
            dataGridViewVector.RowCount = int.Parse(data1) + 1;
            dataGridViewVector.ColumnCount = 1;
            dataGridViewMatrix.AllowUserToAddRows = false;
            dataGridViewVector.AllowUserToAddRows = false;
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� ��� � DataGridView �� ��������� ��'��� SLAR
                double[,] matrixData = new double[dataGridViewMatrix.RowCount, dataGridViewMatrix.ColumnCount];
                for (int i = 0; i < dataGridViewMatrix.RowCount; i++)
                {
                    for (int j = 0; j < dataGridViewMatrix.ColumnCount; j++)
                    {
                        matrixData[i, j] = Convert.ToDouble(dataGridViewMatrix.Rows[i].Cells[j].Value);
                    }
                }

                double[] vectorData = new double[dataGridViewVector.RowCount];
                for (int i = 0; i < dataGridViewVector.RowCount; i++)
                {
                    vectorData[i] = Convert.ToDouble(dataGridViewVector.Rows[i].Cells[0].Value);
                }

                // ��������� ��'��� SLAR
                slar = new SLAR(new Matrix(matrixData), new Vector(vectorData));

                // ����'����� ������� ������
                int result = slar.SolveMatrix();

                // �������� ��������� �� ����
                if (result == 0)
                {
                    // ���������� ����'����
                    textBoxSolution.Text = "����'���� ������� ������:";
                    Vector solution = slar.GetAnswers();
                    for (int i = 0; i < solution.N; i++)
                    {
                        textBoxSolution.Text += $"{Environment.NewLine}X[{i + 1}] = {solution[i]}";

                    }
                }
                else if (result == 1)
                {
                    textBoxSolution.Text = "������� ������ �� �� ����'����.";
                }
                else
                {
                    textBoxSolution.Text = "������� ������ �� ����� ����'����.";
                }
            }
            catch (FormatException)
            {
                textBoxSolution.Text = "�������������, �� �� �������� ������� �� ������� ����� ������ ��������.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (slar != null)
                {
                    // �������� ������ �������� ������� �� �������� �� �� ����
                    Matrix upperTriangular = slar.GetUpperTriangularMatrix();
                    DisplayUpperTriangularMatrix(upperTriangular);

                    // �������� ����� �������� ������� �� �������� �� �� ����
                    Matrix lowerTriangular = slar.GetLowerTriangularMatrix();

                }
                else
                {
                    textBoxSolution.Text = "�������� ����'���� ������� ������.";
                }
            }
            catch (Exception ex)
            {
                textBoxSolution.Text = $"�������: {ex.Message}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewMatrix.AllowUserToAddRows = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridViewVector.AllowUserToAddRows = false;
        }
        private void DisplayUpperTriangularMatrix(Matrix upperTriangular)
        {
            dataGridViewUpperTriangular.RowCount = upperTriangular.N;
            dataGridViewUpperTriangular.ColumnCount = upperTriangular.M;

            for (int i = 0; i < upperTriangular.N; i++)
            {
                for (int j = 0; j < upperTriangular.M; j++)
                {
                    dataGridViewUpperTriangular.Rows[i].Cells[j].Value = upperTriangular[i, j];
                }
            }
        }
        private void LoadSystemFromFile(string matrixFileName, string vectorFileName)
        {
            try
            {
                using (StreamReader matrixReader = new StreamReader(matrixFileName))
                {
                    string line = matrixReader.ReadLine();
                    string[] size = line.Split(' ');
                    int rows = int.Parse(size[0]);
                    int cols = int.Parse(size[1]);

                    // ������� ������� � ����� �� ���������� DataGridViewMatrix
                    dataGridViewMatrix.RowCount = rows;
                    dataGridViewMatrix.ColumnCount = cols;
                    for (int i = 0; i < rows; i++)
                    {
                        line = matrixReader.ReadLine();
                        string[] values = line.Split(' ');
                        for (int j = 0; j < cols; j++)
                        {
                            dataGridViewMatrix.Rows[i].Cells[j].Value = double.Parse(values[j]);
                        }
                    }
                }

                using (StreamReader vectorReader = new StreamReader(vectorFileName))
                {
                    string line = vectorReader.ReadLine();
                    int rows = int.Parse(line);

                    // ������� ������ � ����� �� ���������� DataGridViewVector
                    dataGridViewVector.RowCount = rows;
                    dataGridViewVector.ColumnCount = 1;
                    for (int i = 0; i < rows; i++)
                    {
                        line = vectorReader.ReadLine();
                        dataGridViewVector.Rows[i].Cells[0].Value = double.Parse(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ��� ��������� � �����: {ex.Message}");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            LoadSystemFromFile(textBoxfile1.Text, textBoxfile2.Text);
        }
    }
}
