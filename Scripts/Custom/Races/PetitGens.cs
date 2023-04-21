using Server.Items;

namespace Server.Custom.Races
{
	class PetitGens : BaseRace
	{
		public override string Background => "Certains croient qu’ils sont le mélange entre un Riverains et un Nains, dû à leur pilosité et à leur petite taille. Malgré tout, aucune preuve de leur création, ou était le premier Petits-Gens à avoir foulé la terre de Casterral ? Nul ne peut le dire. Certains croient que la provenance des Petits-Gens est des Riverains qui ont été maudit à la naissance, d’autre croient en une malformation des Nains. Le sujet est à questionnement encore aujourd’hui.\r\n\r\nLes Petits-Gens sont une race de petits êtres humanoïdes. Ils mesurent en moyenne entre 90 cm et 1,20 m de hauteur et ont tendance à être potelés. Leur peau est souvent bronzée et leurs pieds sont grands et velus. Ils ont des yeux brillants et des cheveux bouclés, généralement bruns ou blonds.\r\n\r\nLes Petits-Gens vivent dans des maisons souterraines appelées \"Azmial\" ou des trous d’Petits-Gens, situés dans les plaines et dans les vallées verdoyantes de Casterral. Ils ont une culture simple et paisible, centrée sur la famille et les amis, et se consacrent à des activités telles que la culture de légumes, la cuisine, la fête, la lecture. Bien que les Petits-Gens soient généralement pacifiques et préfèrent éviter les conflits, ils sont capables de courage et de ténacité lorsqu'ils sont poussés à agir. Grâce à leur courage et leur détermination, ils ont réussi à surmonter de nombreux obstacles pour atteindre leur but et pouvoir profiter de leur joli petit village au cœur de la plaine de Casterral. Vivant ainsi en harmonie des festivités et des simples plaisirs de la vie.\r\n\r\nLes Petits-Gens sont banals niveaux vestimentaires saufs pour les grandes soirées ou qu’ils sortent le total de leur collection d’habits. Les vêtements Petits-Gens se résument à la simplicité. Un chandail à moitié déchiré, une salopette de travail, rien de mieux que se sentir valoriser dans la simplicité sauve dans des rares occasions\r\n\r\nLes Petits-Gens sont d'énormes fervents des ancêtres travailleurs, agricoles et fermier. Pour eux, la vie se résume à pouvoir se lever le matin et avoir leur routine quotidienne sans se soucier des problèmes politiques. Vouant ainsi des fêtes et des grandes offrandes pour que les terres soient fertiles pour les jours à venir.\r\n\r\nComme les Nains, les Petits-Gens trouvent l’amour dans la simplicité, par le chant d’une chanteuse charmeuse ou même par la simplicité d’une bonne baguette qui sort directement du four du boulanger du coin.";

		public override int[] SkinHues => new int[] { 1823, 1819, 1830, 1821, 1822 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new PetitGens(2, 2));
		}

		public PetitGens(int raceID, int raceIndex) : base(raceID, raceIndex, "Petit Gens", "Petits Gens", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsPetitGens(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52085;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsPetitGens : BaseRaceGumps
	{
		[Constructable]
		public CorpsPetitGens() : this(0)
		{
		}

		[Constructable]
		public CorpsPetitGens(int hue) : base(0xA220, hue)
		{
			Name = "Petit Gens";
		}

		public CorpsPetitGens(Serial serial)
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

