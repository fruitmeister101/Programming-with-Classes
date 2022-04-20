// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Console.Write("What is your First name? :");
string first = Console.ReadLine();

Console.Write("What is your Last name? :");
string last = Console.ReadLine();

if (last.ToLower() == "herron")
{
    Console.Write($"So... You are a {last}, Hmm... Interesting. That clan is small indeed.\nSearching for your... well, my folk through the world has been a task indeed...");
}
else
{
    Console.Write($"So... You are {last}, {first} {last}?\nVery good");
}


