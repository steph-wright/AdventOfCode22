// See https://aka.ms/new-console-template for more information


string[] lines = System.IO.File.ReadAllLines("/home/steph/Desktop/Projects/AdventOfCode/day2/day2/input.txt");
/*
 * SCORE FOR SHAPE
 * 1 - Rock
 * 2 - Paper
 * 3 - Scissors
 *
 * SCORE FOR OUTCOME
 * 0 - loss
 * 3 - draw
 * 6 - win
 */

/*
 * OPPONENT CHOICE
 * A - Rock
 * B - Paper
 * C - Scissors
 *
 * YOUR CHOICE
 * X - Rock
 * Y - Paper
 * Z - Scissors
 */


// PART 1:
int score = 0;

foreach (string line in lines)
{
    string[] choice = line.Split(" ");

    switch (choice[1])
    {
        case "X":
            score += 1;
            break;
        case "Y":
            score += 2;
            break;
        case "Z":
            score += 3;
            break;
    }

    switch (choice[0])
    {
        case "A": // rock
            switch (choice[1])
            {
                case "X":
                    score += 3;
                    break;
                case "Y":
                    score += 6;
                    break;
                case "Z":
                    score += 0;
                    break;
            }

            break;
        case "B": // paper
            switch (choice[1])
            {
                case "X":
                    score += 0;
                    break;
                case "Y":
                    score += 3;
                    break;
                case "Z":
                    score += 6;
                    break;
            }

            break;
        case "C": // scissors
            switch (choice[1])
            {
                case "X":
                    score += 6;
                    break;
                case "Y":
                    score += 0;
                    break;
                case "Z":
                    score += 3;
                    break;
            }

            break;
    }
}

Console.WriteLine("Part 1 Score: " + score);

// PART 2: 

/*
 * SCORE FOR SHAPE
 * 1 - Rock
 * 2 - Paper
 * 3 - Scissors
 *
 * SCORE FOR OUTCOME
 * 0 - loss
 * 3 - draw
 * 6 - win
 */

/*
 * OPPONENT CHOICE
 * A - Rock
 * B - Paper
 * C - Scissors
 *
 * OUTCOME
 * X - Lose
 * Y - Draw
 * Z - Win
 */
 
 int secondScore = 0;

foreach (string round in lines)
{
    string[] game = round.Split(" ");

    switch (game[1])
    {
        case "X":
            secondScore += 0;
            break;
        case "Y":
            secondScore += 3;
            break;
        case "Z":
            secondScore += 6;
            break;
    }

    switch (game[0])
    {
        case "A": // rock
            switch (game[1])
            {
                case "X": // loss
                    secondScore += 3;
                    break;
                case "Y": // draw
                    secondScore += 1;
                    break;
                case "Z": // win
                    secondScore += 2;
                    break;
            }

            break;
        case "B": // paper
            switch (game[1])
            {
                case "X": // loss
                    secondScore += 1;
                    break;
                case "Y": // draw
                    secondScore += 2;
                    break;
                case "Z": // win
                    secondScore += 3;
                    break;
            }

            break;
        case "C": // scissors
            switch (game[1])
            {
                case "X": // loss
                    secondScore += 2;
                    break;
                case "Y": // draw
                    secondScore += 3;
                    break;
                case "Z": // win
                    secondScore += 1;
                    break;
            }

            break;
    }
}

Console.WriteLine("Part 2 Score: " + secondScore);