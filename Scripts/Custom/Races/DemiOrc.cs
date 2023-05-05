using Server.Items;

namespace Server.Custom.Races
{
	class DemiOrc : BaseRace
	{
		public override string Background => " Les sauvages orques furent le fléau rampant du continent. Leur horde posa des camps et monta indistinctement des embuscades, des assauts et des sièges contre les puissances humaines et elfiques. Organiquement liés à la guerre et son lot d’horreurs sur les vaincus, ces créatures tribales prirent goût à la capture des femmes humaines. Les fruits de ces noces barbares furent les demi-orques. Ceux nés au sein de la horde en finirent bien souvent écartés, volontairement ou non, pour être plus nuancés et plus intelligents que les brutes épaisses occupant les camps de guerre. À l’inverse, ceux nés au sein de sociétés humaines en furent rapidement rejetés, objets de honte pour leurs mères à jamais souillées par les monstruosités. Au plus souvent, ces demi-monstres furent abandonnés dans la nature à assurer leur propre survie. \r\n\r\nAu gré d'errance, les demi-orques développèrent un sens de tribale solidarité après s’être croisés. Ils formèrent de petites tribus, loin de toutes les civilisations où ils furent rejetés, y compris celle des monstres qui en avaient la paternité. Toujours plus nombreux, ils établirent un campement dans les terres gelées où peu osèrent s’aventurer. Parmi les rares exploits des demi-orques, une grande victoire sur une légion de l'Empire Riverain, embourbée sur les terres gelées, éleva la notoriété des demi-orques aux yeux de l'humanité. Davantage que des monstres, ils furent reconnus par l'Empire lui-même comme étant de redoutables combattants. \r\n\r\nMalheureusement, le cataclysme eut raison de leur camp de fortune des terres gelées et des perpétuelles escarmouches avec les montagnards de cette obstinée légion. Comme tant d'autres peuples, les demi-orques refluèrent vers les terres épargnées par la catastrophe, espérant que leur vaillance, leur habileté au combat et leur discipline les protégeraient des préjudices d'autrefois.";

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
			RegisterRace(new DemiOrc(10, 10));
		}

		public DemiOrc(int raceID, int raceIndex) : base(raceID, raceIndex, "Demi-orc", "Demi-orcs", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsDemiOrc(hue);
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
	public class CorpsDemiOrc : BaseRaceGumps
	{
		[Constructable]
		public CorpsDemiOrc() : this(0)
		{
		}

		[Constructable]
		public CorpsDemiOrc(int hue) : base(0xA21D, hue)
		{
			Name = "Demi-orc";
		}

		public CorpsDemiOrc(Serial serial)
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

