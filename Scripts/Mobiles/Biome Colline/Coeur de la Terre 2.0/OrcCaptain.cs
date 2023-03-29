using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName("Le Corps d'un Orc")]
	public class OrcCaptain : BaseCreature
    {
        [Constructable]
        public OrcCaptain()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
			Name = "Un Orc Capitaine";
            Body = 7;
            BaseSoundID = 0x45A;

			SetStr(229, 408);
			SetDex(151, 253);
			SetInt(126, 203);

			SetHits(633, 963);

			SetDamage(40, 67);

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

		}

		public OrcCaptain(Serial serial)
            : base(serial)
        {
        }

        public override InhumanSpeech SpeechType => InhumanSpeech.Orc;
        public override bool CanRummageCorpses => true;
        public override int Meat => 1;

        public override TribeType Tribe => TribeType.Orc;

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager, 2);
            AddLoot(LootPack.LootItem<Yeast>(50.0));
            AddLoot(LootPack.LootItem<StoutWhip>(5.0));
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
