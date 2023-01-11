// PART 1:

char[] dataStream = System.IO.File.ReadAllText("/home/steph/Desktop/Projects/AdventOfCode/day6/input.txt").ToCharArray();

int charactersProcessed = 0;

for (int i = 3; i < dataStream.Length; i++)
{
    char a = dataStream[i - 3];
    char b = dataStream[i - 2];
    char c = dataStream[i - 1];
    char d = dataStream[i];

    
    
    if (a != b && a != c && a != d &&
        b != c && b != d &&
        c != d)
    {
        charactersProcessed = i + 1;
        break;
    }
}

Console.WriteLine("First start-of-packet marker detected at: " + charactersProcessed);


// PART 2:

int charactersProcessedMessage = 0;

HashSet<char> candidateMarker = new HashSet<char>();

for (int x = 0; x < dataStream.Length; x++)
{
    for (int i = x; i < x + 14; i++)
    {
        candidateMarker.Add(dataStream[i]);
    }

    if (candidateMarker.Count == 14)
    {
        charactersProcessedMessage = x + 14;
        break;
    }
    
    candidateMarker.Clear();
}

Console.WriteLine("First start-of-message marker detected at: " + charactersProcessedMessage);