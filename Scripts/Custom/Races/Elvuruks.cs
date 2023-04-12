using Server.Items;

namespace Server.Custom.Races
{
	class Elvuruks : BaseRace
	{
		public override string Background => "Les Elvuruks, également connus sous le nom d'Orcs ou Uruk, est un peuple d'origine elfique qui a évolué vers une apparence plus robuste et musclée. Ils sont souvent associés à leur grande force physique, leur courage et leur bravoure au combat.\r\n\r\nLes premiers Elvuruks qui naquirent sont le bataillon argenté d’Elvolus qui a été décimé prêt de la montagne d’Hagmar, quelques survivants ont été rapatrier sur les hautes-terres elfique, mais fut aussitôt renvoyer sur le champ de bataille pour désertion. Maladif de voir que le peuple Elvolus ne voulait plus d’eux, ils se sont dispersés dans la forêt qui longeait la montagne. Ainsi, leur peau qui était en contact avec la nature et les cendres volcaniques ont eu raison de leur nature argentée.\r\n\r\nLes Elvuruks ont une apparence très reconnaissable, avec leur peau verte et leurs traits de visage massifs et anguleux. Ils ont souvent les cheveux noirs et épais, ainsi que des cicatrices ou des tatouages sur leur peau, chaque tatouage ou cicatrise représente une histoire et ne se gêne pas de décrire l’exploit qui lui est relié. Les habits des Elvuruks se résument à être le plus primitif possible. Que ce soit avec des jupes de guerre ou des armures de cuir. Le style vestimentaire Elvuruks n’est pas pris réellement en considération cependant, il arrive des exceptions ou on y retrouve des Elvuruks en grosse armure de plaque, de grande robe de cérémonie ou même des habits plutôt léger. La couleur du vert de la forêt et du noir du mont Hagmar\r\n\r\nLes Elvuruks sont souvent considérés comme des guerriers redoutables, avec une grande maîtrise de la guerre et de la fabrication d'armes. Ils ont également une culture très communautaire, où la force collective est valorisée par rapport à la force individuelle. Cependant, il n’est pas rare de voir les jeunes écervelés être remis à l’ordre par les plus vieux Elvuruk. Ce peuple a été presque envoyé à l’abattoir par leur géniteur. Prouvons-leur que nous pouvons être mieux qu’eux en étant supérieur sur le point de vue spirituelle et physique.\r\n\r\nEn termes de croyances et de valeurs, les Elvuruks sont souvent décrits comme des gens pragmatiques, qui valorisent l'honneur et la loyauté. Ils ont un profond respect pour les anciens et pour les traditions de leur peuple, ainsi que pour les ancêtres.\r\n\r\nL’amour chez les Elvuruks se résume à la survie de leur espèce bien que parfois un sentiment fort dans la combativité naît et conçois ainsi la symbiose de deux être. Les Elvuruks ne veulent pas refaire les erreurs de leur géniteur. Prouvant ainsi que même dans la douleur, la survie a été plus fort que tout.";

		public override int[] SkinHues => new int[] { 1798, 2687, 2712, 2778, 2781 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new Elvuruks(10, 10));
		}

		public Elvuruks(int raceID, int raceIndex) : base(raceID, raceIndex, "Elvuruk", "Elvuruks", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsElvuruks(0xA21D, hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52082;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsElvuruks : BaseRaceGumps
	{
		[Constructable]
		public CorpsElvuruks() : this(0)
		{
		}

		[Constructable]
		public CorpsElvuruks(int id, int hue) : base(id, hue)
		{
			Name = "Elvuruks";
		}

		public CorpsElvuruks(Serial serial)
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

