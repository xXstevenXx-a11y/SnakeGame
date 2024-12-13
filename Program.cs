using System;

Console.Title = "SnakeGame";
Console.WindowWidth = 50;
Console.WindowHeight = 15;

int posX = Console.WindowWidth / 2;
int posY = Console.WindowHeight / 2;
char character = 'o';
char food = '@';
Random rand = new Random();
int PosJ = rand.Next(1, 50);
int PosK = rand.Next(1, 15);
int eatenApples = 0;

while (true)
{
    Console.Clear();
    Console.SetCursorPosition(posX, posY);
    Console.Write(character);
    Console.SetCursorPosition(PosJ, PosK);
    Console.Write(food);
    Console.SetCursorPosition(0, 0);
    Console.Write($"Eaten Apples: {eatenApples}");

    var key = Console.ReadKey(intercept: true);
    
    switch (key.Key)
    {
        case ConsoleKey.UpArrow:
            posY = posY - 1;
        break;

        case ConsoleKey.DownArrow:
            posY = posY + 1;
        break;

        case ConsoleKey.RightArrow:
            posX = posX + 1;
        break;

        case ConsoleKey.LeftArrow:
            posX = posX - 1;
        break;
        
    }

    if (key.Key == ConsoleKey.Escape)
    {
        Console.Clear();
        break;
    }

    if (posX == 0 || posX == 50){
        Console.Clear();
        break;
    }

    if (posY == 0 || posY == 15){
        Console.Clear();
        break;
    }

    if (posX == PosJ && posY == PosK)
    {
        PosJ = rand.Next(1, 50);
        PosK = rand.Next(1, 15);
        eatenApples = eatenApples + 1;

        Console.Clear();
        Console.SetCursorPosition(posX, posY);
        Console.Write(character);
        Console.SetCursorPosition(PosJ, PosK);
        Console.Write(food); 
        Console.SetCursorPosition(0, 0);
        Console.Write($"Eaten Apples: {eatenApples}");
    }
}
