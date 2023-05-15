using System;
using System.IO;
using System.Text;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.ContextMenus
{
	public class ProtectEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private BaseBook m_Book;

		public ProtectEntry(Mobile from, BaseBook book)
			: base(90, 1)
		{
			m_From = from;
			m_Book = book;
		}

		public override void OnClick()
		{
			if (m_Book.Deleted || !m_From.CheckAlive())
				return;

			if (m_Book.Protected)
			{
				m_From.SendMessage("Ce livre est déjà protégé.");
			}
			else if (!m_Book.IsInBookCase())
			{
				m_From.SendMessage("Ce livre doit être dans une bibliothèque.");
			}
			else
			{
				m_Book.Protected = true;
				m_Book.ProtectMaster = m_From;
				m_From.SendMessage("Vous protégez ce livre.");
			}
		}
	}

	public class UnProtectEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private BaseBook m_Book;

		public UnProtectEntry(Mobile from, BaseBook book)
			: base(91, 1)
		{
			m_From = from;
			m_Book = book;
		}

		public override void OnClick()
		{
			if (m_Book.Deleted || !m_From.CheckAlive())
				return;

			if (!m_Book.Protected)
			{
				m_From.SendMessage("Ce livre n'est pas protégé.");
			}
			else if (m_Book.ProtectMaster != m_From)
			{
				m_From.SendMessage("Vous n'avez pas protégé ce livre.");
			}
			else
			{
				m_Book.Protected = false;
				m_Book.ProtectMaster = null;
				m_From.SendMessage("Vous déprotégez le livre.");
			}
		}
	}
}

namespace Server.Items
{
	public class BookPageInfo
	{
		private string[] m_Lines;

		public string[] Lines
		{
			get
			{
				return m_Lines;
			}
			set
			{
				m_Lines = value;
			}
		}

		public BookPageInfo()
		{
			m_Lines = new string[0];
		}

		public BookPageInfo(GenericReader reader)
		{
			int length = reader.ReadInt();

			m_Lines = new string[length];

			for (int i = 0; i < m_Lines.Length; ++i)
				m_Lines[i] = reader.ReadString();
		}

		public void Serialize(GenericWriter writer)
		{
			writer.Write(m_Lines.Length);

			for (int i = 0; i < m_Lines.Length; ++i)
				writer.Write(m_Lines[i]);
		}
	}

	public class BaseBook : Item
	{
		private string m_Title;
		private string m_Author;
		private BookPageInfo[] m_Pages;
		private bool m_Writable;
		private bool m_Protected;
		private Mobile m_ProtectMaster;

		[CommandProperty(AccessLevel.GameMaster)]
		public string Title
		{
			get { return m_Title; }
			set { m_Title = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string Author
		{
			get { return m_Author; }
			set { m_Author = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Writable
		{
			get { return m_Writable; }
			set { m_Writable = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Protected
		{
			get { return m_Protected; }
			set
			{
				if (value)
				{
					Movable = false;
					Writable = false;
				}
				else
				{
					Movable = true;
					Writable = true;
				}

				m_Protected = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile ProtectMaster
		{
			get { return m_ProtectMaster; }
			set { m_ProtectMaster = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int PagesCount
		{
			get { return m_Pages.Length; }
		}

		public BookPageInfo[] Pages
		{
			get { return m_Pages; }
		}

		public virtual double BookWeight { get { return 1.0; } }

		[Constructable]
		public BaseBook(int itemID) : this(itemID, 20, true)
		{
		}

		[Constructable]
		public BaseBook(int itemID, int pageCount, bool writable) : this(itemID, null, null, pageCount, writable)
		{
		}

		[Constructable]
		public BaseBook(int itemID, string title, string author, int pageCount, bool writable) : base(itemID)
		{
			m_Title = title;
			m_Author = author;
			m_Pages = new BookPageInfo[pageCount];
			m_Writable = writable;

			for (int i = 0; i < m_Pages.Length; ++i)
				m_Pages[i] = new BookPageInfo();

			Weight = BookWeight;
		}

		public BaseBook(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)1); // version

			writer.Write(m_Protected);
			writer.Write(m_ProtectMaster);

			writer.Write(m_Title);
			writer.Write(m_Author);
			writer.Write(m_Writable);

			writer.Write(m_Pages.Length);

			for (int i = 0; i < m_Pages.Length; ++i)
				m_Pages[i].Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_Protected = reader.ReadBool();
						m_ProtectMaster = reader.ReadMobile();

						goto case 0;
					}
				case 0:
					{
						m_Title = reader.ReadString();
						m_Author = reader.ReadString();
						m_Writable = reader.ReadBool();

						m_Pages = new BookPageInfo[reader.ReadInt()];

						for (int i = 0; i < m_Pages.Length; ++i)
							m_Pages[i] = new BookPageInfo(reader);

						break;
					}
			}

			Weight = BookWeight;
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			if (m_Title != null && m_Title.Length > 0)
				list.Add(m_Title);
			else
				base.AddNameProperty(list);
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (from.Alive)
			{
				if (!m_Protected && IsInBookCase())
					list.Add(new ProtectEntry(from, this));
				else if (m_ProtectMaster == from)
					list.Add(new UnProtectEntry(from, this));
			}
		}

		public virtual bool IsInBookCase()
		{
			if (Parent == null)
				return false;

			Type t = Parent.GetType();

			if (t == typeof(EmptyBookcase) || t == typeof(FullBookcase))
				return true;
			else
				return false;
		}

		public override void OnAosSingleClick(Mobile from)
		{
			LabelTo(from, "{0} by {1}", m_Title, m_Author);
			LabelTo(from, "[{0} pages]", m_Pages.Length);
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (m_Title == null && m_Author == null && m_Writable == true)
			{
				Title = "a book";
				Author = from.Name;
			}

			if (from.InRange(this.GetWorldLocation(), 2) && from.InLOS(this))
			{
				from.Send(new BookHeader(from, this));
				from.Send(new BookPageDetails(this));
			}
		}

		public static void Initialize()
		{
			PacketHandlers.Register(0xD4, 0, true, new OnPacketReceive(HeaderChange));
			PacketHandlers.Register(0x66, 0, true, new OnPacketReceive(ContentChange));
			PacketHandlers.Register(0x93, 99, true, new OnPacketReceive(OldHeaderChange));
		}

		public static void OldHeaderChange(NetState state, PacketReader pvSrc)
		{
			Mobile from = state.Mobile;
			BaseBook book = World.FindItem(pvSrc.ReadInt32()) as BaseBook;

			if (book == null || !book.Writable || !from.InRange(book.GetWorldLocation(), 1))
				return;

			pvSrc.Seek(4, SeekOrigin.Current); // Skip flags and page count

			string title = pvSrc.ReadStringSafe(60);
			string author = pvSrc.ReadStringSafe(30);

			book.Title = Utility.FixHtml(title);
			book.Author = Utility.FixHtml(author);
		}

		public static void HeaderChange(NetState state, PacketReader pvSrc)
		{
			Mobile from = state.Mobile;
			BaseBook book = World.FindItem(pvSrc.ReadInt32()) as BaseBook;

			if (book == null || !book.Writable || !from.InRange(book.GetWorldLocation(), 1))
				return;

			pvSrc.Seek(4, SeekOrigin.Current); // Skip flags and page count

			int titleLength = pvSrc.ReadUInt16();

			if (titleLength > 60)
				return;

			string title = pvSrc.ReadUTF8StringSafe(titleLength);

			int authorLength = pvSrc.ReadUInt16();

			if (authorLength > 30)
				return;

			string author = pvSrc.ReadUTF8StringSafe(authorLength);

			book.Title = Utility.FixHtml(title);
			book.Author = Utility.FixHtml(author);
		}

		public static void ContentChange(NetState state, PacketReader pvSrc)
		{
			Mobile from = state.Mobile;
			BaseBook book = World.FindItem(pvSrc.ReadInt32()) as BaseBook;

			if (book == null || !book.Writable || !from.InRange(book.GetWorldLocation(), 1))
				return;

			int pageCount = pvSrc.ReadUInt16();

			if (pageCount > book.PagesCount)
				return;

			for (int i = 0; i < pageCount; ++i)
			{
				int index = pvSrc.ReadUInt16();

				if (index >= 1 && index <= book.PagesCount)
				{
					--index;

					int lineCount = pvSrc.ReadUInt16();

					if (lineCount <= 8)
					{
						string[] lines = new string[lineCount];

						for (int j = 0; j < lineCount; ++j)
							if ((lines[j] = pvSrc.ReadUTF8StringSafe()).Length >= 80)
								return;

						book.Pages[index].Lines = lines;
					}
					else
					{
						return;
					}
				}
				else
				{
					return;
				}
			}
		}
	}

	public sealed class BookPageDetails : Packet
	{
		public BookPageDetails(BaseBook book) : base(0x66)
		{
			EnsureCapacity(256);

			m_Stream.Write((int)book.Serial);
			m_Stream.Write((ushort)book.PagesCount);

			for (int i = 0; i < book.PagesCount; ++i)
			{
				BookPageInfo page = book.Pages[i];

				m_Stream.Write((ushort)(i + 1));
				m_Stream.Write((ushort)page.Lines.Length);

				for (int j = 0; j < page.Lines.Length; ++j)
				{
					byte[] buffer = Utility.UTF8.GetBytes(page.Lines[j]);

					m_Stream.Write(buffer, 0, buffer.Length);
					m_Stream.Write((byte)0);
				}
			}
		}
	}

	public sealed class BookHeader : Packet
	{
		public BookHeader(Mobile from, BaseBook book) : base(0xD4)
		{
			string title = book.Title == null ? "" : book.Title;
			string author = book.Author == null ? "" : book.Author;

			byte[] titleBuffer = Utility.UTF8.GetBytes(title);
			byte[] authorBuffer = Utility.UTF8.GetBytes(author);

			EnsureCapacity(15 + titleBuffer.Length + authorBuffer.Length);

			m_Stream.Write((int)book.Serial);
			m_Stream.Write((bool)true);
			m_Stream.Write((bool)book.Writable && from.InRange(book.GetWorldLocation(), 1));
			m_Stream.Write((ushort)book.PagesCount);

			m_Stream.Write((ushort)(titleBuffer.Length + 1));
			m_Stream.Write(titleBuffer, 0, titleBuffer.Length);
			m_Stream.Write((byte)0); // terminate

			m_Stream.Write((ushort)(authorBuffer.Length + 1));
			m_Stream.Write(authorBuffer, 0, authorBuffer.Length);
			m_Stream.Write((byte)0); // terminate
		}
	}
}