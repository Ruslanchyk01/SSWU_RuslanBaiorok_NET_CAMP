using System;
using System.Text;

namespace Task1
{
    public class SnakeMatrix
    {
        private int _sizeN; // кількість рядочків
        private int _sizeM; // кількість стовпчиків

        private int[,] _matrix;

        public SnakeMatrix(int sizeN, int sizeM)
        {
            _sizeN = sizeN;
            _sizeM = sizeM;
            _matrix = new int[sizeN, sizeM];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _sizeN; i++)
            {
                for (int j = 0; j < _sizeM; j++)
                {
                    sb.Append(_matrix[i, j] + "\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        // метод для дз
        public void CreateMatrixTopToBottom()
        {
            int num = 1;
            int row = 0, col = 0;
            int lastRow = _sizeN - 1, lastCol = _sizeM - 1;


            while (num <= _sizeN * _sizeM)
            {
                // заповнення стовпця зверху внизу
                for (int i = row; i <= lastRow; i++)
                {
                    _matrix[i, col] = num++;
                }
                col++;

                // заповнння рядка зліва направо
                for (int i = col; i <= lastCol; i++)
                {
                    _matrix[lastRow, i] = num++;
                }
                lastRow--;

                // перевірка для зміщщення заповнення стовпців до центру
                if (col <= lastCol)
                {
                    // заповнення стовпця знизу вверх
                    for (int i = lastRow; i >= row; i--)
                    {
                        _matrix[i, lastCol] = num++;
                    }
                    lastCol--;
                }

                // перевірка для зміщщення заповнення рядків до центру
                if (row <= lastRow)
                {
                    // заповнення рядка справа наліво
                    for (int i = lastCol; i >= col; i--)
                    {
                        _matrix[row, i] = num++;
                    }
                    row++;
                }
            }
        }



        // приклад розвернутих змійок
        public void CreateMatrixLeftToRight()
        {
            int num = 1;
            int row = 0, col = 0;
            int lastRow = _sizeN - 1, lastCol = _sizeM - 1;

            while (num <= _sizeN * _sizeM)
            {
                // заповнння рядка зліва направо
                for (int i = col; i <= lastCol; i++)
                {
                    _matrix[row, i] = num++;
                }
                row++;

                // заповнення стовпця зверху внизу
                for (int i = row; i <= lastRow; i++)
                {
                    _matrix[i, lastCol] = num++;
                }
                lastCol--;

                // перевірка для зміщщення заповнення рядків до центру
                if (row <= lastRow)
                {
                    // заповнення рядка справа наліво
                    for (int i = lastCol; i >= col; i--)
                    {
                        _matrix[lastRow, i] = num++;
                    }
                    lastRow--;
                }

                // перевірка для зміщщення заповнення стовпців до центру
                if (col <= lastCol)
                {
                    // заповнення стовпця знизу вверх
                    for (int i = lastRow; i >= row; i--)
                    {
                        _matrix[i, col] = num++;
                    }
                    col++;
                }
            }
        }

        public void CreateMatrixBottomToTop()
        {
            int num = 1;
            int row = _sizeN - 1, col = 0;
            int lastRow = 0, lastCol = _sizeM - 1;

            while (num <= _sizeN * _sizeM)
            {
                // заповнння рядка знизу вверх
                for (int i = row; i >= lastRow; i--)
                {
                    _matrix[i, col] = num++;
                }
                col++;

                // заповнння рядка зліва направо
                for (int i = col; i <= lastCol; i++)
                {
                    _matrix[lastRow, i] = num++;
                }
                lastRow++;

                if (col <= lastCol)
                {
                    // заповнння рядка зверху вниз
                    for (int i = lastRow; i <= row; i++)
                    {
                        _matrix[i, lastCol] = num++;
                    }
                    lastCol--;
                }

                if (row >= lastRow)
                {
                    // заповнння рядка справа наліво
                    for (int i = lastCol; i >= col; i--)
                    {
                        _matrix[row, i] = num++;
                    }
                    row--;
                }
            }
        }

        public void CreateMatrixRightToLeft()
        {
            int num = 1;
            int row = 0, col = _sizeM - 1;
            int lastRow = _sizeN - 1, lastCol = 0;

            while (num <= _sizeN * _sizeM)
            {
                // заповнння рядка справа наліво
                for (int i = col; i >= lastCol; i--)
                {
                    _matrix[row, i] = num++;
                }
                row++;

                // заповнння рядка зверху вниз
                for (int i = row; i <= lastRow; i++)
                {
                    _matrix[i, lastCol] = num++;
                }
                lastCol++;

                if (row <= lastRow)
                {
                    // заповнння рядка зліва направо
                    for (int i = lastCol; i <= col; i++)
                    {
                        _matrix[lastRow, i] = num++;
                    }
                    lastRow--;
                }

                if (col >= lastCol)
                {
                    // заповнння рядка знизу вверх
                    for (int i = lastRow; i >= row; i--)
                    {
                        _matrix[i, col] = num++;
                    }
                    col--;
                }
            }
        }
    }
}