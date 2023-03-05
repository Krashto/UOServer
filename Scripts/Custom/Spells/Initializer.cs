using System;
using Server;
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
   //         Register(101, typeof(Necromancy.BloodOathSpell));
   //         Register(102, typeof(Necromancy.CorpseSkinSpell));
   //         Register(103, typeof(Necromancy.CurseWeaponSpell));
   //         Register(104, typeof(Necromancy.EvilOmenSpell));
   //         Register(105, typeof(Necromancy.HorrificBeastSpell));
   //         Register(106, typeof(Necromancy.LichFormSpell));
   //         Register(107, typeof(Necromancy.MindRotSpell));
   //         Register(108, typeof(Necromancy.PainSpikeSpell));
   //         Register(109, typeof(Necromancy.PoisonStrikeSpell));
   //         Register(110, typeof(Necromancy.StrangleSpell));
   //         Register(111, typeof(Necromancy.SummonFamiliarSpell));
   //         Register(112, typeof(Necromancy.VampiricEmbraceSpell));
   //         Register(113, typeof(Necromancy.VengefulSpiritSpell));
   //         Register(114, typeof(Necromancy.WitherSpell));
   //         Register(115, typeof(Necromancy.WraithFormSpell));

            //Register(400, typeof(AttaquesSpell));

            //Magie arcanique custom
            Register(600, typeof(NourritureSpell));
            Register(601, typeof(VisionDeNuitSpell));
            Register(602, typeof(FlecheMagiqueSpell));
            //Register(603, typeof(BlessureSpell));
            //Register(604, typeof(PieuxDeTerreSpell));
            Register(606, typeof(TelekinesieSpell));

            Register(607, typeof(ForceSpell));
            Register(608, typeof(AgiliteSpell));
            //Register(609, typeof(FaiblesseSpell));
            //Register(610, typeof(MaladresseSpell));
            Register(611, typeof(IntelligenceSpell));
            //Register(612, typeof(StupiditeSpell));
            Register(613, typeof(BenedictionSpell));
            Register(614, typeof(MaledictionSpell));
            //Register(615, typeof(ReversSpell));

            //Register(616, typeof(MurDeHaieSpell));
            //Register(617, typeof(MurDePierreSpell));
            Register(618, typeof(GeyserSpell));
            //Register(619, typeof(MurDeFeuSpell));
            //Register(620, typeof(MurDEnergieSpell));
            //Register(621, typeof(MurDeParalysieSpell));

            Register(622, typeof(RevelationSpell));
            //Register(623, typeof(DissipationSpell));
            Register(624, typeof(ArmureMagiqueSpell));
            Register(625, typeof(DissipationDeMurSpell));
            Register(626, typeof(DissipationDeMasseSpell));
            Register(627, typeof(DerobadeSpell));

            Register(628, typeof(AntidoteSpell));
            Register(629, typeof(GuerisonSpell));
            Register(630, typeof(AntidoteDeMasseSpell));
            Register(631, typeof(GuerisonMajeureSpell));
            Register(632, typeof(ZoneDeGuerisonSpell));
            Register(633, typeof(NResurrectionSpell));

            Register(634, typeof(ArmureSpell));
            //Register(635, typeof(ReflectionSpell));
            Register(636, typeof(ProtectSpell));
            Register(637, typeof(SecoursSpell));
            //Register(638, typeof(CopieSpell));
            Register(639, typeof(ChampDeStaseSpell));

            Register(640, typeof(PoisonMineurSpell));
            Register(641, typeof(NPoisonSpell));
            Register(642, typeof(JetDePoisonSpell));
            Register(643, typeof(MurDePoisonSpell));
            Register(644, typeof(PluieAcideSpell));
            Register(645, typeof(PinceeAcideSpell));

            Register(646, typeof(RacinesSpell));
            Register(647, typeof(AbeillesSpell));
            //Register(648, typeof(EpinesSpell));
            Register(649, typeof(CriDOursSpell));
            Register(650, typeof(ArmurePierreSpell));
            //Register(651, typeof(JetDEpinesSpell));

            Register(652, typeof(BouleDeFeuSpell));
            Register(653, typeof(EclairSpell));
            Register(654, typeof(BouleDeGlaceSpell));
            Register(655, typeof(BouleDEnergieSpell));
            Register(656, typeof(JetDeFeuSpell));
            Register(657, typeof(FulgurationSpell));

            Register(658, typeof(TremblementsSpell));
            Register(659, typeof(ExplosionsSpell));
            Register(660, typeof(SeismeSpell));
            Register(661, typeof(EclairEnChaineSpell));
            Register(662, typeof(MeteoresSpell));
            Register(663, typeof(VortexSpell));

            Register(664, typeof(CreatureSpell));
            Register(665, typeof(ElementaireTerreSpell));
            Register(666, typeof(ElementaireAirSpell));
            Register(667, typeof(ElementaireFeuSpell));
            Register(668, typeof(ElementaireEauSpell));
            Register(669, typeof(ElementaireCristalSpell));

            Register(670, typeof(EspritAnimalSpell));
            Register(671, typeof(EspritDeLamesSpell));
            Register(672, typeof(EspritDEnergieSpell));
            Register(673, typeof(DragonSpell));
            Register(674, typeof(DemonSpell));
            //Register(675, typeof(EspritVengeurSpell));

            //Register(676, typeof(PourritureDEspritSpell));
            //Register(677, typeof(DrainDeManaSpell));
            Register(678, typeof(MalaiseSpell));
            Register(679, typeof(SouffleDEspritSpell));
            Register(680, typeof(DrainVampiriqueSpell));
            Register(681, typeof(EtouffementsSpell));

            //Register(682, typeof(EnduranceSpell));
            Register(683, typeof(TeleportationSpell));
            Register(684, typeof(RappelSpell));
            Register(685, typeof(EvasionSpell));
            Register(686, typeof(TrouDeVerSpell));
            Register(687, typeof(MarquageSpell));

            //Register(688, typeof(PiegeSpell));
            //Register(689, typeof(DesamorcageSpell));
            //Register(690, typeof(SerrureSpell));
            Register(691, typeof(CrochetageSpell));
            Register(692, typeof(IncognitoSpell));
            Register(693, typeof(InvisibiliteSpell));
            //Register(694, typeof(HallucinationsSpell));
            //Register(695, typeof(DisparitionSpell));

            //Register(696, typeof(AlterationSpell));
            //Register(697, typeof(SubterfugeSpell));
            //Register(698, typeof(ChimereSpell));
            //Register(699, typeof(TransmutationSpell));
            //Register(700, typeof(MetamorphoseSpell));
            //Register(701, typeof(MutationSpell));

            Register(702, typeof(CalamiteSpell));
            Register(703, typeof(PeauDeMortSpell));
            Register(704, typeof(MauvaisPresageSpell));
            //Register(705, typeof(LanceOsSpell));
            Register(706, typeof(SermentDeSangSpell));
            Register(707, typeof(JetDeDouleurSpell));

            Register(708, typeof(FamilierSpell));
            //Register(709, typeof(DefraicheurSpell));
            Register(710, typeof(StrangulaireSpell));
            Register(711, typeof(ReanimationSpell));
            Register(712, typeof(AppelDeLaLicheSpell));
			//Register(713, typeof(InsurectionSpell));

			//Register(1000, typeof(VisionDivineSpell));
			//Register(1001, typeof(PoingDeValeurSpell));
			//Register(1002, typeof(EssouflementSpell));
			//Register(1003, typeof(LumiereDivineSpell));
			//Register(1004, typeof(GriffesSpell));
			//Register(1005, typeof(ImbroglioSpell));

			//Register(1006, typeof(RetablissementSpell));
			//Register(1007, typeof(RegenerationSpell));
			//Register(1008, typeof(BouclierSpell));
			//Register(1009, typeof(AmuletteSpell));
			//Register(1010, typeof(RefecteurSpell));
			//Register(1011, typeof(MiracleSpell));

			//Register(1012, typeof(RepartitionSpell));
			//Register(1013, typeof(RenouvellementSpell));
			//Register(1014, typeof(PurificationSpell));
			//Register(1015, typeof(PromptitudeSpell));
			//Register(1016, typeof(PassionSpell));
			//Register(1017, typeof(RegenerescenceSpell));

			//Register(1018, typeof(HautePrecisionSpell));
			//Register(1019, typeof(AgglomerationSpell));
			//Register(1020, typeof(RudesseSpell));
			//Register(1021, typeof(ConsecrationSpell));
			//Register(1022, typeof(ConfessionSpell));
			//Register(1023, typeof(ForceDeLaFoiSpell));

			//Register(1024, typeof(FamineSpell));
			//Register(1025, typeof(ErranceSpell));
			//Register(1026, typeof(BetesSpell));
			//Register(1027, typeof(HypnoseSpell));
			//Register(1028, typeof(FetichismeSpell));
			//Register(1029, typeof(VoodooSpell));

			//Register(1030, typeof(PiedAncreSpell));
			//Register(1031, typeof(RobustesseSpell));
			//Register(1032, typeof(SouplesseSpell));
			//Register(1033, typeof(CorpsPurSpell));
			//Register(1034, typeof(EternelleJeunesseSpell));
			//Register(1035, typeof(ProuesseSpell));

			//Register(1036, typeof(ConscienceSpell));
			//Register(1037, typeof(AppelDeLaNatureSpell));
			//Register(1038, typeof(AnimauxSpell));
			//Register(1039, typeof(InstinctCharnelSpell));
			//Register(1040, typeof(TransfertSpell));
			//Register(1041, typeof(DominationSpell));

			//Register(1042, typeof(PlumeSpell));
			//Register(1043, typeof(IntrinsequeSpell));
			//Register(1044, typeof(VoileSpell));
			//Register(1045, typeof(EchoSpell));
			//Register(1046, typeof(StupefactionSpell));
			//Register(1047, typeof(DecheanceSpell));

			//Register(1048, typeof(AuraDeFatigueSpell));
			//Register(1049, typeof(MortificationSpell));
			//Register(1050, typeof(ExecrationSpell));
			//Register(1051, typeof(HalenePutrideSpell));
			//Register(1052, typeof(HorreurSpell));
			//Register(1053, typeof(PourrissementSpell));

			//Register(1054, typeof(CourageSpell));
			//Register(1055, typeof(SagesseSpell));
			//Register(1056, typeof(BerseckSpell));
			//Register(1057, typeof(TranscendanceSpell));
			//Register(1058, typeof(SpiritualiteSpell));
			//Register(1059, typeof(SoifDuCombatSpell));

			//Register(1060, typeof(SauvegardeSpell));
			//Register(1061, typeof(ExaltationSpell));
			//Register(1062, typeof(LabyrintheSpell));
			//Register(1063, typeof(VisionReelleSpell));
			//Register(1064, typeof(AppuiSpell));
			//Register(1065, typeof(PatronageSpell));

			//Register(1066, typeof(TalismanSpell));
			//Register(1067, typeof(BarilDeBiereSpell));
			//Register(1068, typeof(PointDeParesseSpell));
			//Register(1069, typeof(SoutienSpell));
			//Register(1070, typeof(DonDesRochersSpell));
			//Register(1071, typeof(CouvertureSpell));

			//Register(1600, typeof(MelodieSpell));
			//Register(1601, typeof(ChantSpell));
			//Register(1602, typeof(MurmureSpell));
			//Register(1603, typeof(ConteSpell));
			//Register(1604, typeof(SonnetteSpell));
			//Register(1605, typeof(HymneSpell));
			//Register(1606, typeof(CompositionSpell));

			//Register(1607, typeof(MarcheSpell));
			//Register(1608, typeof(HarmonieSpell));
			//Register(1609, typeof(CriDeGuerreSpell));
			//Register(1610, typeof(FanfareSpell));
			//Register(1611, typeof(SymphonieSpell));
			//Register(1612, typeof(OrchestreSpell));
			//Register(1613, typeof(BruitSpell));
		}

		public static void Register( int spellID, Type type )
		{
			SpellRegistry.Register( spellID, type );
		}
	}
}