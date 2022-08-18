int soat = int.Parse(Console.ReadLine());
int minut = int.Parse(Console.ReadLine());

soat = minut < 45 ? soat - 1 : soat;
minut = minut < 45 ? minut + 60 : minut;
soat += 24;
Console.Write(soat % 24 + " " );
Console.WriteLine(minut - 45);