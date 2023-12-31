using Server.Engines.Craft;

namespace Server.Items
{
    public class EmbroideredOakLeafCloak : BaseOuterTorso, IRepairable
    {
        public CraftSystem RepairSystem => DefTailoring.CraftSystem;

        public override bool IsArtifact => true;
        [Constructable]
        public EmbroideredOakLeafCloak()
            : base(0x2684)
        {
            Hue = 0x483;
            StrRequirement = 0;
            SkillBonuses.Skill_1_Name = SkillName.Hiding;
            SkillBonuses.Skill_1_Value = 5;
        }

        public EmbroideredOakLeafCloak(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber => 1094901;// Embroidered Oak Leaf Cloak [Replica]
        public override int InitMinHits => 150;
        public override int InitMaxHits => 150;
        public override bool CanFortify => false;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}