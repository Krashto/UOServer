using System;
using System.Collections.Generic;
using Server.Engines.Craft;

namespace Server.Items
{
    public abstract class Statue : Item, ICraftable
	{
		private string m_Title;
		private Dictionary<int, string> m_Description = new Dictionary<int, string>();
		private Mobile m_Crafter;
		private string m_CrafterName;
		private bool m_Finish;

		[CommandProperty(AccessLevel.GameMaster)]
		public string CrafterName { get => m_CrafterName; set => m_CrafterName = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Finish { get => m_Finish; set => m_Finish = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public string Title { get => m_Title; set => m_Title = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Dictionary<int, string> Description { get => m_Description; set => m_Description = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Crafter { get => m_Crafter; set => m_Crafter = value; }

		public Statue(int itemID)
            : this(itemID, 0)
        {
			Movable = true;
        }

        public Statue(int itemID, int hue)
            : base(itemID)
        {
			Movable = true;
        }

        public Statue(Serial serial)
            : base(serial)
        {
        }

		public string GetContenu(int Entry)
		{
			if (Description.ContainsKey(Entry))
			{
				return Description[Entry];
			}
			else
			{
				return "";
			}
		}

		public override bool IsAccessibleTo(Mobile check)
		{
			return true;
		}

		public override void GetProperties(ObjectPropertyList list)
        {
            if (!Finish)
                list.Add("artéfact");
			else
			{
				list.Add(m_Title);
				list.Add("Par: " + m_CrafterName);
			}
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
			writer.Write(m_CrafterName);
			writer.Write(m_Finish);
			writer.Write(m_Crafter);
			writer.Write(Description.Count);

			foreach (KeyValuePair<int, string> item in Description)
			{
				writer.Write(item.Key);
				writer.Write(item.Value);
			}

			writer.Write((string)m_Title);
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_CrafterName = reader.ReadString();
						m_Finish = reader.ReadBool();
						m_Crafter = reader.ReadMobile();

						int count = (int)reader.ReadInt();

						for (int i = 0; i < count; i++)
						{
							Description.Add(reader.ReadInt(), reader.ReadString());
						}

						goto case 0;
					}
				case 0:
					{
						m_Title = reader.ReadString();

						break;
					}
			}
        }

		public int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, ITool tool, CraftItem craftItem, int resHue)
		{
			Crafter = from;

			return quality;
		}
	}
}