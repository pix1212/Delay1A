using System;

namespace Delay1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1);

            Console.CursorVisible = false;

            while(true)
            {
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}
