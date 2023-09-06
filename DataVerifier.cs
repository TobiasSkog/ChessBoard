// Tobias Skog - .NET23
namespace ChessBoard
{
    public static class DataVerifier
    {

        public static Board CreateNewBoard()
        {
            // Declaring variables for the creating of the chess board
            int boardSize;
            string blackSquare, whiteSquare, chessPiece;
            int[] placement;

            // Each value is recieved from a method where we use the prompt as an input to the method
            // There is 3 different methods used, Get Required .... Positive Int, String and Int Arr.
            // These methods are in place to handle incorrect input from the user to make sure our software
            // runs without problem
            boardSize = GetRequiredPositiveInt("Hur stort bräde (max 29): ");
            blackSquare = GetRequiredString("Hur ska svarta rutor se ut: ");
            whiteSquare = GetRequiredString("Hur ska vita rutor se ut: ");
            chessPiece = GetRequiredString("Hur ska pjäsen se ut: ");
            placement = GetRequiredIntArr("Var ska pjäsen så (ex. E4): ", boardSize);

            // Declaring and Initializing a new instance of the Board class, we pass in the variables we gathered
            // from the above mentioned methods
            Board newChessBoard = new Board(boardSize, boardSize, blackSquare, whiteSquare, chessPiece, placement);

            // The newly created Chess Board is returned to Program.cs
            return newChessBoard;
        }

        // Method to retrieve a required array of integers, takes the prompt as input and the boardSize
        public static int[] GetRequiredIntArr(string prompt, int boardSize)
        {
            // Creating a new array of integers with the size 2 to hold our values
            // Creating a new char variable to act as a middle point when converting
            // the column letter into an integer
            // Creating 2 new ints that will be used for converting the column number
            // to an integer and hold the rowNumber
            int[] validInts = new int[2];
            char columnLetter;
            int columnNumber, rowNumber;

            // do while loop to keep prompting the user for input until we get a value that's acceptable
            do
            {
                // Writing the prompt to the consoloe
                Console.Write(prompt);

                // Creating a new string and capture the user input and making sure to convert it to all 
                // upper case letters, this is important for converting the value to an int
                string input = Console.ReadLine().ToUpper();

                // Assigning the char we created earlier to the first value of the input string
                columnLetter = input[0];

                // making sure that the char columnLetter is actually a letter AND using int.TryParse to try and convert
                // input[1..] wich is  a substring from the character at index 1 to the end of the string
                // AND if the boardSize is less or equal to 29 (Column Ö)
                // if it fails we will write the error message and the loop will continue until we get the accepted values
                if (char.IsLetter(columnLetter) && int.TryParse(input[1..], out rowNumber) && boardSize <= 29)
                {
                    // The first input check is accepted!

                    // Checking if the clumnLetter is Å, Ä or Ö since they need to be handled differently and if the boardSize
                    // is matching the columnLetter
                    if (columnLetter == 'Å' && boardSize == 27 || columnLetter == 'Ä' && boardSize == 28 || columnLetter == 'Ö' && boardSize == 29)
                    {
                        // Creating a switch to handle each char sepperatly
                        switch (columnLetter)
                        {
                            case 'Å':
                                // If the columnLetter is 'Å' we know that it's value is 197 and the desired value is
                                // 27 so to find out the correct value to subract with to get the correct position we do
                                // 197 - 27 = 170 >> To get the position 27
                                // We assign columnNumber to the value of columnLetter -  170
                                // assigning columnNumber to the validInts array at position 1
                                // assigning the rowNumber to the validInts array at position 0
                                // then returning the validInt array
                                Console.WriteLine("Å");
                                columnNumber = columnLetter - 170;
                                validInts[0] = rowNumber;
                                validInts[1] = columnNumber;
                                return validInts;
                            case 'Ä':
                                // 'Ä' = 196 - 28
                                // If the columnLetter is 'Ä' we know that it's value is 196 and the desired value is
                                // 28 so to find out the correct value to subract with to get the correct position we do
                                // 196 - 28 = 168 >> To get the position 28
                                // We assign columnNumber to the value of columnLetter - 168
                                // assigning columnNumber to the validInts array at position 1
                                // assigning the rowNumber to the validInts array at position 0
                                // then returning the validInt array
                                Console.WriteLine("Ä");
                                columnNumber = columnLetter - 168;
                                validInts[0] = rowNumber;
                                validInts[1] = columnNumber;
                                return validInts;
                            case 'Ö':
                                // 'Ö' = 214 - 29
                                // If the columnLetter is 'Ö' we know that it's value is 214 and the desired value is
                                // 29 so to find out the correct value to subract with to get the correct position we do
                                // 214 - 29 = 185 >> To get the position 29
                                // We assign columnNumber to the value of columnLetter - 185
                                // assigning columnNumber to the validInts array at position 1
                                // assigning the rowNumber to the validInts array at position 0
                                // then returning the validInt array
                                Console.WriteLine("Ö");
                                columnNumber = columnLetter - 185;
                                validInts[0] = rowNumber;
                                validInts[1] = columnNumber;
                                return validInts;
                        }

                    }

                    // The columnLetter was NOT Å, Ä or Ö so then we check if the value of the columnLetter is greater than 0
                    // AND if it's less or equal to the boardSize since we cannot place a chessPiece outside of the board
                    else if (columnLetter - 65 + 1 > 0 && columnLetter - 65 + 1 <= boardSize)
                    {
                        // We assign the value char - 'A' + 1 to columnNumber
                        // We're taking advantage of the char values as ASCII characters where A has the value of 65 and Z has the value of 90
                        // we made sure to make the input upper case letters earlier since the lower case a has a value of 97 and would give us
                        // a int value of `a = - 'A' + 1 = 97 - 65 + 1 = 33` instead of `A = -'A' + 1 = 65 - 65 + 1 = 1`
                        // assigning columnNumber to the validInts array at position 1
                        // assigning the rowNumber to the validInts array at position 0
                        // then returning the validInt array
                        columnNumber = columnLetter - 'A' + 1;
                        validInts[1] = columnNumber;
                        validInts[0] = rowNumber;
                        return validInts;

                    }
                }
                Console.WriteLine($"Ogiltig inmatning av pjäsens position!");
            } while (true);

        }

        // Method to retrieve a required positive int, takes the prompt as input
        public static int GetRequiredPositiveInt(string prompt)
        {

            // Do while loop to keep prompting the user for input until we get a value that's acceptable
            do
            {
                // Writing the prompt to the consoloe
                Console.Write(prompt);

                // Using int.TryParse to try and convert the user input with Console.ReadLine() and outputing
                // it to a new int validInt
                if (int.TryParse(Console.ReadLine(), out int validInt))
                {
                    // The value is a integer
                    // Checking if the valid int is positive
                    if (validInt > 0)
                    {
                        // The value is a positive integer, returning the validInt
                        return validInt;
                    }
                }
                // The value was not an integer or it was less or equal to 0
                // Writing error message to the user and the loop will restart
                Console.WriteLine("Du måste ange ett positivt heltal.");

            } while (true); // while (true) to have an infinite loop until we return a value
        }

        // Method to retrieve a required string from the user, takes the prompt as input
        public static string GetRequiredString(string prompt)
        {
            // Writes out the prompt to the user
            Console.Write(prompt);
            // Creates a new string and assigning it the value the user types in with Console.ReadLine()
            string validString = Console.ReadLine();
            // Returning the string
            return validString;
        }
    }
}
