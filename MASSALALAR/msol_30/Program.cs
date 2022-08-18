int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());
if (a > b && a > c)
{
    Console.WriteLine(a);
}
else if(b > a && b > c )
{
    Console.WriteLine(b);
}
else if (c > a && c > b)
{
    Console.WriteLine(c);
}

