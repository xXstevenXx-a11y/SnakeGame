using System;
using System.Security.Cryptography.X509Certificates;

/*-------------------------------------------------------------------------------*/
// Configuración de la Ventana

Console.Title = "SnakeGame";
Console.WindowWidth = 50;
Console.WindowHeight = 15;
/*-------------------------------------------------------------------------------*/

/*-------------------------------------------------------------------------------*/
//Variables

int headPosX = Console.WindowWidth / 2;
int headPosY = Console.WindowHeight / 2;
Random rand = new Random();
int foodPosX = rand.Next(1, 50);
int foodPosY = rand.Next(1, 15);
int foodEaten = 0;

char character = '0';
char food = '@';

List<(int x, int y)> body = new List<(int, int)>();

var key = ConsoleKey.RightArrow;
/*-------------------------------------------------------------------------------*/

/*-------------------------------------------------------------------------------*/
//Bucle de Juego

while (true)
{
    DrawFrame(headPosX, headPosY, character, food, foodPosX, foodPosY, foodEaten, body);

    if (Console.KeyAvailable)
    {
          key = Console.ReadKey(intercept: true).Key;  
    }

    switch (key)
    {
        
        case ConsoleKey.UpArrow:
            headPosY = headPosY - 1;
            key = ConsoleKey.UpArrow;
        break;

        case ConsoleKey.DownArrow:
            headPosY = headPosY + 1;
            key = ConsoleKey.DownArrow;
        break;

        case ConsoleKey.RightArrow:
            headPosX = headPosX + 1;
            key = ConsoleKey.RightArrow;
        break;

        case ConsoleKey.LeftArrow:
            headPosX = headPosX - 1;
            key = ConsoleKey.LeftArrow;
        break;
        
    }

    if (key == ConsoleKey.Escape)
    {
        Console.Clear();
        break;
    }

    if (headPosX == 0 || headPosX == 50){
        Console.Clear();
        break;
    }

    if (headPosY == 0 || headPosY == 15){
        Console.Clear();
        break;
    }

    if (headPosX == foodPosX && headPosY == foodPosY)
    {
        foodPosX = rand.Next(1, 50);
        foodPosY = rand.Next(1, 15);
        foodEaten = foodEaten + 1;
        body.Add((body[body.Count - 1].x, body[body.Count - 1].y));
        DrawFrame(headPosX, headPosY, character, food, foodPosX, foodPosY, foodEaten, body);
    }
}
/*-------------------------------------------------------------------------------*/

/*-------------------------------------------------------------------------------*/
//Funciones

static void DrawFrame(int headPosX, int headPosY , char character, char food, int foodPosX,
 int foodPosY, int foodEaten, List<(int x, int y)> body)
{
    Console.Clear();
    DrawCharacterHead(headPosX, headPosY, character);
    DrawCharacterBody(headPosX, headPosY, character, body);
    DrawFood(food, foodPosX, foodPosY);
    FoodEaten(foodEaten);

    System.Threading.Thread.Sleep(100);
}

static void DrawCharacterHead(int posX, int posY, char character)
{
    Console.SetCursorPosition(posX, posY);
    Console.Write(character);
}

static void DrawCharacterBody(int headPosX, int headPosY, char character, List<(int x, int y)> body)
{
    body.Insert(0, (headPosX, headPosY));

    foreach (var segment in body)
    {
        Console.SetCursorPosition(segment.x, segment.y);
        Console.Write(character);
    }

    if (body.Count > 1)
    {
          body.RemoveAt(body.Count - 1);  
    }
}

static void DrawFood(char food, int posJ, int posK)
{
    Console.SetCursorPosition(posJ, posK);
    Console.Write(food);
}

static void FoodEaten(int foodEaten)
{
     Console.SetCursorPosition(0, 0);
    Console.Write($"Food Eaten: {foodEaten}");
}
/*-------------------------------------------------------------------------------*/
