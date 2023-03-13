using System;
using Server;
using Server.Custom.Spells.NewSpells.Aeromancie;
using Server.Custom.Spells.NewSpells.Chasseur;
using Server.Custom.Spells.NewSpells.General;
using Server.Custom.Spells.NewSpells.Geomancie;
using Server.Custom.Spells.NewSpells.Hydromancie;
using Server.Custom.Spells.NewSpells.Necromancie;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Custom.Spells.NewSpells.Pyromancie;
using Server.Custom.Spells.NewSpells.Roublardise;
using Server.Spells.OldSpells;

namespace Server.Spells
{
	public class Initializer
	{
        public static void Initialize()
        {
            // First circle
            //Register(00, typeof(ClumsySpell));
            //Register(01, typeof(CreateFoodSpell));
            //Register(02, typeof(FeeblemindSpell));
            Register(03, typeof(HealSpell));
            //Register(04, typeof(MagicArrowSpell));
            //Register(05, typeof(NightSightSpell));
            //Register(06, typeof(ReactiveArmorSpell));
            //Register(07, typeof(WeakenSpell));

            // Second circle
            //Register(08, typeof(AgilitySpell));
            //Register(09, typeof(CunningSpell));
            Register(10, typeof(CureSpell));
            Register(11, typeof(HarmSpell));
            //Register(12, typeof(MagicTrapSpell));
            //Register(13, typeof(RemoveTrapSpell));
            //Register(14, typeof(ProtectionSpell));
            //Register(15, typeof(StrengthSpell));

            // Third circle
            Register(16, typeof(BlessSpell));
            Register(17, typeof(FireballSpell));
            //Register(18, typeof(MagicLockSpell));
            //Register(19, typeof(PoisonSpell));
            Register(20, typeof(TelekinesisSpell));
            Register(21, typeof(TeleportSpell));
            //Register(22, typeof(UnlockSpell));
            //Register(23, typeof(WallOfStoneSpell));

            // Fourth circle
            Register(24, typeof(ArchCureSpell));
            //Register(25, typeof(ArchProtectionSpell));
            //Register(26, typeof(CurseSpell));
            Register(27, typeof(FireFieldSpell));
            Register(28, typeof(GreaterHealSpell));
            Register(29, typeof(LightningSpell));
            //Register(30, typeof(ManaDrainSpell));
            Register(31, typeof(RecallSpell));

            // Fifth circle
            //Register(32, typeof(BladeSpiritsSpell));
            Register(33, typeof(DispelFieldSpell));
            Register(34, typeof(IncognitoSpell));
            //Register(35, typeof(MagicReflectSpell));
            //Register(36, typeof(MindBlastSpell));
            Register(37, typeof(ParalyzeSpell));
            Register(38, typeof(PoisonFieldSpell));
            //Register(39, typeof(SummonCreatureSpell));

            // Sixth circle
            Register(40, typeof(DispelSpell));
            Register(41, typeof(EnergyBoltSpell));
            Register(42, typeof(ExplosionSpell));
            Register(43, typeof(InvisibilitySpell));
            Register(44, typeof(MarkSpell));
            //Register(45, typeof(MassCurseSpell));
            Register(46, typeof(ParalyzeFieldSpell));
            Register(47, typeof(RevealSpell));

            // Seventh circle
            //Register(48, typeof(ChainLightningSpell));
            //Register(49, typeof(EnergyFieldSpell));
            Register(50, typeof(FlameStrikeSpell));
            Register(51, typeof(GateTravelSpell));
			//Register(52, typeof(ManaVampireSpell));
			//Register(53, typeof(MassDispelSpell));
			//Register(54, typeof(MeteorSwarmSpell));
			//Register(55, typeof(PolymorphSpell));

			// Eighth circle
			//Register(56, typeof(EarthquakeSpell));
			//Register(57, typeof(EnergyVortexSpell));
			//Register(58, typeof(.ResurrectionSpell));
			//Register(59, typeof(AirElementalSpell));
			//Register(60, typeof(SummonDaemonSpell));
			//Register(61, typeof(EarthElementalSpell));
			//Register(62, typeof(FireElementalSpell));
			//Register(63, typeof(WaterElementalSpell));

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

            //Magie arcanique custom
            Register(600, typeof(AuraCryogeniseeSpell));
            Register(601, typeof(SoinPreventifSpell));
            Register(602, typeof(CageDeGlaceSpell));
            //Register(603, typeof(BlessureSpell));
            //Register(604, typeof(PieuxDeTerreSpell));
            //Register(606, typeof(TelekinesieSpell));

            Register(607, typeof(AuraFortifianteSpell));
            Register(608, typeof(FortifieSpell));
            //Register(609, typeof(FaiblesseSpell));
            //Register(610, typeof(MaladresseSpell));
            Register(611, typeof(AuraDeRemedeSpell));
            //Register(612, typeof(StupiditeSpell));
            Register(613, typeof(ExplosionDeRocheSpell));
            Register(614, typeof(InfectionSpell));
            //Register(615, typeof(ReversSpell));

            //Register(616, typeof(MurDeHaieSpell));
            //Register(617, typeof(MurDePierreSpell));
            Register(618, typeof(TornadoSpell));
			//Register(619, typeof(MurDeFeuSpell));
			//Register(620, typeof(MurDEnergieSpell));
			Register(621, typeof(AuraBrouillardSpell));

			Register(622, typeof(AvatarDuFroidSpell));
			Register(623, typeof(ToucherSuffocantSpell));
			Register(624, typeof(ArmureGlaceSpell));
            Register(625, typeof(CoupureDesTendonsSpell));
            Register(626, typeof(CoupMortelSpell));
			Register(627, typeof(AveuglementSpell));

            Register(628, typeof(AntidoteSpell));
            Register(629, typeof(GuerisonSpell));
            Register(630, typeof(GazEndormant));
            Register(631, typeof(GuerisonMajeureSpell));
            Register(632, typeof(RestaurationSpell));
            Register(633, typeof(NResurrectionSpell));

            Register(634, typeof(AuraEvasiveSpell));
			Register(635, typeof(ExTeleportationSpell));
			Register(636, typeof(ProtectSpell));
            //Register(637, typeof(SecoursSpell));
            Register(638, typeof(ToucheAbsorbantSpell));
            Register(639, typeof(ExplosionDeGlaceSpell));

            Register(640, typeof(SautAggressifSpell));
            Register(641, typeof(ContaminationSpell));
            Register(642, typeof(LancerPrecisSpell));
            Register(643, typeof(MurDePlanteSpell));
            Register(644, typeof(PluieAcideSpell));
            Register(645, typeof(CoupArriereSpell));

            Register(646, typeof(RacinesSpell));
            Register(647, typeof(SoifDeSangSpell));
            //Register(648, typeof(EpinesSpell));
            Register(649, typeof(VentFavorableSpell));
            Register(650, typeof(AuraExsangueSpell));
            //Register(651, typeof(JetDEpinesSpell));

            Register(652, typeof(RocheSpell));
            Register(653, typeof(RicochetSpell));
            Register(654, typeof(CerveauGeleSpell));
            Register(655, typeof(MarquerSpell));
            Register(656, typeof(FrappeEnsanglanteeSpell));
            Register(657, typeof(CoupDansLeGenouSpell));

            Register(658, typeof(FleauTerrestreSpell));
            Register(659, typeof(SoinAnimalierSpell));
            Register(660, typeof(BlizzardSpell));
            Register(661, typeof(AuraRefrigeranteSpell));
            Register(662, typeof(EmpalementSpell));
            Register(663, typeof(VortexSpell));

            Register(664, typeof(BouclierDeFeuSpell));
            Register(665, typeof(FormeTerrestreSpell));
            Register(666, typeof(FormeEnsangleeSpell));
            Register(667, typeof(FormeEnflammeeSpell));
            Register(668, typeof(FormeEmpoisonneeSpell));
            Register(669, typeof(FormeCristallineSpell));

            Register(670, typeof(FormeGivranteSpell));
            Register(671, typeof(FormeCycloniqueSpell));
            Register(672, typeof(FormeElectrisanteSpell));
            Register(673, typeof(FormeLiquideSpell));
            Register(674, typeof(FormeMetalliqueSpell));
			//Register(675, typeof(EspritVengeurSpell));

			//Register(676, typeof(PourritureDEspritSpell));
			//Register(677, typeof(DrainDeManaSpell));
			Register(678, typeof(RugissementSpell));
			Register(679, typeof(AdrenalineSpell));
            Register(680, typeof(MainBlesseeSpell));
            Register(681, typeof(ChasseurDePrimeSpell));

			Register(682, typeof(ContratResoluSpell));
			Register(683, typeof(TeleportationSpell));
            Register(684, typeof(RappelSpell));
            Register(685, typeof(EvasionSpell));
            Register(686, typeof(TrouDeVerSpell));
            Register(687, typeof(MarquageSpell));

            //Register(688, typeof(PiegeSpell));
            //Register(689, typeof(DesamorcageSpell));
            //Register(690, typeof(SerrureSpell));
            //Register(691, typeof(CrochetageSpell));
            Register(692, typeof(IncognitoSpell));
            Register(693, typeof(BrouillardSpell));
            //Register(694, typeof(HallucinationsSpell));
            //Register(695, typeof(DisparitionSpell));

            //Register(696, typeof(AlterationSpell));
            //Register(697, typeof(SubterfugeSpell));
            //Register(698, typeof(ChimereSpell));
            //Register(699, typeof(TransmutationSpell));
            //Register(700, typeof(MetamorphoseSpell));
            //Register(701, typeof(MutationSpell));

            Register(702, typeof(AuraVampiriqueSpell));
            Register(703, typeof(RegardNecrotiqueSpell));
            Register(704, typeof(AttiranceSpell));
			//Register(705, typeof(LanceOsSpell));
			Register(706, typeof(ArmureOsSpell));
            Register(707, typeof(SommeilSpell));

            //Register(708, typeof(FamilierSpell));
            //Register(709, typeof(DefraicheurSpell));
            //Register(710, typeof(StrangulaireSpell));
            Register(711, typeof(ReanimationSpell));
            Register(712, typeof(AppelDuSangSpell));
			//Register(713, typeof(InsurectionSpell));
		}

		public static void Register( int spellID, Type type )
		{
			SpellRegistry.Register( spellID, type );
		}
	}
}