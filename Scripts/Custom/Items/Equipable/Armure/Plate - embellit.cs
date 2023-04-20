using Server.Engines.Craft;

namespace Server.Items
{
	public class BrassardEmbellit : BaseArmor
	{
		[Constructable]
		public BrassardEmbellit()
			: base(0xA449)
		{
			Weight = 5.0;
			Name = "Brassard Embellit";
		}

		public BrassardEmbellit(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 80;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class CasqueEmbellit : BaseArmor
	{
		public override bool Anonymous => true;

		[Constructable]
		public CasqueEmbellit()
			: base(0xA44A)
		{
			Weight = 5.0;
			Name = "Casque Embellit";
		}

		public CasqueEmbellit(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 80;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class PlastronEmbellit : BaseArmor
	{
		[Constructable]
		public PlastronEmbellit()
			: base(0xA44E)
		{
			Weight = 10.0;
			Name = "Plastron Embellit";
		}

		public PlastronEmbellit(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 95;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	

	public class JambiereEmbellit : BaseArmor
	{
		[Constructable]
		public JambiereEmbellit()
			: base(0xA44D)
		{
			Weight = 7.0;
			Name = "Jambière Embellit";
		}

		public JambiereEmbellit(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 90;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	

	public class GantsEmbellit : BaseArmor
	{
		[Constructable]
		public GantsEmbellit()
			: base(0xA44B)
		{
			Weight = 2.0;
			Name = "Gants Embellit";
		}

		public GantsEmbellit(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 70;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class GorgetEmbellit : BaseArmor
	{
		[Constructable]
		public GorgetEmbellit()
			: base(0xA44C)
		{
			Weight = 2.0;
			Name = "Gorget Embellit";
		}

		public GorgetEmbellit(Serial serial)
			: base(serial)
		{
		}

		public override int BasePhysicalResistance => 6;
		public override int BaseFireResistance => 3;
		public override int BaseColdResistance => 2;
		public override int BasePoisonResistance => 3;
		public override int BaseEnergyResistance => 2;
		public override int InitMinHits => 50;
		public override int InitMaxHits => 65;
		public override int StrReq => 45;
		public override ArmorMaterialType MaterialType => ArmorMaterialType.Chainmail;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	


}






