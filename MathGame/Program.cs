using System;
//Math Game

//Declaring variables
bool exitGame = false;
int[] numbers =  new int[2];
string[,] gameHistory = new string[1,4];
gameHistory[0, 0] = "Player"; gameHistory[0, 1] = "Game"; gameHistory[0, 2] = "Difficulty"; gameHistory[0, 3] = "Points";
int gameHistoryRecordCounter = 1;
int lastGamePoints;
string lastGameName;
string playerNickname = "Player";
string selectedDifficulty = "easy";

GameStart();
    
do
{

    switch (Menu())
    {
        case "1":
            AdditionGame();
            GameStatsRecord();
            break;

        case "2":
            SubstractionGame();
            GameStatsRecord();
            break;

        case "3":
            MultiplicationGame();
            GameStatsRecord();

            break;

        case "4":
            DivisionGame();
            // Turn when Division Game will be done
            // GameStatsRecord();
            break;

        case "5":
            HistoryOfGames();
            break;

        case "6":
            GameStart();
            break;

        case "7":
            ChooseDifficulty();
            break;


        case "8":
            FinishGame();
            break;

        default:
            Console.WriteLine("Please enter correct menu option");
            Thread.Sleep(750);
            break;
    }
} while (exitGame == false);

//methods

string Menu()
{
        Console.Clear();
        Console.WriteLine($"Hello, Dear {playerNickname}. \nYour current difficulty: {selectedDifficulty}. \nMenu:");
        Console.WriteLine("1. Addition Game \n2. Substraction Game \n3. Muptiplication Game \n4. Division Game \n5. Games history \n6. Change player \n7. Change Difficulty \n8. Exit");
        string readResult = Console.ReadLine() ?? "wrong";
         
        
            if (readResult == "1" || readResult == "2" || readResult == "3" || readResult == "4" || readResult == "5" || readResult == "6" || readResult == "7" || readResult == "8")
            {
                return readResult;
            } 
            else
            {
                return ("");
            }
}

void GameStart()
{
    Console.Clear();   
    Console.WriteLine("Welcome to Math Game");
    Thread.Sleep(1000);
    Console.WriteLine("Please, enter your nickname:");
    playerNickname = Console.ReadLine();
    if (playerNickname.Length < 1) playerNickname = "Unknown Player";
}

void AdditionGame()
{
    int points = 0;
    Console.Clear ();
    Console.WriteLine("Welcome to Addition Game.\nPress any key to start.");
    Console.ReadKey();

    for (int i = 0; i < 5; i++)
    {
        numbers = TwoNumberGenerator();
        Console.Clear();
        Console.Write($" {numbers[0]} + {numbers[1]} = ");
        int answer = 0;      
        int.TryParse(Console.ReadLine(), out answer);
        if (answer == numbers[0] + numbers[1])
        {
            points++;
        }

    }
    lastGamePoints = points;
    lastGameName = "Addition";
    Console.WriteLine($"Your total points: {points}.\nPress any key to go back to menu.");
    Console.ReadKey();
    


}

void SubstractionGame()
{
    int points = 0;
    Console.Clear();
    Console.WriteLine("Welcome to Substraction Game.\nPress any key to start.");
    Console.ReadKey();

    for (int i = 0; i < 5; i++)
    {
        numbers = TwoNumberGenerator();
        Console.Clear();
        Console.Write($" {numbers[0]} - {numbers[1]} = ");
        int answer = 0;
        int.TryParse(Console.ReadLine(), out answer);
        if (answer == numbers[0] - numbers[1])
        {
            points++;
        }

    }
    lastGamePoints = points;
    lastGameName = "Substraction";
    Console.WriteLine($"Your total points: {points}.\nPress any key to go back to menu.");
    Console.ReadKey();
}

void MultiplicationGame()
{
    int points = 0;
    Console.Clear();
    Console.WriteLine("Welcome to Multiplication Game.\nPress any key to start.");
    Console.ReadKey();

    for (int i = 0; i < 5; i++)
    {
        numbers = TwoNumberGenerator();
        Console.Clear();
        Console.Write($" {numbers[0]} * {numbers[1]} = ");
        int answer = 0;
        int.TryParse(Console.ReadLine(), out answer);
        if (answer == numbers[0] * numbers[1])
        {
            points++;
        }

    }
    lastGamePoints = points;
    lastGameName = "Multiplication";
    Console.WriteLine($"Your total points: {points}.\nPress any key to go back to menu.");
    Console.ReadKey();
}

void DivisionGame()
{
    Console.Clear();
    Console.WriteLine("Welcome to Division Game. Press any key to start (!UNDER CONSTRUCTION!)");
    Console.ReadKey();
}

//History of games array display
void HistoryOfGames()
{
    Console.Clear();
    for (int i = 0; i < gameHistory.GetLength(0); i++)
    {
        for (int j = 0; j < gameHistory.GetLength(1); j++)
        {
            //error because of empty lines in array
            Console.Write(gameHistory[i,j].PadRight(20));
        }
        Console.WriteLine("");
    }
    Console.WriteLine("\nPress any key to go back to menu.");
    Console.ReadKey();
        
}

// method to store played game info 
void GameStatsRecord()
{
    if (gameHistoryRecordCounter + 1 > gameHistory.GetLength(0))
    {
        string[,] newArray = new string[gameHistoryRecordCounter + 1, gameHistory.GetLength(1)];
        for (int i = 0; i < gameHistory.GetLength(0); i++)
        {
            for (int j = 0; j < gameHistory.GetLength(1); j++)
            {
                newArray[i, j] = gameHistory[i, j];
            }
            
        }
        gameHistory = newArray;


        gameHistory[gameHistoryRecordCounter, 0] = playerNickname;
        gameHistory[gameHistoryRecordCounter, 1] = lastGameName;
        gameHistory[gameHistoryRecordCounter, 2] = selectedDifficulty;
        gameHistory[gameHistoryRecordCounter, 3] = ($"{lastGamePoints}");

        gameHistoryRecordCounter++;
    }
}

//method asking players confirmation to exit the game 
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

// method to create 2 random numbers for games for chosen difficulty
int[] TwoNumberGenerator()
{
    Random random = new Random();
    switch (selectedDifficulty)
    {
        case "easy":
            return [random.Next(1, 11), random.Next(1, 11)];    

        case "normal":
            return [random.Next(1, 51), random.Next(1, 51)];
        
        case "hard":
            return [random.Next(1, 101), random.Next(1, 101)];
        
        default:
            return [random.Next(1, 11), random.Next(1, 11)];
    }

}

void ChooseDifficulty()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Select your difficulty: \n1. Easy \n2. Normal \n3. Hard");
        string formattedInput = Console.ReadLine().ToLower().Trim();
        if (formattedInput.Contains("easy") || formattedInput == "1")
        {
            selectedDifficulty = "easy";
            return;
        }
        else if (formattedInput.Contains("normal") || formattedInput == "2")
        {
            selectedDifficulty = "normal";
            return;
        }
        else if (formattedInput.Contains("hard") || formattedInput == "3")
        {
            selectedDifficulty = "hard";
            return;
        }
        else
        {
            Console.WriteLine("Please, enter correct difficulty name or difficulty number.");
            Thread.Sleep (700);
        }
    }
}