using Raylib_cs;
using PingPongGame.GameObjects;

namespace PingPongGame.Managers
{
    public static class InputManager
    {
        public static void HandleInput(Paddle playerPaddle)
        {
            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                playerPaddle.Move();
            }
            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                playerPaddle.MoveDown();
            }
        }
    }
}
