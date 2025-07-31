// See https://aka.ms/new-console-template for more information


MainLoop();

static void MainLoop()
{
    while (true)
    {
        int numRows = GetIntWithPrompt("How many rows do you want?", 1, int.MaxValue);
        int numColumns = GetIntWithPrompt("How many columns do you want?", 1, int.MaxValue);
        string[,] grid = CreateGrid(numRows, numColumns);
        GridInteractionLoop(grid);
    }
}

static void GridInteractionLoop(string[,] grid)
{
    while (true)
    {
        Console.Clear();
        PrintGrid(grid);
        Console.WriteLine("\n1. Place coordinate\n2. Start over\n3. Exit");
        int choice = GetIntWithPrompt("Select an option: ", 1, 3);
        if (choice == 1)
        {
            PlaceCoordinate(grid);
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

static void PlaceCoordinate(string[,] grid)
{
    int numRows = grid.GetLength(0);
    int numColumns = grid.GetLength(1);
    int row = GetIntWithPrompt($"Enter row (1 - {numRows}): ", 1, numRows) - 1;
    int col = GetIntWithPrompt($"Enter column (1 - {numColumns}): ", 1, numColumns) - 1;
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


static int GetIntWithPrompt(string prompt, int min, int max)
{
    int value;
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (int.TryParse(input, out value) && value >= min && value <= max)
            return value;
        Console.WriteLine($"Please enter a number between {min} and {max}.");
    }
}