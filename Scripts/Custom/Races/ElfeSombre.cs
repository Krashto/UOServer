using Server.Items;

namespace Server.Custom.Races
{
	class ElfeSombre : BaseRace
	{
		public override string Background => "Les Elfes sombres, également connus sous le nom d'Elfes Sombre, est un peuple elfique originaire de Chateau sombre. Attitude ricaneuse, les Elfes sombres ont tendance à trouver la vie en général amusante, que chaque sujet irrite les gens à un tel point. Les Elfes sombres ont cette attitude nonchalante, de ne rien prendre au sérieux puisse qu’au final, tous iront au même endroit. Serait-ce l’utilisation de la magie noire qui a rendu ces êtres atteints mentalement ? Nul ne le sait\r\n\r\nLes Elfes sombres sont un peuples qui était jadis une famille Haut-Elfes qui a été jugé coupable d’utilisation de Nécromancie, sans preuve. Ils ont été bannis des hautes-terres elfiques et ont réussit à migrer vers des grottes pour ainsi pratiquer leur nécromancie. L’utilisation de cette magie noire aura eu l’effet sur eux et leur ‘’Blancheur’’ jadis serait devenu ‘’Noirceur.’’\r\n\r\nLes Elfes sombres ont une apparence distinctive, avec leur peau sombre et leurs yeux rouges. Ils sont souvent considérés comme étant fiers et indépendants, avec une culture très différente de celle des autres races elfiques. Alors que leur culture se permet de salir la race Haut-Elfes dans des pièces de théâtre ou dans des sérénades. Ce côté sarcastique leur vaut surtout le surnom ‘’Sournois’’ bien qu’officiellement, les Elfes sombres n’ont jamais rien fait de mal.  Les Elfes sombres ont tendance à porté des vêtements blanc et rouge. Le blanc pour représenter la mort qu’ils côtoient chaque jour avec les pratiques néoromantiques et le rouge pour le sang versé lors de leur horrible exclusion des Haut-Elfes. Les vêtements gracieux sont en avant-plan dans la culture Elfes sombres alors que d’autre se contente de porter la représentation de la mort avec des ossements et des toges noir.\r\n\r\nLes Elfes sombres ont une société complexe, basée sur des maisons nobles et une forte hiérarchie sociale. Ils ont également une forte tradition sur le sujet de la mort à tel point que leur religion se vouent à être le sujet principal de leur ancêtre, qui ont pratiqué cette magie noire. La mort n’est pas une mauvaise chose puisque nous trouvions repos et réponse dans cette aventure.\r\n\r\nL’amour chez les Elfes sombres n’est situé ni important, ni banal. Ils trouvent que ce sentiment sérieux est lassant et qu’ils doivent profiter de chaque moment de leur vie afin de trouver leur partenaire. L’idéal est de retrouver la parfaite vision comme avec Arkodia et Doriam.";

		public override int[] SkinHues => new int[] { 1107, 1898, 1903, 1906, 2106 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new ElfeSombre(5, 5));
		}

		public ElfeSombre(int raceID, int raceIndex) : base(raceID, raceIndex, "Elfe sombre", "Elfes sombres", 400, 401, 402, 403)
		{
		}


		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsElfeSombre(hue);
		}

		public override int GetGumpId(bool female, int hue)
		{
			var gumpid = 52081;
			return female ? gumpid + 10000 : gumpid;
		}
	}
}

namespace Server.Items
{
	public class CorpsElfeSombre : BaseRaceGumps
	{
		[Constructable]
		public CorpsElfeSombre() : this(0)
		{
		}

		[Constructable]
		public CorpsElfeSombre(int hue) : base(0xA21C, hue)
		{
			Name = "Elfe sombre";
		}

		public CorpsElfeSombre(Serial serial)
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

