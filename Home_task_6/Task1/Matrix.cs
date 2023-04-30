using System;
using System.Text;
using System.Collections;

namespace Task1
{
    public class Matrix<T> : IEnumerable<T>
    {
        private readonly T[,] _matrix;
        private readonly int _size;

        public Matrix(int size)
        {
            _size = size;
            _matrix = new T[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _matrix[i, j] = (T)GenerateRandomValue();
                }
            }
        }

        private object GenerateRandomValue()
        {
            Random random = new Random();

            int minValue = 1;
            int maxValue = 20;
            int minMaxForDoubleFloat = (maxValue - minValue) + minValue;

            if (_matrix is int[,])
                return random.Next(minValue, maxValue);
            else if (_matrix is double[,])
                return random.NextDouble() * minMaxForDoubleFloat;
            else if (_matrix is float[,])
                return (float)random.NextDouble() * minMaxForDoubleFloat;
            else
                throw new Exception("Неправильний тип даних. Допустимі типи даних: int, double, float");
        }

        public IEnumerator<T> GetEnumerator()
        {
            int rows = _size;
            int cols = _size;
            bool down = true;
            for (int i = 0; i < rows + cols - 1; i++)
            {
                int row = down ? (i < cols ? 0 : i - cols + 1) : (i < rows ? i : rows - 1);
                int col = down ? (i < cols ? i : cols - 1) : (i < rows ? 0 : i - rows + 1);

                while (row >= 0 && col >= 0 && row < rows && col < cols)
                {
                    yield return _matrix[row, col];
                    row += down ? 1 : -1;
                    col += down ? -1 : 1;
                }

                down = !down;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    sb.Append(_matrix[i, j] + "\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}

