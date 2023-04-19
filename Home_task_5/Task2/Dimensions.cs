using System;
namespace Task2
{
    internal class Dimensions
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public Dimensions(int width, int length, int height)
        {
            Width = width;
            Length = length;
            Height = height;
        }

        public static Dimensions CalculateBoxDimensions<T>(IEnumerable<T> products, Func<T, Dimensions> getProductDimensions)
        {
            int totalWidth = 0;
            int totalLength = 0;
            int totalHeight = 0;
            foreach (var product in products)
            {
                var dimensions = getProductDimensions(product);
                totalWidth += dimensions.Width;
                totalLength = Math.Max(totalLength, dimensions.Length);
                totalHeight = Math.Max(totalHeight, dimensions.Height);
            }
            return new Dimensions(totalWidth, totalLength, totalHeight);
        }
    }
}

