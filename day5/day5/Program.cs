// PART 1:

string[] lines = System.IO.File.ReadAllLines("/home/steph/Desktop/Projects/AdventOfCode/day5/input.txt");

// create empty stacks
Dictionary<int, Stack<char>> crates = new Dictionary<int, Stack<char>>();

for (int a = 1; a < 10; a++)
{
    crates.Add(a, new Stack<char>());
}


// fill stacks with crates
for (int i = 7; i >= 0; i--)
{
    string line = lines[i];
    char[] lineArray = line.ToCharArray();
    
    
    int stackNo = 1;

    for (int x = 1; x < lineArray.Length; x += 4)
    {
        char crateContent = lineArray[x];
        
        if (!Char.IsWhiteSpace(crateContent))
            crates[stackNo].Push(crateContent);
        stackNo++;
    }
}

// for (int b = 1; b < 10; b++)
// {
//     Console.WriteLine("STACK:" + b);
//     foreach (char crate in crates[b])
//     {
//         Console.WriteLine(crate);
//     }
// }

for (int c = 10; c < lines.Length; c++)
{
    string line = lines[c];
    string[] instruction = line.Split(" ");

    int amountToMove = Int32.Parse(instruction[1]);
    int fromThisStack = Int32.Parse(instruction[3]);
    int toThisStack = Int32.Parse(instruction[5]);

    for (int d = 0; d < amountToMove; d++)
    {
        char craneLiftedCrate = crates[fromThisStack].Pop();
        crates[toThisStack].Push(craneLiftedCrate);
    }
}

// for (int b = 1; b < 10; b++)
// {
//     Console.WriteLine("STACK:" + b);
//     foreach (char crate in crates[b])
//     {
//         Console.WriteLine(crate);
//     }
// }

char[] topOfStack = new char[9];

for(int f = 0; f < 9; f++)
{
    topOfStack[f] = crates[f + 1].Pop();
}

foreach (char crate in topOfStack)
{
    Console.Write(crate);
}

