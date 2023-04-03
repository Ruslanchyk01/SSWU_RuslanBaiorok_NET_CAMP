using Tensor;

Tens tens1 = new Tens(1);
Console.WriteLine(tens1.GetTensor()); //System.Int32[]
int[] values1 = (int[])tens1.GetTensor();
values1[0] = 1;
Console.WriteLine(values1[0]);


Tens tens2 = new Tens(2);
Console.WriteLine(tens2.GetTensor()); // System.Int32[,]
int[,] values2 = (int[,])tens2.GetTensor();
for (int i = 0; i < values2.GetLength(0); i++)
{
    for (int j = 0; j < values2.GetLength(1); j++)
    {
        values2[i, j] = i + j;
    }
}
for (int i = 0; i < values2.GetLength(0); i++)
{
    for (int j = 0; j < values2.GetLength(1); j++)
    {
        Console.Write(values2[i, j] + " ");
    }
    Console.WriteLine();
}


Tens tens3 = new Tens(3);
Console.WriteLine(tens3.GetTensor()); //System.Int32[,,]
int[,,] values3 = (int[,,])tens3.GetTensor();
for (int i = 0; i < values3.GetLength(0); i++)
{
    for (int j = 0; j < values3.GetLength(1); j++)
    {
        for (int k = 0; k < values3.GetLength(2); k++)
        {
            values3[i, j, k] = i + j + k;
        }
    }
}
for (int i = 0; i < values3.GetLength(0); i++)
{
    for (int j = 0; j < values3.GetLength(1); j++)
    {
        for (int k = 0; k < values3.GetLength(2); k++)
        {
            Console.Write(values3[i, j, k] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}


Tens tens4 = new Tens(4);
Console.WriteLine(tens4.GetTensor()); //System.Int32[,,,]

Tens tens5 = new Tens(5);
Console.WriteLine(tens5.GetTensor()); //System.Int32[,,,,]



