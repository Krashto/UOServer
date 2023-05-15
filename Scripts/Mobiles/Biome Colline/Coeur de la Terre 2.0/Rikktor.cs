using Server.Engines.CannedEvil;
using Server.Items;
using System;
using System.Collections;

namespace Server.Mobiles
{

	[CorpseName("Le Corps de Rikktor")]
	public class Rikktor : BaseCreature
    {
        [Constructable]
        public Rikktor()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
            Body = 172;
            Name = "Rikktor";

			SetStr(199, 355);
			SetDex(132, 220);
			SetInt(110, 177);

			SetHits(5258, 7992);

			SetDamage(26, 45);

			SetDamageType(ResistanceType.Physical, 100);
			

			SetResistance(ResistanceType.Physical, 80, 90);
			SetResistance(ResistanceType.Fire, 80, 90);
			SetResistance(ResistanceType.Cold, 80, 90);
			SetResistance(ResistanceType.Poison, 80, 90);
			SetResistance(ResistanceType.Energy, 80, 90);

			SetSkill(SkillName.EvalInt, 75.1, 100.0);
			SetSkill(SkillName.Magery, 75.1, 100.0);
			SetSkill(SkillName.Meditation, 75.1, 100.0);

			SetSkill(SkillName.MagicResist, 75.1, 100.0);
			SetSkill(SkillName.Tactics, 75.1, 100.0);
			SetSkill(SkillName.Wrestling, 75.1, 100.0);
        }

        public Rikktor(Serial serial)
            : base(serial)
        {
        }
     
        public override Poison PoisonImmune => Poison.Lethal;
		public override int Level => 17;
		public override Biome Biome => Biome.Colline;
		public override int Hides => 12;
		public override HideType HideType => HideType.Dragonique;

		public override int Bones => 12;
		public override BoneType BoneType => BoneType.Dragonique;

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (0.2 >= Utility.RandomDouble())
                Earthquake();
        }

        public void Earthquake()
        {
            Map map = Map;

            if (map == null)
                return;

            ArrayList targets = new ArrayList();

            IPooledEnumerable eable = GetMobilesInRange(8);

            foreach (Mobile m in eable)
            {
                if (m == this || !CanBeHarmful(m))
                    continue;

                if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != Team))
                    targets.Add(m);
                else if (m.Player)
                    targets.Add(m);
            }

            eable.Free();

            PlaySound(0x2F3);

            for (int i = 0; i < targets.Count; ++i)
            {
                Mobile m = (Mobile)targets[i];

                double damage = m.Hits * 0.6;

                if (damage < 10.0)
                    damage = 10.0;
                else if (damage > 75.0)
                    damage = 75.0;

                DoHarmful(m);

                AOS.Damage(m, this, (int)damage, 100, 0, 0, 0, 0);

                if (m.Alive && m.Body.IsHuman && !m.Mounted)
                    m.Animate(20, 7, 1, true, false, 0); // take hit
            }
        }

        public override int GetAngerSound()
        {
            return Utility.Random(0x2CE, 2);
        }

        public override int GetIdleSound()
        {
            return 0x2D2;
        }

        public override int GetAttackSound()
        {
            return Utility.Random(0x2C7, 5);
        }

        public override int GetHurtSound()
        {
            return 0x2D1;
        }

        public override int GetDeathSound()
        {
            return 0x2CC;
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
