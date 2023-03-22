using System;


namespace Server.Items
{
    public abstract class BaseBone : Item
    {
        protected virtual CraftResource DefaultResource => CraftResource.PlainoisBone;

        private CraftResource m_Resource;
        public BaseBone(CraftResource resource)
            : this(resource, 1)
        {
        }

        public BaseBone(CraftResource resource, int amount)
            : base(0xf7e)
        {
            Stackable = true;
            Weight = 1.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);


            m_Resource = resource;
        }

        public BaseBone(Serial serial)
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
       /*         if (m_Resource >= CraftResource.SpinedBone && m_Resource <= CraftResource.BarbedBone)
                    return 1049684 + (m_Resource - CraftResource.SpinedBone);*/
 
                return 1049064;
            }
        }
		//       TextDefinition ICommodity.Description => LabelNumber;


		public override void AddNameProperty(ObjectPropertyList list)
		{
			var name = CraftResources.GetName(m_Resource);

			if (Amount > 1)
				list.Add(String.Format("{3} {0}{1}{2}", "Os [", name, "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add(String.Format("{0}{1}{2}", "Os [", name, "]")); // ingots
		}



	//	bool ICommodity.IsDeedable => true;
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

   /*     public override void AddNameProperty(ObjectPropertyList list)
        {
            if (Amount > 1)
                list.Add(1050039, "{0}\t#{1}", Amount, 1024199); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(1024199); // cut Bone
        }*/

  /*      public override void GetProperties(ObjectPropertyList list)
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
    public class PlainoisBone : BaseBone
    {
        [Constructable]
        public PlainoisBone()
            : this(1)
        {
        }

        [Constructable]
        public PlainoisBone(int amount)
            : base(CraftResource.PlainoisBone, amount)
        {
        }

        public PlainoisBone(Serial serial)
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
    public class ForestierBone : BaseBone
    {
        protected override CraftResource DefaultResource => CraftResource.ForestierBone;

        [Constructable]
        public ForestierBone()
            : this(1)
        {
        }

        [Constructable]
        public ForestierBone(int amount)
            : base(CraftResource.ForestierBone, amount)
        {
        }

        public ForestierBone(Serial serial)
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
    public class DesertiqueBone : BaseBone
    {
        protected override CraftResource DefaultResource => CraftResource.DesertiqueBone;

        [Constructable]
        public DesertiqueBone()
            : this(1)
        {
        }

        [Constructable]
        public DesertiqueBone(int amount)
            : base(CraftResource.DesertiqueBone, amount)
        {
        }

        public DesertiqueBone(Serial serial)
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
    public class CollinoisBone : BaseBone
    {
        protected override CraftResource DefaultResource => CraftResource.CollinoisBone;

        [Constructable]
        public CollinoisBone()
            : this(1)
        {
        }

        [Constructable]
        public CollinoisBone(int amount)
            : base(CraftResource.CollinoisBone, amount)
        {
        }

        public CollinoisBone(Serial serial)
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
	public class SavanoisBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.SavanoisBone;

		[Constructable]
		public SavanoisBone()
			: this(1)
		{
		}

		[Constructable]
		public SavanoisBone(int amount)
			: base(CraftResource.SavanoisBone, amount)
		{
		}

		public SavanoisBone(Serial serial)
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
	public class VolcaniqueBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.VolcaniqueBone;

		[Constructable]
		public VolcaniqueBone()
			: this(1)
		{
		}

		[Constructable]
		public VolcaniqueBone(int amount)
			: base(CraftResource.SavanoisBone, amount)
		{
		}

		public VolcaniqueBone(Serial serial)
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
	public class ToundroisBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.ToundroisBone;

		[Constructable]
		public ToundroisBone()
			: this(1)
		{
		}

		[Constructable]
		public ToundroisBone(int amount)
			: base(CraftResource.ToundroisBone, amount)
		{
		}

		public ToundroisBone(Serial serial)
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
	public class TropicauxBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.TropicauxBone;

		[Constructable]
		public TropicauxBone()
			: this(1)
		{
		}

		[Constructable]
		public TropicauxBone(int amount)
			: base(CraftResource.TropicauxBone, amount)
		{
		}

		public TropicauxBone(Serial serial)
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
	public class MontagnardBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.MontagnardBone;

		[Constructable]
		public MontagnardBone()
			: this(1)
		{
		}

		[Constructable]
		public MontagnardBone(int amount)
			: base(CraftResource.MontagnardBone, amount)
		{
		}

		public MontagnardBone(Serial serial)
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
	public class AncienBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.AncienBone;

		[Constructable]
		public AncienBone()
			: this(1)
		{
		}

		[Constructable]
		public AncienBone(int amount)
			: base(CraftResource.AncienBone, amount)
		{
		}

		public AncienBone(Serial serial)
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