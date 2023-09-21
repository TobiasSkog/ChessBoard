// Tobias Skog - .NET23
using ChessBoard;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        // Setting a unicode standard output and input for the Console class so that
        // we can use unicode characters to represent the squares of the board and the chesspiece
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        // Creating a new Board with the help of the method CreateNewBoard in the DataVerifier class
        Board chessBoard = DataVerifier.CreateNewBoard();

        // Drawing the chessboard with the chessBoard objects DrawBoard() method
        chessBoard.DrawBoard();
    }
}
