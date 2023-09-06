// Tobias Skog - .NET23
using ChessBoard;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        // Unicode to show the squares, and setting a unicode standard output and input
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        // Creating a new Board with the help of the method CreateNewBoard in the DataVerifier class
        Board chessBoard = DataVerifier.CreateNewBoard();

        // Drawing the chessboard with the chessBoard objects DrawBoard() method
        chessBoard.DrawBoard();
    }
}
