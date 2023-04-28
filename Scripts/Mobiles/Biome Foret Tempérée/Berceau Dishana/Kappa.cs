using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Kappa")]
    public class Kappa : BaseCreature
    {
        [Constructable]
        public Kappa()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = " Kappa";
            Body = 240;

			SetStr(173, 269);
			SetDex(115, 192);
			SetInt(96, 154);

			SetHits(165, 251);

			SetDamage(23, 39);

			SetDamageType(ResistanceType.Energy, 50);
			SetDamageType(ResistanceType.Poison, 50);


			SetResistance(ResistanceType.Physical, 25, 25);
			SetResistance(ResistanceType.Fire, 25, 25);
			SetResistance(ResistanceType.Cold, 75, 75);
			SetResistance(ResistanceType.Poison, 75, 75);
			SetResistance(ResistanceType.Energy, 75, 75);

			SetSkill(SkillName.EvalInt, 35.1, 50.0);
			SetSkill(SkillName.Magery, 35.1, 50.0);
			SetSkill(SkillName.Meditation, 35.1, 50.0);

			SetSkill(SkillName.MagicResist, 35.1, 50.0);
			SetSkill(SkillName.Tactics, 35.1, 50.0);
			SetSkill(SkillName.Wrestling, 35.1, 50.0);


			SetSpecialAbility(SpecialAbility.LifeLeech);
        }

        public Kappa(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 5;
		public override Biome Biome => Biome.Foret;
		public override int TreasureMapLevel => 2;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
            AddLoot(LootPack.Average);
            AddLoot(LootPack.LootItem<RawFishSteak>(3, true));
            AddLoot(LootPack.RandomLootItem(new [] { typeof(Gears), typeof(Hinge), typeof(Axle) }, 50.0, 1));
        }

        public override int GetAngerSound()
        {
            return 0x50B;
        }

        public override int GetIdleSound()
        {
            return 0x50A;
        }

        public override int GetAttackSound()
        {
            return 0x509;
        }

        public override int GetHurtSound()
        {
            return 0x50C;
        }

        public override int GetDeathSound()
        {
            return 0x508;
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (from != null && from.Map != null)
            {
                int amt = 0;
                Mobile target = this;
                int rand = Utility.Random(1, 100);
                if (willKill)
                {
                    amt = (((rand % 5) >> 2) + 3);
                }
                if ((Hits < 100) && (rand < 21))
                {
                    target = (rand % 2) < 1 ? this : from;
                    amt++;
                }
                if (amt > 0)
                {
                    SpillAcid(target, amt);
                    from.SendLocalizedMessage(1070820);

                    if (Mana > 14)
                        Mana -= 15;
                }
            }
            base.OnDamage(amount, from, willKill);
        }

        public override Item NewHarmfulItem()
        {
            return new AcidSlime(TimeSpan.FromSeconds(10), 5, 10);
        }

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
