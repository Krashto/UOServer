using Server.Items;

namespace Server.Custom.Races
{
	class DemiElfe : BaseRace
	{
		public override string Background => " Des trêves sporadiques ponctuèrent l’éternelle guerre sur le continent entre elfes et humains. C’est dans cette relative paix que des individus des deux peuples tissèrent de profonds liens entre eux jusqu’à des idylles et des passions, engendrant des hybrides mi-elfes, mi-humains. La première génération fut élevée en cachette parmi les hommes ou les elfes, apprenant à se fondre dans la masse, à cacher leur identité et leur véritable nature, incarnant une identité duale unique. Conscients de la persécution subie au sein des deux peuples, une poignée de ces hybrides prit l’initiative de s’exiler et de fonder un bastion qui accueillerait des « sang mêlé » comme eux : Haute-Roche. L’afflux soudain en provenance des terres elfiques et humaines étonna les pionniers. Ils firent de leur simple bastion un édifiant petit village, mariant l'architecture elfique à la solidité structurelle humaine. Au fil des années, Haute-Roche se consolida comme siège d'une civilisation à part entière. Nombreux étaient les poupons hybrides confiés ou même abandonnés à Haute-Roche par les parents échappant à la persécution ou de mortelles sanctions. Dans cette commune renégate se développa une philosophie attestant l’union dans le sang du meilleur des deux peuples d'origine, avec l’espoir d’être les initiateurs d’une paix durable l'humanité et les elfes, ces éternels ennemis. Le malheur du grand cataclysme chamboula leurs plans, imposant aux rescapés demi-elfes de Haute-Roche la fuite vers les terres plus clémentes de Colognan…";

		public override int[] SkinHues => new int[] { 1037, 1039, 1102, 1110, 1114 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new DemiElfe(4, 4));
		}

		public DemiElfe(int raceID, int raceIndex) : base(raceID, raceIndex, "Demi-Elfe", "Demi-Elfes", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsDemiElfe(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52083;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsDemiElfe : BaseRaceGumps
	{
		[Constructable]
		public CorpsDemiElfe() : this(0)
		{
		}

		[Constructable]
		public CorpsDemiElfe(int hue) : base(0xA21E, hue)
		{
			Name = "Demi-Elfe";
		}

		public CorpsDemiElfe(Serial serial)
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

