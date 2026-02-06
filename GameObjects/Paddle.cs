using Raylib_cs;
using PingPongGame.Utils;
using PingPongGame.Managers;

namespace PingPongGame.GameObjects
{
    public class Paddle : GameObject
    {
        public bool IsAI { get; set; }

        public Paddle(Vector2D position, bool isAI = false)
            : base(position, new Vector2D(Constants.PADDLE_WIDTH, Constants.PADDLE_HEIGHT), isAI ? Color.Red : Color.Blue)
        {
            IsAI = isAI;
        }

        public void MoveUp()
        {
            position.Y -= Constants.PADDLE_SPEED;
        }

        public void MoveDown()
        {
            position.Y += Constants.PADDLE_SPEED;
            if (position.Y + Size.Y > Constants.WINDOW_HEIGHT)
            {
                position.Y = Constants.WINDOW_HEIGHT - Size.Y;
            }
        }
        public override void Update()
        {
            if (IsAI)
            {
                if (position.Y + Size.Y / 2 < GameManager.Ball.Position.Y)
                {
                    MoveDown();
                }
                else if (position.Y + Size.Y / 2 > GameManager.Ball.Position.Y)
                {
                    MoveUp();
                }
            }
        }
    }
}
