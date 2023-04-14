using Server.Mobiles;

namespace Server.Custom.PointsAncestraux
{
	public class FioleAncestrale : Item
	{
		[Constructable]
		public FioleAncestrale() : base(0xE26)
		{
			Name = "Fiole Ancestrale";
			Hue = 2575;
		}

		public FioleAncestrale(Serial serial) : base(serial)
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (from is CustomPlayerMobile pm)
			{
				var points = 1;
				pm.PointsAncestraux.AddPoints(points);
				pm.SendMessage($"Vous recevez {points} point{(points > 1 ? "s" : "")} ancestra{(points > 1 ? "ux" : "l")}");
				Delete();
			}
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
	}
}
