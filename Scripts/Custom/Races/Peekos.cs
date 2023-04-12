using Server.Items;

namespace Server.Custom.Races
{
	class Peekos : BaseRace
	{
		public override string Background => "Les Peekos sont une race d'hommes-lion. Ils ont une apparence féline, avec des griffes rétractables et des yeux perçants. Depuis le cataclysme qui a frappé leur patrie Savana, leur nombre a considérablement diminué, et ils sont souvent perçus comme une race en voie d'extinction.\r\n\r\nLes Peekos ont une grande agilité et sont des chasseurs redoutables. Ils ont un instinct de prédateur et sont capables de se déplacer avec une grande discrétion. Leurs griffes leur permettent de s'agripper à des surfaces difficiles d'accès, ce qui leur permet de se déplacer facilement dans des environnements hostiles. Ils ont également la capacité de voir dans l'obscurité, ce qui en fait des chasseurs redoutables la nuit.\r\n\r\nLes habits des Peekos est portés sur la liberté du mouvement, rare qu'ils vont porter des vêtements trop obstruant qui les empêche de se déplacer librement. Alors que certains arborent les couleurs orangées pour être perçu comme un prédateur, d’autre préfère rester en retrait et arborer des couleurs noires pour ne pas attirer l’attention. Malgré leur réputation de chasseurs solitaires, les Peekos sont des êtres sociaux et ont une grande capacité d'empathie envers les autres. Ils sont souvent considérés comme des artisans et des commerçants talentueux, et sont capables de s'adapter à des environnements très différents. Les Peekos sont également réputés pour leur honnêteté, même s'ils peuvent parfois être considérés comme imprévisibles et indomptables.\r\n\r\nLa culture des Peekos est basée sur des traditions tribales et nomades. Ils ont une grande importance accordée à la famille et à la communauté, et ils sont très liés à leur environnement naturel. Les Peekos vénèrent des esprits de la nature et ont une grande méfiance envers les pratiques magiques étrangères. Ils ont également une culture riche en musique, en danse et en récits d'histoires.\r\n\r\nL’amour chez les Peekos est souvent lié à un amour de meute. Tous les guerriers et guerrière Peekos doivent combattre pour prouver être digne de son prétendant ou sa prétendante. Un rituel dénommé aujourd’hui Peekarlie primitif certes, mais reste ancré dans la nature Peekos. Le Peekos victorieux peu ainsi vouer son amour à l’autre personne, en cas de défaite ça ira à la prochaine assemblée du Peekarlie";

		public override int[] SkinHues => new int[] { 1909, 2735, 2338, 2345 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Peekos(8, 8));
		}

		public Peekos(int raceID, int raceIndex) : base(raceID, raceIndex, "Peeko", "Peekos", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsPeekos(0xA226, hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52097;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsPeekos : BaseRaceGumps
	{
		[Constructable]
		public CorpsPeekos() : this(0)
		{
		}

		[Constructable]
		public CorpsPeekos(int id, int hue) : base(id, hue)
		{
			Name = "Peekos";
		}

		public CorpsPeekos(Serial serial)
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

