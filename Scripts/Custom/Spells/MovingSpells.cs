using System.Collections;
using Server.Spells;

namespace Server.Custom.Spells
{
	public class MovingSpells
	{
		public static void MoveMobileTo(Mobile m, Point3D origin, Direction d, int tiles)
		{
			int count = 0;

			var x = origin.X + GetOrientation(d).X;
			var y = origin.Y + GetOrientation(d).Y;
			Point3D newpoint = new Point3D(x, y, origin.Z);
			var p = (IPoint3D)newpoint;
			SpellHelper.GetSurfaceTop(ref p);

			while (count < tiles)
			{
				x = m.X + GetOrientation(d).X;
				y = m.Y + GetOrientation(d).Y;
				newpoint = new Point3D(x, y, m.Z);
				p = (IPoint3D)newpoint;
				SpellHelper.GetSurfaceTop(ref p);

				bool canfit = m.Map.CanSpawnMobile((Point3D)p);
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

		//var targets = new ArrayList();

		//var map = m_From.Map;

		//if (map != null)
		//{
		//	var range = 1;
		//	IPooledEnumerable eable = map.GetMobilesInRange(m_From.Location, range);

		//	ExplodeFX.Tornado.CreateInstance(m_From, m_From.Map, range).Send();

		//	foreach (Mobile m in eable)
		//		if (m_From != m && SpellHelper.ValidIndirectTarget(m_From, m) && m_From.CanBeHarmful(m, false))
		//			targets.Add(m);

		//	eable.Free();
		//}

		//if (targets.Count > 0)
		//{
		//	for (var i = 0; i < targets.Count; ++i)
		//	{
		//		var m = (Mobile)targets[i];

		//		var source = m_From;

		//		Disturb(m);

		//		if (m_Owner.CheckResisted(m))
		//			m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
		//		else
		//		{
		//			SpellHelper.Turn(m, source);

		//			MovingSpells.MoveMobileTo(m, m.Location, MovingSpells.GetOppositeDirection(source.Direction), 2);

		//			source.MovingParticles(m, 0x36D4, 7, 0, false, true, 342, 0, 9502, 4019, 0x160, 0);
		//			source.PlaySound(0x44B);
		//		}
		//	}
		//}
	}
}
