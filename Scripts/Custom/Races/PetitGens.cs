using Server.Items;

namespace Server.Custom.Races
{
	class PetitGens : BaseRace
	{
		public override string Background => " Leur genèse est méconnue et leur existence suscite bien des débats. Certains croient qu’ils sont le mélange entre des humains et des nains dû à leur pilosité et à leur petite taille. D’autres soutiennent cependant que les petits gens sont des humains ou nains difformes, maudits et abandonnés à la naissance, s’accrochant contre toute attente à la vie en se multipliant entre eux. Insouciants de tout ce tohu-bohu, les petits gens sont les orphelins de l’histoire dont la communauté sait bien constituer le grenier de tout Casterral, de quoi rendre les autres peuples heureux.";

		public override int[] SkinHues => new int[] { 2307, 2308, 2309, 2313, 2314 };

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

