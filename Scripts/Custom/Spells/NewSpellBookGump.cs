using System; 
using System.Collections; 
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 
using Server.Spells; 
using Server.Custom.Aptitudes;

namespace Server.Gumps
{
    public class SpellBookEntry
    {
        public int Level { get; private set; }
        public string Name { get; private set; }
		public Type[] Reagents { get; private set; }
		public Aptitude Aptitude { get; private set; }
		public int SpellID { get; private set; }
		public string Description { get; private set; }

		public SpellBookEntry(int level, Aptitude aptitude, string name, Type[] regs, int spellid, string description)
        {
            Level = level;
            Name = name;
            Reagents = regs;
            Aptitude = aptitude;
            SpellID = spellid;
			Description = description;
		}
	}

    public class NewSpellbookGump : Gump
    {
		public static SpellBookEntry[] m_SpellBookEntry = new SpellBookEntry[]
		{
			new SpellBookEntry( 1, Aptitude.Aeromancie, "Aveuglement", new Type[] { typeof(EssenceAeromancie) }, 600, "R�duction des chances de toucher de la cible"),
			new SpellBookEntry( 2, Aptitude.Aeromancie, "Brouillard", new Type[] { typeof(EssenceAeromancie) }, 601, "Rend invisible la cible."),
			new SpellBookEntry( 3, Aptitude.Aeromancie, "T�l�portation", new Type[] { typeof(EssenceAeromancie) }, 602, "Permet de vous t�l�porter sur la case de votre choix."),
			new SpellBookEntry( 4, Aptitude.Aeromancie, "Tornado", new Type[] { typeof(EssenceAeromancie) }, 603, "Cr�e un champ de force autour de vous qui pousse les ennemis qui vous approchent."),
			new SpellBookEntry( 5, Aptitude.Aeromancie, "Aura �vasive", new Type[] { typeof(EssenceAeromancie) }, 604, "Procure un bouclier de points de vie � vos alli�s."),
			new SpellBookEntry( 6, Aptitude.Aeromancie, "Ex-T�l�portation", new Type[] { typeof(EssenceAeromancie) }, 605, "Permet d'interchanger votre place avec votre cible."),
			new SpellBookEntry( 7, Aptitude.Aeromancie, "Toucher suffocant", new Type[] { typeof(EssenceAeromancie) }, 606, "Rend muet votre cible, l'emp�chant de lancer des sorts."),
            new SpellBookEntry( 8, Aptitude.Aeromancie, "Aura de brouillard", new Type[] { typeof(EssenceAeromancie) }, 607, "Rend invisible les alli�s autour de vous."),
			new SpellBookEntry( 9, Aptitude.Aeromancie, "Vent favorable", new Type[] { typeof(EssenceAeromancie) }, 608, "Vous procure la rapidit� de d�placement � pieds d'un cheval."),
			new SpellBookEntry( 10, Aptitude.Aeromancie, "Vortex", new Type[] { typeof(EssenceAeromancie) }, 609, "Cr�e une zone de temp�te, envoyant des �clairs ici et l� � ceux qui traversent la zone."),

            new SpellBookEntry( 1, Aptitude.Chasseur, "Antidote", new Type[] { typeof(EssenceChasseur) }, 610, "Permet de gu�rir le poison sur soi-m�me."),
			new SpellBookEntry( 2, Aptitude.Chasseur, "Marquer", new Type[] { typeof(EssenceChasseur) }, 611, "Marque une cible et gagne de la rapidit� d'attaque."),
			new SpellBookEntry( 3, Aptitude.Chasseur, "Compagnon animal", new Type[] { typeof(EssenceChasseur) }, 612, "Permet d'invoquer un compagnon animal."),
			new SpellBookEntry( 4, Aptitude.Chasseur, "Soin animalier", new Type[] { typeof(EssenceChasseur) }, 613, "Permet de soigner son compagnon animal."),
			new SpellBookEntry( 5, Aptitude.Chasseur, "Rugissement", new Type[] { typeof(EssenceChasseur) }, 614, "Ordonne � votre compagnon animal de rugir, attirant vers lui les cr�atures autour de lui."),
			new SpellBookEntry( 6, Aptitude.Chasseur, "Frappe ensanglant�e", new Type[] { typeof(EssenceChasseur) }, 615, "Permet de faire saigner une cible, l'emp�chant par le fait m�me de se soigner."),
			new SpellBookEntry( 7, Aptitude.Chasseur, "Saut aggressif", new Type[] { typeof(EssenceChasseur) }, 616, "Permet de reculer de quelques cas tout en frappant la cible."),
			new SpellBookEntry( 8, Aptitude.Chasseur, "Coup dans le genou", new Type[] { typeof(EssenceChasseur) }, 617, "Emp�che la cible de courir."),
			new SpellBookEntry( 9, Aptitude.Chasseur, "Chasseur de prime", new Type[] { typeof(EssenceChasseur) }, 618, "Si la cible est touch�e par le sort Marquer, ces r�sistances sont diminu�es drastiquement."),
            new SpellBookEntry( 10, Aptitude.Chasseur, "Contrat r�solu", new Type[] { typeof(EssenceChasseur) }, 619, "Si la cible est marqu�e, ne peut plus courir* et est ensanglant�e, vous t�l�porte sur la cible pour la tuer d'un coup. *Le fait de frapper ou d'ensanglanter une cible lui retire l'emp�chement de courir, alors soyez rapide ou soyez plusieurs!"),

			new SpellBookEntry( 1, Aptitude.Defenseur, "Coup de bouclier", new Type[] { typeof(EssenceDefenseur) }, 620, "Donne un coup de bouclier � la cible."),
			new SpellBookEntry( 2, Aptitude.Defenseur, "Bravage", new Type[] { typeof(EssenceDefenseur) }, 621, "Provoque une cible."),
			new SpellBookEntry( 3, Aptitude.Defenseur, "D�votion", new Type[] { typeof(EssenceDefenseur) }, 622, "Augmente ces points de vie maximun."),
			new SpellBookEntry( 4, Aptitude.Defenseur, "Mutinerie", new Type[] { typeof(EssenceDefenseur) }, 623, "Provoque toutes les cr�atures autour de vous."),
			new SpellBookEntry( 5, Aptitude.Defenseur, "Mentor", new Type[] { typeof(EssenceDefenseur) }, 624, "Procure de la r�duction de co�t de mana sur votre cible."),
			new SpellBookEntry( 6, Aptitude.Defenseur, "Lien de vie", new Type[] { typeof(EssenceDefenseur) }, 625, "La moiti� des d�g�ts re�us sur votre cible vous est transf�r�e."),
			new SpellBookEntry( 7, Aptitude.Defenseur, "Miracle", new Type[] { typeof(EssenceDefenseur) }, 626, "Ressuscite un joueur. Vous devez cibler son corps inerte."),
			new SpellBookEntry( 8, Aptitude.Defenseur, "Indomptable", new Type[] { typeof(EssenceDefenseur) }, 627, "La cible est immunit�e contre la paralysie, le sommeil, l'emp�chement de bouger et l'emp�chement de courir."),
			new SpellBookEntry( 9, Aptitude.Defenseur, "Insensible", new Type[] { typeof(EssenceDefenseur) }, 628, "La cible est immunit�e contre le poison, le saignement, l'emp�chement de se soigner et � la mal�diction."),
			new SpellBookEntry( 10, Aptitude.Defenseur, "Pieds au sol", new Type[] { typeof(EssenceDefenseur) }, 629, "Vous cloue au sol, mais les d�g�ts re�us sont r�duits."),

			new SpellBookEntry( 1, Aptitude.Geomancie, "Fortifi�", new Type[] { typeof(EssenceGeomancie) }, 630, "Augmente votre r�sistance physique."),
			new SpellBookEntry( 2, Aptitude.Geomancie, "Roche", new Type[] { typeof(EssenceGeomancie) }, 631, "Lance une roche sur la cible."),
			new SpellBookEntry( 3, Aptitude.Geomancie, "Contamination", new Type[] { typeof(EssenceGeomancie) }, 632, "Empoisonne la cible."),
			new SpellBookEntry( 4, Aptitude.Geomancie, "Empalement", new Type[] { typeof(EssenceGeomancie) }, 633, "Lance des �pines autour de vous, ensanglante les cibles touch�es."),
			new SpellBookEntry( 5, Aptitude.Geomancie, "Aura fortifiante", new Type[] { typeof(EssenceGeomancie) }, 634, "Augmente la r�sistance physique de vous et vos alli�s."),
			new SpellBookEntry( 6, Aptitude.Geomancie, "Mur de plante", new Type[] { typeof(EssenceGeomancie) }, 635, "Invoque un mur de plante qui empoisonne les cibles autour."),
			new SpellBookEntry( 7, Aptitude.Geomancie, "Explosion de roche", new Type[] { typeof(EssenceGeomancie) }, 636, "Permet de faire exploser sa r�sistance physique et d'envoyer des pierres sur les cibles autour. *Les sorts Fortifi� et Aura fortifiante augmentent les d�g�ts du sort."),
			new SpellBookEntry( 8, Aptitude.Geomancie, "Aura Pr�serv. Manaique", new Type[] { typeof(EssenceGeomancie) }, 637, "Procure de la r�duction de co�t de mana � vous et vos alli�s."),
			new SpellBookEntry( 9, Aptitude.Geomancie, "Racines", new Type[] { typeof(EssenceGeomancie) }, 638, "Enracine une cible, l'emp�chant de bouger."),
			new SpellBookEntry( 10, Aptitude.Geomancie, "Fl�au terrestre", new Type[] { typeof(EssenceGeomancie) }, 639, "Endommage, empoisonne et emp�che de se soigner les ennemis autour de vous."),

			new SpellBookEntry( 1, Aptitude.Guerison, "Main cicatrisante", new Type[] { typeof(EssenceGuerison) }, 640, "Permet de lancer un sortil�ge de soin."),
			new SpellBookEntry( 2, Aptitude.Guerison, "Rem�de", new Type[] { typeof(EssenceGuerison) }, 641, "Permet de gu�rir le poison d'une cible."),
			new SpellBookEntry( 3, Aptitude.Guerison, "Mur de pierre", new Type[] { typeof(EssenceGuerison) }, 642, "Invoque un mur de pierre."),
			new SpellBookEntry( 4, Aptitude.Guerison, "Rayon c�leste", new Type[] { typeof(EssenceGuerison) }, 643, "Permet de lancer un sortil�ge de soin am�lior�."),
			new SpellBookEntry( 5, Aptitude.Guerison, "Don de la vie", new Type[] { typeof(EssenceGuerison) }, 649, "Ressuscite un joueur. Vous devez cibler son corps inerte."),
			new SpellBookEntry( 6, Aptitude.Guerison, "Frayeur", new Type[] { typeof(EssenceGuerison) }, 645, "Votre cible est prise de peur."),
			new SpellBookEntry( 7, Aptitude.Guerison, "Ferveur divine", new Type[] { typeof(EssenceGuerison) }, 646, "Permet d�interchanger vos points de mana avec votre cible."),
			new SpellBookEntry( 8, Aptitude.Guerison, "Inquisition", new Type[] { typeof(EssenceGuerison) }, 647, "Augmente votre rapidit� de lancer des sorts, vos sorts de soins sont am�lior�s et vos murs durent plus longtemps."),
			new SpellBookEntry( 9, Aptitude.Guerison, "Mur de lumi�re", new Type[] { typeof(EssenceGuerison) }, 648, "Permet de lancer un mur de paralysie."),
			new SpellBookEntry( 10, Aptitude.Guerison, "Lumi�re sacr�", new Type[] { typeof(EssenceGuerison) }, 644, "Endommage les ennemis et soigne les alli�s autour de votre cible."),

			new SpellBookEntry( 1, Aptitude.Hydromancie, "Armure de glace", new Type[] { typeof(EssenceHydromancie) }, 650, "Augmente votre r�sistance au froid."),
			new SpellBookEntry( 2, Aptitude.Hydromancie, "Restauration", new Type[] { typeof(EssenceHydromancie) }, 651, "Procure une reg�n�ration de points de vie � votre cible."),
			new SpellBookEntry( 3, Aptitude.Hydromancie, "Soin pr�ventif", new Type[] { typeof(EssenceHydromancie) }, 652, "Permet de se t�l�porter sur un alli� et lui appliquer le sort Restauration."),
			new SpellBookEntry( 4, Aptitude.Hydromancie, "Cage de glace", new Type[] { typeof(EssenceHydromancie) }, 653, "Entoure une cible de mur de glace, l'emp�chant de bouger."),
			new SpellBookEntry( 5, Aptitude.Hydromancie, "Aura cryog�nis�e", new Type[] { typeof(EssenceHydromancie) }, 654, "Augmente la r�sistance au froid de vous et vos alli�s."),
			new SpellBookEntry( 6, Aptitude.Hydromancie, "Pieux de glace", new Type[] { typeof(EssenceHydromancie) }, 655, "La cible est assaillit de pieux de glace qui explosent autour d'elle."),
			new SpellBookEntry( 7, Aptitude.Hydromancie, "Cerveau gel�", new Type[] { typeof(EssenceHydromancie) }, 656, "Si la cible est affect�e par le sort 'Blizzard' ou 'Cage de glace', ses points de vie sont r�duits � la moiti� de son maximum."),
			new SpellBookEntry( 8, Aptitude.Hydromancie, "Aura r�frig�rante", new Type[] { typeof(EssenceHydromancie) }, 657, "Applique le sort Restauration � vous et aux alli�s autour de vous."),
			new SpellBookEntry( 9, Aptitude.Hydromancie, "Avatar du froid", new Type[] { typeof(EssenceHydromancie) }, 658, "Vous cloue les pieds au sol, mais vos sorts de soin sont am�lior�s."),
			new SpellBookEntry( 10, Aptitude.Hydromancie, "Blizzard", new Type[] { typeof(EssenceHydromancie) }, 659, "Cr�e une zone de blizzard, emp�chant les ennemis de courir et leur fait perdre de la stamina."),

			new SpellBookEntry( 1, Aptitude.Martial, "Second souffle", new Type[] { typeof(EssenceMartial) }, 660, "Augmente les points de vie."),
			new SpellBookEntry( 2, Aptitude.Martial, "Provocation", new Type[] { typeof(EssenceMartial) }, 661, "La cible est attir�e vers vous."),
			new SpellBookEntry( 3, Aptitude.Martial, "Saut d�vastateur", new Type[] { typeof(EssenceMartial) }, 662, "Saute de quelques cases et cr�e une zone de feu lors de l'impact."),
			new SpellBookEntry( 4, Aptitude.Martial, "Duel", new Type[] { typeof(EssenceMartial) }, 663, "Gagne un bonus de d�g�ts contre la cible."),
			new SpellBookEntry( 5, Aptitude.Martial, "Charge furieuse", new Type[] { typeof(EssenceMartial) }, 664, "Charge vers la cible, la repoussant lors de l'impact."),
			new SpellBookEntry( 6, Aptitude.Martial, "Enrag�", new Type[] { typeof(EssenceMartial) }, 665, "R�duit sa r�sistance physique, mais augmente ses d�g�ts physiques."),
			new SpellBookEntry( 7, Aptitude.Martial, "Bouclier magique", new Type[] { typeof(EssenceMartial) }, 666, "Permet de renvoyer le prochain sort sur vous sur le lanceur du sort."),
			new SpellBookEntry( 8, Aptitude.Martial, "Commandement", new Type[] { typeof(EssenceMartial) }, 667, "Augmente vos points de vie et ceux de vos alli�s."),
			new SpellBookEntry( 9, Aptitude.Martial, "Pr�sence inspirante", new Type[] { typeof(EssenceMartial) }, 668, "Augmente la reg�n�ration de vos points de vie et celle de vos alli�s."),
			new SpellBookEntry( 10, Aptitude.Martial, "Ange gardien", new Type[] { typeof(EssenceMartial) }, 669, "Vous perdez des points de vie, mais votre r�sistance est grandement am�lior�e."),

			new SpellBookEntry( 1, Aptitude.Musique, "Diversion", new Type[] { typeof(EssenceMusique) }, 670, "Permet d�attirer l�attention d�un monstre sur une cible*. *Ciblez le sol."),
			new SpellBookEntry( 2, Aptitude.Musique, "Calme toi!", new Type[] { typeof(EssenceMusique) }, 671, "Apaise une cr�ature."),
			new SpellBookEntry( 3, Aptitude.Musique, "D�sorient�", new Type[] { typeof(EssenceMusique) }, 672, "D�soriente une cr�ature."),
			new SpellBookEntry( 4, Aptitude.Musique, "D�fi", new Type[] { typeof(EssenceMusique) }, 673, "Provoque une cr�ature sur une autre."),
			new SpellBookEntry( 5, Aptitude.Musique, "Descescendo maniaque", new Type[] { typeof(EssenceMusique) }, 674, "Procure de la r�duction de co�t de mana � vous et vos alli�s."),
			new SpellBookEntry( 6, Aptitude.Musique, "Inspiration �l�mentaire", new Type[] { typeof(EssenceMusique) }, 675, "Ajoute des effets magiques � votre arme de mani�re al�atoire (Ex: boule de feu, �clair, etc)"),
			new SpellBookEntry( 7, Aptitude.Musique, "Absorbation sonore", new Type[] { typeof(EssenceMusique) }, 676, "Permet de drainer la mana des ennemis autour de vous."),
			new SpellBookEntry( 8, Aptitude.Musique, "Parfaite aspiration", new Type[] { typeof(EssenceMusique) }, 677, "Augmente la concentration d'une cible, ce qui lui emp�che de r�ter un sort lorsqu'elle est touch�e."),
			new SpellBookEntry( 9, Aptitude.Musique, "R�v�lation discordance", new Type[] { typeof(EssenceMusique) }, 678, "Permet de r�v�ler tous les invisibles de votre �cran et les d�soriente."),
			new SpellBookEntry( 10, Aptitude.Musique, "Havre de paix", new Type[] { typeof(EssenceMusique) }, 679, "Apaise toutes les cr�atures autour de vous."),

			new SpellBookEntry( 1, Aptitude.Necromancie, "Soif de sang", new Type[] { typeof(EssenceNecromancie) }, 680, "Ensanglante la cible."),
			new SpellBookEntry( 2, Aptitude.Necromancie, "Touch� absorbant", new Type[] { typeof(EssenceNecromancie) }, 681, "Permet de se soigner en ciblant un corp inerte au sol."),
			new SpellBookEntry( 3, Aptitude.Necromancie, "Infection", new Type[] { typeof(EssenceNecromancie) }, 682, "Applique une mal�diction sur la cible."),
			new SpellBookEntry( 4, Aptitude.Necromancie, "Armure d'os", new Type[] { typeof(EssenceNecromancie) }, 683, "Vous procure un aura qui r�fl�te les d�g�ts."),
			new SpellBookEntry( 5, Aptitude.Necromancie, "Familier morbide", new Type[] { typeof(EssenceNecromancie) }, 684, "Invoque une cr�ature morbide."),
			new SpellBookEntry( 6, Aptitude.Necromancie, "R�animation", new Type[] { typeof(EssenceNecromancie) }, 685, "Permet de relever les cadavres."),
			new SpellBookEntry( 7, Aptitude.Necromancie, "Consommation mortelle", new Type[] { typeof(EssenceNecromancie) }, 686, "Permet de consommer l'existance d'une cr�ature invoqu�es et de se soigner."),
			new SpellBookEntry( 8, Aptitude.Necromancie, "Aura vampirique", new Type[] { typeof(EssenceNecromancie) }, 687, "Donne un aura de regain de vie � ses alli�s quand ils sont des d�g�ts."),
			new SpellBookEntry( 9, Aptitude.Necromancie, "Appel du sang", new Type[] { typeof(EssenceNecromancie) }, 688, "Invoque un �l�mentaire de sang."),
			new SpellBookEntry( 10, Aptitude.Necromancie, "Pluie de sang", new Type[] { typeof(EssenceNecromancie) }, 689, "Ensanglante et applique une mal�diction aux ennemis autour de soi."),

			new SpellBookEntry( 1, Aptitude.Polymorphie, "Forme cyclonique", new Type[] { typeof(EssencePolymorphie) }, 690, "Gagne un bonus de comp�tence 'Hiding'."),
			new SpellBookEntry( 2, Aptitude.Polymorphie, "Forme m�tallique", new Type[] { typeof(EssencePolymorphie) }, 691, "Procure une meilleure reg�n�ration de points de vie."),
			new SpellBookEntry( 3, Aptitude.Polymorphie, "Forme terrestre", new Type[] { typeof(EssencePolymorphie) }, 692, "Augmente votre r�sistance phjysique, mais diminue votre r�sistance au feu et � l'�nergie."),
			new SpellBookEntry( 4, Aptitude.Polymorphie, "Forme empoisonn�e", new Type[] { typeof(EssencePolymorphie) }, 693, "Permet d'appliquer un poison lorsque vous frappez une cible."),
			new SpellBookEntry( 5, Aptitude.Polymorphie, "Forme givrante", new Type[] { typeof(EssencePolymorphie) }, 694, "Augmente vos d�g�ts physiques et votre r�g�n�ration de points de vie."),
			new SpellBookEntry( 6, Aptitude.Polymorphie, "Forme liquide", new Type[] { typeof(EssencePolymorphie) }, 695, "Procure un bonus de gu�rison avec les bandages sur soi-m�me."),
			new SpellBookEntry( 7, Aptitude.Polymorphie, "Forme cristalline", new Type[] { typeof(EssencePolymorphie) }, 696, "Augmente votre reg�n�ration de mana, mais vous perdez des points de vie. Augmente votre r�sistance au froid et poison."),
			new SpellBookEntry( 8, Aptitude.Polymorphie, "Forme �lectrisante", new Type[] { typeof(EssencePolymorphie) }, 697, "Augmente votre vitesse de d�placement, de pr�cision des coups et vos points de vie."),
			new SpellBookEntry( 9, Aptitude.Polymorphie, "Forme enflamm�e", new Type[] { typeof(EssencePolymorphie) }, 698, "Br�le les ennemis qui sont trop pr�s de vous."),
			new SpellBookEntry( 10, Aptitude.Polymorphie, "Forme ensanglant�e", new Type[] { typeof(EssencePolymorphie) }, 699, "Procure un regain de vie lors de coups, augmente votre reg�n�ration de mana et de stamina. Vous �tes immunis� aux poisons, mais vous perdez de la r�sistance au feu."),

			new SpellBookEntry( 1, Aptitude.Pyromancie, "Bouclier de feu", new Type[] { typeof(EssencePyromancie) }, 700, "Augmente votre r�sistance au feu."),
			new SpellBookEntry( 2, Aptitude.Pyromancie, "Boule de feu", new Type[] { typeof(EssencePyromancie) }, 701, "Lance une boule de feu."),
			new SpellBookEntry( 3, Aptitude.Pyromancie, "C�l�rit�", new Type[] { typeof(EssencePyromancie) }, 702, "Augmente la vitesse d'attaque de votre cible."),
			new SpellBookEntry( 4, Aptitude.Pyromancie, "Supernova", new Type[] { typeof(EssencePyromancie) }, 703, "Permet de lancer des boules de feu autour de vous."),
			new SpellBookEntry( 5, Aptitude.Pyromancie, "Aura r�chauffante", new Type[] { typeof(EssencePyromancie) }, 704, "Augmente la r�sistance au feu de vous et vos alli�s."),
			new SpellBookEntry( 6, Aptitude.Pyromancie, "Fr�n�sie douloureuse", new Type[] { typeof(EssencePyromancie) }, 705, "Votre cible est attir�e vers vous tout en �tant br�l�e."),
			new SpellBookEntry( 7, Aptitude.Pyromancie, "Folie ardente", new Type[] { typeof(EssencePyromancie) }, 706, "Br�le votre cible de mani�re r�p�titive."),
			new SpellBookEntry( 8, Aptitude.Pyromancie, "Aura d'exaltation", new Type[] { typeof(EssencePyromancie) }, 707, "Augmente la vitesse d'attaque de vous et de vos alli�s."),
			new SpellBookEntry( 9, Aptitude.Pyromancie, "Cage de feu", new Type[] { typeof(EssencePyromancie) }, 708, "La cible est t�l�port�e � vous, vous entourant tous les deux d'une cage de feu. Tous les gens entour�s par la cage de feu ne peuvent s'en �chapper."),
			new SpellBookEntry( 10, Aptitude.Pyromancie, "Passion ardente", new Type[] { typeof(EssencePyromancie) }, 709, "Une partie des d�g�ts de feu re�us vous soigne. Une partie des d�g�ts de feu envoy�s vous soigne �galement."),

			new SpellBookEntry( 1, Aptitude.Roublardise, "Adr�naline", new Type[] { typeof(EssenceRoublardise) }, 710, "Augmente votre reg�n�ration de stamina."),
			new SpellBookEntry( 2, Aptitude.Roublardise, "Sommeil", new Type[] { typeof(EssenceRoublardise) }, 711, "Endort une cible."),
			new SpellBookEntry( 3, Aptitude.Roublardise, "Lancer pr�cis", new Type[] { typeof(EssenceRoublardise) }, 712, "Lance un couteau qui ensanglante votre cible."),
			new SpellBookEntry( 4, Aptitude.Roublardise, "Coup arri�re", new Type[] { typeof(EssenceRoublardise) }, 713, "Permet de se t�l�porter en arri�re de votre cible pour la frapper."),
			new SpellBookEntry( 5, Aptitude.Roublardise, "�vasion", new Type[] { typeof(EssenceRoublardise) }, 714, "Permet de se t�l�porter � une case al�atoire et vous rend invisible."),
			new SpellBookEntry( 6, Aptitude.Roublardise, "Attirance", new Type[] { typeof(EssenceRoublardise) }, 715, "T�l�porte une cible vers vous."),
			new SpellBookEntry( 7, Aptitude.Roublardise, "Main bless�e", new Type[] { typeof(EssenceRoublardise) }, 716, "D�sarmera la prochaine personne que vous frapperez."),
			new SpellBookEntry( 8, Aptitude.Roublardise, "Coupure des tendons", new Type[] { typeof(EssenceRoublardise) }, 717, "Ensanglante une cible et l'emp�che de courir."),
			new SpellBookEntry( 9, Aptitude.Roublardise, "Gas endormant", new Type[] { typeof(EssenceRoublardise) }, 718, "Endort les ennemis autour de votre cible."),
			new SpellBookEntry( 10, Aptitude.Roublardise, "Coup mortel", new Type[] { typeof(EssenceRoublardise) }, 719, "Si les points de vie de votre cible sont sous la barre des 20%, la cible est ex�cut�e."),

			new SpellBookEntry( 1, Aptitude.Totemique, "Totem de feu", new Type[] { typeof(EssenceTotemique) }, 720, "Invoque un totem de feu qui lance des boules de feu."),
			new SpellBookEntry( 2, Aptitude.Totemique, "Totem de l'eau", new Type[] { typeof(EssenceTotemique) }, 721, "Invoque un totem d'eau qui vous soigne."),
			new SpellBookEntry( 3, Aptitude.Totemique, "Totem de terre", new Type[] { typeof(EssenceTotemique) }, 722, "Invoque un totem de terre qui attirent les ennemis autour de lui."),
			new SpellBookEntry( 4, Aptitude.Totemique, "Totem de vent", new Type[] { typeof(EssenceTotemique) }, 723, "Invoque un totem de vent qui lance des �clairs."),
			new SpellBookEntry( 5, Aptitude.Totemique, "Absorbation", new Type[] { typeof(EssenceTotemique) }, 724, "Absorbe un totem pour regagner de la vie, de la stamina et de la mana."),
			new SpellBookEntry( 6, Aptitude.Totemique, "Lier par l'esprit", new Type[] { typeof(EssenceTotemique) },  725, "Permet de t�l�porter les totems sur soi."),
			new SpellBookEntry( 7, Aptitude.Totemique, "Supercharger", new Type[] { typeof(EssenceTotemique) }, 726, "Am�liore la puissance des totems."),
			new SpellBookEntry( 8, Aptitude.Totemique, "Mur tot�mique", new Type[] { typeof(EssenceTotemique) }, 727, "Permet d'invoquer un mur de totems d'�nergie, vous emp�chant de les traverser.."),
			new SpellBookEntry( 9, Aptitude.Totemique, "Appel spirituel", new Type[] { typeof(EssenceTotemique) }, 728, "Permet de retourner une cible � la ville."),
			new SpellBookEntry( 10, Aptitude.Totemique, "Marche � suivre", new Type[] { typeof(EssenceTotemique) }, 729, "Permet aux totems de vous suivre."),
        };

        public bool HasSpell(int spellID)
        {
            return m_Book.HasSpell(spellID);
        }
        
        #region tableaux
        //Liste des magies du spellbook et leur couleur
        public Aptitude[] m_AptitudeList = new Aptitude[] {
			Aptitude.Martial,
			Aptitude.Chasseur,
			Aptitude.Roublardise,
			Aptitude.Polymorphie,
			Aptitude.Totemique,
			Aptitude.Musique,
			Aptitude.Hydromancie,
			Aptitude.Pyromancie,
			Aptitude.Geomancie,
			Aptitude.Aeromancie,
			Aptitude.Necromancie,
			Aptitude.Defenseur,
			Aptitude.Guerison,
		};

        public Hashtable m_NameColors = new Hashtable();
        public Hashtable m_Names = new Hashtable();
        public Hashtable m_Symbols = new Hashtable();

        public void InitializeHashtable()
        {
            m_NameColors[Aptitude.Aeromancie] = 1153;
			m_NameColors[Aptitude.Chasseur] = 1050;
			m_NameColors[Aptitude.Defenseur] = 2006;
			m_NameColors[Aptitude.Geomancie] = 1190;
			m_NameColors[Aptitude.Guerison] = 2006;
			m_NameColors[Aptitude.Hydromancie] = 1264;
			m_NameColors[Aptitude.Martial] = 1105;
			m_NameColors[Aptitude.Musique] = 1250;
			m_NameColors[Aptitude.Necromancie] = 1991;
			m_NameColors[Aptitude.Polymorphie] = 1129;
			m_NameColors[Aptitude.Pyromancie] = 1258;
			m_NameColors[Aptitude.Roublardise] = 1109;
            m_NameColors[Aptitude.Totemique] = 1139;

			m_Names[Aptitude.Aeromancie] = "A�romancie";
			m_Names[Aptitude.Chasseur] = "Chasseur";
			m_Names[Aptitude.Defenseur] = "D�fenseur";
			m_Names[Aptitude.Geomancie] = "G�omancie";
			m_Names[Aptitude.Guerison] = "Gu�rison";
			m_Names[Aptitude.Hydromancie] = "Hydromancie";
			m_Names[Aptitude.Martial] = "Martial";
			m_Names[Aptitude.Musique] = "Musique";
			m_Names[Aptitude.Necromancie] = "N�cromancie";
			m_Names[Aptitude.Polymorphie] = "Polymorphie";
			m_Names[Aptitude.Pyromancie] = "Pyromancie";
			m_Names[Aptitude.Roublardise] = "Roublardise";
			m_Names[Aptitude.Totemique] = "Tot�mique";
		}
        #endregion

        private NewSpellbook m_Book;
        private int m_Page;
		private const int EntriesPerPage = 20;

		public NewSpellbookGump(Mobile from, NewSpellbook book, int page) : base(150, 200)
        {
            InitializeHashtable();

            m_Book = book;
			m_Page = page;
            int vindex = 0;
            int hindex = 0;

			if (!(from is CustomPlayerMobile))
                return;

            CustomPlayerMobile pm = (CustomPlayerMobile)from;

            AddImage(100, 10, 500);

			//On ajoute les boutons de changement de page
			if (m_Page < (m_SpellBookEntry.Length / EntriesPerPage))
				AddButton(456, 10, 502, 502, 18, GumpButtonType.Reply, 0);
			else if (m_Page == m_SpellBookEntry.Length / EntriesPerPage)
				AddButton(456, 10, 502, 502, 20, GumpButtonType.Reply, 0);

			if (m_Page > 0)
				AddButton(100, 10, 501, 501, 19, GumpButtonType.Reply, 0);

			AddPage(0);

			//Pour tous les sorts
			for (int i = m_Page * EntriesPerPage, count = 0; count < EntriesPerPage && i < m_SpellBookEntry.Length; ++i, count++)
			{
				var entry = m_SpellBookEntry[i];

				if (count % EntriesPerPage == 0)
				{
					vindex = 0;
					hindex = 0;
					AddLabel(180 + hindex * 190, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				if (count % (EntriesPerPage / 2) == 0 && count % EntriesPerPage != 0)
				{
					vindex = 0;
					hindex = 1;
					AddLabel(180 + hindex * 190, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				// S�parateurs
				AddImageTiled(140 + hindex * 190, 40, 130, 10, 0x3A);

				//Si le livre poss�de le sort
				if (HasSpell(entry.SpellID) && ArrayContains(m_AptitudeList, entry.Aptitude))
				{
					//On ajoute l'information et les boutons
					AddLabel(163 + hindex * 190, 54 + (vindex * 15), 0, entry.Name);
					AddButton(128 + hindex * 190, 59 + (vindex * 15), 2103, 2104, entry.SpellID, GumpButtonType.Reply, 0); //Cast
					AddButton(140 + hindex * 190, 57 + (vindex * 15), 2224, 2224, 1000 + entry.SpellID, GumpButtonType.Reply, 0); //Info
					vindex++;
				}
			}

			//Pour tous les sorts
			if (m_Page > m_SpellBookEntry.Length / EntriesPerPage)
			{
				for (int i = (m_Page - (int)Math.Ceiling((double)m_SpellBookEntry.Length / EntriesPerPage)), count = 0; count < 1 && i < m_SpellBookEntry.Length; ++i, count++)
				{
					SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

					//Si le livre poss�de le sort
					if (this.HasSpell(info.SpellID) && ArrayContains(m_AptitudeList, info.Aptitude))
					{
						hindex = 0;

						//On ajoute les boutons de pages
						if (i > 0)
							AddButton(100, 10, 501, 501, 21, GumpButtonType.Reply, 0);
						else
							AddButton(100, 10, 501, 501, 19, GumpButtonType.Reply, 0);

						if (i < m_SpellBookEntry.Length)
							AddButton(456, 10, 502, 502, 20, GumpButtonType.Reply, 0);

						int namecolor = 0;
						string name = "...";

						if (m_NameColors.Contains(info.Aptitude))
							namecolor = (int)m_NameColors[info.Aptitude] - 1;

						if (m_Names.Contains(info.Aptitude))
							name = (string)m_Names[info.Aptitude];

						//On ajoute le nom
						AddButton(175 + hindex * 190, 22, 2223, 2223, 100 + ((info.SpellID - 600) / EntriesPerPage), GumpButtonType.Reply, 0);
						AddLabel(200 + hindex * 190, 20, namecolor, name);
						AddButton(140 + hindex * 190, 44, 2103, 2104, info.SpellID, GumpButtonType.Reply, 0);
						AddLabel(155 + hindex * 190, 40, 0, info.Name);

						//On ajoute les s�parateurs
						AddImageTiled(140 + hindex * 190, 60, 130, 10, 0x3A);

						//On ajoute l'icone en tant que bouton pour lancer le sort
						AddLabel(140 + hindex * 190, 80, 0, $"Niveau : {info.Level}");
						AddLabel(140 + hindex * 190, 100, 0, $"Mana : {Spell.GetManaBase(info.Level)}");
						AddLabel(140 + hindex * 190, 120, 0, $"Temps : {Spell.GetCastDelayBase(info.Level).TotalSeconds}s");

						//On ajoute les infos diverses
						AddHtml(140 + hindex * 190, 140, 100, 20, "R�actifs:", false, false);
						for (int j = 0; j < info.Reagents.Length; j++)
						{
							Type type = (Type)info.Reagents[j];
							AddLabel(140 + hindex * 190, 160 + j * 20, 0, $"- {type.Name}");
						}

						hindex = 1;

						AddHtml(130 + hindex * 190, 25, 100, 20, "Description:", false, false);
						AddHtml(130 + hindex * 190, 45, 170, 180, info.Description, false, false);
					}
				}
			}
		}

        public bool ArrayContains(Aptitude[] conn, Aptitude wanted)
        {
            for (int i = 0; i < conn.Length; i++)
            {
                if (wanted == (Aptitude)conn[i])
                    return true;
            }

            return false;
        }

        public static SpellBookEntry FindEntryBySpellID(int spellID)
        {
            for (int i = 0; i < m_SpellBookEntry.Length; i++)
            {
                SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

                if (info.SpellID == spellID)
                    return info;
            }

            return null;
        }

        public class CompareSpellID : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                SpellBookEntry a = (SpellBookEntry)obj1;
                SpellBookEntry b = (SpellBookEntry)obj2;

                return ((int)a.SpellID).CompareTo(((int)b.SpellID));
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)from;

				if (info.ButtonID == 18 && m_Page < m_SpellBookEntry.Length / EntriesPerPage)
                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page + 1));
				else if (info.ButtonID == 19 && m_Page > 0)
					pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page - 1));
				else if (info.ButtonID == 20 && m_Page < (m_SpellBookEntry.Length / EntriesPerPage + m_SpellBookEntry.Length))
					pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page + 1));
				else if (info.ButtonID == 21 && m_Page >= (m_SpellBookEntry.Length / EntriesPerPage))
					pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page - 1));
				else if (info.ButtonID >= 100 && info.ButtonID < 200)
					pm.SendGump(new NewSpellbookGump(pm, m_Book, info.ButtonID - 100));
				else if (info.ButtonID >= 600 && info.ButtonID < 1000)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, pm, null);

                    if (spell != null)
                        spell.Cast();

                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page));
                }
				else if (info.ButtonID >= 1600 && info.ButtonID < 1800)
				{
					pm.SendGump(new NewSpellbookGump(pm, m_Book, (int)Math.Ceiling((double)m_SpellBookEntry.Length / EntriesPerPage) + info.ButtonID - 1600));
				}
			}
        }
    }
}