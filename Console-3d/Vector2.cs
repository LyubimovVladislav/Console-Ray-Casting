namespace Console_3d
{
	public class Vector2
	{
		public double X { get; set; }
		public double Y { get; set; }

		public Vector2(double x, double y)
		{
			X = x;
			Y = y;
		}

		public Vector2(double val)
		{
			X = val;
			Y = val;
		}


		public static Vector2 operator +(Vector2 a, Vector2 b)
			=> new(a.X + b.X, a.Y + b.Y);
		public static Vector2 operator -(Vector2 a, Vector2 b)
			=> new(a.X - b.X, a.Y - b.Y);
		public static Vector2 operator -(Vector2 a, double b)
			=> new(a.X - b, a.Y - b);
		public static Vector2 operator -(double a, Vector2 b)
			=> new(a - b.X, a - b.Y);
		public static Vector2 operator /(Vector2 a, Vector2 b)
			=> new(a.X / b.X, a.Y / b.Y);
		public static Vector2 operator *(Vector2 a, Vector2 b)
			=> new(a.X * b.X, a.Y * b.Y);
		public static Vector2 operator *(Vector2 a, double b)
			=> new(a.X * b, a.Y * b);
		public static Vector2 operator *(double a, Vector2 b)
			=> new(a * b.X, a * b.Y);
	}
}