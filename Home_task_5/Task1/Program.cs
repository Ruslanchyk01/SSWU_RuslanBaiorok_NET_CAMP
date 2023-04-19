using Home_task_5;

Garden garden1 = new Garden();
garden1.Trees.Add(new Tree(1, 0));
garden1.Trees.Add(new Tree(2, 0));
garden1.Trees.Add(new Tree(1, 1));
garden1.Trees.Add(new Tree(2, 2));
garden1.Trees.Add(new Tree(4, 1));
garden1.Trees.Add(new Tree(3, 2));
garden1.Trees.Add(new Tree(0, 3));
garden1.Trees.Add(new Tree(0, 5));
garden1.Trees.Add(new Tree(2, 4));
garden1.Trees.Add(new Tree(3, 5));
garden1.Trees.Add(new Tree(5, 4));

double gardenLength1 = Garden.GetLength(garden1);
Console.Write("Довжина огорожі саду 1: ");
Console.WriteLine(gardenLength1);

double gardenArea1 = Garden.GetArea(garden1);
Console.Write("Площа огорожі саду 1: ");
Console.WriteLine(gardenArea1);

Garden garden2 = new Garden();
garden2.Trees.Add(new Tree(0, 0));
garden2.Trees.Add(new Tree(0, 3));
garden2.Trees.Add(new Tree(3, 0));
garden2.Trees.Add(new Tree(3, 3));
garden2.Trees.Add(new Tree(1, 1));
garden2.Trees.Add(new Tree(2, 2));

double gardenLength2 = Garden.GetLength(garden2);
Console.Write("Довжина огорожі саду 2: ");
Console.WriteLine(gardenLength2);

double gardenArea2 = Garden.GetArea(garden2);
Console.Write("Площа огорожі саду 1: ");
Console.WriteLine(gardenArea2);

if (garden1 == garden2)
{
    Console.WriteLine("Довжина огорож однакова");
}
else
{
    Console.WriteLine("Довжина огорож різна");
}

if (garden1 > garden2)
{
    Console.WriteLine($"Довжина огорожі саду 1 ({Garden.GetLength(garden1):F3}) більша ніж саду 2 ({Garden.GetLength(garden2):F3})");
}
else
{
    Console.WriteLine($"Довжина огорожі саду 1 ({Garden.GetLength(garden1):F3}) менша ніж саду 2 ({Garden.GetLength(garden2):F3})");
}