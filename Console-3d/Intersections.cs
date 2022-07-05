using System;

namespace Console_3d
{
	public static class Intersections
	{
		public static double Sphere(Vector3 center, double radius, Ray3 ray)
		{
			// Sphere equation: (x−x0)^2 + (y−y0)^2 + (z−z0)^2 = r^2
			// P = (x,y,z);
			// C = (x0,y0,z0);
			// Sphere equation: dot((P−C), (P−C)) = r^2 
			// Ray equation: p(t) = A + t*B  where: A - origin vector, B - direction unit vector;
			// Intersection: dot((A+tB−C), (A+tB−C)) = r^2
			// => t^2*dot(B, B) + 2t*dot(B, A−C) + dot(A−C, A−C) − r^2 = 0
			// D = dot(B, B);
			// E = 2*dot(B, A−C);
			// F = dot(A−C, A−C) − r^2
			// => t^2*D + t*E + F = 0 - quadratic equation

			Vector3 ac = ray.Origin - center; // A - C;
			double d = Vector3.Dot(ray.Direction, ray.Direction);
			double e = 2 * Vector3.Dot(ray.Direction, ac);
			double f = Vector3.Dot(ac, ac) - radius * radius;
			double discriminant = e * e - 4 * d * f;
			if (discriminant < 0) // doesn't intersect with the sphere
				return double.NaN;
			double t0 = (-e - Math.Sqrt(discriminant)) / (2 * d); // fist solution for t in p(t) = A + t*B
			double t1 = (-e + Math.Sqrt(discriminant)) / (2 * d);

			if (t0 > t1)
				(t0, t1) = (t1, t0);
			
			if (t0 >= 0) return t0;
			return t1 >= 0 ? t1 : double.NaN;

			// t0 == t1 if one point intersection, aka tangent;
			// t0 > 0 and t1 > 0 ray is facing the sphere and intersecting
			// t0 < 0 and t1 > 0 ray origin is located inside the sphere
			// t0 < 0 and t1 < 0 ray is facing away from the sphere, so it cant intersect with the sphere

			// Also different solution:
			// 	float b = dot(ro, rd);
			// 	float c = dot(ro, ro) - r * r;
			// 	float h = b * b - c;
			// 	if (h < 0.0) return vec2(-1.0);
			// 	h = sqrt(h);
			// 	return vec2(-b - h, -b + h);
		}
	}
}