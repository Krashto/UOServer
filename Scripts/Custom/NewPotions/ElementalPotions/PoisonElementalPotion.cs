using System;
using Server.Network;
using Server;
namespace Server.Items
{
	public class PoisonElementalPotion : Item
	{
		[Constructable]
		public PoisonElementalPotion() : base( 0xF0B )
		{
			Weight = 1.0;
			Movable = true;
			Hue = 1261;
			Name = "Shaz'ars Poison Elemental Potion";
                        //LootType = LootType.Blessed;
		}

		public PoisonElementalPotion( Serial serial ) : base( serial )
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
                        m.Hits = m.HitsMax ;
                        m.Mana = m.ManaMax ;
                        m.Stam = m.StamMax ;
           		m.SendMessage( "You feel completely refreshed!" );
                        this.Consume();
			//this.Delete();
         	} 
         	else 
         	{ 
            	m.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that. 
         	} 
		}
	}
}
