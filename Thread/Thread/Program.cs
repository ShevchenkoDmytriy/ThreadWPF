using System;

double m = 0;
Thread myThread1 = new Thread(Print);
myThread1.Start();
Thread myThread2 = new Thread(Print1);
myThread2.Start();
Random random= new Random();
int[] num =new int[10000];
int min, max;
min = num[0];
max = num[0];
Thread myThread3 = new Thread(Element);
myThread3.Start();
Thread myThread4 = new Thread(MinMax);
myThread4.Start();
Thread myThread5 = new Thread(Average);
myThread5.Start();
Thread myThread6 = new Thread(WriteAsync);
myThread6.Start();

void Print1()
{

    int n;
    int m;
    Console.WriteLine("Enete n: ");
    n =Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enete m: ");
    m = Convert.ToInt32(Console.ReadLine());
    for (int i = n; i <= m; i++)
    {
        Console.Write($"{i} ");
    }
}
void Print()
{
	for (int i = 0; i <= 50; i++)
	{
		Console.Write($"{i} ") ;
	}
}
void Element()
{
    for (int i = 0; i < num.Length; i++)
    {
        num[i] = random.Next(100);
        Console.Write($"{num[i]} ");
    }
}
void MinMax()
{

    for (int i = 0; i < num.Length; i++)
    {
        if (max < num[i]) max = num[i];
        if (min > num[i]) min = num[i];
    }
    Console.WriteLine($"Max={max} \nMin={min}");
}
void Average()
{


    for (int i = 0; i < num.Length; i++)
    {
        m=m+num[i];
    }
    Console.WriteLine($"Average={m/10000}");
}
async void WriteAsync()
{


    string path = "note.txt";
    string text = $"Average={m/10000} Max={max} \nMin={min}";

    using (StreamWriter writer = new StreamWriter(path, false))
    {
        await writer.WriteLineAsync(text);
    }
}