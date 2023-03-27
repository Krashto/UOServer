using System;
using Server.Network;
using Server;
namespace Server.Items
{
	public class StealthPotion : BasePotion
	{
		[Constructable]
		public StealthPotion() : base( 0xF0B, PotionEffect.Stealth  )
		{
			Weight = 1.0;
			Movable = true;
			Hue = 838;
			Name = "Ezra's Stealth Potion";
		}

		public StealthPotion( Serial serial ) : base( serial )
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
	  
	  	public override void Drink( Mobile m )
      	{ 
         	if ( m.InRange( this.GetWorldLocation(), 1 ) ) 
         	{ 
                        m.Hidden = true ;
                        m.AllowedStealthSteps = 10 ;
                        this.Consume();
			//this.Delete();
                        //m.AddToBackpack( new Bottle() );
         	} 
         	else 
         	{ 
            	m.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that. 
         	} 
		}
	}
}
