// created on 26/06/2003 at 14:24
using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class JeuTarot: Item
	{
		[Constructable]
		public JeuTarot() : base( 0x12A5 )
		{
			Weight = 0.5;
			Name = "un jeu de tarots divinatoires";
		}

		public JeuTarot( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if (this.IsChildOf(from.Backpack))
				from.SendMessage("L'objet doit être hors du sac");
			else
			{
				from.PlaySound(0x24A);
				int Card;
				Card = Utility.RandomMinMax(0,21);
				switch (Card)
				{
					case 0 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Bateleur" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Nouvelle action, début d'un processus dans n'importe quel domaine." ));
						break;
					}
					case 1 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Papesse"));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Elément caché pouvant être source de difficultés ou de conflits."));
						break;
					}
					case 2 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Impératrice" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Arrivée d'un courrier, d'une nouvelle, d'un fait heureux ou non. " ));
						break;
					}
					case 3 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Empereur" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Situation arrivée Ã  maturité." ));
						break;
					}
					case 4 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Pape" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "De par son caractére religieux, toutes les cérémonies comme le mariage, le baptême, sont annoncés. Le Pape réconcilie." ));
						break;
					}
					case 5 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Amoureux" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Nécessité de faire un choix, annonce la faiblesse et l'épreuve." ));
						break;
					}
					case 6 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Chariot" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Il annonce la force et la puissance." ));
						break;
					}
					case 7 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Justice" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La notion d'équilibre est ici fortement marquée." ));
						break;
					}
					case 8 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Hermite" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Un long chemin Ã  parcourir, des difficultés, la solitude également." ));
						break;
					}
					case 9 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Roue de Fortune" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Un déblocage d'une situation, un changement (en bien ou en mal) dans n'importe quel domaine." ));
						break;
					}
					case 10 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("La Force" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Victoire, mtrise de soi , notion de puissance sexuelle." ));
						break;
					}
					case 11 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Le Pendu" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Blocage, attente, impossibilité de réagir, solitude." ));
						break;
					}
					case 12 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("L'Arcane sans Nom"));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Une libération, un changement important. Elle libére souvent d'une situation devenue intolérable."));
						break;
					}              
					case 13 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Tempérance" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Modification, voyage, nouvelle rencontre, passage d'une situation Ã  une autre (en mal ou en bien).") );
						break;
					}
					case 14 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Diable" ));
                        this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Tromperie, adultére, mauvaise nouvelle, relation fugace, consultant aveuglé par son égoÃ¯sme. Dans le meilleur des cas, cette lame signifie une rentrée d'argent."));
						break;
					}
					case 15 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Maison Dieu" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Rupture, échec, divorce, maladie, accident." ));
						break;
					}
					case 16 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Etoile" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Apaise, apporte le réconfort aprés l'épreuve. Guérison, réussite, rencontre avec l'Ã¢me soeur.") );
						break;
					}                        
					case 17 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Lune" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Période obscure, dépression, situation peu claire, illusions.") );
						break;
					}              
					case 18 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Soleil" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Réussite, bonheur, une rencontre amoureuse, le mariage, rentrée d'erofith.") );
						break;
					}
					case 19 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Jugement" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Une nouvelle qui arrive, dénouement d'une situation, changement brusque, renouveau. L'effet de cette lame est foudroyant par sa rapidité.") );
						break;    
					}        
					case 20 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Monde" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Lame de réussite, succés aux examens,concrétisation bénéfique, cette lame est trés positive. Même dans le cas d'une infidélité amoureuse, elle prédit le retour de l'infidéle." ));
						break;
					}
					case 21 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Mat" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Abandon, lacheté, départ non préparé, fuite devant ses responsabilités, mais aussi plus pratiquement un voyage." ));
						break;
					}
				}
			}
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}


	}
}