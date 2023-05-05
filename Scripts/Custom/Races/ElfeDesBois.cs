using Server.Items;

namespace Server.Custom.Races
{
	class ElfeDesBois : BaseRace
	{
		public override string Background => "D’importants conflits politiques secouèrent la société des haut-elfes, opposant les voix progressistes à celles conservatrices. À la culmination de ces tensions irréconciliables, que ne purent pas mitiger les sages de la cité de Lonn, la faction la plus humble et ouverte finit par s’exiler volontairement. Les exilés s’établirent dans une luxuriante forêt, espérant ainsi communier avec la nature et l'esprit de la terre. Au fil de siècles paisibles, ils développèrent une symbiose avec la terre plus intense qu’anticipé. Ces exilés devenus elfes des bois apprirent à reconnaître et honorer l'influence des esprits dans chaque bête et chaque plante qui les protégèrent en retour. Cette vie bucolique fut soudainement troublée par les incursions conquérantes des légions de l'Empire riverain. Conjurant l'aide des esprits et puisant à même leur immense pouvoir arcanique ou leur connaissance de la forêt, ils purent temporairement tenir tête aux armées humaines jusqu’à l’épuisement de toute résistance. S’ensuivirent d’innombrables concessions et expiations, face à une puissante armée occupante qui dépouillait entièrement la forêt. Les prières vengeresses des elfes des bois aux esprits naturels furent laissées sans réponse, ces derniers déjà affaiblis par les chasses et corvées bucheronnes des hommes avides à trouver profit dans chaque territoire conquis. Il fallut attendre le grand cataclysme pour mettre un terme aux souffrances des elfes des bois. Cependant, ces réjouissances furent de courte durée : pour survivre, il leur fallait suivre leurs anciens tyrans et travailler avec eux. Les plus optimistes elfes des bois prêchaient l’espoir d’un respect de la nature issu de cette coexistence. Les autres, plus sombres et réalistes, rêvaient de leur émancipation et du retour à la forêt intouchée.";

		public override int[] SkinHues => new int[] { 1052, 1054, 1055, 1056, 1057 };

		public static void Configure()
		{
			/* Here we configure all races. Some notes:
			* 
			* 1) The first 32 races are reserved for core use.
			* 2) Race 0x7F is reserved for core use.
			* 3) Race 0xFF is reserved for core use.
			* 4) Changing or removing any predefined races may cause server instability.
			*/
			RegisterRace(new ElfeDesBois(3, 3));
		}

		public ElfeDesBois(int raceID, int raceIndex) : base(raceID, raceIndex, "Elfe des bois", "Elfes des bois", 400, 401, 402, 403)
		{
		}

		public override bool ValidateEquipment(Item item)
		{
			return true;
		}

		public override BaseRaceGumps GetSkin(int hue)
		{
			return new CorpsElfeDesBois(hue);
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
	public class CorpsElfeDesBois : BaseRaceGumps
	{
		[Constructable]
		public CorpsElfeDesBois() : this(0)
		{
		}

		[Constructable]
		public CorpsElfeDesBois(int hue) : base(0xA21C, hue)
		{
			Name = "Elfe des bois";
		}

		public CorpsElfeDesBois(Serial serial)
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

