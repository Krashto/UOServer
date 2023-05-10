using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Gumps;
///using Server.Custom.Enums;
using Server.Custom;

namespace Server.Items
{

	public  class AmeSquelette : Item //BaseJet
    {
		[Constructable]
		public AmeSquelette() : base(9660)
		{
			
			Name = "ame de squelette";
			Weight = 1.0;
			Hue = 1940;
        }

		public AmeSquelette( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
	public class AmeChevalSquelettique : Item //BaseJet
	{
		[Constructable]
		public AmeChevalSquelettique() : base(9751)
		{

			Name = "ame de cheval squelette";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeChevalSquelettique(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeMageSquelette : Item //BaseJet
	{
		[Constructable]
		public AmeMageSquelette() : base(9662)
		{

			Name = "ame de mage squelette";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeMageSquelette(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeSpectre : Item //BaseJet
	{
		[Constructable]
		public AmeSpectre() : base(9671)
		{

			Name = "ame de spectre";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeSpectre(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeLiche : Item //BaseJet
	{
		[Constructable]
		public AmeLiche() : base(9636)
		{

			Name = "ame de liche";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeLiche(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeSquelRapiece : Item //BaseJet
	{
		[Constructable]
		public AmeSquelRapiece() : base(9769)
		{

			Name = "ame de squelette rapiece";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeSquelRapiece(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeWight : Item //BaseJet
	{
		[Constructable]
		public AmeWight() : base(10092)
		{

			Name = "ame de wight";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeWight(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeSpectreAstral : Item //BaseJet
	{
		[Constructable]
		public AmeSpectreAstral() : base(17054)
		{

			Name = "ame de spectre astral";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeSpectreAstral(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeChevalierSquelettique : Item //BaseJet
	{
		[Constructable]
		public AmeChevalierSquelettique() : base(9661)
		{

			Name = "ame de chevalier squelette";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeChevalierSquelettique(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeSeigneurLiche : Item //BaseJet
	{
		[Constructable]
		public AmeSeigneurLiche() : base(9637)
		{

			Name = "ame de seigneur liche";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeSeigneurLiche(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeCauchemar : Item //BaseJet
	{
		[Constructable]
		public AmeCauchemar() : base(9628)
		{

			Name = "ame de cauchemar";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeCauchemar(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeDragonSquel : Item //BaseJet
	{
		[Constructable]
		public AmeDragonSquel() : base(8406)
		{

			Name = "ame de dragon squelettique";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeDragonSquel(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeLicheAncienne : Item //BaseJet
	{
		[Constructable]
		public AmeLicheAncienne() : base(9637)
		{

			Name = "ame de liche ancienne";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeLicheAncienne(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeLicheSquel : Item //BaseJet
	{
		[Constructable]
		public AmeLicheSquel() : base(9769)
		{

			Name = "ame de liche squelettique";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeLicheSquel(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeDemonOs : Item //BaseJet
	{
		[Constructable]
		public AmeDemonOs() : base(9768)
		{

			Name = "ame de demon d'os";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeDemonOs(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeLadyMelisande : Item //BaseJet
	{
		[Constructable]
		public AmeLadyMelisande() : base(9636)
		{

			Name = "ame de lady melisande";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeLadyMelisande(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AmeSerado : Item //BaseJet
	{
		[Constructable]
		public AmeSerado() : base(10097)
		{

			Name = "ame de serado";
			Weight = 1.0;
			Hue = 1940;

		}

		public AmeSerado(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}