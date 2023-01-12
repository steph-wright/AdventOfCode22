// DAY 7 

// PART 1: 

// find directories with total size of AT MOST 100000
// then calculate the sum of their total sizes

using System.Reflection.Metadata.Ecma335;

string[] lines = System.IO.File.ReadAllLines("/home/steph/Desktop/Projects/AdventOfCode/day7/input.txt");

int totalLessThan100000 = 0;


DirectoryTree tree = new DirectoryTree();
Directory currentDirectory = new Directory();
tree.Root = currentDirectory;

foreach (string line in lines)
{
    string[] words = line.Split(" ");

    switch (words[0])
    {
        case "$":
            if (words[1] == "cd")
            {
                if (words[2] != "..")
                {
                    if (words[2] == "/")
                    {
                        currentDirectory.Name = "/";
                    }
                    else
                    {
                        Directory cd = currentDirectory.FindChildByName(words[2]);
                        cd.Parent = currentDirectory;
                        currentDirectory = cd;
                    }
                }
                else
                {
                    Directory up = currentDirectory.GoToParent();
                    currentDirectory = up;
                }
            }
            break;
        case "dir":
            Directory child = new Directory();
            child.Name = words[1];
            currentDirectory.AddChild(child);
            break;
        default:
            File file = new File();
            file.Name = words[1];
            file.FileSize = int.Parse(words[0]);
            currentDirectory.AddFile(file);
            break;
    }
}

List<Directory> allDirectories = tree.GetAllDirectoriesFromRoot();

foreach (Directory directory in allDirectories)
{
    if (directory.GetTotalSize() <= 100000)
    {
        totalLessThan100000 += directory.GetTotalSize();
    }
}

Console.WriteLine("PART 1: " + totalLessThan100000);

// PART 2: 

int TOTAL_DISK_SPACE = 70000000;
int UNUSED_SPACE_NEEDED = 30000000;

int spaceUsed = tree.Root.GetTotalSize();

int currentlyUnused = TOTAL_DISK_SPACE - spaceUsed;

List<int> bigEnoughDirectories = new List<int>();

foreach (Directory directory in allDirectories)
{
    if (currentlyUnused + directory.GetTotalSize() >= UNUSED_SPACE_NEEDED)
    {
        bigEnoughDirectories.Add(directory.GetTotalSize());
    }
}

int directoryToDelete = bigEnoughDirectories.Min();
Console.WriteLine("Part 2: " + directoryToDelete);


// CLASSES:
class File
{
    private string name;
    private int fileSize;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int FileSize
    {
        get => fileSize;
        set => fileSize = value;
    }
}

class Directory
{
    private string name;
    private Directory parent;
    private List<Directory> children = new List<Directory>();
    private List<File> files = new List<File>();

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Directory Parent
    {
        get => parent;
        set => parent = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Directory GoToParent()
    {
        return this.parent;
    }
    
    public void AddChild(Directory child)
    {
        if (!this.children.Contains(child))
            this.children.Add(child);
    }

    public void AddFile(File file)
    {
        if (!this.files.Contains(file))
            this.files.Add(file);
    }

    public int GetTotalSize()
    {
        int directoryTotal = 0;

        foreach (File file in files)
        {
            directoryTotal += file.FileSize;
        }
        
        foreach (Directory child in children)
        {
            directoryTotal += child.GetTotalSize();
        }

        return directoryTotal;
    }

    public Directory FindChildByName(string name)
    {
        foreach (Directory child in children)
        {
            if (child.Name == name)
            {
                return child;
            }
            
        }

        return null;
    }

    public List<Directory> GetAllDirectories()
    {
        List<Directory> directories = new List<Directory>();
        
        directories.Add(this);
        
        foreach (Directory child in this.children)
        {
            directories.AddRange(child.GetAllDirectories());
        }

        return directories;
    }
}

class DirectoryTree
{
    private Directory root;

    public Directory Root
    {
        get => root;
        set => root = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Directory> GetAllDirectoriesFromRoot()
    {
         return root.GetAllDirectories();
    }
}

