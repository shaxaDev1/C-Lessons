int a = int.Parse(Console.ReadLine());

if( a % 2 == 0 && a % 3 == 0 && a % 5 == 0 )
{
    Console.WriteLine("A");
}
else if (a % 2 == 0 && a % 3 == 0 )
{
    Console.WriteLine("B");
}
else if (a % 2 == 0  && a % 5 == 0)
{
    Console.WriteLine("C");
}
else if (a % 3 == 0 && a % 5 == 0)
{
    Console.WriteLine("D");
 
}
else if (a % 2 == 0 || a % 3 == 0 || a % 5 == 0)
{
    Console.WriteLine("E");
}
else { 
}

