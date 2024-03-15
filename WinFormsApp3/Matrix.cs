using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
   public  class Matrix : ICloneable
    {
        private double[,] _source;
        public int N { get; private set; }
        public int M { get; private set; }
        public Matrix(double[,] source)
        {
            N = source.GetLength(0);
            M = source.GetLength(1);
            _source = new double[N, M];

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    _source[i, j] = source[i, j];
                }
            }
        }

        public Matrix(int n, int m)
        {
            N = n;
            M = m;
            _source = new double[N, M];
        }

        public Matrix(StreamReader sr)
        {
            ReadFromFile(sr);
        }

        public Matrix(int n, int m, int minValue, int maxValue)
        {
            N = n;
            M = m;
            _source = new double[N, M];
            var random = new Random();
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    _source[i, j] = random.Next(minValue, maxValue);
                }
            }
        }

        public static Matrix operator +(Matrix f, Matrix s) => f.OperationOnMatrix(s, (a, b) => a + b);

        public static Matrix operator -(Matrix f, Matrix s) => f.OperationOnMatrix(s, (a, b) => a - b);

        public static Matrix operator *(Matrix f, Matrix s) => f.Multiplications(s);

        public double this[int i, int j]
        {
            get => _source[i, j];

            set => _source[i, j] = value;
        }

        public void WtiteToFile(string fileName)
        {
            if (!File.Exists(fileName))
                _ = File.Create(fileName);

            using var sw = new StreamWriter(fileName);

            sw.WriteLine($"{N} {M}");
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    sw.Write($"{Math.Round(_source[i, j], 2)} ");
                }
                sw.WriteLine();
            }

        }

        public void Print()
        {
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    var value = Math.Round(_source[i, j], 1);
                    Console.Write("{0,6}", value);
                }
                Console.WriteLine();
            }
        }

        public double FindNorm()
        {
            var max = 0.0;
            for (var i = 0; i < N; i++)
            {
                var currentValue = 0.0;
                for (var j = 0; j < M; j++)
                {
                    currentValue += Math.Abs(_source[i, j]);
                }

                if (currentValue > max)
                    max = currentValue;
            }
            return max;
        }

        public double FindMaxModul()
        {
            var max = 0.0;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    if (Math.Abs(_source[i, j]) > max)
                        max = Math.Abs(_source[i, j]);
                }
            }
            return max;
        }

        public double FindEvklidNorm()
        {
            var normSquared = 0.0;
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    normSquared += Math.Pow(_source[i, j], 2);
                }
            }
            return Math.Sqrt(normSquared);
        }

        public void ReadFromFile(StreamReader sr)
        {
            try
            {
                var line = sr.ReadLine();
                var rowCol = line!.Split(" ");
                N = int.Parse(rowCol[0], CultureInfo.InvariantCulture);
                M = int.Parse(rowCol[1], CultureInfo.InvariantCulture);
                _source = new double[N, M];

                for (var i = 0; i < N; i++)
                {
                    line = sr.ReadLine();
                    var rowArr = line!
                        .Split(" ")
                        .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                        .ToArray();

                    for (var j = 0; j < M; j++)
                    {
                        _source[i, j] = rowArr[j];
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"It's format error: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"It's overflow error: {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Index out of range: {ex.Message}");
            }
        }

        private Matrix OperationOnMatrix(Matrix matrix, Func<double, double, double> operation)
        {
            var resMat = new Matrix(N, M);
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < M; j++)
                {
                    resMat._source[i, j] = operation(_source[i, j], matrix._source[i, j]);
                }
            }
            return resMat;
        }

        private Matrix Multiplications(Matrix matrix)
        {
            var resMat = new Matrix(N, matrix.M);

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < matrix.M; j++)
                {
                    resMat._source[i, j] = 0;

                    for (var k = 0; k < M; k++)
                    {
                        resMat._source[i, j] += _source[i, k] * matrix._source[k, j];
                    }
                }
            }
            return resMat;
        }

        public object Clone()
        {
            return new Matrix(_source);
        }
    }
}
