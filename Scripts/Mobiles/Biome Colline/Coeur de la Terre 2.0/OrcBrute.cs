using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Orc")]
    public class OrcBrute : BaseCreature
    {
        [Constructable]
        public OrcBrute()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Body = 189;

            Name = "un Orc Brute";
            BaseSoundID = 0x45A;

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(1738, 2642);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Physical, 100);
			

			SetResistance(ResistanceType.Physical, 60, 70);
			SetResistance(ResistanceType.Fire, 60, 70);
			SetResistance(ResistanceType.Cold, 60, 70);
			SetResistance(ResistanceType.Poison, 60, 70);
			SetResistance(ResistanceType.Energy, 60, 70);

			SetSkill(SkillName.EvalInt, 55.1, 65.0);
			SetSkill(SkillName.Magery, 55.1, 65.0);
			SetSkill(SkillName.Meditation, 55.1, 65.0);


			SetSkill(SkillName.MagicResist, 45.1, 60.0);
			SetSkill(SkillName.Tactics, 55.1, 65.0);
			SetSkill(SkillName.Wrestling, 55.1, 65.0);

		}

		public OrcBrute(Serial serial)
            : base(serial)
        {
        }
		public override int Level => 12;
		public override Biome Biome => Biome.Colline;
		public override Poison PoisonImmune => Poison.Lethal;
        public override int Meat => 2;

        public override TribeType Tribe => TribeType.Orc;

        public override bool CanRummageCorpses => true;
        public override bool AutoDispel => true;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich);
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.LootItem<Yeast>());
        }

        public override bool IsEnemy(Mobile m)
        {
            if (m.Player && m.FindItemOnLayer(Layer.Helm) is OrcishKinMask)
                return false;

            return base.IsEnemy(m);
        }

        public override void AggressiveAction(Mobile aggressor, bool criminal)
        {
            base.AggressiveAction(aggressor, criminal);

            Item item = aggressor.FindItemOnLayer(Layer.Helm);

            if (item is OrcishKinMask)
            {
                AOS.Damage(aggressor, 50, 0, 100, 0, 0, 0);
                item.Delete();
                aggressor.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
                aggressor.PlaySound(0x307);
            }
        }

        public override int Damage(int amount, Mobile from, bool informMount, bool checkDisrupt)
        {
            int damage = base.Damage(amount, from, informMount, checkDisrupt);

            if (from != null && from != this && !Controlled && !Summoned && Utility.RandomDouble() <= 0.2)
            {
                SpawnOrcLord(from);
            }

            return damage;
        }

        public void SpawnOrcLord(Mobile target)
        {
            Map map = target.Map;

            if (map == null)
                return;

            int orcs = 0;
            IPooledEnumerable eable = GetMobilesInRange(10);

            foreach (Mobile m in eable)
            {
                if (m is OrcishLord)
                    ++orcs;
            }

            eable.Free();

            if (orcs < 10)
            {
                BaseCreature orc = new SpawnedOrcishLord
                {
                    Team = Team
                };

                Point3D loc = target.Location;
                bool validLocation = false;

                for (int j = 0; !validLocation && j < 10; ++j)
                {
                    int x = target.X + Utility.Random(3) - 1;
                    int y = target.Y + Utility.Random(3) - 1;
                    int z = map.GetAverageZ(x, y);

                    if (validLocation = map.CanFit(x, y, Z, 16, false, false))
                        loc = new Point3D(x, y, Z);
                    else if (validLocation = map.CanFit(x, y, z, 16, false, false))
                        loc = new Point3D(x, y, z);
                }

                orc.MoveToWorld(loc, map);

                orc.Combatant = target;
            }
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
