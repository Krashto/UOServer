using System;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;
using Server;
namespace Server.Items
{
	public class ShrinkPotion : BasePotion
	{

		#region Constructors
		public ShrinkPotion( Serial serial ) : base( serial )
		{
		}
		[Constructable]
		public ShrinkPotion() : base( 0xF04, PotionEffect.Shrink )
		{
			Name="ASayre's Shrink potion";
		}
		#endregion

		public override void Drink( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 1 ) )
         	       {

			//Container pack = from.Backpack;

			/*if ( !(Parent == from || ( pack != null && Parent == pack )) ) //If not in pack.
			{
				from.SendLocalizedMessage( 1042001 );	//That must be in your pack to use it.
				return;
			}*/
			//from.Target=new ShrinkPotionTarget( this );
                        from.Target = new ShrinkCmdTarget();
			from.SendMessage( "Que voulez-vous rétrécir?" );
                        this.Delete();
                        from.AddToBackpack( new Bottle() );
                        }
         	else
         	{
            	from.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that.
         	}
		//}
		}

// This class is using the Shrink system
		private class ShrinkCmdTarget : Target
		{
			public ShrinkCmdTarget() : base( 15, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targ )
			{
                             BaseCreature pet = targ as BaseCreature;
                          if ( pet.ControlMaster == from )
                                {
                                //this.Hue = 1170;     /// Set Active Hue Here
				ShrinkFunctions.Shrink( from, targ, false );
                                }
			}
		}

//// end: Edited for shrink
		public class ShrinkPotionTarget : Target
		{
			private ShrinkPotion m_Potion;

			public ShrinkPotionTarget( Item i ) : base( 3, false, TargetFlags.None )
			{
				m_Potion=(ShrinkPotion)i;
			}
			
			protected override void OnTarget( Mobile from, object targ )
			{
				if ( !(m_Potion.Deleted) )
				{
					ShrinkFunctions.Shrink( from, targ );
				}

				return;
			}
		}


		#region Serialization
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
		#endregion
	}
}
