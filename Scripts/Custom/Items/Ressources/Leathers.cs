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
    public class PlainoisLeather : BaseLeather
    {
        [Constructable]
        public PlainoisLeather()
            : this(1)
        {
        }

        [Constructable]
        public PlainoisLeather(int amount)
            : base(CraftResource.PlainoisLeather, amount)
        {
        }

        public PlainoisLeather(Serial serial)
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
    public class ForestierLeather : BaseLeather
    {
        protected override CraftResource DefaultResource => CraftResource.ForestierLeather;

        [Constructable]
        public ForestierLeather()
            : this(1)
        {
        }

        [Constructable]
        public ForestierLeather(int amount)
            : base(CraftResource.ForestierLeather, amount)
        {
        }

        public ForestierLeather(Serial serial)
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
    public class DesertiqueLeather : BaseLeather
    {
        protected override CraftResource DefaultResource => CraftResource.DesertiqueLeather;

        [Constructable]
        public DesertiqueLeather()
            : this(1)
        {
        }

        [Constructable]
        public DesertiqueLeather(int amount)
            : base(CraftResource.DesertiqueLeather, amount)
        {
        }

        public DesertiqueLeather(Serial serial)
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
    public class CollinoisLeather : BaseLeather
    {
        protected override CraftResource DefaultResource => CraftResource.CollinoisLeather;

        [Constructable]
        public CollinoisLeather()
            : this(1)
        {
        }

        [Constructable]
        public CollinoisLeather(int amount)
            : base(CraftResource.CollinoisLeather, amount)
        {
        }

        public CollinoisLeather(Serial serial)
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
	public class SavanoisLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.SavanoisLeather;

		[Constructable]
		public SavanoisLeather()
			: this(1)
		{
		}

		[Constructable]
		public SavanoisLeather(int amount)
			: base(CraftResource.SavanoisLeather, amount)
		{
		}

		public SavanoisLeather(Serial serial)
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
	public class ToundroisLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.ToundroisLeather;

		[Constructable]
		public ToundroisLeather()
			: this(1)
		{
		}

		[Constructable]
		public ToundroisLeather(int amount)
			: base(CraftResource.ToundroisLeather, amount)
		{
		}

		public ToundroisLeather(Serial serial)
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
	public class VolcaniqueLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.VolcaniqueLeather;

		[Constructable]
		public VolcaniqueLeather()
			: this(1)
		{
		}

		[Constructable]
		public VolcaniqueLeather(int amount)
			: base(CraftResource.ToundroisLeather, amount)
		{
		}

		public VolcaniqueLeather(Serial serial)
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
	public class TropicauxLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.TropicauxLeather;

		[Constructable]
		public TropicauxLeather()
			: this(1)
		{
		}

		[Constructable]
		public TropicauxLeather(int amount)
			: base(CraftResource.TropicauxLeather, amount)
		{
		}

		public TropicauxLeather(Serial serial)
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
	public class MontagnardLeather : BaseLeather
	{
		protected override CraftResource DefaultResource => CraftResource.MontagnardLeather;

		[Constructable]
		public MontagnardLeather()
			: this(1)
		{
		}

		[Constructable]
		public MontagnardLeather(int amount)
			: base(CraftResource.MontagnardLeather, amount)
		{
		}

		public MontagnardLeather(Serial serial)
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