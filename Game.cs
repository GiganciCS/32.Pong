using Raylib_cs;
using PingPongGame.Managers;

namespace PingPongGame
{
    public class Game
    {
        public static void Main()
        {
            GameManager.Initialize();

            while (Raylib.WindowShouldClose())
            {
                GameManager.Update();

                GameManager.Draw();
            }

            Raylib.CloseWindow();
        }
    }
}
