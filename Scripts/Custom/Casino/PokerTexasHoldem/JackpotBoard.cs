﻿using System;
using System.Text;

using Server.Poker;
using Server.Network;
using Server.CustomScripts;

namespace Server.Items
{
	[Flipable( 0x1E5E, 0x1E5F )]
	public class JackpotBoard : Item
	{
		[Constructable]
		public JackpotBoard()
			: base( 0x1E5E )
		{
			Movable = false;
            Name = "Jackpot du Poker ";
			Hue = 1161;
		}

		public override void OnDoubleClick( Mobile from )
		{ 

			if ( from.InRange( this.Location, 4 ) && from.NetState != null )
			{
				if ( PokerDealer.Jackpot > 0 && PokerDealer.JackpotWinners != null && PokerDealer.JackpotWinners.Winners.Count > 0 )
				{
					if ( PokerDealer.JackpotWinners.Winners.Count > 1 )
					{
						StringBuilder sb = new StringBuilder( String.Format( "Le jackpot est de {0} pièces d'or. ", PokerDealer.Jackpot.ToString( "#,###" ) ) );

						sb.Append( "It is currently split by: " );

						for ( int i = 0; i < PokerDealer.JackpotWinners.Winners.Count; ++i )
						{
							if ( PokerDealer.JackpotWinners.Winners[i].Mobile != null )
								sb.Append( PokerDealer.JackpotWinners.Winners[i].Mobile.Name );
							else
								sb.Append( "(-null-)" );

							if ( PokerDealer.JackpotWinners.Winners.Count == 2 && i == 0 )
								sb.Append( " et " );
							else if ( i != PokerDealer.JackpotWinners.Winners.Count - 2 )
								sb.Append( ", " );
							else
								sb.Append( " et " );
						}

						sb.Append( String.Format( " mène avec {0}", HandRanker.RankString( PokerDealer.JackpotWinners.Hand ) ) );

						DisplayMessage( from, sb.ToString() );
						return;
					}
					else if ( PokerDealer.JackpotWinners.Winners[0] != null && PokerDealer.JackpotWinners.Winners[0].Mobile != null )
					{
						DisplayMessage( from, String.Format( "Le jackpot est de {0} pièces d'or. {1} mène avec {2}", PokerDealer.Jackpot.ToString( "#,###" ), PokerDealer.JackpotWinners.Winners[0].Mobile.Name, HandRanker.RankString( PokerDealer.JackpotWinners.Hand ) ) );
						return;
					}
				}

				DisplayMessage( from, "Aucun jackpot" );
			}
			else
				from.SendMessage( "Ceci est trop loin." );
		}

		private void DisplayMessage( Mobile from, string text )
		{
			from.NetState.Send( new AsciiMessage( Serial, ItemID, MessageType.Regular, Hue, 3, Name, text ) );
		}

		public JackpotBoard( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
		}
	}
}