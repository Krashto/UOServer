using System;


namespace Server.Items
{
    public abstract class BaseLeather : Item, ICommodity
    {
        protected virtual CraftResource DefaultResource => CraftResource.PlainoisLeather;

        private CraftResource m_Resource;
        public BaseLeather(CraftResource resource)
            : this(resource, 1)
        {
        }

        public BaseLeather(CraftResource resource, int amount)
            : base(0x1081)
        {
            Stackable = true;
            Weight = 1.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);

            m_Resource = resource;
        }

        public BaseLeather(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get
            {
                return m_Resource;
            }
            set
            {
                m_Resource = value;
                InvalidateProperties();
            }
        }
        public override int LabelNumber
        {
            get
            {
       /*         if (m_Resource >= CraftResource.SpinedLeather && m_Resource <= CraftResource.BarbedLeather)
                    return 1049684 + (m_Resource - CraftResource.SpinedLeather);*/

                return 1047022;
            }
        }
        TextDefinition ICommodity.Description => LabelNumber;
        bool ICommodity.IsDeedable => true;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version

            writer.Write((int)m_Resource);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 2: // Reset from Resource System
                    m_Resource = DefaultResource;
                    reader.ReadString();
                    break;
                case 1:
                    {
                        m_Resource = (CraftResource)reader.ReadInt();
                        break;
                    }
                case 0:
                    {
                        OreInfo info = new OreInfo(reader.ReadInt(), reader.ReadInt(), reader.ReadString());

                        m_Resource = CraftResources.GetFromOreInfo(info);
                        break;
                    }
            }
        }

		public override void AddNameProperty(ObjectPropertyList list)
		{
			var name = CraftResources.GetName(m_Resource);

			if (Amount > 1)
				list.Add(String.Format("{3} {0}{1}{2}", "Morceaux de cuir [", name, "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add(String.Format("{0}{1}{2}", "Morceau de cuir [", name, "]")); // ingots
		}

		/*      public override void AddNameProperty(ObjectPropertyList list)
			  {
				  if (Amount > 1)
					  list.Add(1050039, "{0}\t#{1}", Amount, 1024199); // ~1_NUMBER~ ~2_ITEMNAME~
				  else
					  list.Add(1024199); // cut leather
			  }

			  public override void GetProperties(ObjectPropertyList list)
			  {
				  base.GetProperties(list);

				  if (!CraftResources.IsStandard(m_Resource))
				  {
					  int num = CraftResources.GetLocalizationNumber(m_Resource);

					  if (num > 0)
						  list.Add(num);
					  else
						  list.Add(CraftResources.GetName(m_Resource));
				  }
			  }*/
	}

    [Flipable(0x1081, 0x1082)]
    public class Leather : BaseLeather
    {
        [Constructable]
        public Leather()
            : this(1)
        {
        }

        [Constructable]
        public Leather(int amount)
            : base(CraftResource.PlainoisLeather, amount)
        {
        }

        public Leather(Serial serial)
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

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1081, 0x1082)]
    public class LupusLeather : BaseLeather
    {
        protected override CraftResource DefaultResource => CraftResource.ForestierLeather;

        [Constructable]
        public LupusLeather()
            : this(1)
        {
        }

        [Constructable]
        public LupusLeather(int amount)
            : base(CraftResource.ForestierLeather, amount)
        {
        }

        public LupusLeather(Serial serial)
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

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1081, 0x1082)]
    public class ReptilienLeather : BaseLeather
    {
        protected override CraftResource DefaultResource => CraftResource.DesertiqueLeather;

        [Constructable]
        public ReptilienLeather()
            : this(1)
        {
        }

        [Constructable]
        public ReptilienLeather(int amount)
            : base(CraftResource.DesertiqueLeather, amount)
        {
        }

        public ReptilienLeather(Serial serial)
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

            int version = reader.ReadInt();
        }
    }

    [Flipable(0x1081, 0x1082)]
    public class GeantLeather : BaseLeather
    {
        protected override CraftResource DefaultResource => CraftResource.TaigoisLeather;

        [Constructable]
        public GeantLeather()
            : this(1)
        {
        }

        [Constructable]
        public GeantLeather(int amount)
            : base(CraftResource.TaigoisLeather, amount)
        {
        }

        public GeantLeather(Serial serial)
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

            int version = reader.ReadInt();
        }
    }

	[Flipable(0x1081, 0x1082)]
	public class OphidienLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.SavanoisLeather;

		[Constructable]
		public OphidienLeather()
			: this(1)
		{
		}

		[Constructable]
		public OphidienLeather(int amount)
			: base(CraftResource.SavanoisLeather, amount)
		{
		}

		public OphidienLeather(Serial serial)
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

			int version = reader.ReadInt();
		}
	}

	[Flipable(0x1081, 0x1082)]
	public class ArachnideLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.ToundroisLeather;

		[Constructable]
		public ArachnideLeather()
			: this(1)
		{
		}

		[Constructable]
		public ArachnideLeather(int amount)
			: base(CraftResource.ToundroisLeather, amount)
		{
		}

		public ArachnideLeather(Serial serial)
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

			int version = reader.ReadInt();
		}
	}

	[Flipable(0x1081, 0x1082)]
	public class DragoniqueLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.TropicauxLeather;

		[Constructable]
		public DragoniqueLeather()
			: this(1)
		{
		}

		[Constructable]
		public DragoniqueLeather(int amount)
			: base(CraftResource.TropicauxLeather, amount)
		{
		}

		public DragoniqueLeather(Serial serial)
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

			int version = reader.ReadInt();
		}
	}

	[Flipable(0x1081, 0x1082)]
	public class DemoniaqueLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.MontagnardLeather;

		[Constructable]
		public DemoniaqueLeather()
			: this(1)
		{
		}

		[Constructable]
		public DemoniaqueLeather(int amount)
			: base(CraftResource.MontagnardLeather, amount)
		{
		}

		public DemoniaqueLeather(Serial serial)
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

			int version = reader.ReadInt();
		}
	}

	[Flipable(0x1081, 0x1082)]
	public class AncienLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.AncienLeather;

		[Constructable]
		public AncienLeather()
			: this(1)
		{
		}

		[Constructable]
		public AncienLeather(int amount)
			: base(CraftResource.AncienLeather, amount)
		{
		}

		public AncienLeather(Serial serial)
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

			int version = reader.ReadInt();
		}
	}



}