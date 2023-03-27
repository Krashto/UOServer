using System;
using Server.Network;
using Server;
using Server.Targets;
using Server.Targeting;
namespace Server.Items
{
	public class DurabilityPotion : Item
	{
		[Constructable]
		public DurabilityPotion() : base( 0xF0B )
		{
			Weight = 1.0;
			Movable = true;
			Hue = 1261;
			Name = "Rikktor's Durability Potion";
                        //LootType = LootType.Blessed;
		}

		public DurabilityPotion( Serial serial ) : base( serial )
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
	  
	  	public override void OnDoubleClick( Mobile m )
      	{ 
         	if ( m.InRange( this.GetWorldLocation(), 1 ) ) 
         	{ 
                        m.Target = new DurabilityTarget();
           		m.SendMessage( "What would you like to pour this on!" );
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
