using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;
using Server.Targeting;
using Server.Misc;

namespace Server.Items
{
	[Flipable(0x9C14, 0x9C15)]
	public abstract class BaseCard : Item
	{

	
		public virtual int SkillRequis => 50;


		


		[Constructable]
		public BaseCard() : base(0x9C14)
		{
			Weight = 0.2;  // ?
		//	Name = "Hit Harm Rune";
			Hue = 294;
		}

		public virtual bool CanEnchant(Item item, Mobile from)
		{

		

			return false;

		}


		public virtual void Enchant(Item item, Mobile from)
		{

			item.Enchantement++;

			from.PlaySound(0x1F5);
			this.Delete();
		}


		public virtual bool CheckSuccess(Mobile from)
		{

			if (!from.CheckSkill(SkillName.Inscribe, SkillRequis, SkillRequis + 5))
			{
				from.SendMessage("La Carte se defait en mille morceaux.");
				from.PlaySound(65);
				from.PlaySound(0x1F8);
				Delete();
				return false;
			}
			else
			{
				return true;
			}
		}





		public override void OnDoubleClick( Mobile from ) 
		{
		
		 
			PlayerMobile pm = from as PlayerMobile;
		
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}

			else if ( pm == null || from.Skills[SkillName.Inscribe].Base < SkillRequis)
			{
				from.SendMessage( "Vous n'etes pas assez doué pour réussir." );
			}												
		    else 
		    {
			    from.SendMessage("Select the item to enhance.");
				from.Target = new InternalTarget(this);
			} 
		} 
		
		private class InternalTarget : Target 
		{
			private BaseCard m_Rune;

			public InternalTarget(BaseCard rune ) : base( 1, false, TargetFlags.None )
			{
				m_Rune = rune;
			}

		 	protected override void OnTarget( Mobile from, object targeted ) 
		 	{ 
				int DestroyChance = Utility.Random( 5 );
				int augmentper = Utility.Random( 8 ) + 1;

           	    if ( targeted is Item item )  // protects from crash if targeting a Mobile. 
			    {
					if (!m_Rune.CanEnchant(item, from))
					{
					
						return;
					}
					else if (item.Enchantement >= 1)
					{
						from.SendMessage("Cette objet a déjà un enchantement.");
						return;
					}				
					else if (!from.InRange(item.GetWorldLocation(), 1))
					{
						from.SendMessage("Vous êtes trop loin de la l'objet."); // That is too far away. 
						return;
					}
					else if ((((Item)targeted).Parent != null) && (((Item)targeted).Parent is Mobile))
					{
						from.SendMessage("Vous ne pouvez pas enchanter cette objets à cette endroit.");
					}
					else if (!m_Rune.CheckSuccess(from))
					{
						return;
					}
					else
					{
						m_Rune.Enchant(item, from);
						from.SendMessage("Vous enchantez l'objet.");
					}
				}
				else 
				{
		       			from.SendMessage( "Vous devez cibler un objet." );
		    	} 
		  	}
		
		}

		public override bool DisplayLootType{ get{ return false; } }  // ha ha!

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