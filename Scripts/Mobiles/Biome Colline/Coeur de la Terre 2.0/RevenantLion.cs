using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un revenant")]
    public class RevenantLion : BaseCreature
    {
        [Constructable]
        public RevenantLion()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Un Revenant";
            Body = 251;

			SetDamageType(ResistanceType.Physical, 100);


			SetResistance(ResistanceType.Physical, 50, 60);
			SetResistance(ResistanceType.Fire, 50, 60);
			SetResistance(ResistanceType.Cold, 50, 60);
			SetResistance(ResistanceType.Poison, 50, 60);
			SetResistance(ResistanceType.Energy, 50, 60);

			SetSkill(SkillName.EvalInt, 50.1, 55.0);
			SetSkill(SkillName.Magery, 50.1, 55.0);
			SetSkill(SkillName.Meditation, 50.1, 55.0);


			SetSkill(SkillName.MagicResist, 35.1, 55.0);
			SetSkill(SkillName.Tactics, 50.1, 55.0);
			SetSkill(SkillName.Wrestling, 50.1, 55.0);

			SetWeaponAbility(WeaponAbility.BleedAttack);
        }

        public RevenantLion(Serial serial)
            : base(serial)
        {
        }

        public override bool BleedImmune => true;
        public override Poison PoisonImmune => Poison.Greater;
        public override Poison HitPoison => Poison.Greater;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich, 2);
            AddLoot(LootPack.MedScrolls, 2);
            AddLoot(LootPack.NecroRegs, 6, 8);
            AddLoot(LootPack.BodyPartsAndBones);
        }

        public override int GetAngerSound()
        {
            return 0x518;
        }

        public override int GetIdleSound()
        {
            return 0x517;
        }

        public override int GetAttackSound()
        {
            return 0x516;
        }

        public override int GetHurtSound()
        {
            return 0x519;
        }

        public override int GetDeathSound()
        {
            return 0x515;
        }

        public override int TreasureMapLevel => 3;

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
