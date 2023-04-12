namespace Server.Items
{
    public class LesserHealPotion : BaseHealPotion
    {
        [Constructable]
        public LesserHealPotion()
            : base(PotionEffect.HealLesser)
        {
			Name = "Potion de soin mineure";
		}

		public LesserHealPotion(Serial serial)
            : base(serial)
        {
        }

        public override int MinHeal => 10;
        public override int MaxHeal => 10;
        public override double Delay => 4.0;
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
