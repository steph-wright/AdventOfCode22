// See https://aka.ms/new-console-template for more information

string[] backpacks = System.IO.File.ReadAllLines("/home/steph/Desktop/Projects/AdventOfCode/day3/input.txt");

// PART 1: 

string items = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

char[] itemsPriorities = items.ToCharArray();



int totalPriorities = 0;

foreach (string backpack in backpacks)
{
    int halfway = (backpack.Length / 2);

    char[] compartment1 = new char[halfway];
    char[] compartment2 = new char[halfway];

    for (int i = 0; i < backpack.Length; i++)
    {
        if (i < halfway)
        {
            compartment1[i] = backpack[i];
        }
        else
        {
            compartment2[i - halfway] = backpack[i];
        }
    }
    
    char inBothCompartments = new char();

    for (int a = 0; a < halfway; a++)
    {
        char item1 = compartment1[a];
        
        for (int b = 0; b < halfway; b++)
        {
            char item2 = compartment2[b];
            
            if (item1 == item2)
            {
                inBothCompartments = item1;
                break;
            }
            
        }
        

    }
   
    
    int priority = Array.IndexOf(itemsPriorities, inBothCompartments);

    totalPriorities += priority;
    
}

Console.WriteLine("Sum of priorities: " + totalPriorities);

// PART 2: 
int priorities = 0;
    
for (int backpackNo = 0; backpackNo < backpacks.Length; backpackNo += 3)
{
    foreach (char item in backpacks[backpackNo])
    {
        foreach (char item1 in backpacks[backpackNo + 1])
        {
            foreach (char item2 in backpacks[backpackNo + 2])
            {
                if (item == item1 && item1 == item2)
                {
                    priorities += Array.IndexOf(itemsPriorities, item);
                    goto LoopEnd;
                }
            }
        }
    }

    LoopEnd:;
}

Console.WriteLine("Part 2 Priorities: " + priorities);