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
        public int AptitudeLevel { get; private set; }
        public string Nom { get; private set; }
		public Type[] Reagents { get; private set; }
		public int ImageID { get; private set; }
		public int Cercle { get; private set; }
		public Aptitude Aptitude { get; private set; }
		public int SpellID { get; private set; }
		public string Description { get; private set; }

		public SpellBookEntry(int conn, Aptitude connaissance, string nom, Type[] regs, int imageid, int cercle, int spellid, string description)
        {
            AptitudeLevel = conn;
            Nom = nom;
            Reagents = regs;
            ImageID = imageid;
            Cercle = cercle;
            Aptitude = connaissance;
            SpellID = spellid;
			Description = description;
		}
	}

    public class NewSpellbookGump : Gump
    {
		public static SpellBookEntry[] m_SpellBookEntry = new SpellBookEntry[]
		{
			new SpellBookEntry( 1, Aptitude.Aeromancie, "Aveuglement", new Type[] { typeof(Garlic), typeof(SpidersSilk), typeof(SulfurousAsh) }, 0x8c6, 1, 600, "Réduction des chances de toucher de la cible"),
			new SpellBookEntry( 2, Aptitude.Aeromancie, "Brouillard", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(BlackPearl) }, 0x8eb, 2, 601, "Rend invisible la cible."),
			new SpellBookEntry( 3, Aptitude.Aeromancie, "Téléportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8d5, 3, 602, "Permet de vous téléporter sur la case de votre choix."),
			new SpellBookEntry( 4, Aptitude.Aeromancie, "Tornado", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Ginseng) }, 0x128, 3, 603, "Crée un champ de force autour de vous qui pousse les ennemis qui vous approchent."),
			new SpellBookEntry( 5, Aptitude.Aeromancie, "Aura Évasive", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12e, 4, 604, "Procure un bouclier de points de vie à vos alliés."),
			new SpellBookEntry( 6, Aptitude.Aeromancie, "Ex-Téléportation", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8d5, 4, 605, "Permet d'interchanger votre place avec votre cible."),
			new SpellBookEntry( 7, Aptitude.Aeromancie, "Toucher suffocant", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8e8, 5, 606, "Rend muet votre cible, l'empêchant de lancer des sorts."),
            new SpellBookEntry( 8, Aptitude.Aeromancie, "Aura de brouillard", new Type[] { typeof(MandrakeRoot), typeof(Ginseng), typeof(SpidersSilk) }, 0x8ee, 6, 607, "Rend invisible les alliés autour de vous."),
			new SpellBookEntry( 9, Aptitude.Aeromancie, "Vent favorable", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x59e4, 7, 608, "Vous procure la rapidité de déplacement à pieds d'un cheval."),
			new SpellBookEntry( 10, Aptitude.Aeromancie, "Vortex", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(Bloodmoss) }, 0x148, 8, 609, "Crée une zone de tempête, envoyant des éclairs ici et là à ceux qui traversent la zone."),

            new SpellBookEntry( 1, Aptitude.Chasseur, "Antidote", new Type[] { typeof(Garlic), typeof(Ginseng) }, 0x8ca, 1, 610, "Permet de guérir le poison sur soi-même."),
			new SpellBookEntry( 2, Aptitude.Chasseur, "Marquer", new Type[] { typeof(Nightshade), typeof(BlackPearl), typeof(Garlic) }, 0x8e9, 2, 611, "Marque une cible et gagne de la rapidité d'attaque."),
			new SpellBookEntry( 3, Aptitude.Chasseur, "Compagnon animal", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x8dd, 3, 612, "Permet d'invoquer un compagnon animal."),
			new SpellBookEntry( 4, Aptitude.Chasseur, "Soin animalier", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(Bloodmoss) }, 0x8ea, 4, 613, "Permet de soigner son compagnon animal."),
			new SpellBookEntry( 5, Aptitude.Chasseur, "Rugissement", new Type[] { typeof(Garlic), typeof(SulfurousAsh), typeof(Ginseng) }, 0x08e5, 4, 614, "Ordonne à votre compagnon animal de rugir, attirant vers lui les créatures autour de lui."),
			new SpellBookEntry( 6, Aptitude.Chasseur, "Frappe ensanglantée", new Type[] { typeof(SpidersSilk), typeof(SulfurousAsh), typeof(BlackPearl) }, 0x8f2, 5, 615, "Permet de faire saigner une cible, l'empêchant par le fait même de se soigner."),
			new SpellBookEntry( 7, Aptitude.Chasseur, "Saut aggressif", new Type[] { typeof(Nightshade) }, 0x134, 5, 616, "Permet de reculer de quelques cas tout en frappant la cible."),
			new SpellBookEntry( 8, Aptitude.Chasseur, "Coup dans le genou", new Type[] { typeof(MandrakeRoot), typeof(SulfurousAsh), typeof(Ginseng) }, 0x126, 6, 617, "Empêche la cible de courir."),
			new SpellBookEntry( 9, Aptitude.Chasseur, "Chasseur de prime", new Type[] { typeof(SulfurousAsh), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8e5, 7, 618, "Si la cible est touchée par le sort Marquer, ces résistances sont diminuées drastiquement."),
            new SpellBookEntry( 10, Aptitude.Chasseur, "Contrat résolu", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(Garlic) }, 0x5323, 8, 619, "Si la cible est marquée, ne peut plus courir* et est ensanglantée, vous téléporte sur la cible pour la tuer d'un coup. *Le fait de frapper ou d'ensanglanter une cible lui retire l'empêchement de courir, alors soyez rapide ou soyez plusieurs!"),

			new SpellBookEntry( 1, Aptitude.Defenseur, "Coup de bouclier", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 1, 620, "Donne un coup de bouclier à la cible."),
			new SpellBookEntry( 2, Aptitude.Defenseur, "Bravage", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SulfurousAsh) }, 0x8d1, 2, 621, "Provoque une cible."),
			new SpellBookEntry( 3, Aptitude.Defenseur, "Dévotion", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8d3, 3, 622, "Augmente ces points de vie maximun."),
			new SpellBookEntry( 4, Aptitude.Defenseur, "Mutinerie", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x8f6, 3, 623, "Provoque toutes les créatures autour de vous."),
			new SpellBookEntry( 5, Aptitude.Defenseur, "Mentor", new Type[] { typeof(MandrakeRoot), typeof(Nightshade)  }, 0x8cf, 4, 624, "Procure de la réduction de coût de mana sur votre cible."),
			new SpellBookEntry( 6, Aptitude.Defenseur, "Lien de vie", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(NoxCrystal) }, 0x8e6, 4, 625, "La moitié des dégâts reçus sur votre cible vous est transférée."),
			new SpellBookEntry( 7, Aptitude.Defenseur, "Miracle", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8d0, 5, 626, "Ressuscite un joueur. Vous devez cibler son corps inerte."),
			new SpellBookEntry( 8, Aptitude.Defenseur, "Indomptable", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 6, 627, "La cible est immunitée contre la paralysie, le sommeil, l'empêchement de bouger et l'empêchement de courir."),
			new SpellBookEntry( 9, Aptitude.Defenseur, "Insensible", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x122, 7, 628, "La cible est immunitée contre le poison, le saignement, l'empêchement de se soigner et à la malédiction."),
			new SpellBookEntry( 10, Aptitude.Defenseur, "Pieds au sol", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8f8, 8, 629, "Vous cloue au sol, mais les dégâts reçus sont réduits."),

			new SpellBookEntry( 1, Aptitude.Geomancie, "Fortifié", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 1, 630, "Augmente votre résistance physique."),
			new SpellBookEntry( 2, Aptitude.Geomancie, "Roche", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SulfurousAsh) }, 0x8d1, 2, 631, "Lance une roche sur la cible."),
			new SpellBookEntry( 3, Aptitude.Geomancie, "Contamination", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8d3, 3, 632, "Empoisonne la cible."),
			new SpellBookEntry( 4, Aptitude.Geomancie, "Empalement", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x8f6, 3, 633, "Lance des épines autour de vous, ensanglante les cibles touchées."),
			new SpellBookEntry( 5, Aptitude.Geomancie, "Aura fortifiante", new Type[] { typeof(MandrakeRoot), typeof(Nightshade)  }, 0x8cf, 4, 634, "Augmente la résistance physique de vous et vos alliés."),
			new SpellBookEntry( 6, Aptitude.Geomancie, "Mur de plante", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(NoxCrystal) }, 0x8e6, 4, 635, "Invoque un mur de plante qui empoisonne les cibles autour."),
			new SpellBookEntry( 7, Aptitude.Geomancie, "Explosion de roche", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8d0, 5, 636, "Permet de faire exploser sa résistance physique et d'envoyer des pierres sur les cibles autour. *Les sorts Fortifié et Aura fortifiante augmentent les dégâts du sort."),
			new SpellBookEntry( 8, Aptitude.Geomancie, "Aura Préserv. Manaique", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 6, 637, "Procure de la réduction de coût de mana à vous et vos alliés."),
			new SpellBookEntry( 9, Aptitude.Geomancie, "Racines", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x122, 7, 638, "Enracine une cible, l'empêchant de bouger."),
			new SpellBookEntry( 10, Aptitude.Geomancie, "Fléau terrestre", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8f8, 8, 639, "Endommage, empoisonne et empêche de se soigner les ennemis autour de vous."),

			new SpellBookEntry( 1, Aptitude.Guerison, "Main cicatrisante", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8c8, 1, 640, "Permet de lancer un sortilège de soin."),
			new SpellBookEntry( 2, Aptitude.Guerison, "Remède", new Type[] { typeof(BlackPearl), typeof(Garlic), typeof(SulfurousAsh) }, 0x8d1, 2, 641, "Permet de guérir le poison d'une cible."),
			new SpellBookEntry( 3, Aptitude.Guerison, "Mur de pierre", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(SulfurousAsh) }, 0x8d3, 3, 642, "Invoque un mur de pierre."),
			new SpellBookEntry( 4, Aptitude.Guerison, "Rayon céleste", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SulfurousAsh) }, 0x8f6, 3, 643, "Permet de lancer un sortilège de soin amélioré."),
			new SpellBookEntry( 5, Aptitude.Guerison, "Don de la vie", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SulfurousAsh) }, 0x8f8, 8, 649, "Ressuscite un joueur. Vous devez cibler son corps inerte."),
			new SpellBookEntry( 6, Aptitude.Guerison, "Frayeur", new Type[] { typeof(Garlic), typeof(Nightshade), typeof(NoxCrystal) }, 0x8e6, 4, 645, "Votre cible est prise de peur."),
			new SpellBookEntry( 7, Aptitude.Guerison, "Ferveur divine", new Type[] { typeof(Garlic), typeof(MandrakeRoot) }, 0x8d0, 5, 646, "Permet d’interchanger vos points de mana avec votre cible."),
			new SpellBookEntry( 8, Aptitude.Guerison, "Inquisition", new Type[] { typeof(MandrakeRoot), typeof(Nightshade) }, 0x8c9, 6, 647, "Augmente votre rapidité de lancer des sorts, vos sorts de soins sont améliorés et vos murs durent plus longtemps."),
			new SpellBookEntry( 9, Aptitude.Guerison, "Mur de lumière", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x122, 7, 648, "Permet de lancer un mur de paralysie."),
			new SpellBookEntry( 10, Aptitude.Guerison, "Lumière sacré", new Type[] { typeof(MandrakeRoot), typeof(Nightshade)  }, 0x8cf, 4, 644, "Endommage les ennemis et soigne les alliés autour de votre cible."),

			new SpellBookEntry( 1, Aptitude.Hydromancie, "Armure de glace", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x11a, 1, 650, "Augmente votre résistance au froid."),
			new SpellBookEntry( 2, Aptitude.Hydromancie, "Restauration", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x14a, 2, 651, "Procure une regénération de points de vie à votre cible."),
			new SpellBookEntry( 3, Aptitude.Hydromancie, "Soin préventif", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8c5, 3, 652, "Permet de se téléporter sur un allié et lui appliquer le sort Restauration."),
			new SpellBookEntry( 4, Aptitude.Hydromancie, "Cage de glace", new Type[] { typeof(SulfurousAsh), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8c4, 4, 653, "Entoure une cible de mur de glace, l'empêchant de bouger."),
			new SpellBookEntry( 5, Aptitude.Hydromancie, "Aura cryogénisée", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8c1, 4, 654, "Augmente la résistance au froid de vous et vos alliés."),
			new SpellBookEntry( 6, Aptitude.Hydromancie, "Pieux de glace", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12e, 5, 655, "La cible est assaillit de pieux de glace qui explosent autour d'elle."),
			new SpellBookEntry( 7, Aptitude.Hydromancie, "Cerveau gelé", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(Garlic) }, 0x127, 5, 656, "Si la cible est affectée par le sort 'Blizzard' ou 'Cage de glace', ses points de vie sont réduits à la moitié de son maximum."),
			new SpellBookEntry( 8, Aptitude.Hydromancie, "Aura réfrigérante", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8f0, 6, 657, "Applique le sort Restauration à vous et aux alliés autour de vous."),
			new SpellBookEntry( 9, Aptitude.Hydromancie, "Avatar du froid", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8ef, 1, 658, "Vous cloue les pieds au sol, mais vos sorts de soin sont améliorés."),
			new SpellBookEntry( 10, Aptitude.Hydromancie, "Blizzard", new Type[] { typeof(SulfurousAsh), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x13d, 5, 659, "Crée une zone de blizzard, empêchant les ennemis de courir et leur fait perdre de la stamina."),

			new SpellBookEntry( 1, Aptitude.Martial, "Second souffle", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x11a, 1, 660, "Augmente les points de vie."),
			new SpellBookEntry( 2, Aptitude.Martial, "Provocation", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(SulfurousAsh) }, 0x14a, 2, 661, "La cible est attirée vers vous."),
			new SpellBookEntry( 3, Aptitude.Martial, "Saut dévastateur", new Type[] { typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8c5, 3, 662, "Saute de quelques cases et crée une zone de feu lors de l'impact."),
			new SpellBookEntry( 4, Aptitude.Martial, "Duel", new Type[] { typeof(SulfurousAsh), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8c4, 4, 663, "Gagne un bonus de dégâts contre la cible."),
			new SpellBookEntry( 5, Aptitude.Martial, "Charge furieuse", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8c1, 4, 664, "Charge vers la cible, la repoussant lors de l'impact."),
			new SpellBookEntry( 6, Aptitude.Martial, "Enragé", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x12e, 5, 665, "Réduit sa résistance physique, mais augmente ses dégâts physiques."),
			new SpellBookEntry( 7, Aptitude.Martial, "Bouclier magique", new Type[] { typeof(BlackPearl), typeof(Ginseng), typeof(Garlic) }, 0x127, 5, 666, "Permet de renvoyer le prochain sort sur vous sur le lanceur du sort."),
			new SpellBookEntry( 8, Aptitude.Martial, "Commandement", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(MandrakeRoot) }, 0x8f0, 6, 667, "Augmente vos points de vie et ceux de vos alliés."),
			new SpellBookEntry( 9, Aptitude.Martial, "Présence inspirante", new Type[] { typeof(Bloodmoss), typeof(SulfurousAsh) }, 0x8ef, 1, 668, "Augmente la regénération de vos points de vie et celle de vos alliés."),
			new SpellBookEntry( 10, Aptitude.Martial, "Ange gardien", new Type[] { typeof(SulfurousAsh), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x13d, 5, 669, "Vous perdez des points de vie, mais votre résistance est grandement améliorée."),

			new SpellBookEntry( 1, Aptitude.Musique, "Diversion", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(Garlic) }, 0x135, 1, 670, "Permet d’attirer l’attention d’un monstre sur une cible*. *Ciblez le sol."),
			new SpellBookEntry( 2, Aptitude.Musique, "Calme toi!", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8dc, 2, 671, "Apaise une créature."),
			new SpellBookEntry( 3, Aptitude.Musique, "Désorienté", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8da, 3, 672, "Désoriente une créature."),
			new SpellBookEntry( 4, Aptitude.Musique, "Défi", new Type[] { typeof(DaemonBlood), typeof(Garlic) }, 0x5001, 3, 673, "Provoque une créature sur une autre."),
			new SpellBookEntry( 5, Aptitude.Musique, "Descescendo maniaque", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SpidersSilk) }, 0x59e0, 4, 674, "Procure de la réduction de coût de mana à vous et vos alliés."),
			new SpellBookEntry( 6, Aptitude.Musique, "Inspiration élémentaire", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(DaemonBlood) }, 0x147, 4, 675, "Ajoute des effets magiques à votre arme de manière aléatoire (Ex: boule de feu, éclair, etc)"),
			new SpellBookEntry( 7, Aptitude.Musique, "Absorbation sonore", new Type[] { typeof(BatWing), typeof(GraveDust) }, 0x167, 5, 676, "Permet de drainer la mana des ennemis autour de vous."),
			new SpellBookEntry( 8, Aptitude.Musique, "Parfaite aspiration", new Type[] { typeof(PigIron) }, 0x5003, 6, 677, "Augmente la concentration d'une cible, ce qui lui empêche de râter un sort lorsqu'elle est touchée."),
			new SpellBookEntry( 9, Aptitude.Musique, "Révélation discordance", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(PigIron) }, 0x168, 7, 678, "Permet de révéler tous les invisibles de votre écran et les désoriente."),
			new SpellBookEntry( 10, Aptitude.Musique, "Havre de paix", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(NoxCrystal) }, 0x59e5, 8, 679, "Apaise toutes les créatures autour de vous."),

			new SpellBookEntry( 1, Aptitude.Necromancie, "Soif de sang", new Type[] { typeof(BlackPearl), typeof(Bloodmoss), typeof(Garlic) }, 0x135, 1, 680, "Ensanglante la cible."),
			new SpellBookEntry( 2, Aptitude.Necromancie, "Touché absorbant", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(SpidersSilk) }, 0x8dc, 2, 681, "Permet de se soigner en ciblant un corp inerte au sol."),
			new SpellBookEntry( 3, Aptitude.Necromancie, "Infection", new Type[] { typeof(Nightshade), typeof(Garlic), typeof(SulfurousAsh) }, 0x8da, 3, 682, "Applique une malédiction sur la cible."),
			new SpellBookEntry( 4, Aptitude.Necromancie, "Armure d'os", new Type[] { typeof(DaemonBlood), typeof(Garlic) }, 0x5001, 3, 683, "Vous procure un aura qui réflète les dégâts."),
			new SpellBookEntry( 5, Aptitude.Necromancie, "Familier morbide", new Type[] { typeof(Bloodmoss), typeof(Ginseng), typeof(SpidersSilk) }, 0x59e0, 4, 684, "Invoque une créature morbide."),
			new SpellBookEntry( 6, Aptitude.Necromancie, "Réanimation", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(DaemonBlood) }, 0x147, 4, 685, "Permet de relever les cadavres."),
			new SpellBookEntry( 7, Aptitude.Necromancie, "Consommation mortelle", new Type[] { typeof(BatWing), typeof(GraveDust) }, 0x167, 5, 686, "Permet de consommer l'existance d'une créature invoquées et de se soigner."),
			new SpellBookEntry( 8, Aptitude.Necromancie, "Aura vampirique", new Type[] { typeof(PigIron) }, 0x5003, 6, 687, "Donne un aura de regain de vie à ses alliés quand ils sont des dégâts."),
			new SpellBookEntry( 9, Aptitude.Necromancie, "Appel du sang", new Type[] { typeof(GraveDust), typeof(DaemonBlood), typeof(PigIron) }, 0x168, 7, 688, "Invoque un élémentaire de sang."),
			new SpellBookEntry( 10, Aptitude.Necromancie, "Pluie de sang", new Type[] { typeof(Nightshade), typeof(Bloodmoss), typeof(NoxCrystal) }, 0x59e5, 8, 689, "Ensanglante et applique une malédiction aux ennemis autour de soi."),

			new SpellBookEntry( 1, Aptitude.Polymorphie, "Forme cyclonique", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8fd, 8, 690, "Gagne un bonus de compétence 'Hiding'."),
			new SpellBookEntry( 2, Aptitude.Polymorphie, "Forme métallique", new Type[] { typeof(Bloodmoss), typeof(Bloodmoss), typeof(Bloodmoss) }, 0x5322, 8, 691, "Procure une meilleure regénération de points de vie."),
			new SpellBookEntry( 3, Aptitude.Polymorphie, "Forme terrestre", new Type[] { typeof(SulfurousAsh), typeof(SulfurousAsh), typeof(SpidersSilk) }, 0x8fe, 8, 692, "Augmente votre résistance phjysique, mais diminue votre résistance au feu et à l'énergie."),
			new SpellBookEntry( 4, Aptitude.Polymorphie, "Forme empoisonnée", new Type[] { typeof(Bloodmoss), typeof(Garlic), typeof(SpidersSilk) }, 0x8fc, 8, 693, "Permet d'appliquer un poison lorsque vous frappez une cible."),
			new SpellBookEntry( 5, Aptitude.Polymorphie, "Forme givrante", new Type[] { typeof(BlackPearl), typeof(Nightshade), typeof(Bloodmoss) }, 0x8f9, 8, 694, "Augmente vos dégâts physiques et votre régénération de points de vie."),
			new SpellBookEntry( 6, Aptitude.Polymorphie, "Forme liquide", new Type[] { typeof(Ginseng), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8fb, 8, 695, "Procure un bonus de guérison avec les bandages sur soi-même."),
			new SpellBookEntry( 7, Aptitude.Polymorphie, "Forme cristalline", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Nightshade) }, 0x8e0, 8, 696, "Augmente votre regénération de mana, mais vous perdez des points de vie. Augmente votre résistance au froid et poison."),
			new SpellBookEntry( 8, Aptitude.Polymorphie, "Forme électrisante", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8ff, 8, 697, "Augmente votre vitesse de déplacement, de précision des coups et vos points de vie."),
			new SpellBookEntry( 9, Aptitude.Polymorphie, "Forme enflammée", new Type[] { typeof(Bloodmoss), typeof(BlackPearl) }, 0x123, 8, 698, "Brûle les ennemis qui sont trop près de vous."),
			new SpellBookEntry( 10, Aptitude.Polymorphie, "Forme ensanglantée", new Type[] { typeof(BlackPearl), typeof(BlackPearl), typeof(SpidersSilk) }, 0x11f, 8, 699, "Procure un regain de vie lors de coups, augmente votre regénération de mana et de stamina. Vous êtes immunisé aux poisons, mais vous perdez de la résistance au feu."),

			new SpellBookEntry( 1, Aptitude.Pyromancie, "Bouclier de feu", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Garlic) }, 0x8e4, 1, 700, "Augmente votre résistance au feu."),
			new SpellBookEntry( 2, Aptitude.Pyromancie, "Boule de feu", new Type[] { typeof(GraveDust), typeof(PigIron), typeof(BatWing) }, 0x164, 2, 701, "Lance une boule de feu."),
			new SpellBookEntry( 3, Aptitude.Pyromancie, "Célérité", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(BlackPearl) }, 0x137, 3, 702, "Augmente la vitesse d'attaque de votre cible."),
			new SpellBookEntry( 4, Aptitude.Pyromancie, "Supernova", new Type[] { typeof(Nightshade), typeof(NoxCrystal), typeof(BlackPearl) }, 0x133, 3, 703, "Permet de lancer des boules de feu autour de vous."),
			new SpellBookEntry( 5, Aptitude.Pyromancie, "Aura réchauffante", new Type[] { typeof(BlackPearl) }, 0x5326, 4, 704, "Augmente la résistance au feu de vous et vos alliés."),
			new SpellBookEntry( 6, Aptitude.Pyromancie, "Frénésie douloureuse", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x161, 4, 705, "Votre cible est attirée vers vous tout en étant brûlée."),
			new SpellBookEntry( 7, Aptitude.Pyromancie, "Folie ardente", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8f4, 5, 706, "Brûle votre cible de manière répétitive."),
			new SpellBookEntry( 8, Aptitude.Pyromancie, "Aura d'exaltation", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Garlic) }, 0x8e1, 6, 707, "Augmente la vitesse d'attaque de vous et de vos alliés."),
			new SpellBookEntry( 9, Aptitude.Pyromancie, "Cage de feu", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d8, 7, 708, "La cible est téléportée à vous, vous entourant tous les deux d'une cage de feu. Tous les gens entourés par la cage de feu ne peuvent s'en échapper."),
			new SpellBookEntry( 10, Aptitude.Pyromancie, "Passion ardente", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8f5, 6, 709, "Une partie des dégâts de feu reçus vous soigne. Une partie des dégâts de feu envoyés vous soigne également."),

			new SpellBookEntry( 1, Aptitude.Roublardise, "Adrénaline", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Garlic) }, 0x8e4, 1, 710, "Augmente votre regénération de stamina."),
			new SpellBookEntry( 2, Aptitude.Roublardise, "Sommeil", new Type[] { typeof(GraveDust), typeof(PigIron), typeof(BatWing) }, 0x164, 2, 711, "Endort une cible."),
			new SpellBookEntry( 3, Aptitude.Roublardise, "Lancer précis", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(BlackPearl) }, 0x137, 3, 712, "Lance un couteau qui ensanglante votre cible."),
			new SpellBookEntry( 4, Aptitude.Roublardise, "Coup arrière", new Type[] { typeof(Nightshade), typeof(NoxCrystal), typeof(BlackPearl) }, 0x133, 3, 713, "Permet de se téléporter en arrière de votre cible pour la frapper."),
			new SpellBookEntry( 5, Aptitude.Roublardise, "Évasion", new Type[] { typeof(BlackPearl) }, 0x5326, 4, 714, "Permet de se téléporter à une case aléatoire et vous rend invisible."),
			new SpellBookEntry( 6, Aptitude.Roublardise, "Attirance", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x161, 4, 715, "Téléporte une cible vers vous."),
			new SpellBookEntry( 7, Aptitude.Roublardise, "Main blessée", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8f4, 5, 716, "Désarmera la prochaine personne que vous frapperez."),
			new SpellBookEntry( 8, Aptitude.Roublardise, "Coupure des tendons", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Garlic) }, 0x8e1, 6, 717, "Ensanglante une cible et l'empêche de courir."),
			new SpellBookEntry( 9, Aptitude.Roublardise, "Gas endormant", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d8, 7, 718, "Endort les ennemis autour de votre cible."),
			new SpellBookEntry( 10, Aptitude.Roublardise, "Coup mortel", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8f5, 6, 719, "Si les points de vie de votre cible sont sous la barre des 20%, la cible est exécutée."),

			new SpellBookEntry( 1, Aptitude.Totemique, "Totem de feu", new Type[] { typeof(BlackPearl), typeof(MandrakeRoot), typeof(Garlic) }, 0x8e4, 1, 720, "Invoque un totem de feu qui lance des boules de feu."),
			new SpellBookEntry( 2, Aptitude.Totemique, "Totem de l'eau", new Type[] { typeof(GraveDust), typeof(PigIron), typeof(BatWing) }, 0x164, 2, 721, "Invoque un totem d'eau qui vous soigne."),
			new SpellBookEntry( 3, Aptitude.Totemique, "Totem de terre", new Type[] { typeof(NoxCrystal), typeof(Nightshade), typeof(BlackPearl) }, 0x137, 3, 722, "Invoque un totem de terre qui attirent les ennemis autour de lui."),
			new SpellBookEntry( 4, Aptitude.Totemique, "Totem de vent", new Type[] { typeof(Nightshade), typeof(NoxCrystal), typeof(BlackPearl) }, 0x133, 3, 723, "Invoque un totem de vent qui lance des éclairs."),
			new SpellBookEntry( 5, Aptitude.Totemique, "Absorbation", new Type[] { typeof(BlackPearl) }, 0x5326, 4, 724, "Absorbe un totem pour regagner de la vie, de la stamina et de la mana."),
			new SpellBookEntry( 6, Aptitude.Totemique, "Lier par l'esprit", new Type[] { typeof(BatWing), typeof(NoxCrystal) }, 0x161, 4, 725, "Permet de téléporter les totems sur soi."),
			new SpellBookEntry( 7, Aptitude.Totemique, "Supercharger", new Type[] { typeof(Bloodmoss), typeof(MandrakeRoot), typeof(SpidersSilk) }, 0x8f4, 5, 726, "Améliore la puissance des totems."),
			new SpellBookEntry( 8, Aptitude.Totemique, "Mur totémique", new Type[] { typeof(BlackPearl), typeof(SpidersSilk), typeof(Garlic) }, 0x8e1, 6, 727, "Permet d'invoquer un mur de totems d'énergie, vous empêchant de les traverser.."),
			new SpellBookEntry( 9, Aptitude.Totemique, "Appel spirituel", new Type[] { typeof(Garlic), typeof(Ginseng), typeof(MandrakeRoot) }, 0x8d8, 7, 728, "Permet de retourner une cible à la ville."),
			new SpellBookEntry( 10, Aptitude.Totemique, "Marche à suivre", new Type[] { typeof(Garlic), typeof(MandrakeRoot), typeof(BlackPearl) }, 0x8f5, 6, 729, "Permet aux totems de vous suivre."),
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

        public void InitializeHashtable()
        {
            m_NameColors[Aptitude.Martial] = 1105;
            m_NameColors[Aptitude.Chasseur] = 1050;
            m_NameColors[Aptitude.Roublardise] = 1109;
            m_NameColors[Aptitude.Polymorphie] = 1129;
            m_NameColors[Aptitude.Totemique] = 1139;
            m_NameColors[Aptitude.Musique] = 1250;
            m_NameColors[Aptitude.Hydromancie] = 1264;
            m_NameColors[Aptitude.Pyromancie] = 1258;
            m_NameColors[Aptitude.Geomancie] = 1190;
            m_NameColors[Aptitude.Aeromancie] = 1153;
            m_NameColors[Aptitude.Necromancie] = 2006;
            m_NameColors[Aptitude.Defenseur] = 2006;
            m_NameColors[Aptitude.Guerison] = 2006;

            m_Names[Aptitude.Martial] = "Martial";
            m_Names[Aptitude.Chasseur] = "Chasseur";
			m_Names[Aptitude.Roublardise] = "Roublardise";
			m_Names[Aptitude.Polymorphie] = "Polymorphie";
			m_Names[Aptitude.Totemique] = "Totémique";
            m_Names[Aptitude.Musique] = "Musique";
            m_Names[Aptitude.Hydromancie] = "Hydromancie";
            m_Names[Aptitude.Pyromancie] = "Pyromancie";
            m_Names[Aptitude.Geomancie] = "Géomancie";
            m_Names[Aptitude.Aeromancie] = "Aéromancie";
            m_Names[Aptitude.Necromancie] = "Nécromancie";
            m_Names[Aptitude.Defenseur] = "Défenseur";
            m_Names[Aptitude.Guerison] = "Guérison";
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
					AddLabel(170 + hindex * 190, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				if (count % (EntriesPerPage / 2) == 0 && count % EntriesPerPage != 0)
				{
					vindex = 0;
					hindex = 1;
					AddLabel(170 + hindex * 190, 25, (int)m_NameColors[entry.Aptitude] - 1, (string)m_Names[entry.Aptitude]);
				}

				// Séparateurs
				AddImageTiled(150 + hindex * 190, 40, 130, 10, 0x3A);

				//Si le livre possède le sort
				if (HasSpell(entry.SpellID) && ArrayContains(m_AptitudeList, entry.Aptitude))
				{
					int buttonID = 2224;

					if (pm.QuickSpells.Contains(entry.SpellID))
						buttonID = 2223;

					//On ajoute l'information et les boutons
					AddLabel(162 + hindex * 190, 54 + (vindex * 15), 0, entry.Nom);
					AddButton(127 + hindex * 190, 59 + (vindex * 15), 2103, 2104, entry.SpellID, GumpButtonType.Reply, 0); //Cast
					AddButton(140 + hindex * 190, 58 + (vindex * 15), buttonID, buttonID, entry.SpellID + 200, GumpButtonType.Reply, 0); //AddQSL
					vindex++;
				}
			}

			//Pour tous les sorts
			if (m_Page > m_SpellBookEntry.Length / EntriesPerPage)
			{
				for (int i = (m_Page - (int)Math.Ceiling((double)m_SpellBookEntry.Length / EntriesPerPage)), count = 0; count < 1 && i < m_SpellBookEntry.Length; ++i, count++)
				{
					SpellBookEntry info = (SpellBookEntry)m_SpellBookEntry[i];

					//Si le livre possède le sort
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
							namecolor = (int)m_NameColors[info.Aptitude];

						if (m_Names.Contains(info.Aptitude))
							name = (string)m_Names[info.Aptitude];

						//On ajoute le nom
						AddLabel(130 + hindex * 190, 45, namecolor, info.Nom);

						//On ajoute les séparateurs
						AddImageTiled(130 + hindex * 190, 60, 130, 10, 0x3A);

						//On ajoute l'icone en tant que bouton pour lancer le sort
						AddButton(140 + hindex * 190, 75, info.ImageID, info.ImageID, info.SpellID, GumpButtonType.Reply, 0);
						AddLabel(190 + hindex * 190, 78, namecolor, "Niveau : " + info.AptitudeLevel.ToString());

						int buttonID = 2224;

						if (pm.QuickSpells.Contains(info.SpellID))
							buttonID = 2223;

						//On ajoute les boutons pour le lancement rapide
						AddLabel(215 + hindex * 190, 98, 0, "Rapide");
						AddButton(190 + hindex * 190, 101, buttonID, buttonID, info.SpellID + 200, GumpButtonType.Reply, 0);

						//On ajoute les infos diverses
						AddHtml(130 + hindex * 190, 120, 100, 20, "Réactifs:", false, false);
						for (int j = 0; j < info.Reagents.Length; j++)
						{
							Type type = (Type)info.Reagents[j];
							AddLabel(130 + hindex * 190, 138 + j * 18, 0, $"- {type.Name}");
						}

						AddLabel(170 + hindex * 190, 25, namecolor, name);

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
				else if (info.ButtonID >= 600 && info.ButtonID < 800)
                {
                    Spell spell = SpellRegistry.NewSpell(info.ButtonID, pm, null);

                    if (spell != null)
                        spell.Cast();

                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page));
                }
                else if (info.ButtonID >= 800 && info.ButtonID < 1000)
                {
                    if (pm.QuickSpells == null)
                        return;

                    if (pm.QuickSpells.Contains((int)(info.ButtonID - 200)))
                    {
                        pm.SendMessage("Le sort a été retiré de votre liste de lancement rapide.");
                        pm.QuickSpells.Remove((int)(info.ButtonID - 200));
                    }
                    else
                    {
                        pm.SendMessage("Le sort a été ajouté à votre liste de lancement rapide.");
                        pm.QuickSpells.Add((int)(info.ButtonID - 200));
                    }

                    pm.SendGump(new NewSpellbookGump(pm, m_Book, m_Page));
                }
            }
        }
    }
}