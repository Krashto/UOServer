using System;
using Server.Network;
using Server;
using Server.Targets;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;
namespace Server.Items
{
	public class FireElementalPotion : BasePotion
	{
		[Constructable]
		public FireElementalPotion() : base( 0xF0B, PotionEffect.WaterElemental)
		{
			Weight = 1.0;
			Movable = true;
			Hue = 38;
			Name = "Shaz'ars Fire Elemental Potion";
		}

		public FireElementalPotion( Serial serial ) : base( serial )
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
                  if ( Core.AOS && (m.Paralyzed || m.Frozen || (m.Spell != null && m.Spell.IsCasting)) )
			{
				m.SendMessage( "You can't throw that while paralyzed!" );
				return;
			}
                  if ( m.InRange( this.GetWorldLocation(), 1 ) )
         	        {
			m.Target = new FThrowTarget();

			m.RevealingAction();

           		m.SendMessage( "Where do you want to throw this?!" );
                        this.Consume();
                        //this.Delete();
                        }
         	else
         	{
            	m.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that.
         	}
		}
	}
            public class FThrowTarget : Target
		{
			public FThrowTarget() : base( 12, true, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
                                IPoint3D p = targeted as IPoint3D;
                                Map map = from.Map;
                                IEntity to;
                                if ( p is Mobile )
					to = (Mobile)p;
				else
					to = new Entity( Serial.Zero, new Point3D( p ), map );
                                Effects.SendMovingEffect( from, to, 0xF0B & 0x3FFF, 7, 0, false, false, 0x26, 0 );
				if ( targeted is BaseCreature || targeted is PlayerMobile)
				{
                                from.SendMessage( "Nothing happens!" );
                                return;
                                }
                                TimeSpan duration = TimeSpan.FromMinutes( 10 );
                                if ( targeted is Item )
                                {
                                   Item item = (Item)targeted;
				      if ( item is Forge || item is StoneFireplaceSouthAddon || item is StoneFireplaceEastAddon || item is SandstoneFireplaceSouthAddon || item is SandstoneFireplaceEastAddon || item is GrayBrickFireplaceSouthAddon || item is GrayBrickFireplaceEastAddon || item is LargeForgeSouthAddon || item is LargeForgeEastAddon || item is LargeForgeEast || item is LargeForgeWest || item is SmallForgeAddon || item is HeatingStand || item is Campfire)
                                      {
                                        SpellHelper.Summon( new FireElemental(), from, 0x217, duration, false, false );
                                                 return;
                                        }
                                        else
				        {
                                        from.SendMessage( "Nothing happens!" );
                                        return;
                                        }
				}
                                if (targeted is StaticTarget)
                                {
                                StaticTarget obj = (StaticTarget)targeted;

                                        if ((obj.ItemID == 4012 /*&& obj.ItemID < 6077)*/)) //|| (obj.ItemID > 13420 && obj.ItemID < 13529) || (obj.ItemID >= 0x5796 && obj.ItemID <= 0x57B2) )
                                        {
                                        SpellHelper.Summon( new FireElemental(), from, 0x217, duration, false, false );
                                             return;
                                        }
				         else
                                        {
                                        from.SendMessage( "Nothing happens!" );
                                        return;
                                        }
			         }

                                /*if (targeted is LandTarget)
                                {
                                LandTarget landTile = (LandTarget)targeted;

                                        if (((landTile.TileID >= 168 && landTile.TileID <= 171) || (landTile.TileID >= 310 && landTile.TileID <= 311)))
                                        {
                                        SpellHelper.Summon( new SummonedWaterElemental(), from, 0x217, duration, false, false );
                                             return;
                                        }
				         else
                                        {
                                        from.SendMessage( "Nothing happens!" );
                                        return;
                                        }
			         }*/
                                else
				{
                                        from.SendMessage( "Nothing happens!" );
                                        return;
				}
		       }
}
}
