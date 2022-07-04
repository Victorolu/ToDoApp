Console.WriteLine("Hello there, welcome to perfect square checker");
var tryAnotherNumber = true;
while (tryAnotherNumber)
{
    Console.WriteLine("Please input the number you want to check");
    string? numberString = Console.ReadLine();
    bool isInteger = Int64.TryParse(numberString, out long number);

    if (!isInteger)
    {
        Console.WriteLine("Please check that number is valid");
        return;
    }

    var squareRoot = Math.Sqrt(number);
    Console.WriteLine("Loading...");
    Thread.Sleep(2000);
    Console.WriteLine(Math.Ceiling(squareRoot) == Math.Floor(squareRoot) ? "True" : "False");
    Thread.Sleep(1000);
    Console.WriteLine("Would you like to try another number? Yes[Y] or No[N]");
    string? answer = Console.ReadLine();
    tryAnotherNumber = answer != null && answer.ToLower() == "y" ? true : false;

    if (!tryAnotherNumber)
        Console.WriteLine("See you later!!");
}