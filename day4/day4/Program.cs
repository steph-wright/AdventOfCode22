// PART 1:

string[] lines = System.IO.File.ReadAllLines("/home/steph/Desktop/Projects/AdventOfCode/day4/input.txt");

int fullyContained = 0;

int overlapping = 0;

foreach (string line in lines)
{
    string[] pair = line.Split(",");

    string[] range1 = pair[0].Split("-");
    string[] range2 = pair[1].Split("-");
    
    int minRange1 = Int32.Parse(range1[0]);
    int maxRange1 = Int32.Parse(range1[1]);
    
    int minRange2 = Int32.Parse(range2[0]);
    int maxRange2 = Int32.Parse(range2[1]);
    
    // part 1 logic:
    if (maxRange1 - minRange1 >= maxRange2 - minRange2)
    {
        if (minRange1 <= minRange2 && maxRange1 >= maxRange2)
        {
            fullyContained++;
        }
    }
    else
    {
        if (minRange2 <= minRange1 && maxRange2 >= maxRange1)
        {
            fullyContained++;
        }
    }
    
    // part 2 logic:
    if (minRange1 >= minRange2 && minRange1 <= maxRange2 
        || maxRange1 >= minRange2 && maxRange1 <= maxRange2
        || minRange1 <= minRange2 && maxRange1 >= maxRange2
        || minRange2 <= minRange1 && maxRange2 >= maxRange1)
    {
        overlapping++;
    }

}

Console.WriteLine("Assignment pairs where one range fully contains the other: " + fullyContained);


// PART 2: 


Console.WriteLine("Assignment pairs where ranges overlap: " + overlapping);
