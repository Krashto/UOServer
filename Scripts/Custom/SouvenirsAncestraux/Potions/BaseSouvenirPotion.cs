using Server.Gumps;
using Server.Targeting;
using static Server.Custom.SouvenirsAncestraux.NewSetSystem;
using Server.Network;
using Server.Items;

namespace Server.Custom.Items.SouvenirsAncestraux.Souvenirs
{
	public abstract class BaseSouvenirPotion : Item
	{
		public virtual SetAptitudeType SetType { get; set; }

		public BaseSouvenirPotion() : base(0x1832)
		{
		}

		public BaseSouvenirPotion(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			from.SendMessage("Sur quelle pièce d'armure voulez-vous appliquer cette potion ?");

			from.BeginTarget(12, false, TargetFlags.None, new TargetStateCallback(ApplyPotionOnNewItemSet), new object[] { this, SetType, Hue });
		}

		public static void ApplyPotionOnNewItemSet(Mobile from, object targeted, object state)
		{
			if (targeted is INewSetItem item)
			{
				object[] states = (object[])state;
				var potion = (BaseSouvenirPotion)states[0];
				potion.Delete();
				item.SetAptitudeType = (SetAptitudeType)states[1];
				item.SetHue = (int)states[2];
				from.SendGump(new ApplySouvenirAcceptGump(from, item));
			}
			else
				from.SendMessage("Vous devez cibler une pièce d'armure.");
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		public class ApplySouvenirAcceptGump : BaseProjectMGump
		{
			private readonly INewSetItem m_Item;
			private readonly Mobile m_From;
			public ApplySouvenirAcceptGump(Mobile from, INewSetItem item) : base("Confirmation", 450, 175, false)
			{
				m_From = from;
				m_Item = item;

				m_From.CloseGump(typeof(ApplySouvenirAcceptGump));

				AddPage(0);

				int y = 100;
				int line = 0;
				int lineSpace = 25;

				AddSection(100, y + lineSpace * line++, 425, 150, "Confirmation");
				line++;

				AddHtmlTexte(100, y + lineSpace * line++, 425, 20, "<CENTER>Voulez-vous teindre votre armure</CENTER>");
				AddHtmlTexte(100, y + lineSpace * line++, 425, 20, "<CENTER>de la couleur du set ?</CENTER>");

				AddButton(150, y + lineSpace * line, 4005, 4007, 1, GumpButtonType.Reply, 0);
				AddHtmlTexte(185, y + lineSpace * line, 200, 20, "Couleur du set");

				AddButton(300, y + lineSpace * line, 4005, 4007, 0, GumpButtonType.Reply, 0);
				AddHtmlTexte(335, y + lineSpace * line, 200, 20, "Couleur de la ressource");
			}

			public override void OnResponse(NetState sender, RelayInfo info)
			{
				if (info.ButtonID == 1)
				{
					if (m_Item is Item item)
						item.Hue = m_Item.SetHue;
				}
				else
				{
					if (m_Item is BaseArmor armor)
						armor.Hue = CraftResources.GetHue(armor.Resource);
				}
			}
		}
	}
}
