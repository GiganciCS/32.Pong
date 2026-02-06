using Raylib_cs;

namespace PingPongGame.GameObjects
{
    public abstract class GameObject
    {
        protected Vector2D position;
        public Vector2D Position { get => position; }
        public Vector2D Size { get; protected set; }
        public Color Color { get; protected set; }
        public bool IsActive { get; set; }

        protected GameObject(Vector2D position, Vector2D size, Color color)
        {
            this.position = position;
            Size = size;
            Color = color;
            IsActive = true;
        }

        public void Move(Vector2D delta)
        {
            position += delta;
        }

        public void SetPosition(Vector2D position)
        {
            this.position = position;
        }

        public abstract void Update();

        public void Draw()
        {
            Raylib.DrawRectangle((int)position.X, (int)position.Y, (int)Size.X, (int)Size.Y, Color);
        }

        public bool CollidesWith(GameObject other)
        {
            return position.X < other.position.X + other.Size.X &&
                   position.X + Size.X > other.position.X &&
                   position.Y < other.position.Y + other.Size.Y &&
                   position.Y + Size.Y > other.position.Y;
        }
    }
}
