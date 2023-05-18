using System;
using Server.Custom.Spells.NewSpells.Aeromancie;
using Server.Custom.Spells.NewSpells.Chasseur;
using Server.Custom.Spells.NewSpells.Defenseur;
using Server.Custom.Spells.NewSpells.Geomancie;
using Server.Custom.Spells.NewSpells.Guerison;
using Server.Custom.Spells.NewSpells.Hydromancie;
using Server.Custom.Spells.NewSpells.Martial;
using Server.Custom.Spells.NewSpells.Musique;
using Server.Custom.Spells.NewSpells.Necromancie;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Custom.Spells.NewSpells.Pyromancie;
using Server.Custom.Spells.NewSpells.Roublardise;
using Server.Custom.Spells.NewSpells.Totemique;
using Server.Spells.Eighth;
using Server.Spells.Fifth;
using Server.Spells.First;
using Server.Spells.Fourth;
using Server.Spells.Second;
using Server.Spells.Seventh;
using Server.Spells.Sixth;
using Server.Spells.Third;

namespace Server.Spells
{
	public class Initializer
	{
        public static void Initialize()
        {
            // First circle
            Register(00, typeof(ClumsySpell));
            Register(01, typeof(CreateFoodSpell));
            Register(02, typeof(FeeblemindSpell));
            Register(03, typeof(HealSpell));
            Register(04, typeof(MagicArrowSpell));
            Register(05, typeof(NightSightSpell));
            Register(06, typeof(ReactiveArmorSpell));
            Register(07, typeof(WeakenSpell));

            // Second circle
            Register(08, typeof(AgilitySpell));
            Register(09, typeof(CunningSpell));
            Register(10, typeof(CureSpell));
            Register(11, typeof(HarmSpell));
            Register(12, typeof(MagicTrapSpell));
            Register(13, typeof(RemoveTrapSpell));
            Register(14, typeof(ProtectionSpell));
            Register(15, typeof(StrengthSpell));

            // Third circle
            Register(16, typeof(BlessSpell));
            Register(17, typeof(FireballSpell));
            Register(18, typeof(MagicLockSpell));
            Register(19, typeof(PoisonSpell));
            Register(20, typeof(TelekinesisSpell));
            Register(21, typeof(TeleportSpell));
            Register(22, typeof(UnlockSpell));
            Register(23, typeof(WallOfStoneSpell));

            // Fourth circle
            Register(24, typeof(ArchCureSpell));
            Register(25, typeof(ArchProtectionSpell));
            Register(26, typeof(CurseSpell));
            Register(27, typeof(FireFieldSpell));
            Register(28, typeof(GreaterHealSpell));
            Register(29, typeof(LightningSpell));
            Register(30, typeof(ManaDrainSpell));
            Register(31, typeof(RecallSpell));

            // Fifth circle
            Register(32, typeof(BladeSpiritsSpell));
            Register(33, typeof(DispelFieldSpell));
            Register(34, typeof(IncognitoSpell));
            Register(35, typeof(MagicReflectSpell));
            Register(36, typeof(MindBlastSpell));
            Register(37, typeof(ParalyzeSpell));
            Register(38, typeof(PoisonFieldSpell));
            Register(39, typeof(SummonCreatureSpell));

            // Sixth circle
            Register(40, typeof(DispelSpell));
            Register(41, typeof(EnergyBoltSpell));
            Register(42, typeof(ExplosionSpell));
            Register(43, typeof(InvisibilitySpell));
            Register(44, typeof(MarkSpell));
            Register(45, typeof(MassCurseSpell));
            Register(46, typeof(ParalyzeFieldSpell));
            Register(47, typeof(RevealSpell));

            // Seventh circle
            Register(48, typeof(ChainLightningSpell));
            Register(49, typeof(EnergyFieldSpell));
            Register(50, typeof(FlameStrikeSpell));
            Register(51, typeof(GateTravelSpell));
			Register(52, typeof(ManaVampireSpell));
			Register(53, typeof(MassDispelSpell));
			Register(54, typeof(MeteorSwarmSpell));
			Register(55, typeof(PolymorphSpell));

			// Eighth circle
			Register(56, typeof(EarthquakeSpell));
			Register(57, typeof(EnergyVortexSpell));
			Register(58, typeof(ResurrectionSpell));
			Register(59, typeof(AirElementalSpell));
			Register(60, typeof(SummonDaemonSpell));
			Register(61, typeof(EarthElementalSpell));
			Register(62, typeof(FireElementalSpell));
			Register(63, typeof(WaterElementalSpell));

			// Necromancy spells
			//Register(100, typeof(Necromancy.AnimateDeadSpell));
			//Register(101, typeof(Necromancy.BloodOathSpell));
			//Register(102, typeof(Necromancy.CorpseSkinSpell));
			//Register(103, typeof(Necromancy.CurseWeaponSpell));
			//Register(104, typeof(Necromancy.EvilOmenSpell));
			//Register(105, typeof(Necromancy.HorrificBeastSpell));
			//Register(106, typeof(Necromancy.LichFormSpell));
			//Register(107, typeof(Necromancy.MindRotSpell));
			//Register(108, typeof(Necromancy.PainSpikeSpell));
			//Register(109, typeof(Necromancy.PoisonStrikeSpell));
			//Register(110, typeof(Necromancy.StrangleSpell));
			//Register(111, typeof(Necromancy.SummonFamiliarSpell));
			//Register(112, typeof(Necromancy.VampiricEmbraceSpell));
			//Register(113, typeof(Necromancy.VengefulSpiritSpell));
			//Register(114, typeof(Necromancy.WitherSpell));
			//Register(115, typeof(Necromancy.WraithFormSpell));

            //Register(400, typeof(AttaquesSpell));

            //Aeromancie
            Register(600, typeof(AveuglementSpell));
            Register(601, typeof(BrouillardSpell));
            Register(602, typeof(TeleportationSpell));
            Register(603, typeof(TornadoSpell));
            Register(604, typeof(AuraElectrisanteSpell));
            Register(605, typeof(ToucherSuffocantSpell));
            Register(606, typeof(VentFavorableSpell));
			Register(607, typeof(AuraDeBrouillardSpell));
            Register(608, typeof(ExTeleportationSpell));
			Register(609, typeof(VortexSpell));

			//Chasseur
			Register(610, typeof(AntidoteSpell));
			Register(611, typeof(MarquerSpell));
			Register(612, typeof(CompagnonAnimalSpell));
			Register(613, typeof(SoinAnimalierSpell));
			Register(614, typeof(FrappeEnsanglanteeSpell));
			Register(615, typeof(SautAggressifSpell));
			Register(616, typeof(RugissementSpell));
			Register(617, typeof(ChasseurDePrimeSpell));
			Register(618, typeof(CoupDansLeGenouSpell));
			Register(619, typeof(ContratResoluSpell));

			//Defenseur
			Register(620, typeof(DevotionSpell));
			Register(621, typeof(BravadeSpell));
			Register(622, typeof(MentorSpell));
			Register(623, typeof(MutinerieSpell));
			Register(624, typeof(InterventionSpell));
			Register(625, typeof(LienDeVieSpell));
			Register(626, typeof(MiracleSpell));
			Register(627, typeof(IndomptableSpell));
            Register(628, typeof(InsensibleSpell));
            Register(629, typeof(PiedsAuSolSpell));

			//Geomancie
			Register(630, typeof(FortifieSpell));
			Register(631, typeof(RocheSpell));
			Register(632, typeof(ContaminationSpell));
			Register(633, typeof(EmpalementSpell));
			Register(634, typeof(AuraFortifianteSpell));
			Register(635, typeof(MurDePlanteSpell));
			Register(636, typeof(ExplosionDeRochesSpell));
			Register(637, typeof(AuraPreservationManaiqueSpell));
			Register(638, typeof(RacinesSpell));
			Register(639, typeof(FleauTerrestreSpell));

			//Guerison
			Register(640, typeof(MainCicatrisanteSpell));
			Register(641, typeof(RemedeSpell));
			Register(642, typeof(DonDeLaVieSpell));
			Register(643, typeof(RayonCelesteSpell));
			Register(644, typeof(MurDePierreSpell));
			Register(645, typeof(FrayeurSpell));
			Register(646, typeof(FerveurDivineSpell));
			Register(647, typeof(InquisitionSpell));
			Register(648, typeof(MurDeLumiereSpell));
			Register(649, typeof(LumiereSacreeSpell));

			//Hydromancie
			Register(650, typeof(ArmureDeGlaceSpell));
            Register(651, typeof(PieuxDeGlaceSpell));
            Register(652, typeof(RestaurationSpell));
			Register(653, typeof(CageDeGlaceSpell));
            Register(654, typeof(AuraCryogeniseeSpell));
            Register(655, typeof(SoinPreventifSpell));
			Register(656, typeof(CerveauGeleSpell));
            Register(657, typeof(AuraRefrigeranteSpell));
            Register(658, typeof(AvatarDuFroidSpell));
            Register(659, typeof(BlizzardSpell));

			//Martial
            Register(660, typeof(SecondSouffleSpell));
            Register(661, typeof(ProvocationSpell));
            Register(662, typeof(SautDevastateurSpell));
            Register(663, typeof(DuelSpell));
            Register(664, typeof(ChargeFurieuseSpell));
            Register(665, typeof(EnrageSpell));
            Register(666, typeof(BouclierMagiqueSpell));
            Register(667, typeof(CommandementSpell));
            Register(668, typeof(PresenceInspiranteSpell));
            Register(669, typeof(AngeGardienSpell));

			//Musique
            Register(670, typeof(DiversionSpell));
            Register(671, typeof(CalmeToiSpell));
            Register(672, typeof(DesorienterSpell));
            Register(673, typeof(DefiSpell));
            Register(674, typeof(DecrescendoManaiqueSpell));
			Register(675, typeof(InspirationElementaireSpell));
			Register(676, typeof(AbsorbationSonoreSpell));
			Register(677, typeof(ParfaiteAspirationSpell));
			Register(678, typeof(RevelationDiscordanteSpell));
			Register(679, typeof(HavreDePaixSpell));

			//Necromancie
            Register(680, typeof(SoifDeSangSpell));
            Register(681, typeof(ToucheAbsorbantSpell));
			Register(682, typeof(InfectionSpell));
			Register(683, typeof(ArmureOsSpell));
            Register(684, typeof(FamilierMorbideSpell));
            Register(685, typeof(ReanimationSpell));
            Register(686, typeof(ConsommationMortelleSpell));
            Register(687, typeof(AuraVampiriqueSpell));
            Register(688, typeof(AppelDuSangSpell));
            Register(689, typeof(PluieDeSangSpell));

			//Polymorphie
            Register(690, typeof(FormeCycloniqueSpell));
            Register(691, typeof(FormeMetalliqueSpell));
            Register(692, typeof(FormeTerrestreSpell));
            Register(693, typeof(FormeEmpoisonneeSpell));
            Register(694, typeof(FormeGivranteSpell));
            Register(695, typeof(FormeLiquideSpell));
            Register(696, typeof(FormeCristallineSpell));
            Register(697, typeof(FormeElectrisanteSpell));
            Register(698, typeof(FormeEnflammeeSpell));
            Register(699, typeof(FormeEnsanglanteeSpell));

			//Pyromancie
            Register(700, typeof(BouclierDeFeuSpell));
            Register(701, typeof(CeleriteSpell));
            Register(702, typeof(BouleDeFeuSpell));
			Register(703, typeof(SupernovaSpell));
            Register(704, typeof(AuraRechauffanteSpell));
            Register(705, typeof(PassionArdenteSpell));
            Register(706, typeof(CageDeFeuSpell));
            Register(707, typeof(AuraExaltationSpell));
			Register(708, typeof(FrenesieDouloureuseSpell));
			Register(709, typeof(FolieArdenteSpell));

			//Roublardise
			Register(710, typeof(AdrenalineSpell));
            Register(711, typeof(LancerPrecisSpell));
			Register(712, typeof(CoupArriereSpell));
            Register(713, typeof(SommeilSpell));
			Register(716, typeof(MainBlesseeSpell));
			Register(715, typeof(AttiranceSpell));
			Register(714, typeof(EvasionSpell));
			Register(717, typeof(CoupureDesTendonsSpell));
			Register(718, typeof(GazEndormantSpell));
			Register(719, typeof(CoupMortelSpell));

			//Totemique
			Register(720, typeof(TotemDeTerreSpell));
			Register(721, typeof(TotemDeFeuSpell));
			Register(722, typeof(TotemDuVentSpell));
			Register(723, typeof(TotemDeauSpell));
			Register(724, typeof(AbsorbationSpell));
			Register(725, typeof(LierParEspritSpell));
			Register(726, typeof(SuperChargerSpell));
			Register(727, typeof(MurTotemiqueSpell));
			Register(728, typeof(AppelSpirituelSpell));
			Register(729, typeof(MarcheAsuivreSpell));
		}

		public static void Register( int spellID, Type type )
		{
			SpellRegistry.Register( spellID, type );
		}
	}
}