// Tobias Skog - .NET23
namespace ChessBoard
{
  public class Board
  {
    // The class Board have some attributes that a public but only the get is set to public
    // while the set is private
    // To actually set the values of the created Board you need to do it inside the Board class
    // with the help of the constructor that takes all the required values and creates the Board
    // with the values assigned correctly
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    public string BlackSquare { get; private set; }
    public string WhiteSquare { get; private set; }
    public string ChessPiece { get; private set; }
    public int ChessPieceRowPlacement { get; private set; }
    public int ChessPieceColumnPlacement { get; private set; }

    // Constructor for the Board class that takes an input of
    // int rows, int columns wich is the same value since the assignment only asked
    // for one input from the user, but we already made the Board class expandable by
    // including both rows and columns here incase we want to initialize the board differently
    // string blackSquare, whiteSquare, chessPice holds the values of how the board will
    // look when printing it to the console
    // int[] plcementValues is the row and col value of the chessPiece we want to place
    public Board(int rows, int columns, string blackSquare, string whiteSquare, string chessPiece, int[] placementValues)
    {

      // Assigning the values we recieved when calling the constructor to the values of this Board
      Rows = rows;
      Columns = columns;
      BlackSquare = blackSquare;
      WhiteSquare = whiteSquare;
      ChessPiece = chessPiece;
      ChessPieceRowPlacement = placementValues[0];
      ChessPieceColumnPlacement = placementValues[1];
    }
    // Method to draw the chess board to the console
    public void DrawBoard()
    {
      // Creating a bool placeWhiteSquare and assigning it to true wich will be used to 
      // alternate the black and white squares when drawing the board
      bool placeWhiteSquare = true;
      // for loop for the amount of rows
      for (int i = 0; i < Rows; i++)
      {
        // for loop for the amount of columns
        for (int j = 0; j < Columns; j++)
        {
          // Checking IF we are at the chessPiece placement (note -1 to account for the loop starting at 0
          // and our values start at 1) and if we are at the correct placement we write out the ChessPiece 
          // to the console
          if (i == ChessPieceColumnPlacement - 1 && j == ChessPieceRowPlacement - 1)
          {
            Console.Write(ChessPiece);
          }
          // We are NOT at the correct spot for the ChessPiece so we write out either a black or white square
          else
          {
            //// if placeWhiteSquare is true we will write out a black square
            //if (placeWhiteSquare)
            //{
            //  Console.Write(WhiteSquare);
            //}
            //// placeWhiteSquare was false so we will write out a white square instead
            //else
            //{
            //  Console.Write(BlackSquare);
            //}


            // Ternary conditional operator to check if placeWhiteSquare is true.
            // If it's true we write the value of WhiteSquare
            // If it's false we write the value of BlackSquare
            Console.Write($"{(placeWhiteSquare == true ? WhiteSquare : BlackSquare)}");

          }
          // inverting the value of the bool to the negative of itself so true will be false and false will be true
          placeWhiteSquare = !placeWhiteSquare;
        }
        // If the board is an even size we have to invert the value of placeWhiteSquare
        if (Rows % 2 == 0)
        {
          placeWhiteSquare = !placeWhiteSquare;
        }
        // Making a empty Console.WriteLine to add a new row before the loop restarts       
        Console.WriteLine();
      }
    }

  }
}
