using Server.Items;

namespace Server.Custom.Races
{
	class Montagnard : BaseRace
	{
		public override string Background => "Grâce aux cohortes bien entraînées et disciplinées des légions riveraines, les ambitions conquérantes de L'Empire Riverain s’étalèrent sur le territoire et absorbèrent les royaumes et domaines claniques voisins. Leurs suzerains et habitants refusant de payer le prix de leur allégeance par l'or et la loyauté payèrent celui du fer et du sang. L’Empire grandissant en terrain et population, une culture militariste imposa la discipline comme valeur cardinale avec le service militaire pour instrument de conquête. En émergea la treizième Légion, formée de ces fils, petits-fils et arrière-petits-fils des royaumes vaincus, qui fut dépêchée vers les lointaines terres gelées avec un seul ordre : revenez triomphants ou périssez. \r\n\r\nAu sein de ces terres désolées, de roc et de neige, on espérait trouver des ressources cruciales à la machine de guerre impériale. Les légionnaires assumèrent que la nécessaire éradication des monstres occupant le territoire pour le plein contrôle des terres gelées ne prendrait que quelques semaines. Cependant, au retour d’une sortie de reconnaissance, les éclaireurs se virent coursés par des colosses mi-hommes, mi-monstres, qui tenaient à pied le rythme de leurs chevaux. Odieusement confiants et peu préparés, les membres de la treizième légion durent lourdement perdre face au choc de la marée des demi-orques, parias des landes, pour qui la meilleure défense était l’offensive. La rigoureuse discipline et le talent des combattants légionnaires purent sauver la moitié d’eux, qui battirent en retraite vers la haute montagne. Les demi-orques partirent aussitôt satisfaits d’avoir chassé des confins de leur territoire ces adversaires considérés jusqu’alors indestructibles. ";

		public override int[] SkinHues => new int[] { 1002, 1003, 1004, 1023, 1045 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Montagnard(9, 9));
		}

		public Montagnard(int raceID, int raceIndex) : base(raceID, raceIndex, "Montagnard", "Montagnards", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsMontagnard(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52084;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsMontagnard : BaseRaceGumps
	{
		[Constructable]
		public CorpsMontagnard() : this(0)
		{
		}

		[Constructable]
		public CorpsMontagnard(int hue) : base(0xA21F, hue)
		{
			Name = "Montagnard";
		}

		public CorpsMontagnard(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();
		}
	}
}

