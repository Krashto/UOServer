using System.Linq;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Spells;

namespace Server.Scripts.Commands
{
	public class SpellCommands
	{
		public static void Initialize()
		{
			CommandSystem.Register("Aeromancie", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Chasseur", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Defenseur", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Geomancie", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Guerison", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Hydromancie", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Martial", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Musique", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Necromancie", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Polymorphie", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Pyromancie", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Roublardise", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
			CommandSystem.Register("Totemique", AccessLevel.Player, new CommandEventHandler(CastSpell_OnCommand));
		}

		public static void CastSpell_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			if (e.Length != 1)
			{
				from.SendMessage("Utilisation : NomEcoleMagie <ID> (Ex: .Aeromancie 4)");
				return;
			}

			var spellId = e.GetInt32(0);

			if (spellId < 1 || spellId > 10)
			{
				from.SendMessage("Le numéro du sort doit être compris entre 1 et 10, représentant le niveau du sort dans l'école de magie.");
				return;
			}

			int offset = 0;

			if (e.Command.ToLower().Contains("aeromancie"))
				offset = 600;
			else if (e.Command.ToLower().Contains("chasseur"))
				offset = 610;
			else if (e.Command.ToLower().Contains("defenseur"))
				offset = 620;
			else if (e.Command.ToLower().Contains("geomancie"))
				offset = 630;
			else if (e.Command.ToLower().Contains("guerison"))
				offset = 640;
			else if (e.Command.ToLower().Contains("hydromancie"))
				offset = 650;
			else if (e.Command.ToLower().Contains("martial"))
				offset = 660;
			else if (e.Command.ToLower().Contains("musique"))
				offset = 670;
			else if (e.Command.ToLower().Contains("necromancie"))
				offset = 680;
			else if (e.Command.ToLower().Contains("polymorphie"))
				offset = 690;
			else if (e.Command.ToLower().Contains("pyromancie"))
				offset = 700;
			else if (e.Command.ToLower().Contains("roublardise"))
				offset = 710;
			else if (e.Command.ToLower().Contains("totemique"))
				offset = 720;

			if (offset == 0)
			{
				from.SendMessage("Sort introuvable.");
				return;
			}

			CastSpell(from, offset, spellId);
		}

		public static void CastSpell(Mobile from, int offset, int id)
		{
			if (from is CustomPlayerMobile pm)
			{
				var items = pm.Backpack.FindItemsByType(typeof(NewSpellbook)).ToList();

				var equippedSpellBook = pm.FindItemOnLayer(Layer.OneHanded);

				if (equippedSpellBook is NewSpellbook eqb1)
					items.Add(eqb1);

				equippedSpellBook = pm.FindItemOnLayer(Layer.TwoHanded);

				if (equippedSpellBook is NewSpellbook eqb2)
					items.Add(eqb2);

				var foundSpell = false;
				var spellId = offset + id - 1;

				foreach (var item in items)
				{
					var spellbook = item as NewSpellbook;
					
					if (spellbook == null)
						continue;

					if (spellbook.HasSpell(spellId))
					{
						foundSpell = true;
						break;
					}
				}

				if (!foundSpell)
				{
					pm.SendMessage("Ancun grimoire contenant ce sort n'a été trouvé dans vos mains ou dans votre sac.");
					return;
				}

				Spell spell = SpellRegistry.NewSpell(spellId, from, null);
				spell.Cast();
			}
		}
	}
}