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

        public static Ball Ball => ball;

        private static int playerScore = 0;
        private static int aiScore = 0;


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

            // Restart gry po naciśnięciu "R" po końcu

            if (playerScore >= 10 || aiScore >= 10)
            {
                // Restart gry po naciśnięciu R
                if (Raylib.IsKeyPressed(KeyboardKey.R))
                {
                    playerScore = 0;
                    aiScore = 0;
                    ball.Reset();
                }

                return;
            }

            if (ball.CollidesWith(playerPaddle) || ball.CollidesWith(aiPaddle))
            {
                ball.Velocity = new Vector2D(-ball.Velocity.X, ball.Velocity.Y);
            }

            // if (ball.Position.X < 0 || ball.Position.X > Constants.WINDOW_WIDTH)
            // {
            //     ball.Reset();
            // }

            if (ball.Position.X + Constants.BALL_SIZE < 0)
            {
                aiScore++;
                ball.Reset();
            }
            else if (ball.Position.X > Constants.WINDOW_WIDTH)
            {
                playerScore++;
                ball.Reset();
            }
        }

        public static void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText($"Player: {playerScore}", 20, 20, 30, Color.Blue);
            Raylib.DrawText($"AI: {aiScore}", Constants.WINDOW_WIDTH - 150, 20, 30, Color.Red);

            // Koniec gry jeśli któryś zdobędzie 10 pkt

            if (playerScore >= 10 || aiScore >= 10)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                string winnerText = playerScore >= 10 ? "Gracz wygral!" : "AI wygralo!";
                Raylib.DrawText(winnerText, Constants.WINDOW_WIDTH / 2 - 150, Constants.WINDOW_HEIGHT / 2 - 30, 40, Color.White);
                Raylib.DrawText("Nacisnij [R], aby zagrac ponownie", Constants.WINDOW_WIDTH / 2 - 200, Constants.WINDOW_HEIGHT / 2 + 30, 20, Color.Gray);
                Raylib.EndDrawing();
                return;
            }


            playerPaddle.Draw();
            aiPaddle.Draw();
            ball.Draw();

            Raylib.EndDrawing();
        }
    }
}
