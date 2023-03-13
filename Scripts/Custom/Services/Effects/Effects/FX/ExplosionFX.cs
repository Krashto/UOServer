#region Header
//   Vorspire    _,-'/-'/  ExplosionFX.cs
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

using Server;
using Server.Commands;

using VitaNex.Network;
#endregion

namespace VitaNex.FX
{
	public enum ExplodeFX
	{
		None = 0,
		Random,
		Smoke,
		Water,
		Fire,
		Earth,
		Ice,
		Air,
		Energy,
		Poison,
		Bee,
		Blood,
		Bone,
		Tornado,
		Snow,
		BloodRain,
	}

	public static class ExplodeEffects
	{
		public static void Initialize()
		{
			CommandSystem.Register(
				"ExplodeFXHide",
				AccessLevel.GameMaster,
				ce =>
				{
					if (ce == null || ce.Mobile == null)
					{
						return;
					}

					var m = ce.Mobile;

					if (m.Hidden)
					{
						m.Hidden = false;
						CommandSystem.Entries["ExplodeFX"].Handler(ce);
					}
					else
					{
						CommandSystem.Entries["ExplodeFX"].Handler(ce);
						m.Hidden = true;
					}
				});

			CommandSystem.Register(
				"ExplodeFX",
				AccessLevel.GameMaster,
				ce =>
				{
					if (ce == null || ce.Mobile == null)
					{
						return;
					}

					var m = ce.Mobile;
					ExplodeFX effect;
					int range, speed, repeat, reverse;

					if (ce.Arguments.Length < 1 || !Enum.TryParse(ce.Arguments[0], true, out effect))
					{
						effect = ExplodeFX.None;
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

		public static BaseExplodeEffect CreateInstance(
			this ExplodeFX type,
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
		{
			switch (type)
			{
				case ExplodeFX.None:
					return null;
				case ExplodeFX.Smoke:
					return new SmokeExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Water:
					return new WaterRippleEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Fire:
					return new FireExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Earth:
					return new EarthExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Ice:
					return new IceExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Air:
					return new AirExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Energy:
					return new EnergyExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Poison:
					return new PoisonExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Bee:
					return new BeeExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Blood:
					return new BloodExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Bone:
					return new BoneExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Tornado:
					return new TornadoExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.Snow:
					return new SnowExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				case ExplodeFX.BloodRain:
					return new BloodRainExplodeEffect(start, map, range, repeat, interval, effectHandler, callback);
				default:
					{
						var rfx = (ExplodeFX[])Enum.GetValues(typeof(ExplodeFX));

						do
						{
							type = rfx.GetRandom();
						}
						while (type == ExplodeFX.Random || type == ExplodeFX.None);

						return CreateInstance(type, start, map, range, repeat, interval, effectHandler, callback);
					}
			}
		}
	}
}

namespace VitaNex.FX
{
	public abstract class BaseExplodeEffect : BaseRangedEffect<EffectQueue, EffectInfo>
	{
		public BaseExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 2,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
		{ }

		public override EffectQueue CreateEffectQueue(IEnumerable<EffectInfo> queue)
		{
			return new EffectQueue(queue, null, EffectHandler, false);
		}

		public override EffectInfo CloneEffectInfo(EffectInfo src)
		{
			return new EffectInfo(null, null, src.EffectID, src.Hue, src.Speed, src.Duration, src.Render, src.Delay);
		}
	}

	public class SmokeExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get { return new[] { new EffectInfo(null, null, 14120, 0, 10, 10, EffectRender.SemiTransparent) }; }
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public SmokeExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
		{ }
	}

	public class WaterRippleEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info { get { return new[] { new EffectInfo(null, null, -1, 0, 10, 30) }; } }

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public WaterRippleEffect(
			IPoint3D start,
			Map map,
			int range = 3,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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
					e.EffectID = 8099;
					break;
				case Direction.Down:
				case Direction.South:
					e.EffectID = 8114;
					break;
				case Direction.Right:
				case Direction.East:
					e.EffectID = 8109;
					break;
				case Direction.Left:
				case Direction.West:
					e.EffectID = 8104;
					break;
			}
		}
	}

	public class FireExplodeEffect : BaseExplodeEffect
	{
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

		public FireExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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

	public class EarthExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20),
					//new EffectInfo(null, null, 14120, 0, 10, 20, EffectRender.Normal, TimeSpan.FromMilliseconds(400))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public EarthExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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

			var list = new int[] { 0x1771, 0x1773, 0x1774, 0x1775, 0x1776, 0x1777, 0x1778, 0x1779, 0x177B, 0x177C };
			e.EffectID = Utility.RandomList(list);
			e.Hue = Utility.RandomMinMax(2107, 2112);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}


	public class IceExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20),
					//new EffectInfo(null, null, 14120, 0, 10, 20, EffectRender.Normal, TimeSpan.FromMilliseconds(400))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public IceExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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

			var list = new int[] { 0x1771, 0x1773, 0x1774, 0x1775, 0x1776, 0x1777, 0x1778, 0x1779, 0x177B, 0x177C };
			e.EffectID = Utility.RandomList(list);
			e.Hue = Utility.RandomMinMax(1361, 1366);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}

	public class AirExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 14217, 899, 10, 20, EffectRender.Lighten),
					new EffectInfo(null, null, 14284, 899, 10, 30, EffectRender.LightenMore, TimeSpan.FromMilliseconds(200))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public AirExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
		{ }
	}

	public class EnergyExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 14170, 0, 10, 20, EffectRender.LightenMore),
					new EffectInfo(null, null, 14201, 0, 10, 30, EffectRender.Normal, TimeSpan.FromMilliseconds(200))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public EnergyExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e != null && e.EffectID == 14201)
			{
				e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: -5), e.Map);
			}
		}
	}

	public class PoisonExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 14217, 65, 10, 30, EffectRender.Darken),
					new EffectInfo(null, null, 14120, 65, 10, 30, EffectRender.Transparent, TimeSpan.FromMilliseconds(200))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public PoisonExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e != null)
			{
				e.Hue = Utility.RandomMinMax(550, 580);
			}
		}
	}

	public class BeeExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, 2331, 0, 10, 20, EffectRender.Normal),
					new EffectInfo(null, null, 2331, 0, 10, 30, EffectRender.Darken, TimeSpan.FromMilliseconds(300))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public BeeExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
		{
			EnableMutate = true;
		}

		public override void MutateEffect(EffectInfo e)
		{
			base.MutateEffect(e);

			if (e != null && e.EffectID == 14201)
			{
				e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: -5), e.Map);
			}
		}
	}

	public class BloodExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal),
					new EffectInfo(null, null, -1, 0, 10, 30, EffectRender.Darken, TimeSpan.FromMilliseconds(300))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public BloodExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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

	public class BoneExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal),
					new EffectInfo(null, null, -1, 0, 10, 30, EffectRender.Normal, TimeSpan.FromMilliseconds(300))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public BoneExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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

			var idList = new int[] { Utility.RandomMinMax(0x0ECA, 0x0ED2) };
			e.EffectID = Utility.RandomList(idList);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}

	public class TornadoExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get { return new[] { new EffectInfo(null, null, 14284, 899, 10, 10, EffectRender.ShadowOutline) }; }
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public TornadoExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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
		}
	}

	public class SnowExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Darken, TimeSpan.FromMilliseconds(100)),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Lighten, TimeSpan.FromMilliseconds(100))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }

		public SnowExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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

			var idList = new int[] { Utility.RandomMinMax(0x1153, 0x115D) };
			e.EffectID = Utility.RandomList(idList);
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}

	public class BloodRainExplodeEffect : BaseExplodeEffect
	{
		public static EffectInfo[] Info
		{
			get
			{
				return new[]
				{
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Normal),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Darken, TimeSpan.FromMilliseconds(100)),
					new EffectInfo(null, null, -1, 0, 10, 20, EffectRender.Lighten, TimeSpan.FromMilliseconds(100))
				};
			}
		}

		private readonly EffectInfo[] _Effects = Info;

		public override EffectInfo[] Effects { get { return _Effects; } }
		public override bool Reversed { get { return true; } }

		public BloodRainExplodeEffect(
			IPoint3D start,
			Map map,
			int range = 5,
			int repeat = 0,
			TimeSpan? interval = null,
			Action<EffectInfo> effectHandler = null,
			Action callback = null)
			: base(start, map, range, repeat, interval, effectHandler, callback)
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

			var idList = new int[] { Utility.RandomMinMax(0x1153, 0x115D) };
			e.EffectID = Utility.RandomList(idList);
			e.Hue = 33;
			e.Source = new Entity(Serial.Zero, e.Source.Location.Clone3D(zOffset: 5), e.Map);
		}
	}
}