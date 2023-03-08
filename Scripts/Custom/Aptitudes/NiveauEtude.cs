using System;
using Server;
using Server.Commands;
using Server.Custom.Aptitudes;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Scripts.Commands
{
    public class NiveauEtude
    {
        public static void Initialize()
        {
            CommandSystem.Register("NiveauEtude", AccessLevel.Player, new CommandEventHandler(NiveauEtude_OnCommand));
        }

        [Usage("NiveauEtude")]
        public static void NiveauEtude_OnCommand(CommandEventArgs e)
        {
            CustomPlayerMobile from = (CustomPlayerMobile)e.Mobile;

            if (from != null)
            {
                if (!from.Alive)
                    return;

                int value = e.GetInt32(0);

                if (value <= 0)
                {
                    from.SendMessage("Vous devez choisir un niveau en haut de 0.");
                }
                else if (value > from.GetAptitudeValue(Aptitude.Transcription) * 10)
                {
                    from.SendMessage("Vous n'avez pas assez dans l'aptitude Étude pour augmenter à la valeur désirée.");
                }
                else
                {
                    from.Target = new InternalTarget(from, value);
                }
            }
        }

        private class InternalTarget : Target
        {
            private CustomPlayerMobile m_From;
            private int m_Value;

            public InternalTarget(CustomPlayerMobile from, int value) : base(1, false, TargetFlags.None)
            {
                m_From = from;
                m_Value = value;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                bool success = false;

                if (m_Value > m_From.GetAptitudeValue(Aptitude.Transcription) * 10)
                {
                    m_From.SendMessage("Vous n'avez pas assez dans l'aptitude Étude pour augmenter à la valeur désirée.");
                }
				else if (targeted is LivreSkills)
				{
					LivreSkills livre = targeted as LivreSkills;

					if (livre.Author != m_From)
					{
						m_From.SendMessage("Vous n'êtes pas l'auteur de ce livre.");
					}
					else if (livre.Owner != null)
					{
						m_From.SendMessage("Ce livre a déjà été lu.");
					}
					else if (livre.Level <= m_Value)
					{
						m_From.SendMessage("Vous devez choisir un niveau plus petit que celui du livre actuellement.");
					}
					else
					{
						livre.Level = m_Value;
						success = true;
					}
				}
				else
                {
                    m_From.SendMessage("Ce n'est pas un livre d'étude.");
                }

                if (success)
                {
                    m_From.SendMessage("Vous changez avec succès le niveau d'apprentissage du livre.");
                    m_From.PlaySound(0x249);
                }
            }
        }
    }
}