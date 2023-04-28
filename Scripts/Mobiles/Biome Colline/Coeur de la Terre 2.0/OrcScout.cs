#region References
using Server.Items;
using Server.Misc;
using Server.Targeting;
#endregion

namespace Server.Mobiles
{
	[CorpseName("Le Corps d'un Orc")]
	public class OrcScout : BaseCreature
    {
        public override double HealChance => 1.0;

        [Constructable]
        public OrcScout()
            : base(AIType.AI_OrcScout, FightMode.Closest, 10, 7, 0.2, 0.4)
        {
            Name = " orc Scout";
            Body = 0xB5;
            BaseSoundID = 0x45A;
			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(323, 491);

			SetDamage(30, 51);

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


			if (0.1 > Utility.RandomDouble())
            {
                AddItem(new OrcishBow());
            }
            else
            {
                AddItem(new Bow());
            }
        }

        public OrcScout(Serial serial)
            : base(serial)
        { }
		public override int Level => 7;
		public override Biome Biome => Biome.Colline;
		public override bool CanRummageCorpses => true;
        public override bool CanStealth => true;
        public override int Meat => 1;

        public override InhumanSpeech SpeechType => InhumanSpeech.Orc;
        public override TribeType Tribe => TribeType.Orc;
        public override void GenerateLoot()

        {
            AddLoot(LootPack.Rich);
            AddLoot(LootPack.LootItem<Yeast>(50.0));
            AddLoot(LootPack.LootItem<Apple>(3, 5));
            AddLoot(LootPack.LootItem<Arrow>(15, 28));
            AddLoot(LootPack.LootItem<Bandage>(1, 15));
        }

        public override bool IsEnemy(Mobile m)
        {
            if (m.Player && m.FindItemOnLayer(Layer.Helm) is OrcishKinMask)
            {
                return false;
            }

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

        public override void OnThink()
        {
            if (Utility.RandomDouble() < 0.2)
            {
                TryToDetectHidden();
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

        private Mobile FindTarget()
        {
            IPooledEnumerable eable = GetMobilesInRange(10);
            foreach (Mobile m in eable)
            {
                if (m.Player && m.Hidden && m.IsPlayer())
                {
                    eable.Free();
                    return m;
                }
            }

            eable.Free();
            return null;
        }

        private void TryToDetectHidden()
        {
            Mobile m = FindTarget();

            if (m != null)
            {
                if (Core.TickCount >= NextSkillTime && UseSkill(SkillName.DetectHidden))
                {
                    Target targ = Target;

                    if (targ != null)
                    {
                        targ.Invoke(this, this);
                    }

                    Effects.PlaySound(Location, Map, 0x340);
                }
            }
        }
    }
}
