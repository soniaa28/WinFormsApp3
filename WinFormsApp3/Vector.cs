using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
   public  class Vector : ICloneable
    {
        private double[] _source;
        public int N { get; private set; }

        public Vector(double[] source)
        {
            N = source.GetLength(0);
            _source = new double[N];
            Array.Copy(source, _source, N);
        }

        public Vector(int n)
        {
            N = n;
            _source = new double[n];
        }

        public Vector(int n, int minValue, int maxValue)
        {
            N = n;
            _source = new double[N];

            var random = new Random();
            for (var i = 0; i < N; i++)
            {
                _source[i] = random.Next(minValue, maxValue);
            }
        }

        public Vector(StreamReader sr)
        {
            ReadFromFile(sr);
        }

        public double this[int index]
        {
            get => _source[index];

            set => _source[index] = value;
        }

        public void Print()
        {
            for (var i = 0; i < N; i++)
            {
                Console.Write($"{_source[i]} ");
            }
            Console.WriteLine();
        }

        public void ReadFromFile(StreamReader sr)
        {
            try
            {
                var line = sr.ReadLine();
                N = int.Parse(line!, CultureInfo.InvariantCulture);
                _source = new double[N];

                var arrLine = sr.ReadLine();
                var rowArr = arrLine!
                    .Split(" ")
                    .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                    .ToArray();

                _source = rowArr;
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

        public object Clone()
        {
            return new Vector(_source);
        }
    }
}
