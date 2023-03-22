using System;
using Server.Commands;
using Server.CustomScripts.Systems;
using Server.CustomScripts.Systems.Experience;

namespace Server.CustomScripts.Commands
{
	class DailyResetCommand
	{
		public static void Initialize()
		{
			CommandSystem.Register("ManualReset", AccessLevel.Owner, new CommandEventHandler(ManualReset_OnCommand));
		}

		[Usage("ManualReset")]
		[Description("Manual Daily Reset Launcher")]
		public static void ManualReset_OnCommand(CommandEventArgs e)
		{
			DailyReset.DailyResetLauncher(false);
		}
	}
}

namespace Server.CustomScripts.Systems
{
	public class DailyReset
	{
		public static DateTime LastReset = DateTime.Now;

		public static void DailyResetLauncher(bool Auto)
		{
			if (Auto)
				Console.WriteLine("DailyResetLauncher (Date: {0})", DateTime.Now);
			else
				Console.WriteLine("ManualDailyResetLauncher (Date: {0})", DateTime.Now);

			ExperienceSystem.ResetAllTicks();

			LastReset = DateTime.Now;
		}

		public static void Initialize()
		{
			DateTime now = DateTime.Now;
			DateTime next = new DateTime(now.Year, now.Month, now.Day, 18, 0, 0);

			Console.WriteLine("DailyResetLauncher: now {0}", now);
			Console.WriteLine("DailyResetLauncher: next {0}", next);

			new ResetTimer(next - now).Start();

			if (LastReset.AddDays(1) < now)
			{
				Console.WriteLine("Daily Reset Now (Last Reset: {0})", LastReset.ToString());
				DailyResetLauncher(true);
			}
		}

		public class ResetTimer : Timer
		{
			public ResetTimer(TimeSpan delay)
				: base(delay, TimeSpan.FromDays(1))
			{
				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				DailyResetLauncher(true);
			}
		}
	}
}
