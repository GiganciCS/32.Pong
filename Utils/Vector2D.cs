namespace PingPongGame.Utils
{
    public struct Vector2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D operator +(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b)
        {
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2D operator *(Vector2D a, float scalar)
        {
            return new Vector2D(a.X + scalar, a.Y + scalar);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
