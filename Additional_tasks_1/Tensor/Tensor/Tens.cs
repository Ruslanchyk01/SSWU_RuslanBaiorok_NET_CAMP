using System;

namespace Tensor
{
    class Tens
    {
        private readonly int[] _size;

        public Tens(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException("Розмір повинен бути більше 0");
            }
            _size = new int[size];
            for (int i = 0; i < size; i++)
            {
                _size[i] = size;
            }
        }
        public Array GetTensor()
        {
            Type tensType = typeof(int);
            Array tens = Array.CreateInstance(tensType, _size);

            return tens;
        }
    }
}