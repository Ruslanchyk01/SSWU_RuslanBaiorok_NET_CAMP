using System;
using System.Text;

namespace Task2
{
	public class ColorMatrix
	{
		private int _sizeN; // кількість рядочків
        private int _sizeM; // кількість стовпчиків

        private int[,] _matrix;
// Краще ці атрибути визначити як параметри результату методу, а не поля.
        private int _longestLineIndex = 0; // індекс [i] найдовшої лінії
        private int _longestLineStartIndex = 0; // індекс [j] початку найдовшої лінії
        private int _longestLineEndIndex = 0; // індекс [j] кінця найдовшої лінії
        private int _longestLineLength = 0; // довжина найдовшої лінії

		public ColorMatrix(int sizeN, int sizeM)
		{
			_sizeN = sizeN;
			_sizeM = sizeM;

            _matrix = new int[sizeN, sizeM];

            Random random = new Random();
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeM; j++)
                {
                    _matrix[i, j] = random.Next(17);
                }
            }
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
// Не вартує об'єднувати сстан системи і результат одного з методів. Це зробить проблемним додавання інших методів заповнення матриці при потребі.		
            sb.Append($"Індекс [i] найдовшої лінії: {_longestLineIndex}");
            sb.Append("\n");
            sb.Append($"Початковий індекс [j] найдовшої лінії: {_longestLineStartIndex}");
            sb.Append("\n");
            sb.Append($"Кінцевий індекс [j] найдовшої лінії: {_longestLineEndIndex}");
            sb.Append("\n");
            sb.Append($"Довжина найдовшої лінії: {_longestLineLength}");
            sb.Append("\n");
            sb.Append($"Колір найдовшої лінії: {_matrix[_longestLineIndex, _longestLineStartIndex]}");
            return sb.ToString();
        }

        public void GetInfoLongestLineColor()
        {
            for (int i = 0; i < _sizeN; i++)
            {
                int currentLineLength = 0; // довжина поточної лінії
                int currentLineStartIndex = 0; // початковий індекс поточної лінії

                for (int j = 0; j < _sizeM; j++)
                {
                    // перевірка чи поточний піксель має той самий колір
                    if (j > 0 && _matrix[i, j] == _matrix[i, j - 1])
                    {
                        // збільшуємо довжину лінії
                        currentLineLength++;
                    }
                    //якщо піксель має інший колір від попереднього
                    else
                    {
                        // перевірка чи довжина поточної лінії більша за найдовшу досі знайдену
                        if (currentLineLength > _longestLineLength)
                        {
                            // оновлюємо інформацію
                            _longestLineStartIndex = currentLineStartIndex;
                            _longestLineEndIndex = j - 1;
                            _longestLineIndex = i;
                            _longestLineLength = currentLineLength;
                        }
                        // дані для нової лінії
                        currentLineLength = 1;
                        currentLineStartIndex = j;
                    }

                    // перевірка чи довжина поточної лінії більша за найдовшу досі знайдену
                    if (currentLineLength > _longestLineLength)
                    {
                        // оновлюємо інформацію
                        _longestLineStartIndex = currentLineStartIndex;
                        _longestLineEndIndex = j;
                        _longestLineIndex = i;
                        _longestLineLength = currentLineLength;
                    }
                }
            }
        }
	}
}

