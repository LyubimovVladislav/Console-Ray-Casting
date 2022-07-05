using System;
using System.Diagnostics.CodeAnalysis;

namespace Console_3d
{
	public struct Vector3 : ICloneable
	{
		public double X { get; private set; }
		public double Y { get; private set; }
		public double Z { get; private set; }

		public Vector3(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Vector3(double val)
		{
			X = val;
			Y = val;
			Z = val;
		}

		public static Vector3 operator +(Vector3 a) => a;

		public static Vector3 operator -(Vector3 a) => new(-a.X, -a.Y, -a.Z);

		public static Vector3 operator +(Vector3 a, Vector3 b)
			=> new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

		public static Vector3 operator -(Vector3 a, Vector3 b)
			=> new(a.X - +b.X, a.Y - b.Y, a.Z - b.Z);

		public static Vector3 operator /(Vector3 a, Vector3 b)
			=> new(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

		public static Vector3 operator /(Vector3 a, double b)
			=> new(a.X / b, a.Y / b, a.Z / b);

		public static Vector3 operator /(double a, Vector3 b)
			=> new(a / b.X, a / b.Y, a / b.Z);

		public static Vector3 operator *(Vector3 a, Vector3 b)
			=> new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

		public static Vector3 operator *(Vector3 a, double b)
			=> new(a.X * b, a.Y * b, a.Z * b);

		public static Vector3 operator *(double b, Vector3 a)
			=> new(a.X * b, a.Y * b, a.Z * b);


		public Vector3 Normalize() => this / Length();
		public static Vector3 Normalize(double x, double y, double z) => new Vector3(x, y, z).Normalize();
		public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

		public Vector3 Abs() => new(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));

		public Vector3 Sign() => new(Math.Sign(X), Math.Sign(Y), Math.Sign(Z));

		public Vector3 RelativeTo(Vector3 edge) => new(X.CompareTo(edge.X), Y.CompareTo(edge.Y), Z.CompareTo(edge.Z));

		public double Dot(Vector3 other) => X * other.X + Y * other.Y + Z * other.Z;

		public static double Dot(Vector3 first, Vector3 second) =>
			first.X * second.X + first.Y * second.Y + first.Z * second.Z;

		// ReSharper disable InconsistentNaming
		public Vector3 Rotate(double angleYZ = 0, double angleXZ = 0, double angleXY = 0)
		{
			Vector3 vec = (Vector3) this.Clone();
			if (angleYZ != 0)
				RotateYZ(ref vec, angleYZ);
			if (angleXZ != 0)
				RotateXZ(ref vec, angleXZ);
			if (angleXY != 0)
				RotateXY(ref vec, angleXY);
			return vec;
		}


		private static void RotateYZ(ref Vector3 vec, double angle)
		{
			var tempY = vec.Y;
			var tempZ = vec.Z;
			vec.Y = tempY * Math.Cos(angle) - tempZ * Math.Sin(angle);
			vec.Z = tempY * Math.Sin(angle) + tempZ * Math.Cos(angle);
		}

		private static void RotateXZ(ref Vector3 vec, double angle)
		{
			var tempX = vec.X;
			var tempZ = vec.Z;
			vec.X = tempX * Math.Cos(angle) + tempZ * Math.Sin(angle);
			vec.Z = tempX * -Math.Sin(angle) + tempZ * Math.Cos(angle);
		}

		private static void RotateXY(ref Vector3 vec, double angle)
		{
			var tempX = vec.X;
			var tempY = vec.Y;
			vec.X = tempX * Math.Cos(angle) - tempY * Math.Sin(angle);
			vec.Y = tempX * Math.Sin(angle) + tempY * Math.Cos(angle);
		}

		// ReSharper restore InconsistentNaming


		public object Clone()
		{
			return new Vector3(X, Y, Z);
		}
	}
}