using Raylib_cs;
using PingPongGame.Utils;

namespace PingPongGame.GameObjects
{
    public class Ball : GameObject
    {
        public Vector2D Velocity { get; set; }

        public Ball(Vector2D position, Vector2D velocity)
            : base(position, new Vector2D(Constants.BALL_SIZE, Constants.BALL_SIZE), Color.Yellow)
        {
            Velocity = velocity;
        }

        public override void Update()
        {
            position += Velocity;

            if (position.Y <= 0 || position.Y + Size.Y >= Constants.WINDOW_HEIGHT)
            {
                Velocity = new Vector2D(Velocity.X, -Velocity.Y);
            }
        }

        public void Reset()
        {
            position = new Vector2D(Constants.WINDOW_WIDTH / 2 - Constants.BALL_SIZE / 2, Constants.WINDOW_HEIGHT / 2 - Constants.BALL_SIZE / 2);
            Velocity = new Vector2D(Constants.BALL_SPEED, Constants.BALL_SPEED);
        }
    }
}
