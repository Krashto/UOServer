namespace Server.Items
{
	public  class AmeSquelette : BaseSoul
    {
		[Constructable]
		public AmeSquelette() : base(1940, 9660)
		{
			Name = "�me de squelette";
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

	public class AmeChevalSquelettique : BaseSoul
	{
		[Constructable]
		public AmeChevalSquelettique() : base(1940, 9751)
		{
			Name = "�me de cheval squelette";
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
	public class AmeMageSquelette : BaseSoul
	{
		[Constructable]
		public AmeMageSquelette() : base(1940, 9662)
		{
			Name = "�me de mage squelette";
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
	public class AmeSpectre : BaseSoul
	{
		[Constructable]
		public AmeSpectre() : base(1940, 9671)
		{
			Name = "�me de spectre";
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
	public class AmeLiche : BaseSoul
	{
		[Constructable]
		public AmeLiche() : base(1940, 9636)
		{
			Name = "�me de liche";
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
	public class AmeSquelRapiece : BaseSoul
	{
		[Constructable]
		public AmeSquelRapiece() : base(1940, 9769)
		{
			Name = "�me de squelette rapiece";
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
	public class AmeWight : BaseSoul
	{
		[Constructable]
		public AmeWight() : base(1940, 10092)
		{
			Name = "�me de wight";
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
	public class AmeSpectreAstral : BaseSoul
	{
		[Constructable]
		public AmeSpectreAstral() : base(1940, 17054)
		{
			Name = "�me de spectre astral";
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
	public class AmeChevalierSquelettique : BaseSoul
	{
		[Constructable]
		public AmeChevalierSquelettique() : base(1940, 9661)
		{
			Name = "�me de chevalier squelette";
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
	public class AmeSeigneurLiche : BaseSoul
	{
		[Constructable]
		public AmeSeigneurLiche() : base(1940, 9637)
		{
			Name = "�me de seigneur liche";
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
	public class AmeCauchemar : BaseSoul
	{
		[Constructable]
		public AmeCauchemar() : base(1940, 9628)
		{
			Name = "�me de cauchemar";
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
	public class AmeDragonSquelettique : BaseSoul
	{
		[Constructable]
		public AmeDragonSquelettique() : base(1940, 8406)
		{
			Name = "�me de dragon squelettique";
		}

		public AmeDragonSquelettique(Serial serial) : base(serial)
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
	public class AmeLicheAncienne : BaseSoul
	{
		[Constructable]
		public AmeLicheAncienne() : base(1940, 9637)
		{
			Name = "�me de liche ancienne";
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
	public class AmeLicheSquelettique : BaseSoul
	{
		[Constructable]
		public AmeLicheSquelettique() : base(1940, 9769)
		{
			Name = "�me de liche squelettique";
		}

		public AmeLicheSquelettique(Serial serial) : base(serial)
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
	public class AmeDemonOs : BaseSoul
	{
		[Constructable]
		public AmeDemonOs() : base(1940, 9768)
		{
			Name = "�me de demon d'os";
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

	public class AmeLadyMelisande : BaseSoul
	{
		[Constructable]
		public AmeLadyMelisande() : base(1940, 9636)
		{
			Name = "�me de lady melisande";
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
	public class AmeSerado : BaseSoul
	{
		[Constructable]
		public AmeSerado() : base(1940, 10097)
		{
			Name = "�me de serado";
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