using System;
using Server.Network;
using Server;
namespace Server.Items
{
	public class SuperStealthPotion : BasePotion
	{
		[Constructable]
		public SuperStealthPotion() : base( 0xF0B, PotionEffect.SuperStealth )
		{
			Weight = 1.0;
			Movable = true;
			Hue = 903;
			Name = "Ezra's Super Stealth Potion";
		}

		public SuperStealthPotion( Serial serial ) : base( serial )
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
                        m.AllowedStealthSteps = 15 ;
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
