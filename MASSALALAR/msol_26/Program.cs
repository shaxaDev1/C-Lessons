int a1 = int.Parse(Console.ReadLine());
int b1 = int.Parse(Console.ReadLine());
int t = default;
int c = default;
if(a1 > b1)
{
     t = a1 / b1;
     c = a1 % b1;
}
else
{
    t = b1 / a1;
    c = b1 % a1;
}
Console.WriteLine(t);
Console.WriteLine(c);
