using Server.Mobiles;

namespace Server.Custom.PointsAncestraux
{
	public class FioleAncestrale : Item
	{
		public Mobile Owner { get; set; }

		[Constructable]
		public FioleAncestrale(Mobile owner) : base(0xE26)
		{
			Owner = owner;

			Name = "Fiole Ancestrale";
			Hue = 2575;
		}

		public FioleAncestrale(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!(from is CustomPlayerMobile pm))
				return;

			if (IsChildOf(from.Backpack))
			{
				from.SendMessage("La fiole doit être dans votre sac pour la boire.");
				return;
			}

			if (Owner != null && Owner != from)
			{
				from.SendMessage($"Seul {Owner.Name} peut boite cette fiole.");
				return;
			}

			var points = 1;
			pm.PointsAncestraux.AddPoints(points);
			pm.SendMessage($"Vous recevez {points} point{(points > 1 ? "s" : "")} ancestra{(points > 1 ? "ux" : "l")}");
			Delete();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version

			writer.Write(Owner);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			Owner = reader.ReadMobile();
		}
	}
}
