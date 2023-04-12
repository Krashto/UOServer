using Server.Items;

namespace Server.Custom.Races
{
	class Azmins : BaseRace
	{
		public override string Background => "Certains croient qu’ils sont le mélange entre un Azuriens et un Minkos, dû à leur pilosité et à leur petite taille. Malgré tout, aucune preuve de leur création, ou était le premier Azmins à avoir foulé la terre de Casterral ? Nul ne peut le dire. Certains croient que la provenance des Azmins est des Azuriens qui ont été maudit à la naissance, d’autre croient en une malformation des Minkos. Le sujet est à questionnement encore aujourd’hui.\r\n\r\nLes Azmins sont une race de petits êtres humanoïdes. Ils mesurent en moyenne entre 90 cm et 1,20 m de hauteur et ont tendance à être potelés. Leur peau est souvent bronzée et leurs pieds sont grands et velus. Ils ont des yeux brillants et des cheveux bouclés, généralement bruns ou blonds.\r\n\r\nLes Azmins vivent dans des maisons souterraines appelées \"Azmial\" ou des trous d’Azmins, situés dans les plaines et dans les vallées verdoyantes de Casterral. Ils ont une culture simple et paisible, centrée sur la famille et les amis, et se consacrent à des activités telles que la culture de légumes, la cuisine, la fête, la lecture. Bien que les Azmins soient généralement pacifiques et préfèrent éviter les conflits, ils sont capables de courage et de ténacité lorsqu'ils sont poussés à agir. Grâce à leur courage et leur détermination, ils ont réussi à surmonter de nombreux obstacles pour atteindre leur but et pouvoir profiter de leur joli petit village au cœur de la plaine de Casterral. Vivant ainsi en harmonie des festivités et des simples plaisirs de la vie.\r\n\r\nLes Azmins sont banals niveaux vestimentaires saufs pour les grandes soirées ou qu’ils sortent le total de leur collection d’habits. Les vêtements Azmins se résument à la simplicité. Un chandail à moitié déchiré, une salopette de travail, rien de mieux que se sentir valoriser dans la simplicité sauve dans des rares occasions\r\n\r\nLes Azmins sont d'énormes fervents des ancêtres travailleurs, agricoles et fermier. Pour eux, la vie se résume à pouvoir se lever le matin et avoir leur routine quotidienne sans se soucier des problèmes politiques. Vouant ainsi des fêtes et des grandes offrandes pour que les terres soient fertiles pour les jours à venir.\r\n\r\nComme les Minkos, les Azmins trouvent l’amour dans la simplicité, par le chant d’une chanteuse charmeuse ou même par la simplicité d’une bonne baguette qui sort directement du four du boulanger du coin.";

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
			RegisterRace(new Azmins(2, 2));
		}

		public Azmins(int raceID, int raceIndex) : base(raceID, raceIndex, "Azmin", "Azmins", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsAzmin(0xA220, hue);
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
	public class CorpsAzmin : BaseRaceGumps
	{
		[Constructable]
		public CorpsAzmin() : this(0)
		{
		}

		[Constructable]
		public CorpsAzmin(int id, int hue) : base(id, hue)
		{
			Name = "Azmin";
		}

		public CorpsAzmin(Serial serial)
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

