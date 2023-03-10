namespace Server.Custom.Spells
{
	public class MovingSpells
	{
		public static void PushMobileTo(Mobile m, Point3D origin, Direction d, int tiles)
		{
			int count = 0;

			while (count < tiles)
			{
				var x = origin.X + GetOrientation(d).X;
				var y = origin.Y + GetOrientation(d).Y;
				var z = m.Map.GetAverageZ(x, y);
				Point3D newpoint = new Point3D(x, y, z);
				bool canfit = m.Map.CanSpawnMobile(newpoint);
				if (canfit)
					m.MoveToWorld(newpoint, m.Map);
				else
					break;
				count++;
			}
		}

		public static Point2D GetOrientation(Direction d)
		{
			switch (d)
			{
				case Direction.North: return new Point2D(0, -1);
				case Direction.Right: return new Point2D(1, -1);
				case Direction.East: return new Point2D(1, 0);
				case Direction.Down: return new Point2D(1, 1);
				case Direction.South: return new Point2D(0, 1);
				case Direction.Left: return new Point2D(-1, 1);
				case Direction.West: return new Point2D(-1, 0);
				case Direction.Up: return new Point2D(-1, 1);
			}

			return new Point2D(0, 0);
		}

		public static Direction GetOppositeDirection(Direction d)
		{
			switch(d)
			{
				case Direction.North: return Direction.South;
				case Direction.Right: return Direction.Left;
				case Direction.East: return Direction.West;
				case Direction.Down: return Direction.Up;
				case Direction.South: return Direction.North;
				case Direction.Left: return Direction.Right;
				case Direction.West: return Direction.East;
				case Direction.Up: return Direction.Down;
			}

			return d;
		}
	}
}
