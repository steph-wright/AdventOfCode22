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


// move the crates
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

Console.WriteLine("Part 1 answer:");
foreach (char crate in topOfStack)
{
    Console.Write(crate);
}

// PART 2: 

// create empty lists
Dictionary<int, List<char>> cratesPart2 = new Dictionary<int, List<char>>();

for (int a = 1; a < 10; a++)
{
    cratesPart2.Add(a, new List<char>());
}


// fill lists with crates
for (int i = 7; i >= 0; i--)
{
    string line = lines[i];
    char[] lineArray = line.ToCharArray();
    
    
    int stackNo = 1;

    for (int x = 1; x < lineArray.Length; x += 4)
    {
        char crateContent = lineArray[x];
        
        if (!Char.IsWhiteSpace(crateContent))
            cratesPart2[stackNo].Add(crateContent);
        stackNo++;
    }
}


// DEBUGGING
// for (int b = 1; b < 10; b++)
// {
//     Console.WriteLine("LIST:" + b);
//     foreach (char crate in cratesPart2[b])
//     {
//         Console.WriteLine(crate);
//     }
// }


// move the crates

// traverse through instructions
for (int c = 10; c < lines.Length; c++)
{
    string line = lines[c];
    string[] instruction = line.Split(" ");

    int amountToMove = Int32.Parse(instruction[1]);
    int fromThisList = Int32.Parse(instruction[3]);
    int toThisList = Int32.Parse(instruction[5]);

    // take the crates from the origin list
    var cratesLifted = cratesPart2[fromThisList].Skip(cratesPart2[fromThisList].Count-amountToMove);

    var enumerable = cratesLifted as char[] ?? cratesLifted.ToArray();

    
    
    // ensure they are removed from that list

    for (int g = 0; g < amountToMove; g++)
    {
        if (cratesPart2[fromThisList].Any())
        {
            cratesPart2[fromThisList].RemoveAt(cratesPart2[fromThisList].Count - 1);
        }

    }

    cratesPart2[toThisList].AddRange(enumerable);
    
   
}



char[] topOfList2 = new char[9];

for(int f = 0; f < 9; f++)
{
    var currentList = cratesPart2[f + 1];
    topOfList2[f] = currentList[currentList.Count-1];
}

Console.WriteLine("");
Console.WriteLine("Part 2 answer:");
foreach (char crate in topOfList2)
{
    Console.Write(crate);
}

