using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Custom;
using Server.Spells.OldSpells;
using Server.Custom.Aptitudes;
using Server.Custom.Spells.NewSpells.Geomancie;
using Server.Custom.Spells.NewSpells.Defenseur;
using Server.Custom.Capacites;
using Server.Custom.Classes;
using System.Linq;
using Server.Custom.Spells.NewSpells.Guerison;
using Server.Custom.Spells.NewSpells.Musique;

namespace Server.Spells
{
	public abstract class Spell : ISpell
	{
        public static bool CheckTransformation(Mobile Caster, Mobile m)
        {
            if (!m.CanBeginAction(typeof(IncognitoSpell)))
            {
                Caster.SendMessage(m.Name + " est déjà affecté par Incognito.");
                return false;
            }
            //else if (!m.CanBeginAction(typeof(MetamorphoseSpell)) || !m.CanBeginAction(typeof(MutationSpell)) || !m.CanBeginAction(typeof(AlterationSpell)) || !m.CanBeginAction(typeof(SubterfugeSpell)) || !m.CanBeginAction(typeof(ChimereSpell)) || !m.CanBeginAction(typeof(TransmutationSpell)))
            //{
            //    Caster.SendMessage(m.Name + " est déjà transformé.");
            //    return false;
            //}
            //else if (!m.CanBeginAction(typeof(BaseMorphPotion)))
            //{
            //    Caster.SendMessage(m.Name + " est déjà transformé.");
            //    return false;
            //}
            //else if (!m.CanBeginAction(typeof(InstinctCharnelSpell)))
            //{
            //    Caster.SendMessage(m.Name + " est déjà transformé.");
            //    return false;
            //}
			//else if (!m.CanBeginAction(typeof(ChauveSouris)))
			//{
			//    Caster.SendMessage(m.Name + " est sous la forme d'une chauve-souris.");
			//    return false;
			//}
			//else if (!m.CanBeginAction(typeof(BaseMorphPotion)))
			//{
			//    Caster.SendMessage(m.Name + " est déjà transformé.");
			//    return false;
			//}
			else if (m.BodyMod == 183 || m.BodyMod == 184)
			{
				Caster.SendLocalizedMessage(1042512); // You cannot polymorph while wearing body paint
				return false;
			}
			else if (m.Blessed)
            {
                Caster.SendMessage(m.Name + " ne peut être la cible de sorts changeant l'apparence.");
                return false;
            }

            return true;
        }

		public Mobile m_Caster;
		public Item m_Scroll;
		private SpellInfo m_Info;
		public SpellState m_State;
		public DateTime m_StartCastTime;

		public SpellState State{ get{ return m_State; } set{ m_State = value; } }
		public Mobile Caster{ get{ return m_Caster; } }
		public SpellInfo Info{ get{ return m_Info; } }
		public string Name{ get{ return m_Info.Name; } }
		public string Mantra{ get{ return m_Info.Mantra; } }
		public SpellCircle Circle{ get{ return m_Info.Circle; } }
		public Type[] Reagents{ get{ return m_Info.Reagents; } }
		public Item Scroll{ get{ return m_Scroll; } }

		private static double NextSpellDelay = 2.0;
		private static TimeSpan AnimateDelay = TimeSpan.FromSeconds( 1.5 );

		public virtual SkillName CastSkill{ get{ return SkillName.Magery; } }
		public virtual SkillName DamageSkill{ get{ return SkillName.EvalInt; } }

		public virtual bool RevealOnCast{ get{ return true; } }
		public virtual bool ClearHandsOnCast{ get{ return false; } }

		public virtual bool DelayedDamage{ get{ return false; } }

        public virtual bool AnimateOnCast { get { return true; } }
        public virtual bool CheckHurt { get { return true; } }

		public Spell( Mobile caster, Item scroll, SpellInfo info )
		{
			m_Caster = caster;
			m_Scroll = scroll;
			m_Info = info;
		}

        public virtual int GetNewAosDamage( Mobile target, int bonus, int dice, int sides, bool playerVsPlayer )
		{
			int damage = Utility.Dice( dice, sides, bonus ) * 100;
			int damageBonus = 0;

            double anatomySkill = Caster.Skills[SkillName.Anatomy].Value;
            damageBonus += (int)(anatomySkill / 2.5);

			int intBonus = Caster.Int / 2;
			damageBonus += intBonus;

            int evalSkill = GetDamageFixed( m_Caster );
            damageBonus += ((9 * evalSkill) / 100);

			damage = AOS.Scale( damage, 100 + damageBonus );

            //if (AOS.Testing)
            //    Caster.SendMessage("Spell - Damage : " + String.Format("{0:0.##}", (damage / 100)));

            if (target is BaseCreature)
                damage *= 4;

            return damage / 100;
		}

		public virtual double GetAosDamage( int min, int random, double div )
		{
			double scale = 1.0;

			scale += GetInscribeSkill( m_Caster ) * 0.001;

			if ( Caster.Player )
				scale += Caster.Int * 0.001;

			int baseDamage = min + (int)(GetDamageSkill( m_Caster ) / div);

			double damage = Utility.RandomMinMax( baseDamage, baseDamage + random );

			return damage * scale;
		}

		public virtual bool IsCasting{ get{ return m_State == SpellState.Casting; } }

        public virtual void OnCasterHurt()
        {
            if (CheckHurt)
            {
                CustomPlayerMobile pm = m_Caster as CustomPlayerMobile;
                double chance = m_Caster.Skills[SkillName.Magery].Value / 333;
                chance += m_Caster.Skills[SkillName.EvalInt].Value / 333;

                if (chance > Utility.RandomDouble())
                    m_Caster.SendMessage("Vous réussissez à garder votre concentration.");
                else
                    Disturb(DisturbType.Hurt);
            }
        }

		public virtual void OnCasterKilled()
		{
			Disturb( DisturbType.Kill );
		}

		public virtual void OnConnectionChanged()
		{
			FinishSequence();
		}

		public virtual bool OnCasterMoving( Direction d )
		{
			if (IsCasting && BlocksMovement && (!(m_Caster is BaseCreature) || ((BaseCreature)m_Caster).FreezeOnCast))
			{
				m_Caster.SendMessage("Vous ne pouvez pas vous déplacer en canalisant un sort."); // You are frozen and can not move.
				return false;
			}

			return true;
		}

		/// <summary>
		/// Post ML code where player is frozen in place while casting.
		/// </summary>
		/// <param name="caster"></param>
		/// <returns></returns>
		public virtual bool CheckMovement(Mobile caster)
		{
			if (IsCasting && BlocksMovement && (!(m_Caster is BaseCreature) || ((BaseCreature)m_Caster).FreezeOnCast))
			{
				return false;
			}

			return true;
		}

		public virtual bool OnCasterEquiping( Item item )
		{
			if ( IsCasting )
				Disturb( DisturbType.EquipRequest );

			return true;
		}

		public virtual bool OnCasterUsingObject( object o )
		{
			if ( m_State == SpellState.Sequencing )
				Disturb( DisturbType.UseRequest );

			return true;
		}

		public virtual bool OnCastInTown( Region r )
		{
			return m_Info.AllowTown;
		}

		public virtual bool ConsumeReagents()
		{
			if ( m_Scroll != null || !m_Caster.Player )
				return true;

			//if ( AosAttributes.GetValue( m_Caster, AosAttribute.LowerRegCost ) > Utility.Random( 100 ) )
			//	return true;

			var pm = m_Caster as CustomPlayerMobile;

			if (pm != null && pm.Aptitudes.Transcription * 10 > Utility.Random(100))
				return true;

			Container pack = m_Caster.Backpack;

			if ( pack == null )
				return false;

			if ( pack.ConsumeTotal( m_Info.Reagents, m_Info.Amounts ) == -1 )
				return true;

			return false;
		}

		public virtual bool CheckResisted( Mobile target )
        {
            //Modification majeure, voir AOS.cs
            return false;

            //if (target is CustomPlayerMobile)
            //{
            //    CustomPlayerMobile pm = (CustomPlayerMobile)target;

            //    if (pm.CheckFatigue(4))
            //        return false;
            //}

            double n = GetResistPercent( target );

            n /= 100.0;

            //if (target is CustomPlayerMobile)
            //    n += ((CustomPlayerMobile)target).GetAttributValue(Attribut.Resistance) / 1000;

            if ( n <= 0.0 )
            	return false;

            if ( n >= 1.0 )
                return true;

            int maxSkill = (1 + (int)Circle) * 10;
            maxSkill += (1 + ((int)Circle / 6)) * 25;

            if ( target.Skills[SkillName.MagicResist].Value < maxSkill )
                target.CheckSkill( SkillName.MagicResist, 0.0, 120.0 );

            return ( n >= Utility.RandomDouble() );
		}

		public virtual double GetInscribeSkill( Mobile m )
		{
			// There is no chance to gain
			// m.CheckSkill( SkillName.Inscribe, 0.0, 120.0 );

			return m.Skills[SkillName.Inscribe].Value;
		}

		public virtual int GetInscribeFixed( Mobile m )
		{
			// There is no chance to gain
			// m.CheckSkill( SkillName.Inscribe, 0.0, 120.0 );

			return m.Skills[SkillName.Inscribe].Fixed;
		}

		public virtual int GetDamageFixed( Mobile m )
		{
			m.CheckSkill( DamageSkill, 0.0, 120.0 );

			return m.Skills[DamageSkill].Fixed;
		}

		public virtual double GetDamageSkill( Mobile m )
		{
			m.CheckSkill( DamageSkill, 0.0, 120.0 );

			return m.Skills[DamageSkill].Value;
		}

		public virtual int GetResistFixed( Mobile m )
		{
			int maxSkill = (1 + (int)Circle) * 10;
			maxSkill += (1 + ((int)Circle / 6)) * 25;

			if ( m.Skills[SkillName.MagicResist].Value < maxSkill )
				m.CheckSkill( SkillName.MagicResist, 0.0, 120.0 );

			return m.Skills[SkillName.MagicResist].Fixed;
		}

		public virtual double GetResistSkill( Mobile m )
		{
			int maxSkill = (1 + (int)Circle) * 10;
			maxSkill += (1 + ((int)Circle / 6)) * 25;

			if ( m.Skills[SkillName.MagicResist].Value < maxSkill )
				m.CheckSkill( SkillName.MagicResist, 0.0, 120.0 );

			return m.Skills[SkillName.MagicResist].Value;
		}

		public virtual double GetResistPercentForCircle( Mobile target, SpellCircle circle )
		{
			double firstPercent = target.Skills[SkillName.MagicResist].Value / 5.0;
			double secondPercent = target.Skills[SkillName.MagicResist].Value - (((m_Caster.Skills[CastSkill].Value - 20.0) / 5.0) + (1 + (int)circle) * 5.0);

			return ( firstPercent > secondPercent ? firstPercent : secondPercent ) / 2.0; // Seems should be about half of what stratics says.
		}

		public virtual double GetResistPercent( Mobile target )
		{
			return GetResistPercentForCircle( target, m_Info.Circle );
		}

		public virtual double GetDamageScalar( Mobile target )
		{
			double casterEI = m_Caster.Skills[DamageSkill].Value;
			double targetRS = target.Skills[SkillName.MagicResist].Value;
			double scalar;

			m_Caster.CheckSkill( DamageSkill, 0.0, 120.0 );

			if ( casterEI > targetRS )
				scalar = (1.0 + ((casterEI - targetRS) / 500.0));
			else
				scalar = (1.0 + ((casterEI - targetRS) / 200.0));

			// magery damage bonus, -25% at 0 skill, +0% at 100 skill, +5% at 120 skill
			scalar += ( m_Caster.Skills[CastSkill].Value - 100.0 ) / 400.0;

			if ( target is BaseCreature )
				scalar += 0.5; // Double magery damage to monsters/animals if not AOS

			if ( target is BaseCreature )
				((BaseCreature)target).AlterDamageScalarFrom( m_Caster, ref scalar );

			if ( m_Caster is BaseCreature )
				((BaseCreature)m_Caster).AlterDamageScalarTo( target, ref scalar );

			target.Region.SpellDamageScalar( m_Caster, target, ref scalar );

			return scalar;
		}

        public virtual TimeSpan GetDurationForSpell(double min, double scale = 1.0)
        {
            double bonus = 1;

			bonus += (Caster.Skills[CastSkill].Value - 50) / 150;
			bonus += (Caster.Skills[DamageSkill].Value - 50) / 200;

			bonus += Caster.Int / 2000;

			if (Caster is CustomPlayerMobile pm)
			{
				bonus += pm.Capacites.Magie / 50;
				bonus += pm.Aptitudes.GetValue(RequiredAptitude.First()) / 100;
			}

			min *= bonus * scale;

			if (min < 0.5)
                return TimeSpan.FromSeconds(0.5);

            return TimeSpan.FromSeconds(min);
        }

		public virtual void DoFizzle()
		{
			m_Caster.LocalOverheadMessage( MessageType.Regular, 0x3B2, 502632 ); // The spell fizzles.

			if ( m_Caster.Player )
			{
				m_Caster.FixedEffect( 0x3735, 6, 30 );
				m_Caster.PlaySound( 0x5C );
			}
		}

		public CastTimer m_CastTimer;
		public AnimTimer m_AnimTimer;

		public virtual bool CheckDisturb(DisturbType type)
		{
			if (ParfaiteAspirationSpell.IsActive(m_Caster))
				return false;

			return true;
		}

		public void Disturb(DisturbType type)
        {
            if (!CheckDisturb(type))
                return;

            if (m_State == SpellState.Casting)
            {
                m_State = SpellState.None;
                m_Caster.Spell = null;

                OnDisturb(type, true);

                if (m_CastTimer != null)
                    m_CastTimer.Stop();

                if (m_AnimTimer != null)
                    m_AnimTimer.Stop();

                DoFizzle();

                m_Caster.NextSpellTime = Core.TickCount + GetDisturbRecovery();
            }
            /*else if (m_State == SpellState.Sequencing)
            {
                m_State = SpellState.None;
                m_Caster.Spell = null;

                OnDisturb(type, true);

                DoFizzle();

                Targeting.Target.Cancel(m_Caster);
            }*/
        }

		public virtual void DoHurtFizzle()
		{
			m_Caster.FixedEffect( 0x3735, 6, 30 );
			m_Caster.PlaySound( 0x5C );
		}

		public virtual void OnDisturb( DisturbType type, bool message )
		{
			if ( message )
				m_Caster.SendLocalizedMessage( 500641 ); // Your concentration is disturbed, thus ruining thy spell.
		}

		public virtual bool CheckCast()
        {
            CustomPlayerMobile caster = m_Caster as CustomPlayerMobile;

			if (caster != null && caster.Squelched)
			{
				caster.SendMessage("Vous ne pouvez incanter si vous êtes muet.");
				return false;
			}

			BaseCreature bc = m_Caster as BaseCreature;

            if (bc != null && (bc.Squelched))
                return false;

			return true;
		}

		public virtual void SayMantra()
		{
			if ( m_Info.Mantra != null && m_Info.Mantra.Length > 0 && m_Caster.Player )
				m_Caster.PublicOverheadMessage( MessageType.Spell, m_Caster.SpeechHue, true, m_Info.Mantra, false );

            //if (m_Info.Mantra != null && m_Info.Mantra.Length > 0 /*&& m_Caster.Player*/)
            //{
            //    //  m_Caster.PublicOverheadMessage(MessageType.Spell, m_Caster.SpeechHue, true, m_Info.Mantra, false);
            //    string[] splitted = m_Info.Mantra.Trim().Split(' ');
            //    TimeSpan castDelay = this.GetCastDelay();

            //    Timer m_ParolesTimer = new ParolesTimer(Caster, castDelay, splitted);
            //    m_ParolesTimer.Start();
            //}
		}

        //public class ParolesTimer : Timer
        //{
        //    private int Count;
        //    private Mobile m_Caster = null;
        //    private string[] split = null;

        //    public ParolesTimer(Mobile Caster, TimeSpan castDelay, string[] splitted)
        //        : base(TimeSpan.Zero, TimeSpan.FromSeconds(castDelay.TotalSeconds / splitted.Length))
        //    {
        //        Count = 0;
        //        m_Caster = Caster;
        //        split = splitted;
        //    }

        //    protected override void OnTick()
        //    {
        //        if (m_Caster != null && split != null)
        //        {
        //            if (Count < split.Length)
        //                m_Caster.Say(split[Count]);
        //        }

        //        Count++;
        //    }
        //}

		public virtual bool BlockedByHorrificBeast{ get{ return false; } }
		public virtual bool BlocksMovement{ get{ return true; } }

		public virtual bool CheckNextSpellTime{ get{ return true; } }

		public virtual bool Cast()
        {
            CustomPlayerMobile pm = m_Caster as CustomPlayerMobile;
			m_StartCastTime = DateTime.Now;

			if ( !m_Caster.CheckAlive() )
			{
				return false;
			}
			else if ( m_Caster.Spell != null && m_Caster.Spell.IsCasting )
			{
				m_Caster.SendLocalizedMessage( 502642 ); // You are already casting a spell.
			}
			//else if ( BlockedByHorrificBeast && TransformationSpell.UnderTransformation( m_Caster, typeof( HorrificBeastSpell ) ) )
			//{
			//	m_Caster.SendLocalizedMessage( 1061091 ); // You cannot cast that spell in this form.
			//}
			else if (m_Caster.Paralyzed)
			{
				m_Caster.SendMessage($"Vous ne pouvez pas envoyer de sort lorsque vous êtes paralysé{(m_Caster.Female ? "e" : "")}.");
			}
			else if ( m_Caster.Frozen )
			{
				m_Caster.SendMessage($"Vous ne pouvez pas envoyer de sort lorsque vous êtes endormi{(m_Caster.Female ? "e" : "")}");
			}
			else if ( CheckNextSpellTime && Core.TickCount < m_Caster.NextSpellTime )
			{
				m_Caster.SendLocalizedMessage( 502644 ); // You must wait for that spell to have an effect.
            }
			else if ( m_Caster.Mana >= ScaleMana( GetMana() ) )
			{
				if (m_Caster.Spell == null && m_Caster.CheckSpellCast( this ) && CheckCast() && m_Caster.Region.OnBeginSpellCast( m_Caster, this ) )
				{
					m_State = SpellState.Casting;
					m_Caster.Spell = this;

					if ( RevealOnCast )
						m_Caster.RevealingAction();

					SayMantra();

					TimeSpan castDelay = this.GetCastDelay();

					if (m_Caster.Body.IsHuman || (m_Caster.Player && m_Caster.Body.IsMonster))
					{
						int count = (int)Math.Ceiling( castDelay.TotalSeconds / AnimateDelay.TotalSeconds );

						if ( count != 0 && AnimateOnCast)
						{
							m_AnimTimer = new AnimTimer( this, count );
							m_AnimTimer.Start();
						}

						if ( m_Info.LeftHandEffect > 0 )
							Caster.FixedParticles( 0, 10, 5, m_Info.LeftHandEffect, EffectLayer.LeftHand );

						if ( m_Info.RightHandEffect > 0 )
							Caster.FixedParticles( 0, 10, 5, m_Info.RightHandEffect, EffectLayer.RightHand );
					}

					if ( CheckHands() )
						m_Caster.ClearHands();

					m_CastTimer = new CastTimer( this, castDelay );
					m_CastTimer.Start();

					OnBeginCast();

					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				m_Caster.LocalOverheadMessage( MessageType.Regular, 0x22, 502625 ); // Insufficient mana
			}

			return false;
		}

        public bool CheckHands()
        {
			return false;

            //bool clear = ClearHandsOnCast;

            //return clear;
        }

		public abstract void OnCast();

		public virtual void OnBeginCast()
		{
		}

        public virtual void OnEndCast()
        {
        }

		private const double ChanceOffset = 20.0, ChanceLength = 100.0 / 9.0;

		public virtual void GetCastSkills( out double min, out double max )
		{
			int circle = (int)m_Info.Circle;

			if ( m_Scroll != null )
				circle -= 2;

			double avg = ChanceLength * circle;

			min = avg - ChanceOffset;
            max = avg + ChanceOffset;
		}

		public virtual bool CheckFizzle()
		{
			double minSkill, maxSkill;

			GetCastSkills( out minSkill, out maxSkill );

			if (m_Caster is CustomPlayerMobile && m_Caster.Mounted)
			{
				CustomPlayerMobile pm = (CustomPlayerMobile)m_Caster;

				double chance = 100 - (pm.Capacites.Equitation * 6);

				if (Utility.Random(0, 100) <= chance)
					return false;
			}

			Caster.CheckSkill(CastSkill, 0, 120);

			return Caster.CheckSkill( CastSkill, minSkill, maxSkill );
		}

		public static int GetManaBase(int requiredAptitudeValue)
		{
			return requiredAptitudeValue * 4;

		}

		public virtual int GetMana()
		{
			return GetManaBase(GetAptitudeValue());
		}

        public virtual int GetAptitudeValue()
        {
            return RequiredAptitudeValue;
        }

        public virtual Aptitude[] GetAptitude()
        {
            return RequiredAptitude;
        }

        public virtual int RequiredAptitudeValue { get { return 99; } }
        public virtual int RequiredMagicCapacity { get { return 99; } }
        public virtual Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Aeromancie }; } }

		public virtual int ScaleMana( int mana )
		{
			double scalar = 1.0;

            if (Caster.IsPlayer())
                mana = (int)(mana * (1 - (Caster.Int * 0.003)));

			scalar -= DecrescendoManaiqueSpell.GetValue(Caster) / 100;

			scalar -= AuraPreservationManaiqueSpell.GetValue(Caster) / 100;

			scalar -= MentorSpell.GetValue(Caster) / 100;

			if (scalar < 0)
				scalar = 0;

			return (int)(mana * scalar);
		}

		public virtual long GetDisturbRecovery()
		{
			double delay = 1.0 - Math.Sqrt( (DateTime.Now - m_StartCastTime).TotalSeconds / GetCastDelay().TotalSeconds );

			if ( delay < 0.1 )
				delay = 0.1;

			return (long)(delay * 1000);
		}

		public virtual int CastRecoveryBase => 6;
		public virtual int CastRecoveryFastScalar => 1;
		public virtual int CastRecoveryPerSecond => 4;
		public virtual int CastRecoveryMinimum => 0;

		public virtual TimeSpan GetCastRecovery()
		{
			int fcrDelay = -CastRecoveryFastScalar;

			int delay = CastRecoveryBase + fcrDelay;

			if (delay < CastRecoveryMinimum)
				delay = CastRecoveryMinimum;

			return TimeSpan.FromSeconds((double)delay / CastRecoveryPerSecond);
		}

        public virtual TimeSpan CastDelayBase => GetCastDelayBase(GetAptitudeValue());
        public virtual double CastDelayFastScalar => 1.0;
		public virtual double CastDelaySecondsPerTick => 1.0;
        public virtual TimeSpan CastDelayMinimum => TimeSpan.FromSeconds(0.5);


		public static TimeSpan GetCastDelayBase(int requiredAptitudeValue)
		{
			switch(requiredAptitudeValue)
			{
				case 1:
				case 2:
				case 3: return TimeSpan.FromSeconds(1);
				case 4:
				case 5:
				case 6: return TimeSpan.FromSeconds(1.5);
				case 7:
				case 8:
				case 9: return TimeSpan.FromSeconds(2.5);
				case 10:
				case 11:
				case 12:
				default: return TimeSpan.FromSeconds(3);
			}
		}

		public virtual TimeSpan GetCastDelay()
		{
			TimeSpan baseDelay = CastDelayBase;
			TimeSpan fcDelay = TimeSpan.FromSeconds(-(CastDelayFastScalar * CastDelaySecondsPerTick));
			TimeSpan delay = baseDelay + fcDelay;

			if (InquisitionSpell.IsActive(Caster))
				delay -= TimeSpan.FromSeconds(1);

			if (delay < CastDelayMinimum)
				delay = CastDelayMinimum;

			return delay;
		}

		public virtual void FinishSequence()
		{
			m_State = SpellState.None;

			if ( m_Caster.Spell == this )
				m_Caster.Spell = null;
		}

        public virtual bool VerifyConn(CustomPlayerMobile pm, Aptitude[] apt, int cValueRequis)
        {
            bool ok = false;

            for (int i = 0; !ok && i < apt.Length; ++i)
            {
                Aptitude c = apt[i];

                ok = (pm.GetTotalAptitudeValue(c) >= cValueRequis);
            }

            return ok;
        }

        public virtual bool CheckSequence()
		{
            int mana = ScaleMana(GetMana());
            int aptitudeValueRequis = GetAptitudeValue();
            Aptitude[] aptitudeRequise = GetAptitude();

            CustomPlayerMobile pm = m_Caster as CustomPlayerMobile;

			if ( m_Caster.Deleted || !m_Caster.Alive || m_Caster.Spell != this || m_State != SpellState.Sequencing )
            {
				DoFizzle();
			}
			else if ( m_Scroll != null && !(m_Scroll is Runebook) && (m_Scroll.Amount <= 0 || m_Scroll.Deleted || m_Scroll.RootParent != m_Caster) )
			{
				DoFizzle();
            }
            else if (!ConsumeReagents())
            {
                m_Caster.LocalOverheadMessage(MessageType.Regular, 0x22, 502630); // More reagents are needed for this spell.
            }
			else if ( m_Caster.Mana < mana )
			{
				m_Caster.LocalOverheadMessage( MessageType.Regular, 0x22, 502625 ); // Insufficient mana for this spell.
            }
            else if (pm != null && !VerifyConn(pm, aptitudeRequise, aptitudeValueRequis))
            {
                m_Caster.LocalOverheadMessage(MessageType.Regular, 0x22, false, "La connaissance nécessaire pour ce sort n'est pas assez développée.");
            }
            else if (pm != null && !pm.CheckEquitation(EquitationType.CastAttacking))
            {
                DoFizzle();
            }
			else if ( CheckFizzle() )
			{
                m_Caster.Mana -= mana;

				MentorSpell.Deactivate(m_Caster);

				if ( m_Scroll is SpellScroll )
					m_Scroll.Consume();

				if ( CheckHands() )
					m_Caster.ClearHands();

				return true;
			}
			else
            {
				DoFizzle();
			}

			return false;
		}

		public bool CheckBSequence( Mobile target )
		{
			return CheckBSequence( target, false );
		}

		public bool CheckBSequence( Mobile target, bool allowDead )
		{
			if ( !target.Alive && !allowDead )
			{
				m_Caster.SendLocalizedMessage( 501857 ); // This spell won't work on that!
				return false;
			}
			else if ( Caster.CanBeBeneficial( target, true, allowDead ) && CheckSequence() )
			{
				Caster.DoBeneficial( target );
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CheckHSequence( Mobile target )
		{
			if ( !target.Alive )
			{
				m_Caster.SendLocalizedMessage( 501857 ); // This spell won't work on that!
				return false;
			}
			else if ( Caster.CanBeHarmful( target ) && CheckSequence() )
			{
				Caster.DoHarmful( target );
				return true;
			}
			else
			{
				return false;
			}
		}

		public class AnimTimer : Timer
		{
			private Spell m_Spell;

			public AnimTimer( Spell spell, int count ) : base( TimeSpan.Zero, AnimateDelay, count )
			{
				m_Spell = spell;

				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				if ( m_Spell.State != SpellState.Casting || m_Spell.m_Caster.Spell != m_Spell )
				{
					Stop();
					return;
				}

				if ( !m_Spell.Caster.Mounted && m_Spell.Caster.Body.IsHuman && m_Spell.m_Info.Action >= 0 )
					m_Spell.Caster.Animate( m_Spell.m_Info.Action, 7, 1, true, false, 0 );

				if ( !Running )
					m_Spell.m_AnimTimer = null;
			}
		}

        public static void Disturb(Mobile m)
        {
			m.Frozen = false;
			m.Paralyzed = false;
			m.CantWalk = false;
		}

		public class CastTimer : Timer
		{
			private Spell m_Spell;

			public CastTimer( Spell spell, TimeSpan castDelay ) : base( castDelay )
			{
				m_Spell = spell;

				Priority = TimerPriority.TwentyFiveMS;
			}

			protected override void OnTick()
			{
                try
                {
                    if (m_Spell != null && m_Spell.m_Caster != null && m_Spell.m_State == SpellState.Casting && m_Spell.m_Caster.Spell == m_Spell)
                    {
                        m_Spell.m_State = SpellState.Sequencing;
                        m_Spell.m_CastTimer = null;
                        m_Spell.m_Caster.OnSpellCast(m_Spell);
                        m_Spell.m_Caster.Region.OnSpellCast(m_Spell.m_Caster, m_Spell);
                        m_Spell.m_Caster.NextSpellTime = Core.TickCount + (int)m_Spell.GetCastRecovery().TotalMilliseconds;

                        Target originalTarget = m_Spell.m_Caster.Target;

                        m_Spell.OnCast();

                        if (m_Spell.m_Caster.Player && m_Spell.m_Caster.Target != originalTarget && m_Spell.Caster.Target != null)
                            m_Spell.m_Caster.Target.BeginTimeout(m_Spell.m_Caster, TimeSpan.FromSeconds(30.0));

                        m_Spell.m_CastTimer = null;

                        m_Spell.OnEndCast();
                    }
                }
                catch
                {
                    m_Spell.m_CastTimer = null;

                    if (m_Spell != null && m_Spell.m_Caster != null)
                        m_Spell.m_Caster.NextSpellTime = Core.TickCount;
                }
			}
		}
	}
}