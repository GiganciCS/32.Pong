using Raylib_cs;
using PingPongGame.GameObjects;
using PingPongGame.Utils;
using System.Collections.Generic;

namespace PingPongGame.Managers
{
    public static class GameManager
    {
        private static Paddle playerPaddle;
        private static Paddle aiPaddle;
        private static Ball ball;


        public static void Initialize()
        {
            Raylib.InitWindow(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT, "Ping Pong Game");
            Raylib.SetTargetFPS(60);

            playerPaddle = new Paddle(new Vector2D(50, Constants.WINDOW_HEIGHT / 2 - Constants.PADDLE_HEIGHT / 2));
            aiPaddle = new Paddle(new Vector2D(Constants.WINDOW_WIDTH - 70, Constants.WINDOW_HEIGHT / 2 - Constants.PADDLE_HEIGHT / 2), true);
            ball = new Ball(new Vector2D(Constants.WINDOW_WIDTH / 2 - Constants.BALL_SIZE / 2, Constants.WINDOW_HEIGHT / 2 - Constants.BALL_SIZE / 2), new Vector2D(Constants.BALL_SPEED, Constants.BALL_SPEED));
        }

        public static void Update()
        {
            
            InputManager.HandleInput(playerPaddle);
            ball.Update();
            aiPaddle.Update();

            if (ball.CollidesWith(playerPaddle) || ball.CollidesWith(aiPaddle))
            {
                ball.Velocity = new Vector2D(ball.Velocity.X, -ball.Velocity.Y);
            }

            if (ball.Position.X < 0 || ball.Position.X > Constants.WINDOW_WIDTH)
            {
                ball.Reset();
            }
        }

        public static void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            playerPaddle.draw();
            aiPaddle.Draw();
            ball.Draw();

            Raylib.EndDrawing();
        }
    }
}
