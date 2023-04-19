using System;
using System.Drawing;

namespace Home_task_5
{
    public class Tree
    {
        private readonly int _x;
        private readonly int _y;
        public int X { get => _x; }
        public int Y { get => _y; }

        public Tree(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }


    class Garden
    {
        public List<Tree> Trees { get; set; }

        public Garden()
        {
            Trees = new List<Tree>();
        }

        private static double FindDistanceBetweenTrees(Tree tree1, Tree tree2)
        {
            int xDiff = tree2.X - tree1.X;
            int yDiff = tree2.Y - tree1.Y;
            double distance = Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
            return distance;
        }

        public static double GetLength(Garden garden)
        {
            List<Tree> utmostTrees = FindTrees(garden);

            double fenceLength = 0;
            for (int i = 0; i < utmostTrees.Count - 1; i++)
            {
                fenceLength += FindDistanceBetweenTrees(utmostTrees[i], utmostTrees[i + 1]);
            }
            fenceLength += FindDistanceBetweenTrees(utmostTrees[utmostTrees.Count - 1], utmostTrees[0]);

            return fenceLength;
        }

        private static List<Tree> FindTrees(Garden garden)
        {
            List<Tree> trees = garden.Trees.Select(x => new Tree(x.X, x.Y)).ToList();
            List<Tree> utmost = new List<Tree>();

            Tree start = trees.Where(x => x.Y == trees.Min(min => min.Y)).First();

            Tree current = start;
            Tree next;

            do
            {
                utmost.Add(current);
                next = trees[0];

                for (int i = 1; i < trees.Count; i++)
                {
                    if (next == current || IsLeftOf(current, next, trees[i]))
                    {
                        next = trees[i];
                    }
                }

                current = next;
            } while (current != start);

            List<Tree> innerTrees = new List<Tree>();
            foreach (var tree in garden.Trees)
            {
                var p = new Tree(tree.X, tree.Y);
                if (!utmost.Contains(p))
                {
                    innerTrees.Add(p);
                }
            }

            foreach (var inner in innerTrees)
            {
                trees.Remove(inner);
            }

            return utmost;
        }

        private static bool IsLeftOf(Tree A, Tree B, Tree C)
        {
            return ((B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X)) < 0;
        }

        public static double GetArea(Garden garden)
        {
            List<Tree> utmostTrees = FindTrees(garden);
            double area = 0;

            for (int i = 0; i < utmostTrees.Count; i++)
            {
                int j = (i + 1) % utmostTrees.Count;
                double y1 = utmostTrees[i].Y;
                double y2 = utmostTrees[j].Y;
                double x1 = utmostTrees[i].X;
                double x2 = utmostTrees[j].X;
                area += (x2 - x1) * (y1 + y2) / 2;
            }

            return Math.Abs(area);
        }



        public static bool operator ==(Garden garden1, Garden garden2)
        {
            return GetLength(garden1) == GetLength(garden2);
        }

        public static bool operator !=(Garden garden1, Garden garden2)
        {
            return GetLength(garden1) == GetLength(garden2);
        }

        public static bool operator <(Garden garden1, Garden garden2)
        {
            return GetLength(garden1) < GetLength(garden2);
        }

        public static bool operator >(Garden garden1, Garden garden2)
        {
            return GetLength(garden1) > GetLength(garden2);
        }

        public static bool operator <=(Garden garden1, Garden garden2)
        {
            return GetLength(garden1) <= GetLength(garden2);
        }

        public static bool operator >=(Garden garden1, Garden garden2)
        {
            return GetLength(garden1) >= GetLength(garden2);
        }

    }

}

