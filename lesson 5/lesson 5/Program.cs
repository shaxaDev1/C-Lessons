var menu = new string[]
{
    "Testni boshlash",
    "Savol qoshish",
    "Malumot",
    "Statistika"
};

//Console.WriteLine("Testni boshlash");
//Console.WriteLine("Savol qoshish");
//Console.WriteLine("Malumot");
//Console.WriteLine("Statistika");

for(int i = 1; i <= menu.Length; i++)
{
    Console.WriteLine(menu[i]);
}
switch (menu)
{
   
}
var statistika =new string[][]
{
    new string[]{"Javlon","4","5"}
};

var belitlar = new string[][]
{
    new string[]{"5 * 4 = ?", "20","21","23"},
    new string[]{"5 + 4 = ?", "9","12","10"},
    new string[]{"5 - 4 = ?", "1","2","3"},
    new string[]{"16 / 4 = ?", "4","2","3"},
    new string[]{"5 % 4 = ?", "1","4","6"}

};




    int b1= 0;
    int k = 0;
    int b2 = 0;
    for (int i = 0; i < belitlar.Length; i++)
    {

        for (int j = 0; j < belitlar[i].Length; j++)
        {
            k = j;
            if (j == 0) Console.WriteLine("savol " + belitlar[i][j]);
            else Console.WriteLine($"{j}.{belitlar[i][j]}");
        }
        Console.Write("Javob : ");
        var input = Console.ReadLine();

        string javob = "Notogri";
        if (input == "1")
        {
            javob = "Togri";
            b1++;
        }
        if (i == belitlar.Length - 1 && k == belitlar[0].Length - 1)
        {
            Console.WriteLine("tugatish uchun enterni bosing");
        }
        else
        {
            Console.WriteLine($"{javob}\n Kengi savolga entrni bosing");
        }

        Console.ReadKey();
    }
    Console.WriteLine($"togri javobingiz {b1} ta");





void Show(string[] ms)
{
    foreach (var m in ms) Console.WriteLine(m);

}
