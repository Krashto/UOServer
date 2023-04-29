using System;
using Server.Commands;
using Server.Custom.Services;
using static Server.Custom.Services.DiscordService;

namespace Server.Custom.Commands
{
	class AutoDiscordMessageCommand
	{
		public static void Initialize()
		{
			CommandSystem.Register("PlayerCount", AccessLevel.Owner, new CommandEventHandler(PlayerCount_OnCommand));
		}

		[Usage("PlayerCount")]
		[Description("Send Player Count to discord")]
		public static void PlayerCount_OnCommand(CommandEventArgs e)
		{
			AutoDiscordMessage.PlayerCountMessage();
		}
	}
}

namespace Server.Custom.Services
{
	public class AutoDiscordMessage
	{
		private static bool Enabled => true;

		public static DateTime LastReset = DateTime.Now;
		private static TimeSpan PlayerCountMessageDelay => TimeSpan.FromMinutes(30);
		
		public static void Initialize()
		{
			if (Enabled)
			{
				new PlayerCountMessageTimer().Start();
			}
		}

		public static void PlayerCountMessage()
		{
			SendMessage(DiscordMessageType.Status, $"Il y a présentement {10} joueurs connectés.");

			LastReset = DateTime.Now;
		}

		public class PlayerCountMessageTimer : Timer
		{
			public PlayerCountMessageTimer() : base(TimeSpan.FromMinutes(1), PlayerCountMessageDelay)
			{
				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				PlayerCountMessage();
			}
		}
	}
}

