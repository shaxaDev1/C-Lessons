
string[][] quiz = new string[][]
{
    new string[] {"4 + 2 = ?","6","9","7","2"},
    new string[] {"4 * 2 = ?","8","4","16","9"},
    new string[] {"4 / 2 = ?","2","5","7","5"}
};
int b1 = 0;
int k = 0;
for (int i = 0; i <quiz.Length; i++)
{
    for (int j =0; j < quiz[i].Length; j++)
    {
        k = j;
        if (j == 0) Console.WriteLine("savol= " + quiz[i][j]);
        else Console.WriteLine($"{j} . {quiz[i][j]}");
    }
    Console.WriteLine("Jovob : ");
    var input = Console.ReadLine();

    string javob = "Notogri";
    if (input == "1")
    {
        javob = "Togri";
        b1++;
    }
    if(i == quiz.Length-1 && k == quiz[0].Length-1)
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

