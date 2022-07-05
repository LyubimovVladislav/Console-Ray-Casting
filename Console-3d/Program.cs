using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Console_3d
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			int height = 30, width = 120;
			ConsoleHelper.SetWindow((short) width, (short) height);
			var aspect = width / (double) height;
			const double pxAspect = 11f / 24f;
			var screen = new char[height * width];
			var gradient = " .:!/r(l1Z4H9W8$@".ToCharArray();
			var gradientSize = gradient.Length - 1;


			var lightDirection = Vector3.Normalize(-0.5, 0.5, -1.0);
			// TODO: make a Sphere class
			var spherePos = new Vector3(0, 0, 0);

			for (int t = 0; t < 100000; t++)
			{
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						var uv = new Vector2(i, j) / new Vector2(width, height) * 2 - 1;
						uv.X *= aspect * pxAspect;
						var ray =
							new Ray3(
								new Vector3(-6, 0, 0),
								new Vector3(3, uv.X, uv.Y));

						// first - camera pos, second - ray direction
						// ray that is pointing at given pixel(char)

						// ray.Origin = ray.Origin.Rotate(angleXZ: 0.25);
						// ray.Direction = ray.Direction.Rotate(angleXZ: 0.25);

						ray.Origin = ray.Origin.Rotate(      angleXY: t * 0.01, angleXZ: t * 0.01);
						ray.Direction = ray.Direction.Rotate(angleXY: t * 0.01, angleXZ: t * 0.01);


						var intersection = Intersections.Sphere(spherePos, 1, ray);
						int colour = 0;
						if (!double.IsNaN(intersection))
						{
							var hitPoint = ray.Point(intersection);
							var normal = (hitPoint - spherePos).Normalize();
							var differenceInAngle = (-normal).Dot(lightDirection);
							colour = (int) (differenceInAngle * 20);
							colour = colour.Clamp(0, gradientSize);
						}

						screen[i + j * width] = gradient[colour];
					}
				}

				ConsoleHelper.WriteToBufferAt(screen, 0, 0);
			}
		}
	}
}