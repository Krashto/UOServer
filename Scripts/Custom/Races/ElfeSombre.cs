using Server.Items;

namespace Server.Custom.Races
{
	class ElfeSombre : BaseRace
	{
		public override string Background => " Alors que la grande guerre entre les elfes et humains battait son plein, de jeunes curieux haut-elfes questionnèrent les restrictions et entraves imposées par leurs anciens à l’étude des arcanes en leur ensemble. Puiser dans le grand flot des âmes, à la puissance incommensurable, était selon ces jeunes un incontournable pour garantir une victoire décisive et indiscutable du peuple elfique, remettant ainsi les présomptueux humains à leur place. Dédaignant les limitations arbitrairement injustes entourant les arts arcaniques, la cabale de ces jeunes haut-elfes entreprit des rites et pratiques qui peu à peu altérèrent leur nature. Dénoncés par certains de leurs pairs craintifs, ils furent jugés et bannis de Lonn. Les anciens espéraient que les jeunes arcanistes apprendraient de cette leçon et reviendraient se repentir, mais les expulsés furent au contraire aigris, vengeurs, vindicatifs, déjà affectés par les auras funestes des forces qu’ils manipulaient sans tout en comprendre. \r\n\r\nLes exilés trouvèrent une grotte à flanc de montagne à l’intérieur de laquelle ils fondèrent leur commune au mode de vie troglodyte, en un lieu où le soleil ne brillait jamais. Ces haut-elfes devinrent au fil des années elfes sombres, corrompus par les obscurs arts arcaniques dans lesquels ils furent plongés, gagnés par la folie tandis qu’ils brouillaient les frontières entre le monde des morts et celui des vivants. Le cataclysme venu, les elfes sombres furent à nouveau éjectés de leur isolement et condamnés à refluer vers les terres de Colognan. Ils emportèrent pour bagage leurs compétences arcaniques indiscutables et leur proverbiale folie.";

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

