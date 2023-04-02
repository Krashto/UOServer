using Server.Items;
using Server.Network;
using System;

namespace Server.Mobiles
{
    [CorpseName("Le corps d'un fourifeu")]
    public class RedSolenWarrior : BaseCreature, IRedSolen
    {
        private bool m_BurstSac;
        [Constructable]
        public RedSolenWarrior()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Un Guerrier Fourifeu";
            Body = 782;
            BaseSoundID = 959;

            SetStr(196, 220);
            SetDex(101, 125);
            SetInt(36, 60);

            SetHits(96, 107);

            SetDamage(5, 15);

            SetDamageType(ResistanceType.Physical, 80);
            SetDamageType(ResistanceType.Poison, 20);

            SetResistance(ResistanceType.Physical, 20, 35);
            SetResistance(ResistanceType.Fire, 20, 35);
            SetResistance(ResistanceType.Cold, 10, 25);
            SetResistance(ResistanceType.Poison, 20, 35);
            SetResistance(ResistanceType.Energy, 10, 25);

            SetSkill(SkillName.MagicResist, 60.0);
            SetSkill(SkillName.Tactics, 80.0);
            SetSkill(SkillName.Wrestling, 80.0);

            Fame = 3000;
            Karma = -3000;
        }
		public override int Level => 7;
		public override Biome Biome => Biome.Savane;
		public override int Hides => 7;
		public override HideType HideType => HideType.Arachnide;


		public override int Bones => 7;
		public override BoneType BoneType => BoneType.Arachnide;

		public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
        }

        public RedSolenWarrior(Serial serial)
            : base(serial)
        {
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {

            if (attacker.Weapon is BaseRanged)

                BeginAcidBreath();

            base.OnGotMeleeAttack(attacker);
        }

        public override void OnDamagedBySpell(Mobile attacker)
        {
            base.OnDamagedBySpell(attacker);

            BeginAcidBreath();
        }

        #region Acid Breath
        private DateTime m_NextAcidBreath;

        public void BeginAcidBreath()
        {
            PlayerMobile m = Combatant as PlayerMobile;
            // Mobile m = Combatant;

            if (m == null || m.Deleted || !m.Alive || !Alive || m_NextAcidBreath > DateTime.Now || !CanBeHarmful(m))
                return;

            PlaySound(0x118);
            MovingEffect(m, 0x36D4, 1, 0, false, false, 0x3F, 0);

            TimeSpan delay = TimeSpan.FromSeconds(GetDistanceToSqrt(m) / 5.0);
            Timer.DelayCall<Mobile>(delay, EndAcidBreath, m);

            m_NextAcidBreath = DateTime.Now + TimeSpan.FromSeconds(5);
        }

        public void EndAcidBreath(Mobile m)
        {
            if (m == null || m.Deleted || !m.Alive || !Alive)
                return;

            if (0.2 >= Utility.RandomDouble())
                m.ApplyPoison(this, Poison.Greater);

            AOS.Damage(m, Utility.RandomMinMax(100, 120), 0, 0, 0, 100, 0);
        }
        #endregion

        public bool BurstSac => m_BurstSac;
        public override int GetAngerSound()
        {
            return 0xB5;
        }

        public override int GetIdleSound()
        {
            return 0xB5;
        }

        public override int GetAttackSound()
        {
            return 0x289;
        }

        public override int GetHurtSound()
        {
            return 0xBC;
        }

        public override int GetDeathSound()
        {
            return 0xE4;
        }

        public override bool IsEnemy(Mobile m)
        {
            if (SolenHelper.CheckRedFriendship(m))
                return false;
            else
                return base.IsEnemy(m);
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            SolenHelper.OnRedDamage(from);

            if (!willKill)
            {
                if (!BurstSac)
                {
                    if (Hits < 50)
                    {
                        PublicOverheadMessage(MessageType.Regular, 0x3B2, true, "* The solen's acid sac is burst open! *");
                        m_BurstSac = true;
                    }
                }
                else if (from != null && from != this && InRange(from, 1))
                {
                    SpillAcid(from, 1);
                }
            }

            base.OnDamage(amount, from, willKill);
        }

        public override bool OnBeforeDeath()
        {
            SpillAcid(4);

            return base.OnBeforeDeath();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
            writer.Write(m_BurstSac);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_BurstSac = reader.ReadBool();
                        break;
                    }
            }
        }
    }
}