using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using System.Collections.Generic;
using Server.Commands;
using Server.Custom;

namespace Server.Scripts.Commands
{
    public class Titre
    {
        public static void Initialize()
        {
            CommandSystem.Register("Titre", AccessLevel.Player, new CommandEventHandler(Titre_OnCommand));
        }

        [Usage("Titre")]
        [Description("Permet de changer son titre.")]
        public static void Titre_OnCommand(CommandEventArgs e)
        {
            CustomPlayerMobile pm = e.Mobile as CustomPlayerMobile;

            if (pm != null)
            {
                string classe = pm.Classe.ToString();
				string customTitle = pm.CustomTitle;

                pm.TitleCycle += 1;

				if (pm.TitleCycle > 2)
                    pm.TitleCycle = 0;

                switch (pm.TitleCycle)
                {
                    case 0:
                        {
                            pm.Title = classe;
                            pm.SendMessage("Vous affichez désormais le titre de classe: {0}", classe );
                            break;
                        }
					case 1:
                        {
                            pm.Title = customTitle;
                            pm.SendMessage("Vous affichez désormais le titre personnalisé: {0}", customTitle);
                            break;
                        }
					case 2:
						{
							pm.Title = String.Empty;
							pm.SendMessage("Vous affichez désormais aucun titre.");
							break;
						}
				}
            }
        }
    }
}