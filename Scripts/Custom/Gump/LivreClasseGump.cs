using System;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Custom.Classes;

namespace Server.Gumps
{
    public class LivreClasseGump : BaseProjectMGump
	{
		CustomPlayerMobile m_From;
		Classe m_Classe;
		LivreClasse m_Livre;

        public LivreClasseGump(CustomPlayerMobile from, Classe classe, LivreClasse livre) : base("Livre de classes", 250, 150, true)
        {
			m_From = from;
			m_Classe = classe;
			m_Livre = livre;

			int x = XBase + 20;
			int y = YBase + 10;

			int line = 0;
			int lineSpace = 20;

			if (m_From.Classe != Classe.Aucune)
				AddHtml(x, y, 250, 60, String.Concat($"<h3><basefont color=\"#FFFFFF\">Vous devez oublier votre classe avec un livre d'oubli de classe avant d'apprendre une nouvelle classe.</basefont></h3>"), false, false);
			else
			{
				AddHtml(x, y, 250, 60, String.Concat($"<h3><basefont color=\"#FFFFFF\">Veuillez choisir ou vous désirez placer la classe {classe}.</basefont></h3>"), false, false);
				line += 3;

				if (from.Classe != classe)
					AddButtonHtml(x, y + line * lineSpace, 1, "Classe", "#FFFFFF");
			}
		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {
			Mobile from = sender.Mobile;

			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)from;

				if (info.ButtonID == 1)
				{
					cp.Classe = m_Classe;
					m_Livre.Delete();
				}
			}
        }
    }
}
