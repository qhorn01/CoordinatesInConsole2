// See https://aka.ms/new-console-template for more information

MainLoop();

static void MainLoop()
{
    while (true)
    {
        int numRows = GetPositiveInt("How many rows do you want?");
        int numColumns = GetPositiveInt("How many columns do you want?");
        string[,] grid = CreateGrid(numRows, numColumns);

        while (true)
        {
            Console.Clear();
            PrintGrid(grid);
            Console.WriteLine("\n1. Place coordinate\n2. Start over\n3. Exit");
            int choice = GetMenuChoice(1, 3);
            if (choice == 1)
            {
                int row = GetCoordinate("row", numRows);
                int col = GetCoordinate("column", numColumns);
                if (grid[row, col] == "()")
                {
                    Console.WriteLine("A coordinate is already placed here. Press Enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    grid[row, col] = "()";
                }
            }
            else if (choice == 2)
            {
                break; // Start over
            }
            else if (choice == 3)
            {
                Environment.Exit(0);
            }
        }
    }
}

static string[,] CreateGrid(int rows, int cols)
{
    string[,] grid = new string[rows, cols];
    for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
            grid[r, c] = "[]";
    return grid;
}

static void PrintGrid(string[,] grid)
{
    int rows = grid.GetLength(0);
    int cols = grid.GetLength(1);
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < cols; c++)
        {
            Console.Write(grid[r, c]);
        }
        Console.WriteLine();
    }
}

static int GetPositiveInt(string prompt)
{
    int value;
    while (true)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        if (int.TryParse(input, out value) && value > 0)
            return value;
        Console.WriteLine("Please enter a positive integer.");
    }
}

static int GetMenuChoice(int min, int max)
{
    int value;
    while (true)
    {
        Console.Write("Select an option: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out value) && value >= min && value <= max)
            return value;
        Console.WriteLine($"Please enter a number between {min} and {max}.");
    }
}

static int GetCoordinate(string name, int max)
{
    int value;
    while (true)
    {
        Console.Write($"Enter {name} (1 - {max}): ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out value) && value >= 1 && value <= max)
            return value - 1; // zero-based
        Console.WriteLine($"Please enter a valid {name} number between 1 and {max}.");
    }
}