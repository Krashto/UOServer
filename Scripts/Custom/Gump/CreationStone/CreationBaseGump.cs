using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class CreationBaseGump : BaseProjectMGump
	{
		public CustomPlayerMobile m_from;
		public CreationPerso m_Creation;

		public CreationBaseGump(CustomPlayerMobile from, CreationPerso creationPerso, string Title , bool back, bool next)
			: base(Title , 560, 622,false)
		{
			m_Creation = creationPerso;
			m_from = from;

			int x = XBase;
			int y = YBase;

			AddSection(x - 10, y + 610, 610, 50, Title);

			if (back)
				AddButton(x, y + 610, 1000, 4506);
			if (next)
			AddButton(x + 540, y + 610, 1001, 4502);
		}
		public override void OnResponse(NetState sender, RelayInfo info)
		{
    		CustomPlayerMobile from = (CustomPlayerMobile)sender.Mobile;

			if (from.Deleted || !from.Alive)
				return;   
		}
	}
}
