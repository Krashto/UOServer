namespace Server.Items
{
   
    public class WoodenShield : BaseShield
    {
        public override bool IsArtifact => true;
        [Constructable]
        public WoodenShield()
            : base(0x4200)
        {
            Weight = 5.0;
        }

        public WoodenShield(Serial serial)
            : base(serial)
        {
        }

        public override int BasePhysicalResistance => 2;
        public override int BaseFireResistance => 0;
        public override int BaseColdResistance => 0;
        public override int BasePoisonResistance => 0;
        public override int BaseEnergyResistance => 1;
        public override int InitMinHits => 20;
        public override int InitMaxHits => 25;
        public override int StrReq => 20;

		public override ArmorMaterialType MaterialType => ArmorMaterialType.Leather;

		public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);//version
        }
    }
}
