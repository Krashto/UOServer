using System;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Ecraseur : Item
	{
		[Constructable]
		public Ecraseur() : base(4787)
		{
			Name = "Écraseur";
			Weight = 1.0;
		}

		public Ecraseur(Serial serial)
			: base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (IsChildOf(from.Backpack))
			{
				from.SendMessage("Que voulez-vous écraser?");
				from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(OnTarget));
			}
			else
			{
				from.SendMessage("L'objet doit être dans votre sac pour être utilisé.");
			}
		}

		private void OnTarget(Mobile from, object o)
		{
			if (o is BaseShell)
			{
				BaseShell shell = (BaseShell)o;

				int alchemySkill = from.Skills.Alchemy.BaseFixedPoint;
				int powderAmount = 1; // Quantité par défaut de poudre de coquillages

				if (alchemySkill >= 25 && alchemySkill < 50)
				{
					powderAmount = 2;
				}
				else if (alchemySkill >= 50 && alchemySkill < 75)
				{
					powderAmount = 3;
				}
				else if (alchemySkill >= 75 && alchemySkill < 100)
				{
					powderAmount = 4;
				}
				else if (alchemySkill >= 100)
				{
					powderAmount = 5;
				}
				else
				{
					from.SendMessage("Votre compétence en alchimie n'est pas suffisamment élevée.");
				}
				shell.Delete();
				from.AddToBackpack(new PoudreCoquillages(powderAmount));
			}
			else
			{
				from.SendMessage("Vous ne pouvez écraser cela.");
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
