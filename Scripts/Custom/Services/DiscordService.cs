using System;
using System.Threading.Tasks;
using Discord.Webhook;

namespace Server.Custom.Services
{
	public class DiscordService
	{
		public enum DiscordMessageType
		{
			News,
			Status,
			Staff
		}
		public static void Initialize()
		{
			if (m_NewsClient == null)
				m_NewsClient = new DiscordWebhookClient(m_NewsWebHookLink);
			if (m_StatusClient == null)
				m_StatusClient = new DiscordWebhookClient(m_StatusWebHookLink);
			if (m_StaffClient == null)
				m_StaffClient = new DiscordWebhookClient(m_StaffWebHookLink);
		}

		public static void Configure()
		{
			EventSink.ServerStarted += ServerStarted;
			EventSink.Shutdown += Shutdown;
			EventSink.Crashed += Crashed;
		}

		private static void ServerStarted()
		{
			SendMessage(DiscordMessageType.Status, "Le serveur a démarré.");
		}

		private static void Shutdown(ShutdownEventArgs e)
		{
			SendMessage(DiscordMessageType.Status, "Le serveur a fermé.");
		}

		private static void Crashed(CrashedEventArgs e)
		{
			SendMessage(DiscordMessageType.Status, "Le serveur a fermé.");
		}
		
		public static bool IsMainServer => Environment.MachineName == "BUREAU" && SocketOptions.Port == 2593;

		private static string m_NewsWebHookLink => "https://discord.com/api/webhooks/1109157266403369012/b3Z9VA3MesBBL5NhhGtZafDNcKD57rrq_eRBEqCrNtYtG8hNQqw7OdrmUhfifYLahTHe";
		private static string m_StatusWebHookLink => "https://discord.com/api/webhooks/1101125982011785346/9TfIC7xzC-FimBXd8m3DKdcGr3SpgE6ug9AXyfEM2HWFAQnOiCDg2HRjVcjl6snEygLi";
		private static string m_StaffWebHookLink => "https://discord.com/api/webhooks/1109153730483454092/IY9U_sx-ZDx8fBBGiZDSme-dNzaS9n3pOwhOpzv5uwKKTWbSZvk-DlwXlN4hMZCsOSDW";

		private static DiscordWebhookClient m_NewsClient;
		private static DiscordWebhookClient m_StatusClient;
		private static DiscordWebhookClient m_StaffClient;
		public static void SendMessage(DiscordMessageType type, string message)
		{
			if (!IsMainServer)
				return;

			switch(type)
			{
				case DiscordMessageType.News: 
					{
						if (m_NewsClient != null)
							Task.Run(() => m_NewsClient.SendMessageAsync(message)).Wait();
						break; 
					}
				case DiscordMessageType.Status:
					{
						if (m_StatusClient != null)
							Task.Run(() => m_StatusClient.SendMessageAsync(message)).Wait();
						break;
					}
				case DiscordMessageType.Staff:
					{
						if (m_StaffClient != null)
							Task.Run(() => m_StaffClient.SendMessageAsync(message)).Wait();
						break;
					}
			}
			
		}
	}
}
