#region References
using Server.Network;
using System.Reflection;
using System;
using System.Collections.Generic;
using Server.Items;
using Server.Custom.Misc;
using System.Collections;
using Server.Custom;
using Server.Movement;
using Server.Gumps;
using Server.Custom.Classes;
using Server.Custom.Aptitudes;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Custom.Spells;
using Server.Custom.Spells.NewSpells.Hydromancie;
using Server.Custom.Spells.NewSpells.Defenseur;
using Server.CustomScripts.Systems.Experience;
using Server.Custom.Capacites;
using Newtonsoft.Json.Linq;
using Server.Custom.PointsAncestraux;

#endregion

namespace Server.Mobiles
{
	public partial class CustomPlayerMobile : PlayerMobile
	{
		private GrandeurEnum m_Grandeur;
		private CorpulenceEnum m_Corpulence;
		private AppearanceEnum m_Apparence;

		private Classe m_Classe;

		private Container m_Corps;

		private DateTime m_LastLoginTime;

		private DateTime m_LastPay;
		private int m_Salaire;

		private int m_IdentiteId;

		private bool m_Masque = false;

		private Race m_BaseRace;
		private bool m_BaseFemale;
		private int m_BaseHue;

		public bool Hallucinating;

		public bool m_Vulnerability;

		private List<MissiveContent> m_MissiveEnAttente = new List<MissiveContent>();

		#region Possess
		private Mobile m_Possess;
		private Mobile m_PossessStorage;

		public Mobile Possess
		{
			get { return m_Possess; }
			set { m_Possess = value; }
		}

		public Mobile PossessStorage
		{
			get { return m_PossessStorage; }
			set { m_PossessStorage = value; }
		}
		#endregion

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Journaliste { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime LastDeathTime { get; private set; }

		public double DeathDuration => 1; //minutes

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime EndOfVulnerabilityTime { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Vulnerability
		{
			get
			{
				if (m_Vulnerability && EndOfVulnerabilityTime <= DateTime.Now)
				{
					m_Vulnerability = false;
					SendMessage(HueManager.GetHue(HueManagerList.Green), "Vous n'êtes plus vulnérable. La prochaine fois que vous tomberez au combat, vous serez assomé.");
				}

				return m_Vulnerability;
			}
			set
			{
				m_Vulnerability = value;
			}

		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool DeathShot { get; set; }
		public int VulnerabilityDuration => 5; //minutes

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime PreventPvpAttackTime { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool PreventPvpAttack { get; set; }
		public int PreventPvpAttackDuration => 1; //minutes

		[CommandProperty(AccessLevel.GameMaster)]
		public CorpulenceEnum Grosseur { get => m_Corpulence; set => m_Corpulence = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public GrandeurEnum Grandeur { get => m_Grandeur; set => m_Grandeur = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public AppearanceEnum Beaute { get => m_Apparence; set => m_Apparence = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public string BaseName
		{
			get => GetBaseName();
		}

		[CommandProperty(AccessLevel.Administrator)]
		public bool IsHallucinating
		{
			get { return Hallucinating; }
			set { Hallucinating = value; InvalidateProperties(); }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Classe Classe
		{
			get => m_Classe;
			set { m_Classe = value; }
		}

		public virtual string GetClasse()
		{
			return ((ClasseInfo)Classes.GetInfos(m_Classe)).Nom;
		}

		public virtual string GetClasse(Classe c)
		{
			return ((ClasseInfo)Classes.GetInfos(c)).Nom;
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime LastLoginTime
		{
			get { return m_LastLoginTime; }
			set { m_LastLoginTime = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime LastPay
		{
			get { return m_LastPay; }
			set { m_LastPay = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Salaire { get { return m_Salaire; } set { m_Salaire = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public override int FollowersMax => 2 + Capacites[Capacite.Compagnon];

		[CommandProperty(AccessLevel.GameMaster)]
		public Container Corps { get { return m_Corps; } set { m_Corps = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public NewSpellbook ChosenSpellbook { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int IdentiteID
		{
			get => m_IdentiteId;
			set { m_IdentiteId = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Race BaseRace
		{
			get
			{
				return m_BaseRace;
			}
			set
			{
				m_BaseRace = value;
				Race = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool BaseFemale
		{
			get
			{
				return m_BaseFemale;
			}
			set
			{
				m_BaseFemale = value;
				Female = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int BaseHue
		{
			get
			{
				return m_BaseHue;
			}
			set
			{
				m_BaseHue = value;
				Hue = value;
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int TitleCycle { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public string CustomTitle { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public QuiOptions QuiOptions
		{
			get;
			set;
		}
		public List<MissiveContent> MissiveEnAttente { get { return m_MissiveEnAttente; } set { m_MissiveEnAttente = value; } }

		public override double GetRacialSkillBonus(SkillName skill)
		{
			var value = 0;

			switch (skill)
			{
				case SkillName.Alchemy: value = Aptitudes.Chimie * 4; break;
				case SkillName.Tailoring: value = Aptitudes.Couture * 4; break;
				case SkillName.Tinkering: value = Aptitudes.Ingenierie * 4; break;
				case SkillName.Blacksmith: value = Aptitudes.Metallurgie * 4; break;
				case SkillName.Inscribe: value = Aptitudes.Transcription * 4; break;
			}

			return value;
		}
		
		public new static void Initialize()
		{
			EventSink.Login += new LoginEventHandler(OnLogin);
		}

		private static void OnLogin(LoginEventArgs e)
		{
			var pm = e.Mobile as CustomPlayerMobile;
			if (pm != null)
				Classes.SetBaseAndCapSkills(pm, pm.Experience.Niveau);
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime JailTime { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Point3D JailLocation { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Map JailMap { get; set; }

		private bool m_Jail = false;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Jail
		{
			get
			{
				if (m_Jail && DateTime.Now >= JailTime)
					JailRelease();

				return m_Jail;
			}
			set
			{
				if (!m_Jail && value)
					JailP(null,TimeSpan.FromDays(7));
				else
					JailRelease();

				m_Jail = value;

			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile JailBy { get; set; }

		public DateTime NextFaimMessage { get; set; }

		public DateTime NextSoifMessage { get; set; }

		public DateTime NextFrapper { get; set; }

		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (Vulnerability)
			{
				list.Add(1050045, "<\th3><basefont color=#FF8000>" + (Female ? "ASSOMÉE" : "ASSOMÉ") + "</basefont></h3>\t");
			}

			if (NameMod == null)
			{
				list.Add(1050045, "{0}, \t{1}\t", Race.Name, Apparence()); // ~1_PREFIX~~2_NAME~~3_SUFFIX~
				list.Add(1050045, "{0}, \t{1}\t", GrandeurString(), CorpulenceString());
			}
		}

		#region Missive
		public virtual void AddMissive(Missive missive)
		{
			if (missive == null || missive.Deleted)
				return;

			MissiveEnAttente.Add(missive.Content);

			missive.Delete();

			SendMessage("Vous avez reçu une missive.");
		}

		public virtual void GetMissive()
		{
			for (int i = 0; i < MissiveEnAttente.Count; ++i)
			{
				MissiveContent entry = MissiveEnAttente[i];

				if (entry != null)
				{
					AddToBackpack(new Missive(entry));
				}
			}
			MissiveEnAttente = new List<MissiveContent>();
		}

		#endregion

		public override bool CheckPoisonImmunity(Mobile from, Poison poison)
		{
			return InsensibleSpell.IsActive(this) || FormeEnsangleeSpell.IsActive(this);
		}

		#region Hiding
		public override void Reveal(Mobile m)
		{
			if (m is CustomPlayerMobile)
			{
				if (!VisibilityList.Contains(m))
				{
					VisibilityList.Add(m);
					m.SendMessage("Vous avez detecté " + Name + ".");
				}

				if (Utility.InUpdateRange(m, this))
				{
					NetState ns = m.NetState;

					if (ns != null)
					{
						if (m.CanSee(this))
						{
							ns.Send(new MobileIncoming(m, this));

							ns.Send(this.OPLPacket);

							foreach (Item item in this.Items)
								ns.Send(item.OPLPacket);
						}
						else
						{
							ns.Send(this.RemovePacket);
						}
					}
				}
			}
			else if (m is BaseCreature && ((BaseCreature)m).IsBonded) // Grosso modo ici, c'est pour permettre de detecter sans revealer avec les familiers, car certains on du DH.
			{
				BaseCreature sd = (BaseCreature)m;

				Mobile cm = sd.ControlMaster;

				if (!VisibilityList.Contains(cm))
				{
					VisibilityList.Add(cm);
					cm.SendMessage(sd.Name + " vous indique la présence de " + Name + ".");
				}

				if (Utility.InUpdateRange(cm, this))
				{
					NetState ns = cm.NetState;

					if (ns != null)
					{
						if (cm.CanSee(this))
						{
							ns.Send(new MobileIncoming(cm, this));

							ns.Send(this.OPLPacket);

							foreach (Item item in this.Items)
								ns.Send(item.OPLPacket);
						}
						else
						{
							ns.Send(this.RemovePacket);
						}
					}
				}
			}
			else
			{
				RevealingAction();
			}
		}

		public override void RevealingAction()
		{
			if (Hidden)
				VisibilityList = new List<Mobile>();

			base.RevealingAction();
		}
		
		public override int GetHideBonus()
		{
			int bonus = 0;

			double chance = 0.80 * GetBagFilledRatio(this);

			if (chance >= Utility.RandomDouble())
				bonus -= 10;

			int ar = SkillHandlers.Hiding.GetArmorRating(this);

			if (ar >= 90)
				bonus -= 50;
			else if (ar >= 75)
				bonus -= 40;
			else if (ar >= 60)
				bonus -= 30;
			else if (ar >= 40)
				bonus -= 20;
			else if (ar >= 20)
				bonus -= 10;

			return base.GetHideBonus() + bonus;
		}

		public override int GetDetectionBonus(Mobile mobile)
		{
			int bonus = 0;

			if (FindItemOnLayer(Layer.TwoHanded) is BaseEquipableLight)
			{
				BaseEquipableLight Light = (BaseEquipableLight)FindItemOnLayer(Layer.TwoHanded);

				ComputeLightLevels(out int global, out int personal);

				int lightLevel = global + personal;

				if (lightLevel >= 20 && Light.Burning)
					bonus += 10;
			}

			return base.GetDetectionBonus(mobile) + bonus;
		}

		public static double GetBagFilledRatio(CustomPlayerMobile pm)
		{
			Container pack = pm.Backpack;

			if (pm.AccessLevel >= AccessLevel.GameMaster)
				return 0;

			if (pack != null)
			{
				int maxweight = pm.MaxWeight;

				double value = (pm.TotalWeight / maxweight) - 0.50;

				if (value < 0)
					value = 0;

				if (value > 0.50)
					value = 0.50;

				return value;
			}

			return 0;
		}

		public int GainGold(int gold, bool bank = false)
		{
			int gainGold = gold;
			int taxesGold = 0;

			if (Race.RaceID != 0)
				taxesGold = (int)Math.Round((gainGold * 0.1), 0, MidpointRounding.AwayFromZero);

			if (bank)
			{
				if (Banker.Deposit(this, gainGold))
					SendMessage(HueManager.GetHue(HueManagerList.Green), "Votre guilde a déposé votre salaire de " + gainGold + " pièces d'or dans votre coffre de banque.");
			}
			else
			{
				while (gainGold > 60000)
				{
					AddToBackpack(new Gold(60000));
					gainGold -= 60000;
				}

				AddToBackpack(new Gold(gainGold));

				PlaySound(0x0037); //Gold dropping sound
			}

			if (AccessLevel == AccessLevel.Player)
				CustomPersistence.TaxesMoney += taxesGold;

			return gainGold;
		}

		public void GainSalaire(CustomGuildMember cgm)
		{
			int gold = cgm.Salaire;

			if (m_LastPay.Day != DateTime.Now.Day)
			{
				Salaire = 0;
				m_LastPay = DateTime.Now;
			}

			if (gold > Salaire)
			{
				int Payment = gold - Salaire;

				Server.Custom.System.GuildRecruter.PayLog(cgm, Payment);
				GainGold(Payment, true);

				if (AccessLevel == AccessLevel.Player)
					CustomPersistence.Salaire += Payment;

				Salaire = Payment;
			}
		}

		#endregion

		#region Apparence
		public string Apparence()
		{
			AppearanceEnum apparence = m_Apparence;

			if (apparence < 0)
				apparence = 0;
			else if ((int)apparence > 19)
				apparence = (AppearanceEnum)19;

			var type = typeof(AppearanceEnum);
			MemberInfo[] memberInfo = type.GetMember(apparence.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
		}

		public string CorpulenceString()
		{
			CorpulenceEnum corpolence = m_Corpulence;

			if (corpolence < 0)
				corpolence = 0;
			else if ((int)corpolence > 8)
				corpolence = (CorpulenceEnum)8;

			var type = typeof(CorpulenceEnum);
			MemberInfo[] memberInfo = type.GetMember(corpolence.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
		}

		public string GrandeurString()
		{
			GrandeurEnum grandeur = m_Grandeur;

			var type = typeof(GrandeurEnum);
			MemberInfo[] memberInfo = type.GetMember(grandeur.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
		}
		#endregion

		public CustomPlayerMobile()
		{
			Aptitudes = new Aptitudes(this);
			Experience = new ExperienceSystem();
			Attributs = new Attributs(this);
			Capacites = new Capacites(this);
			PointsAncestraux = new PointsAncestraux(this);
		}

		public CustomPlayerMobile(Serial s) : base(s)
		{
			Aptitudes = new Aptitudes(this);
			Experience = new ExperienceSystem();
			Attributs = new Attributs(this);
			Capacites = new Capacites(this);
			PointsAncestraux = new PointsAncestraux(this);
		}

		public virtual void Tip(Mobile m, string tip)
		{
			SendGump(new TipGump(this, m, tip, true));

			SendMessage("Un maître de jeu vous a envoyé un message, double cliquez le b pour le lire.");
		}

		#region Equitation
		public virtual bool CheckEquitation(EquitationType type)
		{
			return CheckEquitation(type, Location);
		}

		public int TileToDontFall { get; set; }
																// 0    1    2    3    4    5 
		private static int[] m_RunningTable = new int[]			{ 100, 100, 025, 000, 000, 000 };
		private static int[] m_BeingAttackedTable = new int[]	{ 100, 100, 100, 100, 075, 005 };
		private static int[] m_MeleeAttackingTable = new int[]	{ 100, 100, 100, 050, 005, 000 };
		private static int[] m_CastAttackingTable = new int[]	{ 100, 100, 100, 100, 100, 100 };
		private static int[] m_RangedAttackingTable = new int[] { 100, 100, 100, 050, 005, 000 };
		private static int[] m_DismountTable = new int[]		{ 100, 100, 080, 070, 060, 050 };

		public virtual bool CheckEquitation(EquitationType type, Point3D oldLocation)
		{
			//true s'il ne tombe pas, false s'il tombe

			if (!Mounted)
				return true;

			if (Mount is Multis.RowBoat)
				return true;

			if (AccessLevel >= AccessLevel.GameMaster)
				return true;

			if (Map == null)
				return true;

			int chanceToFall = 0;
			int equitation = Capacites.Equitation;

			if (equitation < 0)
				equitation = 0;

			if (equitation > 5)
				equitation = 5;

			switch (type)
			{
				case EquitationType.Running: chanceToFall = m_RunningTable[equitation]; break;
				case EquitationType.BeingAttacked: chanceToFall = m_BeingAttackedTable[equitation]; break;
				case EquitationType.MeleeAttacking: chanceToFall = m_MeleeAttackingTable[equitation]; break;
				case EquitationType.CastAttacking: chanceToFall = m_CastAttackingTable[equitation]; break;
				case EquitationType.RangedAttacking: chanceToFall = m_RangedAttackingTable[equitation]; break;
				case EquitationType.Dismount: chanceToFall = m_DismountTable[equitation]; break;
			}

			if (chanceToFall < 0)
				chanceToFall = 0;

			if (chanceToFall <= Utility.RandomMinMax(0, 100))
				return true;

			if (type == EquitationType.Running)
			{
				TileType tile = Deplacement.GetTileType(this);

				if (tile == TileType.Other || tile == TileType.Dirt)
					return true;
			}

			BaseMount mount = (BaseMount)Mount;

			mount.Rider = null;
			mount.Location = oldLocation;

			TileToDontFall = 3;

			Timer.DelayCall(TimeSpan.FromSeconds(0.3), new TimerStateCallback(Equitation_Callback), mount);

			BeginAction(typeof(BaseMount));
			double seconds = 12.0 - equitation;

			SetMountBlock(BlockMountType.DismountRecovery, TimeSpan.FromSeconds(seconds), false);

			return false;
		}

		private void Equitation_Callback(object state)
		{
			BaseMount mount = (BaseMount)state;

			mount.Animate(5, 5, 1, true, false, 0);
			Animate(22, 5, 1, true, false, 0);

			Damage(Utility.RandomMinMax(10, 20));
		}

		#endregion
		public override int GetMinResistance(ResistanceType type)
		{
			if (type == ResistanceType.Physical)
				return MinPlayerResistance;

			int magicResist = (int)Skills[SkillName.MagicResist].Value;
			int min = (int)(magicResist * 0.2);

			min += Capacites[Capacite.Armure] * 4;

			return Math.Max(MinPlayerResistance, Math.Min(MaxPlayerResistance, min));
		}

		#region Stats

		public bool CanDecreaseStat(StatType stats, int value)
		{
			switch (stats)
			{
				case StatType.Str: return RawStr - value >= 25;
				case StatType.Dex: return RawDex - value >= 25;
				case StatType.Int: return RawInt - value >= 25;
				default: return false;
			}
		}

		public bool CanIncreaseStat(StatType stats, int value)
		{
			if (RawDex + RawStr + RawInt + Attributs.Constitution + Attributs.Sagesse + Attributs.Endurance + value > Attributs.MaxStat)
				return false;

			switch (stats)
			{
				case StatType.Str: return RawStr + value <= 125;
				case StatType.Dex: return RawDex + value <= 125;
				case StatType.Int: return RawInt + value <= 125;
				default: return false;
			}
		}

		public void IncreaseStat(StatType stats, int value)
		{
			if (CanIncreaseStat(stats, value))
			{
				switch (stats)
				{
					case StatType.Str: RawStr += value; break;
					case StatType.Dex: RawDex += value; break;
					case StatType.Int: RawInt += value; break;
				}
			}
		}

		public void DecreaseStat(StatType stats, int value)
		{
			if (CanDecreaseStat(stats, value))
			{
				switch (stats)
				{
					case StatType.Str: RawStr -= value; break;
					case StatType.Dex: RawDex -= value; break;
					case StatType.Int: RawInt -= value; break;
				}
			}
		}
		#endregion

		#region Mort

		public override bool OnBeforeDeath()
		{
			if (Server.Commands.ControlCommand.UncontrolDeath((Mobile)this))
			{
				return base.OnBeforeDeath();
			}
			else
			{
				return false;
			}
			if (m_PossessStorage != null)
			{
				Server.Possess.CopySkills(this, m_Possess);
				Server.Possess.CopyProps(this, m_Possess);
				Server.Possess.MoveItems(this, m_Possess);

				m_Possess.Location = Location;
				m_Possess.Direction = Direction;
				m_Possess.Map = Map;
				m_Possess.Frozen = false;

				Server.Possess.CopySkills(m_PossessStorage, this);
				Server.Possess.CopyProps(m_PossessStorage, this);
				Server.Possess.MoveItems(m_PossessStorage, this);

				m_PossessStorage.Delete();
				m_PossessStorage = null;
				m_Possess.Kill();
				m_Possess = null;
				Hidden = true;
				return false;
			}
		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);

			LastDeathTime = DateTime.Now;

			bool Assomage = false;

			if (!Vulnerability && !DeathShot)
			{
				Frozen = true;
				Assomage = true;
				Timer.DelayCall(TimeSpan.FromMinutes(DeathDuration), new TimerStateCallback(RessuciterOverTime_Callback), this);
			}

			Vulnerability = true;
			EndOfVulnerabilityTime = DateTime.Now + TimeSpan.FromMinutes(DeathDuration + VulnerabilityDuration * (Assomage ? 1 : 5));

			Timer.DelayCall(TimeSpan.FromMinutes(DeathDuration + VulnerabilityDuration * (Assomage ? 1 : 5)), new TimerStateCallback(RemoveVulnerability_Callback), this);

			PreventPvpAttack = true;
			PreventPvpAttackTime = DateTime.Now + TimeSpan.FromMinutes(DeathDuration + PreventPvpAttackDuration);
			Timer.DelayCall(TimeSpan.FromMinutes(DeathDuration + PreventPvpAttackDuration), new TimerStateCallback(RetourCombatPvP_Callback), this);
		}

		public override bool CanHeal()
		{
			if (Vulnerability || MortalStrike.IsWounded(this))
				return false;

			return base.CanHeal();
		}

		public void TrapDamage(int damage, int phys, int fire, int cold, int pois, int nrgy)
		{
			DeathShot = true;

			AOS.Damage(this, damage, phys, fire, cold, pois, nrgy);

			DeathShot = false;
		}

		public override void OnAfterResurrect()
		{
			base.OnAfterResurrect();

			Frozen = false;

			if (Corpse != null)
			{
				ArrayList list = new ArrayList();

				foreach (Item item in Corpse.Items)
				{
					list.Add(item);
				}

				foreach (Item item in list)
				{
					if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
						item.Delete();

					if (item is BaseRaceGumps || (Corpse is Corpse && ((Corpse)Corpse).EquipItems.Contains(item)))
					{
						if (!EquipItem(item))
							AddToBackpack(item);
					}
					else
					{
						AddToBackpack(item);
					}
				}

				Corpse.Delete();
			}

			SendMessage(HueManager.GetHue(HueManagerList.Red), "Vous vous relevez péniblement.", VulnerabilityDuration);
			SendMessage(HueManager.GetHue(HueManagerList.Red), "Vous êtes vulnérable pendant les {0} prochaines minutes.", VulnerabilityDuration);
			SendMessage(HueManager.GetHue(HueManagerList.Red), "Si vous tombez au combat, vous serez envoyé{0} dans le monde des esprits.", Female ? "e" : "");
		}

		private static void RetourCombatPvP_Callback(object state)
		{
			if ((Mobile)state is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)state;

				if (pm.PreventPvpAttack && pm.PreventPvpAttackTime <= DateTime.Now)
				{
					pm.PreventPvpAttack = false;
					pm.SendMessage(HueManager.GetHue(HueManagerList.Green), "Vous pouvez maintenant attaquer d'autres joueurs.");
				}
			}
		}

		private static void RessuciterOverTime_Callback(object state)
		{
			if ((Mobile)state is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)state;

				if (!pm.Alive)
					pm.Resurrect();
			}
		}

		private static void RemoveVulnerability_Callback(object state)
		{
			if ((Mobile)state is CustomPlayerMobile)
			{
				var pm = (CustomPlayerMobile)state;

				if (pm.Vulnerability && pm.EndOfVulnerabilityTime <= DateTime.Now)
				{
					pm.Vulnerability = false;
					pm.SendMessage(HueManager.GetHue(HueManagerList.Green), "Vous n'êtes plus vulnérable. La prochaine fois que vous tomberez au combat, vous serez assomé.");
				}
			}
		}

		public override bool CanBeHarmful(IDamageable damageable, bool message, bool ignoreOurBlessedness, bool ignorePeaceCheck)
		{
			if (PreventPvpAttack && damageable is CustomPlayerMobile)
			{
				SendMessage("Vous ne pouvez pas attaquer un joueur pendant encore {0} minute{1}.", (PreventPvpAttackTime - DateTime.Now).Minutes, (PreventPvpAttackTime - DateTime.Now).Minutes > 1 ? "s" : "");
				return false;
			}

			return base.CanBeHarmful(damageable, message, ignoreOurBlessedness, ignorePeaceCheck);
		}
		#endregion

		public override void OnDelete()
		{
			Reroll(); // Ok, c'est un peu bizard de faire quand on delete le perso, que sa reroll automatique, mais ca facilite la pierre de reroll (fait juste deleter le personnage) et ca diminue aussi l'impacte d'un Rage Quit, puisque si le joueur a deleter son perso, il va automatiquement recevoir l'experience et va pouvoir revenir en rerollant.

			base.OnDelete();
		}

		public void Reroll()
		{
			Accounting.Account accFrom = (Accounting.Account)Account;

			if (accFrom != null && accFrom.AccessLevel == AccessLevel.Player)
				accFrom.AddReroll(new Reroll(this));
		}

		public override bool CheckPackage()
		{
			return Backpack.FindItemByType(typeof(Server.Custom.Packaging.Packages.CustomPackaging)) != null;
		}

		public bool CheckRoux()
		{
			return (HairHue >= 1602 && HairHue < 1655) || (HairHue >= 1502 && HairHue < 1534) || (HairHue >= 1202 && HairHue < 1226);
		}

		public void JailP(Mobile Jailor, TimeSpan Time)
		{
			if (!m_Jail)
			{
				JailLocation = Location;
				JailMap = Map;
				m_Jail = true;
			}

			JailTime = DateTime.Now.Add(Time);		

			if (Jailor != null)
			{
				Say($"Mis en tôle par {Jailor.Name}. Ne passez pas go et ne reclamez pas 200$.");
				JailBy = Jailor;
			}

			switch (Utility.Random(9))
			{
				case 0:
					Location = new Point3D(5276, 1164, 0);
					Map = Map.Trammel;
					break;
				case 1:
					Location = new Point3D(5286, 1164, 0);
					Map = Map.Trammel;
					break;
				case 2:
					Location = new Point3D(5296, 1164, 0);
					Map = Map.Trammel;
					break;
				case 3:
					Location = new Point3D(5306, 1164, 0);
					Map = Map.Trammel;
					break;
				case 4:
					Location = new Point3D(5276, 1174, 0);
					Map = Map.Trammel;
					break;
				case 5:
					Location = new Point3D(5276, 1174, 0);
					Map = Map.Trammel;
					break;
				case 6:
					Location = new Point3D(5286, 1174, 0);
					Map = Map.Trammel;
					break;
				case 7:
					Location = new Point3D(5306, 1174, 0);
					Map = Map.Trammel;
					break;
				case 8:
					Location = new Point3D(5283, 1184, 0);
					Map = Map.Trammel;
					break;
				case 9:
					Location = new Point3D(5304, 1184, 0);
					Map = Map.Trammel;
					break;
				default:
					break;
			}

			if (Time.TotalMinutes <= 60)
				Timer.DelayCall(Time.Add(TimeSpan.FromSeconds(15)), new TimerStateCallback(ReleaseJail_Callback), this);
		}
		private static void ReleaseJail_Callback(object state)
		{
			if ((Mobile)state is CustomPlayerMobile cp)
			{				
				if (cp.Jail)
				{

				}
			}
		}

		public void JailRelease()
		{
			if (m_Jail)
			{
				Say($"Vous venez d'être libéré.");

				Location = JailLocation;
				Map = JailMap;
				JailTime = DateTime.MinValue;
				m_Jail = false;
				JailBy = null;
			}
			
		}
		public static bool IsInEquipe(Mobile source, Mobile target)
		{
			if (target is BaseCreature bc)
			{
				if (bc.ControlMaster == source)
					return true;
				else if (IsInParty(bc.ControlMaster, source))
					return true;
			}
			else if (source is BaseCreature bc2)
			{
				if (bc2.ControlMaster == target)
					return true;
				else if (IsInParty(bc2.ControlMaster, target))
					return true;
			}

			return IsInParty(source, target);
		}

		public static bool IsInParty(Mobile source, Mobile target)
		{
			var party = Engines.PartySystem.Party.Get(source);
			return party != null && party.Contains(target);
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public ExperienceSystem Experience { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Attributs Attributs { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Aptitudes Aptitudes { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public Capacites Capacites { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public PointsAncestraux PointsAncestraux { get; set; }

		public virtual void OnAptitudesChange(Aptitude aptitude, int oldvalue, int newvalue)
		{
			Classes.SetBaseAndCapSkills(this, Experience.Niveau);
			CheckStatTimers();
		}

		public virtual void OnAttributsChange(Attribut attribut, int oldvalue, int newvalue)
		{
			if (attribut == Attribut.Constitution)
				Delta(MobileDelta.Hits);

			if (attribut == Attribut.Endurance)
				Delta(MobileDelta.Mana);
		}

		public override void OnSkillChange(SkillName skill, double oldBase)
		{
			Validate(ValidateType.All);

			if (skill == SkillName.MagicResist)
				UpdateResistances();

			base.OnSkillChange(skill, oldBase);
		}

		public virtual int GetBaseAptitudeValue(Aptitude aptitude)
		{
			return Classes.GetAptitudeValue(m_Classe, aptitude);
		}

		public virtual int GetTotalAptitudeValue(Aptitude aptitude)
		{
			return Aptitudes[aptitude] + GetBaseAptitudeValue(aptitude);
		}

		public enum ValidateType
		{
			Aptitudes,
			Classes,
			Connaissances,
			Skills,
			All
		}

		public virtual void Validate(ValidateType type)
		{
			if (AccessLevel >= AccessLevel.Counselor)
				return;

			if (!CanBeginAction(typeof(ValidateType)))
				return;

			if (Aptitudes == null || Attributs == null/* || m_Capacites == null*/ || Skills == null)
				return;

			BeginAction(typeof(ValidateType));

			if (type == ValidateType.Aptitudes || type == ValidateType.All)
			{
				bool wasValid;
				bool hasChange = false;

				for (int i = 0; i < Aptitudes.m_Values.Length; ++i)
				{
					wasValid = true;
					Aptitude aptitude = (Aptitude)i;

					while (!Aptitudes.IsValid(this, aptitude))
					{
						if (!Aptitudes.CanLower(this, aptitude))
						{
							//Console.WriteLine(String.Format("Bug dans la vérification de l'aptitude [{0}] [{1}]", aptitude.ToString(), this));
							break;
						}
						else
						{
							Aptitudes.SetValue(aptitude, Aptitudes[aptitude] - 1);

							if (wasValid)
								wasValid = false;

							if (!hasChange)
								hasChange = true;
						}
					}

					if (!wasValid)
					{
						OnAptitudesChange(aptitude, Aptitudes[aptitude] + 1, Aptitudes[aptitude]);
						SendMessage(String.Format("Vous n'aviez plus les prérequis pour l'aptitude {0}, sa valeur a donc été diminuée.", aptitude.ToString()));
					}
				}
			}

			if (type == ValidateType.Classes || type == ValidateType.All)
			{
				if (m_Classe != Classe.Aucune)
				{
					bool wasValid = true;

					while (!Classes.IsValid(this, m_Classe))
					{
						//Classes.RemoveAptitudesToClassBefore(this, m_Classe);
						//Classes.RemoveCapacitesToClassBefore(this, m_Classe);

						m_Classe = Classes.GetClassBefore(m_Classe);

						wasValid = false;

						if (m_Classe == Classe.Aucune)
							break;
					}

					if (!wasValid)
						SendMessage("Vous n'aviez plus les prérequis pour votre classe");
				}

				Classes.SetBaseAndCapSkills(this, Experience.Niveau);
			}

			if (type == ValidateType.Skills || type == ValidateType.All)
			{
				for (int i = 0; i < Skills.Length; ++i)
				{
					double cap = this.Skills[i].Cap;

					if (this.Skills[i].Base > cap)
						this.Skills[i].Base = cap;
				}
			}

			EndAction(typeof(ValidateType));
		}

		public bool CheckRevealStealth()
		{
			double stealth = this.Skills[SkillName.Hiding].Base;

			if (stealth >= 100)
				return false;

			double chance = 0.80 * GetBagFilledRatio(this);

			if (chance >= Utility.RandomDouble())
				return true;

			return false;
		}

		#region [Stats]Max
		[CommandProperty(AccessLevel.GameMaster)]
		public override int HitsMax => 30 + Attributs.Constitution + AosAttributes.GetValue(this, AosAttribute.BonusHits) + DevotionSpell.GetValue(this) + FormeElectrisanteSpell.GetValue(this);

		[CommandProperty(AccessLevel.GameMaster)]
		public override int StamMax => 30 + Attributs.Endurance + AosAttributes.GetValue(this, AosAttribute.BonusStam);

		[CommandProperty(AccessLevel.GameMaster)]
		public override int ManaMax => 30 + Attributs.Sagesse + AosAttributes.GetValue(this, AosAttribute.BonusMana) + UraliTranceTonic.GetManaBuff(this);
		#endregion

		public static Hashtable m_SpellTransformation = new Hashtable();
		public static Hashtable m_SpellName = new Hashtable();
		public static Hashtable m_SpellHue = new Hashtable();

		public void OnTransformationChange(int body, string name, int hue, bool spell)
		{
			if (spell)
			{
				if (body == 0 && name == null && hue == -1)
				{
					m_SpellTransformation.Remove(this);
					m_SpellName.Remove(this);
					m_SpellHue.Remove(this);
				}
				else
				{
					m_SpellTransformation[this] = body;
					m_SpellName[this] = name;
					m_SpellHue[this] = hue;
				}
			}

			OnBodyChange(body);
			OnNameChange(name);
			OnHueChange(hue);
		}

		public void OnHueChange(int hue)
		{
			if (hue != -1)
			{
				HueMod = hue;
				return;
			}
			else if (m_SpellTransformation.Contains(this))
			{
				HueMod = (int)m_SpellHue[this];
				return;
			}
			else
			{
				HueMod = -1;
				return;
			}
		}

		public void OnBodyChange(int body)
		{
			if (body != 0)
			{
				BodyMod = body;
				Delta(MobileDelta.Body);
				return;
			}
			else if (m_SpellTransformation.Contains(this))
			{
				BodyMod = (int)m_SpellTransformation[this];
				Delta(MobileDelta.Body);
				return;
			}
			else
			{
				BodyMod = 0;
				Delta(MobileDelta.Body);
				return;
			}
		}

		public void OnNameChange(string name)
		{
			if (name != null)
			{
				NameMod = name;
				InvalidateProperties();
				return;
			}
			else if (m_SpellName.Contains(this))
			{
				NameMod = (string)m_SpellName[this];
				InvalidateProperties();
				return;
			}
			else
			{
				NameMod = null;
				InvalidateProperties();
				return;
			}
		}

		public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

			switch (version)
			{
				case 3:
				case 2:
					{
						PointsAncestraux = new PointsAncestraux(this, reader);
						goto case 1;
					}
				case 1:
					{
						Journaliste = reader.ReadBool();
						goto case 0;
					}
				case 0:
					{
						Experience = new ExperienceSystem(reader);
						Capacites = new Capacites(this, reader);
						Attributs = new Attributs(this, reader); 
						Aptitudes = new Aptitudes(this, reader);
						m_Classe = (Classe)reader.ReadInt();
						JailLocation = reader.ReadPoint3D();
						JailMap =  reader.ReadMap();
						JailTime = reader.ReadDateTime();
						m_Jail =  reader.ReadBool();
						JailBy =  reader.ReadMobile();
						m_Salaire = reader.ReadInt();
						m_LastPay = reader.ReadDateTime();
						m_IdentiteId = reader.ReadInt();
						NameMod = reader.ReadString();
						m_Masque = reader.ReadBool();

						MissiveEnAttente = new List<MissiveContent>();

						int count = reader.ReadInt();

						for (int i = 0; i < count; i++)
							MissiveEnAttente.Add(MissiveContent.Deserialize(reader));

						QuiOptions = (QuiOptions)reader.ReadInt();
						TitleCycle = reader.ReadInt();
						CustomTitle = reader.ReadString();
						m_BaseHue = reader.ReadInt();
						m_BaseRace = Server.BaseRace.GetRace(reader.ReadInt());
						m_BaseFemale = reader.ReadBool();
						ChosenSpellbook = (NewSpellbook)reader.ReadItem();

						if (version < 3)
						{
							count = reader.ReadInt();
							for (int i = 0; i < count; i++)
								/*QuickSpells.Add(*/reader.ReadInt()/*)*/;
						}
						
						m_LastLoginTime = reader.ReadDateTime();
						m_Grandeur = (GrandeurEnum)reader.ReadInt();
						m_Corpulence = (CorpulenceEnum)reader.ReadInt();
						m_Apparence = (AppearanceEnum)reader.ReadInt();
                        break;
                    }
            }

			Hits = HitsMax;
			Stam = StamMax;
			Mana = ManaMax;
		}

		public override void Serialize(GenericWriter writer)
        {        
            base.Serialize(writer);

            writer.Write(3); // version

			//Version 2
			PointsAncestraux.Serialize(writer);

			//Version 1
			writer.Write(Journaliste);

			//Version 0
			Experience.Serialize(writer);
			Capacites.Serialize(writer);
			Attributs.Serialize(writer);
			Aptitudes.Serialize(writer);
			writer.Write((int)m_Classe);
			writer.Write(JailLocation);
			writer.Write(JailMap);
			writer.Write(JailTime);
			writer.Write(m_Jail);
			writer.Write(JailBy);
			writer.Write(m_Salaire);
			writer.Write(m_LastPay);
			writer.Write(m_IdentiteId);
			writer.Write(NameMod);
			writer.Write(m_Masque);
			writer.Write(MissiveEnAttente.Count);

			foreach (MissiveContent item in MissiveEnAttente)
				item.Serialize(writer);

			writer.Write((int)QuiOptions);
			writer.Write(TitleCycle);
			writer.Write(CustomTitle);
			m_BaseHue = Hue;
			writer.Write(Hue);

			if (m_BaseRace == null)
				m_BaseRace = Race;

			m_BaseFemale = Female;

			writer.Write(m_BaseRace.RaceID);
			writer.Write(m_BaseFemale);
			writer.Write(ChosenSpellbook);

			writer.Write(m_LastLoginTime);
			writer.Write((int)m_Grandeur);
			writer.Write((int)m_Corpulence);
			writer.Write((int)m_Apparence);
		}
	}
}
