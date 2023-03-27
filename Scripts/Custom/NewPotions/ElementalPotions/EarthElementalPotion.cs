using System;
using Server.Network;
using Server;
using Server.Targets;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;
//using Server.Engines.Plants;
namespace Server.Items
{
	public class EarthElementalPotion : BasePotion
	{
		[Constructable]
		public EarthElementalPotion() : base( 0xF0B, PotionEffect.EarthElemental )
		{
			Weight = 1.0;
			Movable = true;
			Hue = 143;
			Name = "Shaz'ars Earth Elemental Potion";
		}

		public EarthElementalPotion( Serial serial ) : base( serial )
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
			m.Target = new EThrowTarget();

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
                public class EThrowTarget : Target
		{
			public EThrowTarget() : base( 12, true, TargetFlags.None )
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
                                Effects.SendMovingEffect( from, to, 0xF0B & 0x3FFF, 7, 0, false, false, 0x8F, 0 );
				if ( targeted is BaseCreature || targeted is PlayerMobile)
				{
                                from.SendMessage( "Nothing happens!" );
                                return;
                                }
                                TimeSpan duration = TimeSpan.FromMinutes( 10 );
                                if ( targeted is FertileDirt )
				{
					FertileDirt dirt = (FertileDirt)targeted;

					if ( dirt.IsChildOf( from.Backpack ) )
					{
						from.SendMessage( "You can't pour that potion in your bag!" );
					}
					else if ( dirt.Amount < 20 )
					{
						from.SendMessage( "That probably wouldnt be enuff dirt!" );
					}
                                        else
                                        {
                                        SpellHelper.Summon( new EarthElemental(), from, 0x217, duration, false, false );
                                        dirt.Delete();
                                        return;
                                        }
                                        
				       // {
                                        //from.SendMessage( "Nothing happens!" );
                                        //return;
                                        //}
				}
                                /*if (targeted is StaticTarget)
                                {
                                StaticTarget obj = (StaticTarget)targeted;

                                        if ((obj.ItemID > 6025 && obj.ItemID < 6077) || (obj.ItemID > 13420 && obj.ItemID < 13529) || (obj.ItemID >= 0x5796 && obj.ItemID <= 0x57B2) )
                                        {
                                        SpellHelper.Summon( new SummonedWaterElemental(), from, 0x217, duration, false, false );
                                             return;
                                        }
				         else
                                        {
                                        //from.Target = new WThrowTarget();
                                        from.SendMessage( "Nothing happens!" );
                                        return;
                                        }
			         }*/

                                if (IsDirtPatch( targeted ))
                                {
                                        SpellHelper.Summon( new EarthElemental(), from, 0x217, duration, false, false );
			         }
                                else
				{
                                        from.SendMessage( "Nothing happens!" );
                                        return;
				}
		       }
         public static bool IsDirtPatch( object obj )
		{
			int tileID;

			if ( obj is Static && !((Static)obj).Movable )
				tileID = (((Static)obj).ItemID & 0x3FFF) | 0x4000;
			else if ( obj is StaticTarget )
				tileID = (((StaticTarget)obj).ItemID & 0x3FFF) | 0x4000;
			else if ( obj is LandTarget )
				tileID = ((LandTarget)obj).TileID & 0x3FFF;
			else
				return false;

			bool contains = false;

			for ( int i = 0; !contains && i < m_DirtPatchTiles.Length; i += 2 )
				contains = ( tileID >= m_DirtPatchTiles[i] && tileID <= m_DirtPatchTiles[i + 1] );

			return contains;
		}

		private static int[] m_DirtPatchTiles = new int[]
			{
				0x9, 0x15,
				0x71, 0x7C,
				0x82, 0xA7,
				0xDC, 0xE3,
				0xE8, 0xEB,
				0x141, 0x144,
				0x14C, 0x15C,
				0x169, 0x174,
				0x1DC, 0x1EF,
				0x272, 0x275,
				0x27E, 0x281,
				0x2D0, 0x2D7,
				0x2E5, 0x2FF,
				0x303, 0x31F,
				0x32C, 0x32F,
				0x33D, 0x340,
				0x345, 0x34C,
				0x355, 0x358,
				0x367, 0x36E,
				0x377, 0x37A,
				0x38D, 0x390,
				0x395, 0x39C,
				0x3A5, 0x3A8,
				0x3F6, 0x405,
				0x547, 0x54E,
				0x553, 0x556,
				0x597, 0x59E,
				0x623, 0x63A,
				0x6F3, 0x6FA,
				0x777, 0x791,
				0x79A, 0x7A9,
				0x7AE, 0x7B1,
				0x98C, 0x99F,
				0x9AC, 0x9BF,
				0x5B27, 0x5B3E,
				0x71F4, 0x71FB,
				0x72C9, 0x72CA,
			};
}
}
