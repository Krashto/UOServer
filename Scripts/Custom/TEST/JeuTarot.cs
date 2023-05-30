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
				from.SendMessage("L'objet doit �tre hors du sac");
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
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Nouvelle action, d�but d'un processus dans n'importe quel domaine." ));
						break;
					}
					case 1 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Papesse"));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "El�ment cach� pouvant �tre source de difficult�s ou de conflits."));
						break;
					}
					case 2 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Imp�ratrice" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Arriv�e d'un courrier, d'une nouvelle, d'un fait heureux ou non. " ));
						break;
					}
					case 3 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Empereur" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Situation arriv�e �  maturit�." ));
						break;
					}
					case 4 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Pape" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "De par son caract�re religieux, toutes les c�r�monies comme le mariage, le bapt�me, sont annonc�s. Le Pape r�concilie." ));
						break;
					}
					case 5 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Amoureux" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "N�cessit� de faire un choix, annonce la faiblesse et l'�preuve." ));
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
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La notion d'�quilibre est ici fortement marqu�e." ));
						break;
					}
					case 8 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Hermite" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Un long chemin �  parcourir, des difficult�s, la solitude �galement." ));
						break;
					}
					case 9 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Roue de Fortune" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Un d�blocage d'une situation, un changement (en bien ou en mal) dans n'importe quel domaine." ));
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
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Blocage, attente, impossibilit� de r�agir, solitude." ));
						break;
					}
					case 12 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("L'Arcane sans Nom"));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Une lib�ration, un changement important. Elle lib�re souvent d'une situation devenue intol�rable."));
						break;
					}              
					case 13 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Temp�rance" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Modification, voyage, nouvelle rencontre, passage d'une situation �  une autre (en mal ou en bien).") );
						break;
					}
					case 14 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Diable" ));
                        this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Tromperie, adult�re, mauvaise nouvelle, relation fugace, consultant aveugl� par son �goïsme. Dans le meilleur des cas, cette lame signifie une rentr�e d'argent."));
						break;
					}
					case 15 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Maison Dieu" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Rupture, �chec, divorce, maladie, accident." ));
						break;
					}
					case 16 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "L'Etoile" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Apaise, apporte le r�confort apr�s l'�preuve. Gu�rison, r�ussite, rencontre avec l'âme soeur.") );
						break;
					}                        
					case 17 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "La Lune" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "P�riode obscure, d�pression, situation peu claire, illusions.") );
						break;
					}              
					case 18 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Soleil" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "R�ussite, bonheur, une rencontre amoureuse, le mariage, rentr�e d'erofith.") );
						break;
					}
					case 19 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Jugement" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Une nouvelle qui arrive, d�nouement d'une situation, changement brusque, renouveau. L'effet de cette lame est foudroyant par sa rapidit�.") );
						break;    
					}        
					case 20 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Monde" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Lame de r�ussite, succ�s aux examens,concr�tisation b�n�fique, cette lame est tr�s positive. M�me dans le cas d'une infid�lit� amoureuse, elle pr�dit le retour de l'infid�le." ));
						break;
					}
					case 21 :
					{
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Le Mat" ));
						this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format( "Abandon, lachet�, d�part non pr�par�, fuite devant ses responsabilit�s, mais aussi plus pratiquement un voyage." ));
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