using System;
using Server.Custom.Aptitudes;
using Server.Custom.Classes;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	[FlipableAttribute(0xFBE, 0xFBD)]
	public abstract class LivreClasse : Item, ICraftable
	{
        private Classe m_Classe;
		
		public string m_Marque;
		
        private Mobile m_Author;
        private Mobile m_Owner;

        [CommandProperty(AccessLevel.GameMaster)]
        public Classe Classe
        {
            get { return m_Classe; }
            set { m_Classe = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Author
        {
            get { return m_Author; }
            set { m_Author = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }
		
		[CommandProperty(AccessLevel.GameMaster)]
        public string Marque
        {
            get { return m_Marque; }
            set { m_Marque = value; InvalidateProperties(); }
        }
		
		
		public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            if (m_Marque != null && m_Marque != "")
                list.Add(1060527, m_Marque);
        }

        public LivreClasse() : this(Classe.Aucune)
        {
        }

        public LivreClasse(Classe classe) : base(0xFBE)
        {
            Name = "Livre de classe";
            Weight = 2.0;

			m_Classe = classe;
		}

		public LivreClasse(Serial serial) : base(serial)
        {
        }

        public virtual bool IsInLibrary(Mobile from)
        {
			return true; // from.Region is LibraryRegion;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)from;

                ClasseInfo oldinfo = Classes.GetInfos(pm.Classe);
                ClasseInfo newinfo = Classes.GetInfos(m_Classe);

                if (!IsChildOf(pm.Backpack))
                {
                    pm.SendMessage("Le livre doit être dans votre sac.");
                }
                else if (m_Owner != null && m_Owner != pm)
                {
                    pm.SendMessage("Ce livre ne vous appartient pas.");
                }
                else if (newinfo != null && !newinfo.Active)
                {
                    pm.SendMessage("Cette classe n'est pas active.");
                }
                else if (!Classes.IsValidChange(pm.Classe, m_Classe))
                {
                    pm.SendMessage("Vous ne pouvez obtenir cette classe avec votre classe actuelle.");
                }
                else if (pm.Classe == m_Classe)
                {
                    pm.SendMessage("Votre classe est déjà : " + pm.GetClasse(m_Classe));
                }
                else if (!Classes.IsValid(pm, m_Classe))
                {
                    pm.SendMessage("Vous n'avez pas les prérequis pour obtenir cette classe.");
                }
                //else if (pm.ChangementClasse > DateTime.Now && (!CustomPlayerMobile.enabled || DateTime.Now < CustomPlayerMobile.TimeBegin || DateTime.Now > CustomPlayerMobile.TimeEnd)) //+ TimeSpan.FromMinutes(7 + ((int)oldinfo.ClasseBranche != (int)newinfo.ClasseBranche && oldinfo.Classe != Classe.Aucune ? 4 * pm.NombreChangementClasse : 0))
                //{
                //    pm.SendMessage("Vous devez attendre " + String.Format("{0:F0}", (pm.ChangementClasse - DateTime.Now).Days) + " jours avant de pouvoir changer à nouveau.");//(7 + ((int)oldinfo.ClasseBranche != (int)newinfo.ClasseBranche && oldinfo.Classe != Classe.Aucune ? 4 * pm.NombreChangementClasse : 0)).ToString()
                //}
                //else if (newinfo.Prestige && !pm.AccessPrestige)
                //{
                //    pm.SendMessage("Vous n'avez pas accès aux classes de prestige.");
                //}
                else
                {
                    m_Owner = pm;

                    //if ((int)oldinfo.ClasseBranche != (int)newinfo.ClasseBranche && newinfo.Classe != Classe.Aucune)
                    //{
                    //    pm.ChangementClasse = DateTime.Now + TimeSpan.FromDays(7 + pm.NombreChangementClasse * 0);   ///Changer le chiffre 0 ici pour augmenté le nombre de temps avec un changement de classe///
                    //    pm.NombreChangementClasse++;
                    //}
                    //else if (newinfo.Classe != Classe.Aucune)
                    //    pm.ChangementClasse = DateTime.Now + TimeSpan.FromDays(7);

                    pm.Classe = m_Classe;

                    pm.FixedParticles(0x375A, 10, 15, 5010, EffectLayer.Waist);
                    pm.PlaySound(0x28E);

					pm.Aptitudes.Reset();

                    int puEnAttente = FicheAttributsGump.GetRemainingPU(pm, pm.Experience.Niveau) - FicheAttributsGump.GetDisponiblePU(pm);

                    if (puEnAttente > 10)
                        puEnAttente = 10;

                    pm.PUDispo += puEnAttente;

					Classes.SetBaseAndCapSkills(pm, pm.Experience.Niveau);
				}
			}
        }

		public override void Serialize( GenericWriter writer )
		{
            base.Serialize(writer);

            writer.Write((int)1); // version

			writer.Write((string)m_Marque);
						
            writer.Write(m_Author);
            writer.Write(m_Owner);

            writer.Write((int)m_Classe);

		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
				case 1:
                {
					m_Marque = reader.ReadString();
					
					goto case 0;
                }
                case 0:
                {
                    m_Author = reader.ReadMobile();
                    m_Owner = reader.ReadMobile();

                    m_Classe = (Classe)reader.ReadInt();
                    break;
                }
            }
        }

        #region ICraftable Members
		public int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, ITool tool, CraftItem craftItem, int resHue)
		{
			if (craftSystem is DefInscription && from is CustomPlayerMobile)
				m_Author = (CustomPlayerMobile)from;

			return 1;
		}
		#endregion
	}
}