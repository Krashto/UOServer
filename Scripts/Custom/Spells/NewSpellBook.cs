using System.Collections;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable(0xEFA, 0x2253, 0x2252, 0x2254, 0x238C, 0x23A0, 0x225A, 0x2D50, 0x2D9D)]
	public class NewSpellbook : Spellbook
	{
		public override SpellbookType SpellbookType{ get{ return SpellbookType.Regular; } }
		public override int BookOffset{ get{ return 600; } }
		public override int BookCount{ get{ return 200; } }

		public ArrayList Contents = new ArrayList();

		[Constructable]
		public NewSpellbook() : this((ulong)0, 0xEFA)
		{
		}

		[Constructable]
		public NewSpellbook(ulong content, int itemid)
			: base(content, itemid)
		{
			Name = "Grimoire";
			Layer = Layer.OneHanded;
		}

		public override bool OnEquip(Mobile from)
		{
			if (from is CustomPlayerMobile pm)
				pm.ChosenSpellbook = this;

			return base.OnEquip(from);
		}

		public override void OnRemoved(object parent)
		{
			if (parent is CustomPlayerMobile pm)
				pm.ChosenSpellbook = null;

			base.OnRemoved(parent);
		}

		public override void OnDoubleClick( Mobile from )
		{
			Container pack = from.Backpack;

			if ( Parent == from || (pack != null && Parent == pack))
			{
				from.CloseGump( typeof( NewSpellbookGump ) );
				from.SendGump( new NewSpellbookGump( from, this, 0 ) );
			}
			else
			{
				from.SendMessage("Le grimoire doit �tre dans votre sac principal pour l'ouvrir.");
			}
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (dropped is SpellScroll && dropped.Amount == 1)
			{
				SpellScroll scroll = (SpellScroll)dropped;

				if (HasSpell(scroll.SpellID))
				{
					from.SendLocalizedMessage(500179); // That spell is already present in that spellbook.
					return false;
				}
				else
				{
					int val = scroll.SpellID;

					if (val >= 600)
					{
						Contents.Add(val);

						scroll.Delete();

						from.Send(new PlaySound(0x249, GetWorldLocation()));
						return true;
					}

					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public override bool HasSpell(int spellID)
		{
			return Contents.Contains(spellID);
		}

		public NewSpellbook(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version
			
			//Version 2: Remove Resource, transfered to Spellbook.cs

			//Version 1
			//writer.Write((int)Resource);

			//Version 0
			writer.Write(Contents.Count);
			for (int i = 0; i < Contents.Count; i++)
			{
				int spellID = (int)Contents[i];
				writer.Write(spellID);
			}
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch(version)
			{
				case 2:
					{
						goto case 0;
					}
				case 1:
					{
						Resource = (CraftResource)reader.ReadInt();

						goto case 0;
					}
				case 0:
					{
						int count = reader.ReadInt();
						for (int i = 0; i < count; i++)
						{
							Contents.Add(reader.ReadInt());
						}
						break;
					}
			}
		}
	}
}
