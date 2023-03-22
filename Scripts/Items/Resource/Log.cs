namespace Server.Items
{
    [Flipable(0x1bdd, 0x1be0)]
    public class BaseLog : Item, ICommodity, IAxe, IResource
    {
        private CraftResource m_Resource;

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get { return m_Resource; }
            set { m_Resource = value; InvalidateProperties(); }
        }

        TextDefinition ICommodity.Description => CraftResources.IsStandard(m_Resource) ? LabelNumber : 1075062 + ((int)m_Resource - (int)CraftResource.RegularWood);
        bool ICommodity.IsDeedable => true;
        [Constructable]
        public BaseLog() : this(1)
        {
        }

        [Constructable]
        public BaseLog(int amount) : this(CraftResource.RegularWood, amount)
        {
        }

        [Constructable]
        public BaseLog(CraftResource resource)
            : this(resource, 1)
        {
        }
        [Constructable]
        public BaseLog(CraftResource resource, int amount)
            : base(0x1BDD)
        {
            Stackable = true;
            Weight = 2.0;
            Amount = amount;

            m_Resource = resource;
            Hue = CraftResources.GetHue(resource);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

			if (!CraftResources.IsStandard(m_Resource))
				list.Add(CraftResources.GetName(m_Resource));
		}
        public BaseLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(2); // version

            writer.Write((int)m_Resource);
        }

        public static bool UpdatingBaseLogClass;
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 1)
                UpdatingBaseLogClass = true;
            m_Resource = (CraftResource)reader.ReadInt();

            if (version == 0)
                m_Resource = CraftResource.RegularWood;
        }

        public virtual bool TryCreateBoards(Mobile from, double skill, Item item)
        {
            if (Deleted || !from.CanSee(this))
            {
                item.Delete();
                return false;
            }
            if (from.Skills.Carpentry.Value < skill && from.Skills.Lumberjacking.Value < skill)
            {
                item.Delete();
                from.SendLocalizedMessage(1072652); // You cannot work this strange and unusual wood.
                return false;
            }

            if (HasSocket<Caddellite>())
            {
                item.AttachSocket(new Caddellite());
            }

            base.ScissorHelper(from, item, 1, false);
            return true;
        }

        public virtual bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 0, new RegularBoard()))
                return false;

            return true;
        }
    }

	public class RegularLog : BaseLog
    {
        [Constructable]
        public RegularLog()
            : this(1)
        {
        }

        [Constructable]
        public RegularLog(int amount)
            : base(CraftResource.RegularWood, amount)
        {
        }

        public RegularLog(Serial serial)
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
            //don't deserialize anything on update
            if (UpdatingBaseLogClass)
                return;

            int version = reader.ReadInt();
        }

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 0, new RegularBoard()))
                return false;

            return true;
        }
    }

	public class PlainoisLog : BaseLog
	{
		[Constructable]
		public PlainoisLog()
			: this(1)
		{
		}

		[Constructable]
		public PlainoisLog(int amount)
			: base(CraftResource.RegularWood, amount)
		{
		}

		public PlainoisLog(Serial serial)
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
			//don't deserialize anything on update
			if (UpdatingBaseLogClass)
				return;

			int version = reader.ReadInt();
		}

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new PlainoisBoard()))
				return false;

			return true;
		}
	}

	public class HeartwoodLog : BaseLog
    {
        [Constructable]
        public HeartwoodLog()
            : this(1)
        {
        }

        [Constructable]
        public HeartwoodLog(int amount)
            : base(CraftResource.Heartwood, amount)
        {
        }

        public HeartwoodLog(Serial serial)
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

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 100, new HeartwoodBoard()))
                return false;

            return true;
        }
    }

    public class BloodwoodLog : BaseLog
    {
        [Constructable]
        public BloodwoodLog()
            : this(1)
        {
        }

        [Constructable]
        public BloodwoodLog(int amount)
            : base(CraftResource.Bloodwood, amount)
        {
        }

        public BloodwoodLog(Serial serial)
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

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 100, new BloodwoodBoard()))
                return false;

            return true;
        }
    }

    public class FrostwoodLog : BaseLog
    {
        [Constructable]
        public FrostwoodLog()
            : this(1)
        {
        }

        [Constructable]
        public FrostwoodLog(int amount)
            : base(CraftResource.Frostwood, amount)
        {
        }

        public FrostwoodLog(Serial serial)
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

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 100, new FrostwoodBoard()))
                return false;

            return true;
        }
    }

    public class OakLog : BaseLog
    {
        [Constructable]
        public OakLog()
            : this(1)
        {
        }

        [Constructable]
        public OakLog(int amount)
            : base(CraftResource.OakWood, amount)
        {
        }

        public OakLog(Serial serial)
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

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 65, new OakBoard()))
                return false;

            return true;
        }
    }

    public class AshLog : BaseLog
    {
        [Constructable]
        public AshLog()
            : this(1)
        {
        }

        [Constructable]
        public AshLog(int amount)
            : base(CraftResource.AshWood, amount)
        {
        }

        public AshLog(Serial serial)
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

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 80, new AshBoard()))
                return false;

            return true;
        }
    }

    public class YewLog : BaseLog
    {
        [Constructable]
        public YewLog()
            : this(1)
        {
        }

        [Constructable]
        public YewLog(int amount)
            : base(CraftResource.YewWood, amount)
        {
        }

        public YewLog(Serial serial)
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

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            if (!TryCreateBoards(from, 95, new YewBoard()))
                return false;

            return true;
        }
    }

	public class ForestierLog : BaseLog
	{
		[Constructable]
		public ForestierLog()
			: this(1)
		{
		}

		[Constructable]
		public ForestierLog(int amount)
			: base(CraftResource.ForestierWood, amount)
		{
		}

		public ForestierLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new ForestierBoard()))
				return false;

			return true;
		}
	}
	public class CollinoisLog : BaseLog
	{
		[Constructable]
		public CollinoisLog()
			: this(1)
		{
		}

		[Constructable]
		public CollinoisLog(int amount)
			: base(CraftResource.CollinoisWood, amount)
		{
		}

		public CollinoisLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new CollinoisBoard()))
				return false;

			return true;
		}
	}
	public class DesertiqueLog : BaseLog
	{
		[Constructable]
		public DesertiqueLog()
			: this(1)
		{
		}

		[Constructable]
		public DesertiqueLog(int amount)
			: base(CraftResource.DesertiqueWood, amount)
		{
		}

		public DesertiqueLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new DesertiqueBoard()))
				return false;

			return true;
		}
	}
	public class MontagnardLog : BaseLog
	{
		[Constructable]
		public MontagnardLog()
			: this(1)
		{
		}

		[Constructable]
		public MontagnardLog(int amount)
			: base(CraftResource.MontagnardWood, amount)
		{
		}

		public MontagnardLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new MontagnardBoard()))
				return false;

			return true;
		}
	}
	public class SavanoisLog : BaseLog
	{
		[Constructable]
		public SavanoisLog()
			: this(1)
		{
		}

		[Constructable]
		public SavanoisLog(int amount)
			: base(CraftResource.SavanoisWood, amount)
		{
		}

		public SavanoisLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new SavanoisBoard()))
				return false;

			return true;
		}
	}
	public class VolcaniqueLog : BaseLog
	{
		[Constructable]
		public VolcaniqueLog()
			: this(1)
		{
		}

		[Constructable]
		public VolcaniqueLog(int amount)
			: base(CraftResource.VolcaniqueWood, amount)
		{
		}

		public VolcaniqueLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new VolcaniqueBoard()))
				return false;

			return true;
		}
	}
	public class ToundroisLog : BaseLog
	{
		[Constructable]
		public ToundroisLog()
			: this(1)
		{
		}

		[Constructable]
		public ToundroisLog(int amount)
			: base(CraftResource.ToundroisWood, amount)
		{
		}

		public ToundroisLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new ToundroisBoard()))
				return false;

			return true;
		}
	}
	public class TropicauxLog : BaseLog
	{
		[Constructable]
		public TropicauxLog()
			: this(1)
		{
		}

		[Constructable]
		public TropicauxLog(int amount)
			: base(CraftResource.TropicauxWood, amount)
		{
		}

		public TropicauxLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new TropicauxBoard()))
				return false;

			return true;
		}
	}
	public class AncienLog : BaseLog
	{
		[Constructable]
		public AncienLog()
			: this(1)
		{
		}

		[Constructable]
		public AncienLog(int amount)
			: base(CraftResource.AncienWood, amount)
		{
		}

		public AncienLog(Serial serial)
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

		public override bool Axe(Mobile from, BaseAxe axe)
		{
			if (!TryCreateBoards(from, 0, new AncienBoard()))
				return false;

			return true;
		}
	}
}
