using System;
//Math Game

//Declaring variables
bool exitGame = false;

//Game Initialisation
Console.WriteLine("Welcome to Math Game");
Thread.Sleep(1000);
Console.WriteLine("Please, enter your nickname:");
string playerNickname = Console.ReadLine();

//checking if nickname is null, and assigning "player" if yes
if (playerNickname.Length <1) playerNickname = "Player";


do
{

    switch (Menu())
    {
        case "1":
            AdditionGame();
            FinishGame();
            break;

        case "2":
            SubstractionGame();
            FinishGame();
            break;

        case "3":
            MultiplicationGame();
            exitGame = true;
            break;

        case "4":
            DivisionGame();
            exitGame = true;
            break;

        case "5":
            HistoryOfGames();
            exitGame = true;
            break;

        case "6":
            {
                FinishGame();
                break;
            }

        case "7":
            Console.WriteLine("Please enter correct menu option");
            Thread.Sleep(750);
            break;
    }
} while (exitGame == false);


//method allowing to navigate through menu and return correct player selection 
string Menu()
{
        Console.Clear();
        Console.WriteLine($"Hello, Dear {playerNickname}.\nMenu:");
        Console.WriteLine("1. Addition Game \n2. Substraction Game \n3. Muptiplication Game \n4. Division Game \n5. Games history \n6. Exit");
        string readResult = Console.ReadLine() ?? "wrong";
        
            if (readResult == "1" || readResult == "2" || readResult == "3" || readResult == "4" || readResult == "5" || readResult == "6")
            {
                return readResult;
            } 
            else
            {
                return ("7");
            }
}


//Addition Game Method

void AdditionGame()
{
    Console.Clear ();
    Console.WriteLine("Welcome to Addition Game");
    Console.ReadKey();
}

//Substraction Game Method
void SubstractionGame()
{
    Console.Clear();
    Console.WriteLine("Welcome to Substraction Game");
}

//Muptiplication Game Method
void MultiplicationGame()
{
    Console.Clear();
    Console.WriteLine("Welcome to Mupltiplication Game");
}

//Division Game Method
void DivisionGame()
{
    Console.Clear();
    Console.WriteLine("Welcome to Division Game");
}

//History of games

void HistoryOfGames()
{
    Console.Clear();
    Console.WriteLine("Previous games:");
}

//method allowing player to exit the game if he wants to (either from menu or from every game end)
bool FinishGame ()
{
    do
    {
        Console.Clear ();
        Console.WriteLine("Do you want to close the Game? All your history will be deleted (y/n)");
        string readResult = Console.ReadLine();
        if (readResult == "y")
        {
            exitGame = true;
            return true;
        }
        else if (readResult == "n")
        {
            return false;
        }
    } while (true);
}