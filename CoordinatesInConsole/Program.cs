// See https://aka.ms/new-console-template for more information

bool programStart = true;

while (programStart == true)
{
    string rowChar = "[]";

    Console.WriteLine("How many rows do you want?");
    string rowInput = Console.ReadLine();
    int numRows = Int32.Parse(rowInput);

    Console.WriteLine("How many columns do you want?");
    string columnInput = Console.ReadLine();
    int numColumn = Int32.Parse(columnInput);

    string wholeGrid = rowColumnCreation(numRows, numColumn, rowChar);
    Console.WriteLine(wholeGrid);

    Console.WriteLine("1. Place coordinate\n2. Startover\n3.Exit");
    string userInput = Console.ReadLine();
    int userInputInt = Int32.Parse(userInput);

    bool optionSelection = true;

    while (optionSelection == true)
    {
        if (userInputInt == 1)
        {

            Console.WriteLine($"What row do you want the coordinate placed? Enter 1 - {numRows}: ");
            string rowSelect = Console.ReadLine();
            int rowSelectInt = Int32.Parse(rowSelect);

            Console.WriteLine($"What column do you want the coordinate placed? Enter 1 - {numColumn}: ");
            string columnSelect = Console.ReadLine();
            int columnSelectInt = Int32.Parse(rowSelect);

            if (rowSelectInt > numRows)
            {
                Console.WriteLine($"Please type in a number less than or equal to {numRows}");
            }
            else if (rowSelectInt <= numRows)
            {
                string coGrid = coordinatePlacement(rowSelectInt, columnSelectInt, numRows, numColumn, rowChar);
                string secondHalf = wholeGrid.Substring(rowSelectInt*2, wholeGrid.Length-rowSelectInt*2);
                Console.WriteLine(coGrid + secondHalf);
            }
            else
            {

            }
        }
    }

}
    static string rowColumnCreation(int numRows, int numColumn, string rowChar)
    {
        string rowOutput = "";

        for (int i = 0; i < numRows; i++)
        {
            rowOutput += rowChar;
        }

        string columnOutput = rowOutput;

        if (numColumn > 1)
        {
            for (int i = 0; i < numColumn - 1; i++)
            {
                rowOutput += $"\n{columnOutput}";
            }
        }

        return rowOutput;
    }

static string coordinatePlacement(int rowPlacement, int columnPlacement, int numRows, int numColumn, string rowChar)
{
    string rowOutput = "";
    string coordinate = "()";

        for (int i = 0; i < rowPlacement-1; i++)
        {
            rowOutput += rowChar;
        }
        rowOutput += coordinate;

        /*for (int i = 0; i < numRows; i++)
        {
            rowOutput += rowChar;
        }
        
        string columnOutput = rowOutput;

        if (numColumn > 1)
        {
            for (int i = 0; i < columnPlacement - 1; i++)
            {
                rowOutput += $"\n{columnOutput}";
            }
        }

        rowOutput += coordinate;*/

        return rowOutput;
}