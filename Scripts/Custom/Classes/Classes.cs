using Server.Custom.Aptitudes;
using Server.Custom.Capacites;
using Server.Mobiles;

namespace Server.Custom.Classes
{
    public sealed class Classes
    {
        public static bool IsValidChange(Classe oldClass, Classe newClass)
        {
            ClasseInfo oldinfo = GetInfos(oldClass);
            ClasseInfo info = GetInfos(newClass);

            if (info == null)
                return false;

            return (info.ClasseAvant == oldClass || (info != null && oldinfo != null && info.ClasseAvant == Classe.Aucune && oldinfo.ClasseAvant == Classe.Aucune && info.ClasseMode == oldinfo.ClasseMode));
        }

        public static Classe GetClassBefore(Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return Classe.Aucune;

            return info.ClasseAvant;
        }

        public static int GetAptitudeValue(Classe classe, Aptitude aptitude)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return 0;

            if (info.Aptitudes != null)
            {
                for (int i = 0; i < info.Aptitudes.Length; ++i)
                {
                    CAptitudes aptitudes = info.Aptitudes[i];

                    if (aptitudes.Aptitude == aptitude)
                        return aptitudes.Value;
                }
            }

            return 0;
        }

		public static void SetBaseAndCapSkills(CustomPlayerMobile pm, int level)
		{
			if (pm is null)
				return;

			foreach (var skill in pm.Skills)
			{
				skill.Cap = 50 + level;

				if (skill.Base > skill.Cap)
					skill.Base = skill.Cap;
			}

			pm.SkillsCap = 4000 + level * 80;
		}

		public static int GetCapaciteValue(Capacite capacite, Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (info == null)
                return 0;

            for (int i = 0; i < info.Capacites.Length; ++i)
            {
                CCapacites cap = info.Capacites[i];

                if (cap.Capacite == capacite)
                    return cap.Value;
            }

            return 0;
        }

		public static bool HaveRequired(CustomPlayerMobile pm, Classe classe)
		{
			ClasseInfo info = GetInfos(classe);

			if (pm == null || info == null)
				return false;

			if (info.Skills != null)
			{
				foreach (var skill in info.Skills)
				{
					if (pm.Skills[skill.SkillName].Value < skill.Value)
						return false;
				}
			}

			return true;
		}

		public static bool Validate(CustomPlayerMobile pm, Classe classe)
        {
            ClasseInfo info = GetInfos(classe);

            if (pm == null || info == null || classe == Classe.Aucune)
                return true;

            if (info.Skills != null)
            {
				var isValid = true;

				foreach (var skill in info.Skills)
                {
					if (pm.Skills[skill.SkillName].Value < skill.Value)
						isValid = false;

					while (!isValid)
					{
						pm.SendMessage($"Vous n'avez plus les prérequis de la classe: {info.Nom}");
						pm.Classe = GetClassBefore(pm.Classe);
						var newInfo = GetInfos(pm.Classe);
						if (newInfo != null)
							pm.SendMessage($"Votre classe est maintenant: {newInfo.Nom}");

						isValid = Validate(pm, pm.Classe);
					}
                }
            }

			return true;
        }

        public static ClasseInfo GetInfos(Classe classe)
        {
            ClasseInfo info = null;

            switch (classe)
            {
				case Classe.Embouteilleur: info = EmbouteilleurClasse.ClasseInfo; break;
				case Classe.Alchimiste: info = AlchimisteClasse.ClasseInfo; break;
				case Classe.Apothicaire: info = ApothicaireClasse.ClasseInfo; break;

				case Classe.Styliste: info = StylisteClasse.ClasseInfo; break;
				case Classe.Modeleur: info = ModeleurClasse.ClasseInfo; break;
				case Classe.Couturier: info = CouturierClasse.ClasseInfo; break;

				case Classe.Bricoleur: info = BricoleurClasse.ClasseInfo; break;
				case Classe.Ingenieur: info = IngenieurClasse.ClasseInfo; break;
				case Classe.Inventeur: info = InventeurClasse.ClasseInfo; break;

				case Classe.Armurier: info = ArmurierClasse.ClasseInfo; break;
				case Classe.Forgeron: info = ForgeronClasse.ClasseInfo; break;
				case Classe.Forgefer: info = ForgeferClasse.ClasseInfo; break;

				case Classe.Eleve: info = EleveClasse.ClasseInfo; break;
				case Classe.Erudit: info = EruditClasse.ClasseInfo; break;
				case Classe.Sage: info = SageClasse.ClasseInfo; break;

				case Classe.Combattant: info = CombattantClasse.ClasseInfo; break;
				case Classe.Mirmillon: info = MirmillonClasse.ClasseInfo; break;
				case Classe.Champion: info = ChampionClasse.ClasseInfo; break;

				case Classe.Archer: info = ArcherClasse.ClasseInfo; break;
				case Classe.FrancTireur: info = FrancTireurClasse.ClasseInfo; break;
				case Classe.MaitreArcher: info = MaitreArcherClasse.ClasseInfo; break;

				case Classe.Ecuyer: info = EcuyerClasse.ClasseInfo; break;
				case Classe.Jouteur: info = JouteurClasse.ClasseInfo; break;
				case Classe.Cavalier: info = CavalierClasse.ClasseInfo; break;

				case Classe.Defenseur: info = DefenseurClasse.ClasseInfo; break;
				case Classe.Gardien: info = GardienClasse.ClasseInfo; break;
				case Classe.Protecteur: info = ProtecteurClasse.ClasseInfo; break;

				case Classe.Pisteur: info = PisteurClasse.ClasseInfo; break;
				case Classe.Traqueur: info = TraqueurClasse.ClasseInfo; break;
				case Classe.Rodeur: info = RodeurClasse.ClasseInfo; break;

				case Classe.Multiforme: info = MultiformeClasse.ClasseInfo; break;
				case Classe.Diversiforme: info = DiversiformeClasse.ClasseInfo; break;
				case Classe.Changeforme: info = ChangeformeClasse.ClasseInfo; break;

				case Classe.Invocateur: info = InvocateurClasse.ClasseInfo; break;
				case Classe.Conjurateur: info = ConjurateurClasse.ClasseInfo; break;
				case Classe.Spiritualiste: info = SpiritualisteClasse.ClasseInfo; break;

				case Classe.Troubadour: info = TroubadourClasse.ClasseInfo; break;
				case Classe.Barde: info = BardeClasse.ClasseInfo; break;
				case Classe.Menestrel: info = MenestrelClasse.ClasseInfo; break;

				case Classe.Mage: info = MageClasse.ClasseInfo; break;
				case Classe.Magicien: info = MagicienClasse.ClasseInfo; break;
				case Classe.Hydromancien: info = HydromancienClasse.ClasseInfo; break;

				case Classe.Incantateur: info = IncantateurClasse.ClasseInfo; break;
				case Classe.Sorcier: info = SorcierClasse.ClasseInfo; break;
				case Classe.Pyromancien: info = PyromancienClasse.ClasseInfo; break;

				case Classe.Naturaliste: info = NaturalisteClasse.ClasseInfo; break;
				case Classe.Druide: info = DruideClasse.ClasseInfo; break;
				case Classe.Geomancien: info = GeomancienClasse.ClasseInfo; break;

				case Classe.Apprenti: info = ApprentiClasse.ClasseInfo; break;
				case Classe.Evocateur: info = EvocateurClasse.ClasseInfo; break;
				case Classe.Aeromancien: info = AeromancienClasse.ClasseInfo; break;

				case Classe.Thanathauste: info = ThanathausteClasse.ClasseInfo; break;
                case Classe.Necromage: info = NecromageClasse.ClasseInfo; break;
                case Classe.Necromancien: info = NecromancienClasse.ClasseInfo; break;

				case Classe.Vagabond: info = VagabondClasse.ClasseInfo; break;
				case Classe.Voleur: info = VoleurClasse.ClasseInfo; break;
				case Classe.Roublard: info = RoublardClasse.ClasseInfo; break;
				
				case Classe.Intervenant: info = IntervenantClasse.ClasseInfo; break;
				case Classe.Soigneur: info = SoigneurClasse.ClasseInfo; break;
				case Classe.Guerisseur: info = GuerisseurClasse.ClasseInfo; break;

                default: info = ClasseAucune.ClasseInfo; break;
            }

            return info;
        }
    }
}