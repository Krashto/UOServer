using System;

namespace Server.Items
{
    public abstract class BaseHides : Item/*, ICommodity*/
    {
        protected virtual CraftResource DefaultResource => CraftResource.PlainoisLeather;

        private CraftResource m_Resource;
        public BaseHides(CraftResource resource)
            : this(resource, 1)
        {
        }

        public BaseHides(CraftResource resource, int amount)
            : base(0x1079)
        {
            Stackable = true;
            Weight = 5.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);

            m_Resource = resource;
        }

        public BaseHides(Serial serial)
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
              /*  if (m_Resource >= CraftResource.SpinedLeather && m_Resource <= CraftResource.BarbedLeather)
                    return 1049687 + (m_Resource - CraftResource.SpinedLeather);*/

                return 1047023;
            }
        }
      /*  TextDefinition ICommodity.Description => LabelNumber;
        bool ICommodity.IsDeedable => true;*/

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
				list.Add(String.Format("{3} {0}{1}{2}", "Peaux [", name, "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add(String.Format("{0}{1}{2}", "Peau [", name, "]")); // ingots
		}

		/*     public override void AddNameProperty(ObjectPropertyList list)
			 {
				 if (Amount > 1)
					 list.Add(1050039, "{0}\t#{1}", Amount, 1024216); // ~1_NUMBER~ ~2_ITEMNAME~
				 else
					 list.Add(1024216); // pile of hides
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

    [Flipable(0x1079, 0x1078)]
    public class PlainoisHides : BaseHides, IScissorable
    {
        [Constructable]
        public PlainoisHides()
            : this(1)
        {
        }

        [Constructable]
        public PlainoisHides(int amount)
            : base(CraftResource.PlainoisLeather, amount)
        {
        }

        public PlainoisHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }
            base.ScissorHelper(from, new PlainoisLeather(), 1);

            return true;
        }
    }

    [Flipable(0x1079, 0x1078)]
    public class ForestierHides : BaseHides, IScissorable
    {
        protected override CraftResource DefaultResource => CraftResource.ForestierLeather;

        [Constructable]
        public ForestierHides()
            : this(1)
        {
        }

        [Constructable]
        public ForestierHides(int amount)
            : base(CraftResource.ForestierLeather, amount)
        {
        }

        public ForestierHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new ForestierLeather(), 1);

            return true;
        }
    }

    [Flipable(0x1079, 0x1078)]
    public class DesertiqueHides : BaseHides, IScissorable
    {
        protected override CraftResource DefaultResource => CraftResource.DesertiqueLeather;

        [Constructable]
        public DesertiqueHides()
            : this(1)
        {
        }

        [Constructable]
        public DesertiqueHides(int amount)
            : base(CraftResource.DesertiqueLeather, amount)
        {
        }

        public DesertiqueHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new DesertiqueLeather(), 1);

            return true;
        }
    }

    [Flipable(0x1079, 0x1078)]
    public class CollinoisHides : BaseHides, IScissorable
    {
        protected override CraftResource DefaultResource => CraftResource.CollinoisLeather;

        [Constructable]
        public CollinoisHides()
            : this(1)
        {
        }

        [Constructable]
        public CollinoisHides(int amount)
            : base(CraftResource.CollinoisLeather, amount)
        {
        }

        public CollinoisHides(Serial serial)
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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new CollinoisLeather(), 1);

            return true;
        }
    }

	[Flipable(0x1079, 0x1078)]
	public class SavanoisHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.SavanoisLeather;

		[Constructable]
		public SavanoisHides()
			: this(1)
		{
		}

		[Constructable]
		public SavanoisHides(int amount)
			: base(CraftResource.SavanoisLeather, amount)
		{
		}

		public SavanoisHides(Serial serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new SavanoisLeather(), 1);

			return true;
		}
	}

	[Flipable(0x1079, 0x1078)]
	public class ToundroisHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.ToundroisLeather;

		[Constructable]
		public ToundroisHides()
			: this(1)
		{
		}

		[Constructable]
		public ToundroisHides(int amount)
			: base(CraftResource.ToundroisLeather, amount)
		{
		}

		public ToundroisHides(Serial serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new ToundroisLeather(), 1);

			return true;
		}
	}
	[Flipable(0x1079, 0x1078)]
	public class VolcaniqueHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.VolcaniqueLeather;

		[Constructable]
		public VolcaniqueHides()
			: this(1)
		{
		}

		[Constructable]
		public VolcaniqueHides(int amount)
			: base(CraftResource.VolcaniqueLeather, amount)
		{
		}

		public VolcaniqueHides(Serial serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new VolcaniqueLeather(), 1);

			return true;
		}
	}

	[Flipable(0x1079, 0x1078)]
	public class TropicauxHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.TropicauxLeather;

		[Constructable]
		public TropicauxHides()
			: this(1)
		{
		}

		[Constructable]
		public TropicauxHides(int amount)
			: base(CraftResource.TropicauxLeather, amount)
		{
		}

		public TropicauxHides(Serial serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new TropicauxLeather(), 1);

			return true;
		}
	}

	[Flipable(0x1079, 0x1078)]
	public class MontagnardHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.MontagnardLeather;

		[Constructable]
		public MontagnardHides()
			: this(1)
		{
		}

		[Constructable]
		public MontagnardHides(int amount)
			: base(CraftResource.MontagnardLeather, amount)
		{
		}

		public MontagnardHides(Serial serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new MontagnardLeather(), 1);

			return true;
		}
	}

	[Flipable(0x1079, 0x1078)]
	public class AncienHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.AncienLeather;

		[Constructable]
		public AncienHides()
			: this(1)
		{
		}

		[Constructable]
		public AncienHides(int amount)
			: base(CraftResource.AncienLeather, amount)
		{
		}

		public AncienHides(Serial serial)
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

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new AncienLeather(), 1);

			return true;
		}
	}
}
