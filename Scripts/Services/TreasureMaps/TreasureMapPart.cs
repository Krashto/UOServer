namespace Server.Items
{
	public class BaseTreasureMapPart : Item
	{
		public virtual int Level { get; set; }

		[Constructable]
		public BaseTreasureMapPart() : this(1)
		{
			Name = "Morceau de carte au trésor";
			Weight = 0.5;
		}

		[Constructable]
		public BaseTreasureMapPart(int level) : base(0x14EC)
		{
			Name = "Morceau de carte au trésor";
			Weight = 0.5;
			Level = level;
		}

		public BaseTreasureMapPart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);

			writer.Write(Level);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			Level = reader.ReadInt();
		}

		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			list.Add($"Niveau {Level}");
		}
	}

	public class TreasureMapLevelOnePart : BaseTreasureMapPart
	{
		[Constructable]
		public TreasureMapLevelOnePart() : base(1)
		{
		}

		public TreasureMapLevelOnePart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class TreasureMapLevelTwoPart : BaseTreasureMapPart
	{
		[Constructable]
		public TreasureMapLevelTwoPart() : base(2)
		{
		}

		public TreasureMapLevelTwoPart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class TreasureMapLevelThreePart : BaseTreasureMapPart
	{
		[Constructable]
		public TreasureMapLevelThreePart() : base(3)
		{
		}

		public TreasureMapLevelThreePart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class TreasureMapLevelFourPart : BaseTreasureMapPart
	{
		[Constructable]
		public TreasureMapLevelFourPart() : base(4)
		{
		}

		public TreasureMapLevelFourPart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class TreasureMapLevelFivePart : BaseTreasureMapPart
	{
		[Constructable]
		public TreasureMapLevelFivePart() : base(5)
		{
		}

		public TreasureMapLevelFivePart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class TreasureMapLevelSixPart : BaseTreasureMapPart
	{
		[Constructable]
		public TreasureMapLevelSixPart() : base(6)
		{
		}

		public TreasureMapLevelSixPart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
	public class TreasureMapLevelSevenPart : BaseTreasureMapPart
	{
		[Constructable]
		public TreasureMapLevelSevenPart() : base(7)
		{
		}

		public TreasureMapLevelSevenPart(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}
