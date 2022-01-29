int playerChoice;
int computerChoice;
int playerScore = 0;
int computerScore = 0;

void ThrowRock()
{
    Console.WriteLine($@"
     ______
----'   ____)
       (_____)
       (_____)
       (____)
----.__(___)
");
}

void ThrowPaper()
{
    Console.WriteLine($@"
     _______
---'    ____)____
           ______)
          _______)
         _______)
---.__________)
");
}

void ThrowScissors()
{
    Console.WriteLine($@"
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)
");
}

void ScoreAndPrompt()
{
    Console.Clear();
    Console.WriteLine($@"---------------------------
| Player: {playerScore} | Computer: {computerScore} |
---------------------------
What will you throw?
1) Rock
2) Paper
3) Scissors
");
}

void GetPlayerInput()
{
    int.TryParse(Console.ReadLine(), out playerChoice);
    ScoreAndPrompt();
    while (playerChoice < 1 || playerChoice > 3)
    {
        GetPlayerInput();
    }
}

void GetComputerInput()
{
    computerChoice = new Random().Next(1, 4);
}

string Shoot(int _choice)
{
    string choiceName;
    switch (_choice)
    {
        case 1: { ThrowRock(); choiceName = "ROCK"; } break;
        case 2: { ThrowPaper(); choiceName = "PAPER"; } break;
        case 3: { ThrowScissors(); choiceName = "SCISSORS"; } break;
        default: { choiceName = "NOTHING"; } break;
    }
    return choiceName;
}

void DisplayChoices()
{
    Console.WriteLine($"You throw {Shoot(playerChoice)}");
    Console.WriteLine($"Computer throws {Shoot(computerChoice)}");
}

void JudgeWinner()
{

    if (playerChoice == computerChoice)
    {
        ScoreAndPrompt();
        DisplayChoices();
        Console.WriteLine($@"
---------------------------
It's a draw!
");
    }
    else if (playerChoice % 3 == (computerChoice - 1) % 3)
    {
        computerScore++;
        ScoreAndPrompt();
        DisplayChoices();
        Console.WriteLine($@"
---------------------------
Computer wins!
");
    }
    else
    {
        playerScore++;
        ScoreAndPrompt();
        DisplayChoices();
        Console.WriteLine($@"
---------------------------
You win!
");
    }
}

void ResetGame()
{
    playerScore = 0;
    computerScore = 0;
    GameLoop();
}


void GameLoop()
{
    if (playerScore < 3 && computerScore < 3)
    {
        GetPlayerInput();
        GetComputerInput();
        JudgeWinner();

        GameLoop();
    } else
    {
        Console.Clear();
        if (playerScore == 3)
        {
            Console.WriteLine("You win! Congratulations!");
            ResetGame();
        } else
        {
            Console.WriteLine("You lose! Sorry!");
            ResetGame();
        }
    }
}

ScoreAndPrompt();
GameLoop();
