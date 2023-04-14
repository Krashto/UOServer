using Server.Items;
using Server.Targeting;

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
			from.BeginTarget(12, false, TargetFlags.None, new TargetStateCallback(ApplyPotionOnBaseArmor_OnTarget), new object[] { SetType });
		}

		public static void ApplyPotionOnBaseArmor_OnTarget(Mobile from, object targeted, object state)
		{
			if (targeted is BaseArmor armor)
			{
				object[] states = (object[])state;
				armor.SetAptitudeType = (SetAptitudeType)states[0];
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
	}
}
