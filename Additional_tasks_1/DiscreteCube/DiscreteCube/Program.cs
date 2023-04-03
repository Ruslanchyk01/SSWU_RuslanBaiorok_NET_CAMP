using System;
using DiscreteCube;

DiscrCube cube = new(3);
Console.WriteLine(cube);

List<((int, int, int), (int, int, int))> startsEndsLinearVoids = cube.GetStartsEndsLinearVoids();

foreach(var voids in startsEndsLinearVoids)
{
    Console.WriteLine($"({voids.Item1.Item1}, {voids.Item1.Item2}, {voids.Item1.Item3}) - ({voids.Item2.Item1}, {voids.Item2.Item2}, {voids.Item2.Item3})");
}