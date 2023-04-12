namespace Server.Items
{
    public class HealPotion : BaseHealPotion
    {
        [Constructable]
        public HealPotion() : base(PotionEffect.Heal)
        {
			Name = "Potion de soin";
		}

		public HealPotion(Serial serial)
            : base(serial)
        {
        }

        public override int MinHeal => 25;
        public override int MaxHeal => 25;
        public override double Delay => 6.0;
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
