using System;
using Server.Spells;

namespace Server.Custom.Spells
{
	public class MovingSpells
	{
		public static void MoveMobileTo(Mobile m, Direction d, int tiles)
		{
			try
			{
				for (int i = 0; i < tiles; i++)
				{
					var oritentation = GetOrientation(d);
					var from = m.Location;
					from.X += oritentation.X * tiles;
					from.Y += oritentation.Y * tiles;

					Timer.DelayCall(TimeSpan.FromSeconds(0.5 * i), () =>
					{
						if (SpellHelper.AdjustField(ref from, m.Map, 12, false))
						{
							m.Location = from;
							m.ProcessDelta();
						}
						else
							m.Paralyze(TimeSpan.FromSeconds(0.5));
					});
				}
			}
			catch (Exception e)
			{
				Diagnostics.ExceptionLogging.LogException(e);
			}
		}

		public static Point2D GetOrientation(Direction d)
		{
			if ((int)d >= 0x80)
				d = d & (Direction.North | Direction.Right | Direction.East | Direction.Down | Direction.South | Direction.Left | Direction.West | Direction.Up );

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
			if ((int)d >= 0x80)
				d = d & (Direction.North | Direction.Right | Direction.East | Direction.Down | Direction.South | Direction.Left | Direction.West | Direction.Up);

			switch (d)
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
