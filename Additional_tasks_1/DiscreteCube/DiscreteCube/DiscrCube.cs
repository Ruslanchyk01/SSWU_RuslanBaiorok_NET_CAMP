using System;
using System.Collections.Generic;
using System.Text;

namespace DiscreteCube
{
    // нажаль лише зміг реалізувати пошук вертикалей та горизонталей
	public class DiscrCube
    {
		private int _size;
		private int[,,] _cube;

        public DiscrCube(int size)
		{
            if (size < 2)
            {
                throw new ArgumentException("Розмір куба повинен бути більше 1");
            }
            _size = size;
            _cube = new int[size, size, size];

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        _cube[i, j, k] = random.Next(2);
                    }
                }
            }
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        sb.Append(_cube[i, j, k] + " ");

                    }
                    sb.Append("\n");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        // пошук усіх пустот (нулів)
        private List<(int, int, int)> GetVoids()
        {
            // лист для збереження координат пустот
            List<(int, int, int)> voidСoordinates = new List<(int, int, int)>();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        if (_cube[i, j, k] == 0)
                        {
                            voidСoordinates.Add((i,j,k));
                        }
                    }
                }
            }
            return voidСoordinates;
        }

        // пошук лінійних пустот
        private List<List<(int, int, int)>> GetLinearVoids()
        {
            // лист знайдених координат пустот
            List<(int, int, int)> voidСoordinates = GetVoids();

            // лист для збереження лінійних пустот
            List<List<(int, int, int)>> linearVoids = new List<List<(int, int, int)>>();

            for (int i = 0; i < voidСoordinates.Count; i++)
            {
                for (int j = i + 1; j < voidСoordinates.Count; j++)
                {
                    if (voidСoordinates[i].Item1 == voidСoordinates[j].Item1 && voidСoordinates[i].Item2 == voidСoordinates[j].Item2)
                    {
                        List<(int, int, int)> voids = new List<(int, int, int)> { voidСoordinates[i], voidСoordinates[j] };
                        int count = voids.Count;
                        for (int k = j + 1; k < voidСoordinates.Count && count < _size; k++)
                        {
                            if (voidСoordinates[i].Item1 == voidСoordinates[k].Item1 && voidСoordinates[i].Item2 == voidСoordinates[k].Item2)
                            {
                                voids.Add(voidСoordinates[k]);
                                count++;
                            }
                        }
                        if (count == _size)
                        {
                            linearVoids.Add(voids);
                        }
                    }
                    else if (voidСoordinates[i].Item2 == voidСoordinates[j].Item2 && voidСoordinates[i].Item3 == voidСoordinates[j].Item3)
                    {
                        List<(int, int, int)> voids = new List<(int, int, int)> { voidСoordinates[i], voidСoordinates[j] };
                        int count = voids.Count;
                        for (int k = j + 1; k < voidСoordinates.Count && count < _size; k++)
                        {
                            if (voidСoordinates[i].Item2 == voidСoordinates[k].Item2 && voidСoordinates[i].Item3 == voidСoordinates[k].Item3)
                            {
                                voids.Add(voidСoordinates[k]);
                                count++;
                            }
                        }
                        if (count == _size)
                        {
                            linearVoids.Add(voids);
                        }
                    }
                    else if (voidСoordinates[i].Item1 == voidСoordinates[j].Item1 && voidСoordinates[i].Item3 == voidСoordinates[j].Item3)
                    {
                        List<(int, int, int)> voids = new List<(int, int, int)> { voidСoordinates[i], voidСoordinates[j] };
                        int count = voids.Count;
                        for (int k = j + 1; k < voidСoordinates.Count && count < _size; k++)
                        {
                            if (voidСoordinates[i].Item1 == voidСoordinates[k].Item1 && voidСoordinates[i].Item3 == voidСoordinates[k].Item3)
                            {
                                voids.Add(voidСoordinates[k]);
                                count++;
                            }
                        }
                        if (count == _size)
                        {
                            linearVoids.Add(voids);
                        }
                    }
                }
            }
            return linearVoids;
        }

        // пошук початку і кінця лінійних пустот
        public List<((int, int, int), (int, int, int))> GetStartsEndsLinearVoids()
        {
            // лист знайдених лінійних пустот
            List<List<(int, int, int)>> values = GetLinearVoids();

            // лист для збереження координат початку і кінця лінійних пустот
            List<((int, int, int), (int, int, int))> startsEndsLinearVoids = new List<((int, int, int), (int, int, int))>();

            foreach (List<(int, int, int)> list in values)
            {
                (int, int, int) firstVoid = list[0];
                (int, int, int) lastVoid = list[list.Count - 1];
                startsEndsLinearVoids.Add((firstVoid, lastVoid));
            }

            return startsEndsLinearVoids;
        }
    }
}

