using Server.Custom;
using Server.Custom.Aptitudes;
using Server.Targeting;

namespace Server.Items
{
	[Flipable(0x9C14, 0x9C15)]
	public abstract class BaseCard : Item
	{
		public enum CardEnchantType
		{
			[Description("Aucun")]
			Aucun,
			[Description("Chance")]
			Luck,
			[Description("Puissance des potions")]
			EnhancePotions,
			[Description("Résistance physique")]
			PhysicalResistance,
			[Description("Résistance au feu")]
			FireResistance,
			[Description("Résistance au froid")]
			ColdResistance,
			[Description("Résistance au poison")]
			PoisonResistance,
			[Description("Résistance à l'énergie")]
			EnergyResistance,
			[Description("Résistance au chaos")]
			ChaosResistance,
			[Description("Résistance aux dégâts directs")]
			DirectResistance,
			[Description("Réflection des dégâts physiques")]
			ReflectPhysical,
			[Description("Dégâts physiques")]
			WeaponDamage,
			[Description("Vitesse de frappe")]
			WeaponSpeed,
			[Description("Chances de toucher")]
			AttackChance,
			[Description("Chances d'esquive")]
			DefendChance,
			[Description("Dégâts magiques")]
			SpellDamage,
			[Description("Vitesse d'incantation")]
			CastSpeed,
			[Description("Vitesse d'enchainement des sorts")]
			CastRecovery,
			[Description("Réduction en coût de munition")]
			LowerAmmoCost,
			[Description("Réduction en coût de mana")]
			LowerManaCost,
			[Description("Réduction en coût d'essence")]
			LowerRegCost,
			[Description("Bonus de points de vie")]
			BonusHits,
			[Description("Bonus de points de stamina")]
			BonusStam,
			[Description("Bonus de points de mana")]
			BonusMana,
			[Description("Bonus de points de force")]
			BonusStr,
			[Description("Bonus de points de dextérité")]
			BonusDex,
			[Description("Bonus de points d'intelligence")]
			BonusInt,
			[Description("Bonus de regénération de points de vie")]
			RegenHits,
			[Description("Bonus de regénération de points de stamina")]
			RegenStam,
			[Description("Bonus de regénération de points de mana")]
			RegenMana,
			[Description("Aptitude Chimie")]
			AptitudeChimie,
			[Description("Aptitude Couture")]
			AptitudeCouture,
			[Description("Aptitude Ingénierie")]
			AptitudeIngenierie,
			[Description("Aptitude Métallurgie")]
			AptitudeMetallurgie,
			[Description("Aptitude Transcription")]
			AptitudeTranscription,
			[Description("Aptitude Martial")]
			AptitudeMartial,
			[Description("Aptitude Chasseur")]
			AptitudeChasseur,
			[Description("Aptitude Roublardise")]
			AptitudeRoublardise,
			[Description("Aptitude Polymorphie")]
			AptitudePolymorphie,
			[Description("Aptitude Totémique")]
			AptitudeTotemique,
			[Description("Aptitude Musique")]
			AptitudeMusique,
			[Description("Aptitude Hydromancie")]
			AptitudeHydromancie,
			[Description("Aptitude Pyromancie")]
			AptitudePyromancie,
			[Description("Aptitude Géomancie")]
			AptitudeGeomancie,
			[Description("Aptitude Aéromancie")]
			AptitudeAeromancie,
			[Description("Aptitude Nécromancie")]
			AptitudeNecromancie,
			[Description("Aptitude Défenseur")]
			AptitudeDefenseur,
			[Description("Aptitude Guérison")]
			AptitudeGuerison,
		}

		public virtual int RequiredSkill => 50;
		public virtual int Level => 0;
		public virtual CardEnchantType EnchantType => CardEnchantType.Aucun;

		public BaseCard(int hue) : base(0x9C14)
		{
			Hue = hue;
			Weight = 0.2;
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);
			list.Add(string.Format($"[{CustomUtility.GetDescription(EnchantType)} +{Level}]"));
		}

		public virtual bool CanEnchant(Item item, Mobile from)
		{
			if (!(item is BaseBracelet || item is BaseRing))
			{
				from.SendMessage("Vous pouvez enchanter que les bracelets et les anneaux avec cette carte.");
				return false;
			}

			return true;
		}

		public virtual void Enchant(Item item, Mobile from)
		{
			if (!CanEnchant(item, from))
				return;

			if (!(item is BaseBracelet || item is BaseRing))
				return;

			var jewel = item as BaseJewel;

			jewel.Enchantement++;

			switch(EnchantType)
			{
				case CardEnchantType.Luck:					jewel.Attributes.Luck += Level; break;

				case CardEnchantType.PhysicalResistance:	jewel.Resistances.Physical += Level; break;
				case CardEnchantType.FireResistance:		jewel.Resistances.Fire += Level; break;
				case CardEnchantType.ColdResistance:		jewel.Resistances.Cold += Level; break;
				case CardEnchantType.PoisonResistance:		jewel.Resistances.Poison += Level; break;
				case CardEnchantType.EnergyResistance:		jewel.Resistances.Energy += Level; break;
				case CardEnchantType.ChaosResistance:		jewel.Resistances.Chaos += Level; break;
				case CardEnchantType.DirectResistance:		jewel.Resistances.Direct += Level; break;
				case CardEnchantType.ReflectPhysical:		jewel.Attributes.ReflectPhysical += Level; break;

				case CardEnchantType.WeaponDamage:			jewel.Attributes.WeaponDamage += Level; break;
				case CardEnchantType.WeaponSpeed:			jewel.Attributes.WeaponSpeed += Level; break;
				case CardEnchantType.AttackChance:			jewel.Attributes.AttackChance += Level; break;
				case CardEnchantType.DefendChance:			jewel.Attributes.DefendChance += Level; break;

				case CardEnchantType.SpellDamage:			jewel.Attributes.SpellDamage += Level; break;
				case CardEnchantType.CastSpeed:				jewel.Attributes.CastSpeed += Level; break;
				case CardEnchantType.CastRecovery:			jewel.Attributes.CastRecovery += Level; break;

				case CardEnchantType.LowerAmmoCost:			jewel.Attributes.LowerAmmoCost += Level; break;
				case CardEnchantType.LowerManaCost:			jewel.Attributes.LowerManaCost += Level; break;
				case CardEnchantType.LowerRegCost:			jewel.Attributes.LowerRegCost += Level; break;

				case CardEnchantType.BonusHits:				jewel.Attributes.BonusHits += Level; break;
				case CardEnchantType.BonusStam:				jewel.Attributes.BonusStam += Level; break;
				case CardEnchantType.BonusMana:				jewel.Attributes.BonusMana += Level; break;

				case CardEnchantType.RegenHits:				jewel.Attributes.RegenHits += Level; break;
				case CardEnchantType.RegenStam:				jewel.Attributes.RegenStam += Level; break;
				case CardEnchantType.RegenMana:				jewel.Attributes.RegenMana += Level; break;

				case CardEnchantType.BonusStr:				jewel.Attributes.BonusStr += Level; break;
				case CardEnchantType.BonusDex:				jewel.Attributes.BonusDex += Level; break;
				case CardEnchantType.BonusInt:				jewel.Attributes.BonusInt += Level; break;

				case CardEnchantType.AptitudeChimie:		jewel.AptitudeBonus = Aptitude.Chimie;			jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeCouture:		jewel.AptitudeBonus = Aptitude.Couture;			jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeIngenierie:	jewel.AptitudeBonus = Aptitude.Ingenierie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeMetallurgie:	jewel.AptitudeBonus = Aptitude.Metallurgie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeTranscription: jewel.AptitudeBonus = Aptitude.Transcription;	jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeMartial:		jewel.AptitudeBonus = Aptitude.Martial;			jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeChasseur:		jewel.AptitudeBonus = Aptitude.Chasseur;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeRoublardise:	jewel.AptitudeBonus = Aptitude.Roublardise;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudePolymorphie:	jewel.AptitudeBonus = Aptitude.Polymorphie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeTotemique:		jewel.AptitudeBonus = Aptitude.Totemique;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeMusique:		jewel.AptitudeBonus = Aptitude.Musique;			jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeHydromancie:	jewel.AptitudeBonus = Aptitude.Hydromancie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudePyromancie:	jewel.AptitudeBonus = Aptitude.Pyromancie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeGeomancie:		jewel.AptitudeBonus = Aptitude.Geomancie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeAeromancie:	jewel.AptitudeBonus = Aptitude.Aeromancie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeNecromancie:	jewel.AptitudeBonus = Aptitude.Necromancie;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeDefenseur:		jewel.AptitudeBonus = Aptitude.Defenseur;		jewel.AptitudeLevel = Level; break;
				case CardEnchantType.AptitudeGuerison:		jewel.AptitudeBonus = Aptitude.Guerison;		jewel.AptitudeLevel = Level; break;
			}

			from.PlaySound(0x1F5);
			Delete();
		}

		public virtual bool CheckSuccess(Mobile from)
		{
			if (!from.CheckSkill(SkillName.Inscribe, RequiredSkill, RequiredSkill + 5))
			{
				from.SendMessage("La carte se détruit en milles morceaux.");
				from.PlaySound(65);
				from.PlaySound(0x1F8);
				Delete();
				return false;
			}

			return true;
		}

		public override void OnDoubleClick( Mobile from ) 
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage("La carte doit être dans votre sac pour l'utiliser.");
				return;
			}
			else if ( from.Skills[SkillName.Inscribe].Base < RequiredSkill)
			{
				from.SendMessage($"Vous n'êtes pas assez doué{(from.Female ? "e" : "")} pour utiliser cet enchantement ({RequiredSkill}% d'inscription requis).");
				return;
			}

			from.SendMessage("Sélectionner le bijou à enchanter.");
			from.Target = new InternalTarget(this);
		} 
		
		private class InternalTarget : Target 
		{
			private BaseCard m_Card;

			public InternalTarget(BaseCard card) : base( 1, false, TargetFlags.None )
			{
				m_Card = card;
			}

		 	protected override void OnTarget( Mobile from, object targeted ) 
		 	{ 
           	    if ( targeted is Item item )  // protects from crash if targeting a Mobile. 
			    {
					if (!m_Card.CanEnchant(item, from))
						return;
					else if (item.Enchantement >= 1)
					{
						from.SendMessage("Cet objet a déjà un enchantement.");
						return;
					}				
					else if (!from.InRange(item.GetWorldLocation(), 1))
					{
						from.SendMessage("Vous êtes trop loin de l'objet."); // That is too far away. 
						return;
					}
					else if ((((Item)targeted).Parent != null) && (((Item)targeted).Parent is Mobile))
					{
						from.SendMessage("Vous ne pouvez pas enchanter cet objet à cet endroit.");
						return;
					}
					else if (!m_Card.CheckSuccess(from))
					{
						return;
					}

					m_Card.Enchant(item, from);
					from.SendMessage("Vous enchantez l'objet.");
				}
				else 
		       		from.SendMessage( "Vous devez cibler un objet." );
		  	}
		}

		public BaseCard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}