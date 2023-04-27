using Server.Items;

namespace Server.Custom.Races
{
	class HautElfe : BaseRace
	{
		public override string Background => "Haut-Elfes, également connus sous le nom d'Elfes des hautes-terres ou Elfes-Absolu, est un peuple elfique d'origine magique, connus pour leur grande maîtrise de la magie et leur orgueil représentatif de leur digne lignée. Les Haut-Elfes sont les représentant de la première entité elfique du continent de Casterral.\r\n\r\nLes Haut-Elfes ont une apparence distinctive, avec leur teint doré, leurs traits de visage fins et leurs longs cheveux dorés ou argentés. Ils sont souvent considérés comme étant beaux et gracieux, et ont une haute estime de leur propre race à un tel point qu’ils regardent les autres races de haut, ce côté hautain leur a valu le titre de ‘’Race Suprême.’’\r\n\r\nLes premiers elfes sont portées à rester dans le chemin de la lumière par leur grâce, leur position suprême fait d’eux des êtres qui ne puis tomber dans l’oubli donc pour ceci, ils sont disposés à porter des vêtements argenté, jaune et doré pour se sentir ainsi valorisé à leur juste valeur. Prouvant leur supériorité par leur naissance.  Les Haut-Elfes ont une culture qui est basée sur la connaissance et les traditions, ainsi que sur la maîtrise de l’Aéromancie. Ils ont une longue histoire et une grande tradition de savoir, qui est transmise de génération en génération. Les Haut-Elfes sont souvent considérés comme étant arrogants et condescendants envers les autres races, ce qui peut les rendre impopulaires auprès de certaines personnes. Malgré tout, les Haut-Elfes ont su apporter les premières écrits, les traditions de Casterral et surtout les premières nations.\r\n\r\nEn matière de religion, les Haut-Elfes vénèrent leur ancêtre Haut-Elfes, les premiers créateurs des nations, des ancêtres qui leur servent de grand guide spirituel, et considèrent leur propre race comme étant la plus proche de la perfection. Ils sont souvent considérés comme étant conservateurs et traditionnels, et ont tendance à se méfier des étrangers et des idées nouvelles.\r\n\r\nLe lien d’attachement des Haut-Elfes envers les siens est primordial. Ceux voulant copuler avec d’autres races sont rejetés par les leurs, souvent, on entend parler de tuerie publique, car la disgrâce des Haut-Elfes a été souillée par la trahison d’un des leurs. Il ne faut pas jouer avec eux sur les sentiments, car la vision d’un Haut-Elfes est d’être pur.";

		public override int[] SkinHues => new int[] { 2107, 2108, 2109, 2110, 2111 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new HautElfe(0, 0));
		}

		public HautElfe(int raceID, int raceIndex) : base(raceID, raceIndex, "Haut-Elfe", "Haut-Elfes", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsHautElfe(hue);
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
	public class CorpsHautElfe : BaseRaceGumps
	{
		[Constructable]
		public CorpsHautElfe() : this(0)
		{
		}

		[Constructable]
		public CorpsHautElfe(int hue) : base(0xA21C, hue)
		{
			Name = "Haut-Elfe";
		}

		public CorpsHautElfe(Serial serial)
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

