﻿#region Header
//   Vorspire    _,-'/-'/  WaveFX.cs
//   .      __,-; ,'( '/
//    \.    `-.__`-._`:_,-._       _ , . ``
//     `:-._,------' ` _,`--` -: `_ , ` ,' :
//        `---..__,,--'  (C) 2018  ` -'. -'
//        #  Vita-Nex [http://core.vita-nex.com]  #
//  {o)xxx|===============-   #   -===============|xxx(o}
//        #        The MIT License (MIT)          #
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Server;
using Server.Commands;
using Server.Movement;

using VitaNex.Network;
#endregion

namespace VitaNex.FX
{
	public enum WaveFX
	{
		None = 0,
		Random,
		Water,
		Fire,
		Earth,
		Air,
		Energy,
		Poison,
		Tornado,
		Brambles,
		SpiderWeb,
		Blood,
	}

	public static class WaveEffects
	{
		public static void Initialize()
		{
			CommandSystem.Register(
				"WaveFX",
				AccessLevel.GameMaster,
				ce =>
				{
					var m = ce.Mobile;
					WaveFX effect;
					int range, speed, repeat, reverse;

					if (ce.Arguments.Length < 1 || !Enum.TryParse(ce.Arguments[0], true, out effect))
					{
						effect = WaveFX.None;
					}

					if (ce.Arguments.Length < 2 || !Int32.TryParse(ce.Arguments[1], out range))
					{
						range = 5;
					}

					if (ce.Arguments.Length < 3 || !Int32.TryParse(ce.Arguments[2], out speed))
					{
						speed = 10;
					}

					if (ce.Arguments.Length < 4 || !Int32.TryParse(ce.Arguments[3], out repeat))
					{
						repeat = 0;
					}

					if (ce.Arguments.Length < 5 || !Int32.TryParse(ce.Arguments[4], out reverse))
					{
						reverse = 0;
					}

					range = Math.Max(0, Math.Min(100, range));
					speed = Math.Max(1, Math.Min(10, speed));
					repeat = Math.Max(0, Math.Min(100, repeat));
					reverse = Math.Max(0, Math.Min(1, reverse));

					var e = effect.CreateInstance(
						m.Location,
						m.Map,
						m.Direction,
						range,
						repeat,
						TimeSpan.FromMilliseconds(1000 - ((speed - 1) * 100)));

					if (e != null)
					{
						e.Reversed = (reverse > 0);
						e.Send();
					}
					else
					{
						m.SendMessage(0x55, "Usage: <effect> <range> <speed> <repeat> <reverse>");
					}
				});
		}

		public static BaseWaveEffect CreateInstance(
			this WaveFX type,
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
		{
			switch (type)
			{
				case WaveFX.None:
					return null;
				case WaveFX.Fire:
					return new FireWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Water:
					return new WaterWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Earth:
					return new EarthWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Air:
					return new AirWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Energy:
					return new EnergyWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Poison:
					return new PoisonWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Tornado:
					return new TornadoEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Brambles:
					return new BramblesWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.SpiderWeb:
					return new SpiderWebWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				case WaveFX.Blood:
					return new BloodWaveEffect(start, map, d, range, repeat, interval, effectHandler, callback);
				default:
					{
						var rfx = (WaveFX[])Enum.GetValues(typeof(WaveFX));

						do
						{
							type = rfx.GetRandom();
						}
						while (type == WaveFX.Random || type == WaveFX.None);

						return CreateInstance(type, start, map, d, range, repeat, interval, effectHandler, callback);
					}
			}
		}
	}

	public abstract class BaseWaveEffect : BaseRangedEffect<EffectQueue, EffectInfo>
	{
		public virtual Direction Direction { get; set; }

		public BaseWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
		{
			Direction = d & Direction.ValueMask;
		}

		public override EffectQueue CreateEffectQueue(IEnumerable<EffectInfo> queue)
		{
			return new EffectQueue(queue, null, EffectHandler, false);
		}

		public override EffectInfo CloneEffectInfo(EffectInfo src)
		{
			return new EffectInfo(null, null, src.EffectID, src.Hue, src.Speed, src.Duration, src.Render, src.Delay);
		}

		protected override bool ExcludePoint(Point3D p, int range, Direction fromCenter)
		{
			switch (Direction & Direction.Mask)
			{
				case Direction.Up:
					return !(fromCenter == Direction.West || fromCenter == Direction.Up || fromCenter == Direction.North);
				case Direction.North:
					return !(fromCenter == Direction.Up || fromCenter == Direction.North || fromCenter == Direction.Right);
				case Direction.Right:
					return !(fromCenter == Direction.North || fromCenter == Direction.Right || fromCenter == Direction.East);
				case Direction.East:
					return !(fromCenter == Direction.Right || fromCenter == Direction.East || fromCenter == Direction.Down);
				case Direction.Down:
					return !(fromCenter == Direction.East || fromCenter == Direction.Down || fromCenter == Direction.South);
				case Direction.South:
					return !(fromCenter == Direction.Down || fromCenter == Direction.South || fromCenter == Direction.Left);
				case Direction.Left:
					return !(fromCenter == Direction.South || fromCenter == Direction.Left || fromCenter == Direction.West);
				case Direction.West:
					return !(fromCenter == Direction.Left || fromCenter == Direction.West || fromCenter == Direction.Up);
			}

			return true;
		}
	}

	public class WaterWaveEffect : BaseWaveEffect
	{
		public static bool DisplayElemental = true;

		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 0x34FF, 0, 10, 20),
					new EffectInfo(null, null, 14089, 100, 10, 30, EffectRender.SemiTransparent, TimeSpan.FromMilliseconds(200)),
					new EffectInfo(null, null, -1, 0, 10, 40, EffectRender.Normal, TimeSpan.FromMilliseconds(400))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public WaterWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override EffectInfo CloneEffectInfo(EffectInfo src)
		{
			if (src != null && src.EffectID == 8459 && !DisplayElemental)
			{
				return null;
			}

			return base.CloneEffectInfo(src);
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null || e.EffectID != -1)
			{
				return;
			}

			switch (Direction)
			{
				case Direction.North:
					{
						switch (Utility.GetDirection(Start, e.Source))
						{
							case Direction.Up:
							case Direction.North:
							case Direction.Right:
								e.EffectID = 8099;
								break;
						}
					}
					break;
				case Direction.East:
					{
						switch (Utility.GetDirection(Start, e.Source))
						{
							case Direction.Down:
							case Direction.East:
							case Direction.Right:
								e.EffectID = 8109;
								break;
						}
					}
					break;
				case Direction.South:
					{
						switch (Utility.GetDirection(Start, e.Source))
						{
							case Direction.Down:
							case Direction.South:
							case Direction.Left:
								e.EffectID = 8114;
								break;
						}
					}
					break;
				case Direction.West:
					{
						switch (Utility.GetDirection(Start, e.Source))
						{
							case Direction.Up:
							case Direction.West:
							case Direction.Left:
								e.EffectID = 8104;
								break;
						}
					}
					break;
				default:
					{
						switch (Utility.GetDirection(Start, e.Source))
						{
							case Direction.Up:
							case Direction.North:
								e.EffectID = 8099;
								break;
							case Direction.Right:
							case Direction.East:
								e.EffectID = 8109;
								break;
							case Direction.Down:
							case Direction.South:
								e.EffectID = 8114;
								break;
							case Direction.Left:
							case Direction.West:
								e.EffectID = 8104;
								break;
						}
					}
					break;
			}
		}
	}

	public class FireWaveEffect : BaseWaveEffect
	{
		public static bool DisplayElemental = true;

		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 6571, 0, 10, 20),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal, TimeSpan.FromMilliseconds(100)),
					new EffectInfo(null, null, 6571, 0, 10, 20, EffectRender.Darken, TimeSpan.FromMilliseconds(200))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public FireWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null || e.EffectID != -1)
			{
				return;
			}

			switch (Utility.GetDirection(Start, e.Source))
			{
				case Direction.Up:
				case Direction.North:
					e.EffectID = 0x398C;
					break;
				case Direction.Down:
				case Direction.South:
					e.EffectID = 0x398C;
					break;
				case Direction.Right:
				case Direction.East:
					e.EffectID = 0x3996;
					break;
				case Direction.Left:
				case Direction.West:
					e.EffectID = 0x3996;
					break;
			}
		}
	}

	public class EarthWaveEffect : BaseWaveEffect
	{
		public static bool DisplayElemental = true;

		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal, TimeSpan.FromMilliseconds(300)),
					new EffectInfo(null, null, 14120, 0, 10, 20, EffectRender.Normal, TimeSpan.FromMilliseconds(500))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public EarthWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override EffectInfo CloneEffectInfo(EffectInfo src)
		{
			if (src != null && src.EffectID == 8407 && !DisplayElemental)
			{
				return null;
			}

			return base.CloneEffectInfo(src);
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null || e.EffectID >= 0)
			{
				return;
			}

			var list = new int[] { 0x1771, 0x1773, 0x1774, 0x1775, 0x1776, 0x1777, 0x1778, 0x1779, 0x177B, 0x177C };
			e.EffectID = Utility.RandomList(list);
			e.Hue = Utility.RandomMinMax(2107, 2112);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}

	public class AirWaveEffect : BaseWaveEffect
	{
		public static bool DisplayElemental = true;

		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 8429, 0, 10, 20),
					new EffectInfo(null, null, 14217, 899, 10, 30, EffectRender.Lighten, TimeSpan.FromMilliseconds(200)),
					new EffectInfo(null, null, 14284, 899, 10, 40, EffectRender.LightenMore, TimeSpan.FromMilliseconds(400))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public AirWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override EffectInfo CloneEffectInfo(EffectInfo src)
		{
			if (src != null && src.EffectID == 8429 && !DisplayElemental)
			{
				return null;
			}

			return base.CloneEffectInfo(src);
		}
	}

	public class EnergyWaveEffect : BaseWaveEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 8448, 0, 10, 20),
					new EffectInfo(null, null, 14170, 0, 10, 30, EffectRender.LightenMore, TimeSpan.FromMilliseconds(200)),
					new EffectInfo(null, null, 14201, 0, 10, 40, EffectRender.Normal, TimeSpan.FromMilliseconds(400))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public EnergyWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null)
			{
				return;
			}

			switch (e.EffectID)
			{
				case 8448:
					e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: -10), e.Map);
					break;
				case 14201:
					e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: -5), e.Map);
					break;
			}
		}
	}

	public class PoisonWaveEffect : BaseWaveEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20),
					new EffectInfo(null, null, 14217, 65, 10, 30, EffectRender.Darken, TimeSpan.FromMilliseconds(200)),
					new EffectInfo(null, null, 14120, 65, 10, 40, EffectRender.Normal, TimeSpan.FromMilliseconds(400))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public PoisonWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null)
			{
				return;
			}

			switch (e.EffectID)
			{
				case -1:
					e.EffectID = Utility.RandomMinMax(11666, 11668);
					break;
				default:
					e.Hue = Utility.RandomMinMax(550, 580);
					break;
			}
		}
	}

	public class TornadoEffect : BaseWaveEffect
	{
		public static EffectInfo[] Info
		{
			get { return new[] { new EffectInfo(null, null, 14284, 899, 10, 10, EffectRender.ShadowOutline) }; }
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public int Size { get; set; }
		public int Climb { get; set; }
		public int Height { get; set; }

		public bool CanMove { get; set; }

		public TornadoEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 10,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;

			Size = 5;
			Climb = 5;
			Height = 80;

			CanMove = true;
		}

		protected override bool ExcludePoint(Point3D p, int range, Direction fromCenter)
		{
			return false;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			e.Duration = 7 + (int)(Interval.TotalMilliseconds / 100.0);

			switch (Utility.Random(3))
			{
				case 0:
					e.Render = EffectRender.Darken;
					break;
				case 1:
					e.Render = EffectRender.SemiTransparent;
					break;
				case 2:
					e.Render = EffectRender.ShadowOutline;
					break;
			}
		}

		public override Point3D[][] GetTargetPoints(int count)
		{
			var start = Start.Clone3D();

			int x = 0, y = 0;

			if (CanMove)
			{
				Movement.Offset(Direction, ref x, ref y);
			}

			var end = start.Clone3D(Range * x, Range * y);

			if (AverageZ)
			{
				start = start.GetWorldTop(Map);
				end = end.GetWorldTop(Map);
			}

			var path = CanMove ? start.GetLine3D(end, Map, AverageZ) : new[] { start };
			var points = new List<Point3D>[path.Length];

			points.SetAll(i => new List<Point3D>());

			var climb = Climb;
			var size = Size;
			double height = Height;

			Action<int> a = i =>
			{
				var step = path[i];

				for (var z = 0; z < height; z += climb)
				{
					var mm = (int)Math.Max(0, size * (z / height));

					points[i].AddRange(step.ScanRangeGet(Map, mm, mm, ComputePoint, false).Combine().Select(p => p.Clone3D(0, 0, z)));
				}
			};

			if (path.Length < 10)
			{
				for (var i = 0; i < path.Length; i++)
				{
					a(i);
				}
			}
			else
			{
				Parallel.For(0, path.Length, a);
			}

			return points.FreeToMultiArray(true);
		}
	}

	public class BramblesWaveEffect : BaseWaveEffect
	{
		public static bool DisplayElemental = true;

		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal, TimeSpan.FromMilliseconds(400)),
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public BramblesWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null || e.EffectID != -1)
			{
				return;
			}

			var idList = new int[] { Utility.RandomMinMax(0x3020, 0x3024), Utility.RandomMinMax(0x0D3F, 0x0D40) };
			e.EffectID = Utility.RandomList(idList);
			var hueList = new int[] { Utility.RandomMinMax(2107, 2111), Utility.RandomMinMax(2126, 2129) };
			e.Hue = Utility.RandomList(hueList);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}

	public class SpiderWebWaveEffect : BaseWaveEffect
	{
		public static bool DisplayElemental = true;

		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal, TimeSpan.FromMilliseconds(400)),
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public SpiderWebWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null || e.EffectID != -1)
			{
				return;
			}

			var idList = new int[] { Utility.RandomMinMax(0x0EE3, 0x0EE6), Utility.RandomMinMax(0x10D4, 0x10D7) };
			e.EffectID = Utility.RandomList(idList);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}

	public class BloodWaveEffect : BaseWaveEffect
	{
		public static bool DisplayElemental = true;

		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Darken, TimeSpan.FromMilliseconds(300)),
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public BloodWaveEffect(
			IPoint3D start,
			Map map,
			Direction d,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, d, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e == null || e.EffectID != -1)
			{
				return;
			}

			var idList = new int[] { Utility.RandomMinMax(0x122A, 0x122E) };
			e.EffectID = Utility.RandomList(idList);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}
}