﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
 		
        class GodInit 
        {
				public static void Configure()
					{
							God.RegisterGod(new God(-1, "Aucun", new Dictionary<MagieType, int>(), 302,40, "Hérétique !"));

							God.RegisterGod(new God(0, "Greald", new Dictionary<MagieType, int>() { { MagieType.Obeissance, 8}, }, 303,0, "Animal Représentatif: Loup \n\nArme représentative: épée \n\nLogo Représentatif: Une balance \n\nDévotion: Obéissance \n\nCroyance: Protection, Courage, Justice, Naissance, Beauté, Sacrifice, Endurance \n\nAntagoniste: Seras \n\nLes Dévoués: \n\nLes loyalistes, les traditionnalistes et les respectueux du prestige sont souvent relier à Greald. Les Magistrats, Les politiciens, les militaires ont tendances à pencher vers l’éthique que Greald leur apportes. Après tout pourquoi se plier à une déchéance de l’ordre qui fera vivre un enfer sur terre dans le manque de respect ? \n\nHistoire: \n\nOn ne sait que très peu de choses sur Greald dit le loyaliste mise à part qu’il déclara alors une chasse de sang sur la tête de Seras pour avoir osé corrompre les esprits des gens droit et discipliné. La légende raconte que le loup aurait été piéger par le serpent lors d’un échange sur le mont Gruydia. \n\nLe coup d’épée lancer par Greald fut si violent que la montagne s’écrasa sous la puissance de l’épée, alors que les gens pensaient se sortir de la guerre, Greald ramena alors ses troupes vers le chemin et leur montra alors la voie à prendre. Un seul commandement aurait été énoncé par le fauve \n\n‘’Suivez les ordres!’’  "));
							God.RegisterGod(new God(1, "Quirel", new Dictionary<MagieType, int>() { { MagieType.Vie, 8 }, }, 304,8, "Animal Représentatif : Oiseau \n\nArme Représentative: Arc à flèche \n\nLogo Représentatif: Une lune dans un soleil \n\nDévotion: Vie \n\nCroyance: Paix, L’Amour, Lune et Soleil, Divination et Destin, Santé, Prospérité, Bienveillance \n\nAntagoniste: Zox \n\nLes Dévoués: \n\nLes bons vivants, Honorable, Protecteur est souvent relier à Quirel. Chevalier, Paladin, Prêtre ont tendance à pencher vers la morale que Quirel leur procure. Après tout pourquoi essayer de faire le mal qui est tellement facile alors que nous pourrions juste aider et pardonner son prochain ? \n\nHistoire: \n\n On ne sait que très peu de chose sur Quirel dit le bienveillant mise à part qu’il décida d’avouer son amour pour Zox et que le tout fini dans une rage pour le chien de la mort. Alors que Quirel tenta alors de ramener Zox qui était hors de lui. Le chien décida de planter une flèche dans son propre cœur avant de disparaître dans le néant. Quirel ayant perdu son ami mais aussi l’amour de sa vie décida de s’élever dans le ciel pour prospérer sur le royaume. Si lui ne pouvait connaitre l’amour alors il s’efforcerait que d’autre le découvre."));
							God.RegisterGod(new God(2, "Seras", new Dictionary<MagieType, int>() { { MagieType.Anarchique, 8 }, }, 305,5, "Animal Représentatif: Serpent \n\n Arme Représentative: Dague \n\nLogo Représentatif: étoile à huit branches - L’octogramme \n\nDévotion: Anarchique \n\nCroyance: Chance, Mensonge, Liberté, Météo, Luxure, Chasse, Richesse \n\nAntagoniste: Greald \n\nLes Dévoués: \n\nLes anarchistes, les esprits libertins et les Individualistes sont souvent relier à Seras. Pirates, Barbares, Bardes, Sorcier ont tendances à pencher vers l’éthique que Seras leur apportes. Après tout pourquoi se plier à des lois écrites qui n’ont aucun sens et qui nous affaiblit ? \n\nHistoire \n\nOn ne sait que très peu de chose sur Seras dit l’anarchiste mise à part qu’il décida de confronter le prestige de Greald. Remettant en doute l’encadrement et le dogme strict qu’apportait le loyaliste loup. Alors que tout était si limpide et carré, Seras décida de mettre une touche de chaos dans cet ordre absolu, laissant au passage des mortels s’élever et prôner avec ferveur que s’en était assez de cette obéissance. Seras aurait donc initier les sens de rebellions et de libertinage. Jusqu’à quel prix ? Où était prêt à aller les mortels pour défier les divinités ? "));
							God.RegisterGod(new God(3, "Zox", new Dictionary<MagieType, int>() { { MagieType.Mort, 8 }, }, 306,0, "Animal Représentatif: Chien \n\nArme Représentative: Hache \n\nLogo Représentatif: Une croix relief d’un cercle au bout(Une Ankh) \n\nDévotion: Mort \n\nCroyance: Gourmandise, Mort, Souffrance, Maladie, Colère, L’Orgueil, Rancune \n\nAntagoniste: Quirel\n\nLes Dévoués : \n\nCalculateur, Manipulateur et Insensible est souvent relier à Zox. Roublard, Criminel, Meurtrier ont tendance à pencher vers la morale que Zox leur procure. Pourquoi essayer de faire le bien alors que sa n’apporte rien sauf un ‘’Merci’’ ? Aussi bien sévir et abuser des gens. \n\nHistoire \n\nOn ne sait que très peu de chose sur Zox outre le fait qu’il a décider de renier l’amour de Quirel. La légende raconte qu’en fait Zox était très malade, il était sur le seuil de mourir d’une maladie dégénérative, il pensait que les sages conseils de Quirel pourraient le guérir mais au lieu de cela l’oiseau lui dicta un amour ce qui ne plus au chien de la mort. Zox décida ainsi de disparaître dans les profonds abysses du monde, reniant et maudissant la vue du soleil et de la lune. Pour lui l’oiseau l’avait trahi, au lieu de le sauver il lui proposa que de l’amour ? En quoi l’amour pourrait - il me sauver se disait le canin."));
							God.RegisterGod(new God(4, "Celus", new Dictionary<MagieType, int>() { { MagieType.Cycle, 8 }, }, 307,13, "Animal Représentatif: Crocodile ou Dragon \n\nArme Représentative: Mace \n\nLogo Représentatif: Un huit sur le côté(Symbole de l’infini) \n\nDévotion: Cycle \n\nCroyance: Agriculture, Renaissance, Artiste, Nature, Guerre, Magie, Connaissance \n\nAntagoniste: Aucun \n\nLes Dévoués: Les énigmatiques, Médiateurs et Impartial sont souvent relier à Celus. Philosophe, Magicien et Artiste ont tendance à pencher vers l’éthique et moral que Celus leur procure. Après tout pourquoi peser le pour et le contre de tout ses choix ? Restons neutre et profitons du cycle éternel. \n\nHistoire: \n\nOn ne sait que très peu de chose sur Celus dit l’éternel mise à part qu’il décida de rester en dehors de la guerre des divinités. Alors que tous voulaient avoir l’appuis du cycle, Celus décida de rester en plein milieu de la mer pendant sept jours à contempler ainsi le désastre de la guerre. Il attendait patiemment et continuait de regarder juste le vide. La légende raconte que Celus s’aurait endormit au fond de la mer face à tous ses choix. Quel ennuie se disait - il où attendait - il d’effectuer son travail adéquatement ? "));

		
					}
		}
}
