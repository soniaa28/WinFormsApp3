using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class SLAR
    {
        private Matrix _a;

        private Vector _x;

        private Vector _b;
        private Matrix _upperTriangular; // Для зберігання верхньої трикутної матриці
        private Matrix _lowerTriangular; // Для зберігання нижньої трикутної матриці

        public int N { get; private set; }

        public int M { get; private set; }

        public SLAR(Matrix a, Vector b)
        {
            if (a.N != b.N)
            {
                Console.WriteLine("Number of matrix rows should be equal to the number of vector B rows");
            }

            _a = (Matrix)a.Clone();
            _b = (Vector)b.Clone();
            N = a.N;
            M = a.M;
            _x = new Vector(N);
        }
        public SLAR(string fileName)
        {
            ReadFromFile(fileName);
            _x = new Vector(N);
        }

        public Vector GetAnswers()
        {
            return _x;
        }

        public void ReadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                _ = File.Create(fileName);

            try
            {
                using var sr = new StreamReader(fileName);
                _a = new Matrix(sr);
                _b = new Vector(sr);
                N = _a.N;
                M = _a.M;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Print()
        {
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    var value = Math.Round(_a[i, j], 1).ToString(CultureInfo.InvariantCulture);
                    var pluseOrEq = j == M - 1 ? "=" : "+";
                    Console.Write($"{value} * X{j + 1}  {pluseOrEq}  ");
                }
                Console.Write(Math.Round(_b[i], 1).ToString(CultureInfo.InvariantCulture));
                Console.WriteLine();
            }
        }

        public void PrintSolve()
        {
            for (var i = 0; i < N; i++)
            {
                var value = Math.Round(_x[i], 1).ToString(CultureInfo.InvariantCulture);
                var el = i != N - 1 ? ", " : ";";
                Console.Write($"X{i + 1} = {value}{el}");
            }
            Console.WriteLine();
        }

        public void PrintToFile(string fileName)
        {
            if (!File.Exists(fileName))
                _ = File.Create(fileName);

            using var sw = new StreamWriter(fileName);

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    sw.Write(Math.Round(_a[i, j], 1).ToString(CultureInfo.InvariantCulture) + "\t");
                }

                sw.Write("\t" + Math.Round(_x[i], 1).ToString(CultureInfo.InvariantCulture));
                sw.Write("\t" + Math.Round(_b[i], 1).ToString(CultureInfo.InvariantCulture));
                sw.WriteLine();
            }
        }

        private void SortRows(int SortIndex, Matrix a, Vector b)
        {

            var maxElement = a[SortIndex, SortIndex];
            var maxElementIndex = SortIndex;
            for (var i = SortIndex + 1; i < N; i++)
            {
                if (a[i, SortIndex] > maxElement)
                {
                    maxElement = a[i, SortIndex];
                    maxElementIndex = i;
                }
            }

            //тепер знайдено максимальний елемент ставимо його на верхнє місце
            if (maxElementIndex > SortIndex)//якщо це не перший елемент
            {
                var temp = b[maxElementIndex];
                b[maxElementIndex] = b[SortIndex];
                b[SortIndex] = temp;

                for (var i = 0; i < M; i++)
                {
                    temp = a[maxElementIndex, i];
                    a[maxElementIndex, i] = a[SortIndex, i];
                    a[SortIndex, i] = temp;
                }
            }
        }

        public int SolveMatrix()
        {
            var aCopy = (Matrix)_a.Clone();
            var bCopy = (Vector)_b.Clone();

            if (N != M)
                return 1; //немає розв'язку
                          // Ініціалізація матриць
            _upperTriangular = new Matrix(N, M);
            _lowerTriangular = new Matrix(N, M);

            for (var i = 0; i < N - 1; i++)
            {
                SortRows(i, aCopy, bCopy);
                for (var j = i + 1; j < N; j++)
                {
                    if (aCopy[i, i] != 0) //якщо головний елемент не 0, то робимо обчислення
                    {
                        var multElement = aCopy[j, i] / aCopy[i, i];
                        for (var k = i; k < N; k++)
                            aCopy[j, k] -= aCopy[i, k] * multElement;
                        bCopy[j] -= bCopy[i] * multElement;
                    }
                    //для нульового головного елемента просто пропускаємо цей крок
                }
            }
            // Заповнення верхньої та нижньої трикутних матриць
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (j >= i)
                        _upperTriangular[i, j] = aCopy[i, j];
                    else
                        _lowerTriangular[i, j] = aCopy[i, j];
                }
            }
            //шукаємо розв'язок
            for (var i = N - 1; i >= 0; i--)
            {
                _x[i] = bCopy[i];

                for (var j = N - 1; j > i; j--)
                    _x[i] -= aCopy[i, j] * _x[j];

                if (aCopy[i, i] == 0)
                {
                    if (bCopy[i] == 0)
                        return 2; //багато розв'язків
                    else
                        return 1; //немає розв'язку
                }

                _x[i] /= aCopy[i, i];

            }
            return 0;
        }
        public Matrix FindInverseMatrix()
        {
            // Створіть одиничну матрицю
            Matrix identityMatrix = new Matrix(N, N);
            for (int i = 0; i < N; i++)
            {
                identityMatrix[i, i] = 1;
            }

            // Розв'яжіть систему лінійних рівнянь для кожного стовпця одиничної матриці
            Matrix inverseMatrix = new Matrix(N, N);
            for (int i = 0; i < N; i++)
            {
                Vector column = new Vector(N);
                for (int j = 0; j < N; j++)
                {
                    column[j] = identityMatrix[j, i];
                }
                SLAR slar = new SLAR(_upperTriangular, column);
                slar.SolveMatrix();
                Vector solution = slar.GetAnswers();
                for (int j = 0; j < N; j++)
                {
                    inverseMatrix[j, i] = solution[j];
                }
            }

            return inverseMatrix;
        }
        public Matrix GetUpperTriangularMatrix()
        {
            return _upperTriangular;
        }

        public Matrix GetLowerTriangularMatrix()
        {
            return _lowerTriangular;
        }
    }
}


