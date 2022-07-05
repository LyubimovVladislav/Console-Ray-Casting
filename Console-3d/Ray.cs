namespace Console_3d
{
	public struct Ray3
	{
		public Vector3 Origin { get; set; }
		public Vector3 Direction { get; set; }

		public Ray3(Vector3 origin, Vector3 direction)
		{
			Origin = origin;
			Direction = direction.Normalize();
		}

		public Vector3 Point(double t) => Origin + t * Direction;
	}
}