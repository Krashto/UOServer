using System;
using Server;
using Server.Commands;
using Server.Gumps;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Prompts;
using System.IO;

namespace JournalCommand
{
	public class CJournalGump : Gump
	{
		private Mobile m_From;
		private List<JournalEntry> m_JournalEntries;
		private List<JournalEntry> journalEntries;

		public CJournalGump(Mobile from, List<JournalEntry> journalEntries) : base(50, 50)
		{
			m_From = from;
			m_JournalEntries = journalEntries;
			Initialize();
		}

	//	public CJournalGump(List<JournalEntry> journalEntries) => this.journalEntries = journalEntries;

		private void Initialize()
		{
			AddPage(0);
			AddBackground(0, 0, 400, 400, 5054);

			AddHtml(30, 20, 340, 20, "<CENTER><BIG>Journal de la ville</BIG></CENTER>", false, false);

			AddHtml(30, 50, 340, 300, GetJournalEntries(), true, true);

			AddButton(30, 360, 120, 40, 0, GumpButtonType.Reply, 0, "Ajouter un article");
			AddButton(250, 360, 120, 40, 0, GumpButtonType.Reply, 0, "Fermer");
		}

		private void AddButton(int v1, int v2, int v3, int v4, int v5, GumpButtonType reply, int v6, string v7)
		{
			throw new NotImplementedException();
		}

		private string GetJournalEntries()
		{
			string html = "";

			foreach (JournalEntry entry in m_JournalEntries)
			{
				html += "<p>" + entry.Title + "<br>" + entry.Body + "<br><i>" + entry.Date.ToString() + "</i></p>";
			}

			return html;
		}

		public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
		{
			if (info.ButtonID == 0) // Ajouter un article
			{
				m_From.SendMessage("Entrez le titre de l'article :");
				m_From.Prompt = new AddJournalEntryPrompt(m_JournalEntries);
			}
		}
	}

	public class AddJournalEntryPrompt : Prompt
	{
		private List<JournalEntry> m_JournalEntries;

		public AddJournalEntryPrompt(List<JournalEntry> journalEntries)
		{
			m_JournalEntries = journalEntries;
		}

		public override void OnResponse(Mobile from, string text)
		{
			JournalEntry entry = new JournalEntry(text, DateTime.Now);

			m_JournalEntries.Add(entry);

			from.SendLocalizedMessage(501234); // "Votre article a été ajouté au journal."

			if (from is PlayerMobile)
			{
				PlayerMobile pm = (PlayerMobile)from;
				pm.CloseGump(typeof(CJournalGump));
				pm.SendGump(new CJournalGump(pm, m_JournalEntries));
			}
		}
	}

	public class JournalEntry
	{
		private string text;
		private DateTime now;

		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime Date { get; set; }

		public JournalEntry(string title, string body, DateTime date)
		{
			Title = title;
			Body = body;
			Date = date;
		}

		public JournalEntry(string text, DateTime now)
		{
			this.text = text;
			this.now = now;
		}
	}

	public class JournalCommand
	{
		public static void Initialize()
		{
			CommandSystem.Register("journal", AccessLevel.Player, new CommandEventHandler(OnJournalCommand));
		}

		[Usage("journal")]
		[Description("Ouvre le journal de la ville et permet de lire et d'ajouter des articles.")]
		private static void OnJournalCommand(CommandEventArgs e)
		{
			List<JournalEntry> journalEntries = new List<JournalEntry>();

			// Charger les articles existants à partir du fichier JSON
			string json = File.ReadAllText("journal.json");
			if (!string.IsNullOrEmpty(json))
			{
				//journalEntries = JsonConvert.DeserializeObject<List<JournalEntry>>(json);
			}

			// Créer un nouveau gump pour afficher le journal
			e.Mobile.CloseGump(typeof(CJournalGump));
	//		e.Mobile.SendGump(new CJournalGump(journalEntries));
		}
	}
}

