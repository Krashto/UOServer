using System;
using System.Collections;
using System.Reflection;

namespace Server.Items
{
    public enum CraftResource
    {
        None = 0,
		[Description("Cuivre mat")]
		DullCopper,
		[Description("Fer de l'ombre")]
		ShadowIron,
        //Copper,
		//Bronze,
        //Gold,
		[Description("Agapite")]
        Agapite,
		[Description("Vérite")]
        Verite,
		[Description("Valorite")]
        Valorite,
		//Mytheril,

		[Description("Fer")]
		Iron = 101,
		[Description("Bronze")]
		Bronze,
		[Description("Cuivre")]
		Copper,
		[Description("Sonne")]
		Sonne,
		[Description("Argent")]
		Argent,
		[Description("Boréale")]
		Boreale,
		[Description("Chrysteliar")]
		Chrysteliar,
		[Description("Glacias")]
		Glacias,
		[Description("Lithiar")]
		Lithiar,
		[Description("Acier")]
		Acier,
		[Description("Durian")]
		Durian,
		[Description("Equilibrum")]
		Equilibrum,
		[Description("Or")]
		Gold,
		[Description("Jolinar")]
		Jolinar,
		[Description("Justicium")]
		Justicium,
		[Description("Abyssium")]
		Abyssium,
		[Description("Bloodirium")]
		Bloodirium,
		[Description("Herbrosite")]
		Herbrosite,
		[Description("Khandarium")]
		Khandarium,
		[Description("Mytheril")]
		Mytheril,
		[Description("Sombralir")]
		Sombralir,
		[Description("Draconyr")]
		Draconyr,
		[Description("Heptazion")]
		Heptazion,
		[Description("Oceanis")]
		Oceanis,
		[Description("Brazium")]
		Brazium,
		[Description("Lunerium")]
		Lunerium,
		[Description("Marinar")]
		Marinar,
		[Description("Nostalgium")]
		Nostalgium,

		[Description("Plainois")]
		PlainoisLeather = 201,
		[Description("Forestier")]
		ForestierLeather,
		[Description("Collinois")]
		CollinoisLeather,
		[Description("Désertique")]
		DesertiqueLeather,
		[Description("Savanois")]
		SavanoisLeather,
		[Description("Montagnard")]
		MontagnardLeather,
		[Description("Volcanique")]
		VolcaniqueLeather,
		[Description("Toundrois")]
		ToundroisLeather,
		[Description("Tropicaux")]
		TropicauxLeather,
		[Description("Ancien")]
		AncienLeather,

		RedScales = 301,
        YellowScales,
        BlackScales,
        GreenScales,
        WhiteScales,
        BlueScales,

        RegularWood = 401,
        OakWood,
        AshWood,
        YewWood,
        Heartwood,
        Bloodwood,
        Frostwood,

		[Description("Plainois")]
		PlainoisBone = 501,
		[Description("Forestier")]
		ForestierBone,
		[Description("Désertique")]
		DesertiqueBone,
		[Description("Collinois")]
		CollinoisBone,
		[Description("Savanois")]
		SavanoisBone,
		[Description("Toundrois")]
		ToundroisBone,
		[Description("Tropicaux")]
		TropicauxBone,
		[Description("Montagnard")]
		MontagnardBone,
		[Description("Volcanique")]
		VolcaniqueBone,
		[Description("Ancien")]
		AncienBone,
	}

    public enum CraftResourceType
    {
        None,
        Metal,
        Leather,
        Scales,
        Wood,
		Bone
    }

    public class CraftAttributeInfo
    {
        private int m_WeaponFireDamage;
        private int m_WeaponColdDamage;
        private int m_WeaponPoisonDamage;
        private int m_WeaponEnergyDamage;
        private int m_WeaponChaosDamage;
        private int m_WeaponDirectDamage;
        private int m_WeaponDurability;
        private int m_WeaponLuck;
        private int m_WeaponGoldIncrease;
        private int m_WeaponLowerRequirements;
        private int m_WeaponDamage;
        private int m_WeaponHitChance;
        private int m_WeaponHitLifeLeech;
        private int m_WeaponRegenHits;
        private int m_WeaponSwingSpeed;

        private int m_ArmorPhysicalResist;
        private int m_ArmorFireResist;
        private int m_ArmorColdResist;
        private int m_ArmorPoisonResist;
        private int m_ArmorEnergyResist;
        private int m_ArmorDurability;
        private int m_ArmorLuck;
        private int m_ArmorGoldIncrease;
        private int m_ArmorLowerRequirements;
        private int m_ArmorDamage;
        private int m_ArmorHitChance;
        private int m_ArmorRegenHits;
        private int m_ArmorMage;

        private int m_ShieldPhysicalResist;
        private int m_ShieldFireResist;
        private int m_ShieldColdResist;
        private int m_ShieldPoisonResist;
        private int m_ShieldEnergyResist;
        private int m_ShieldPhysicalRandom;
        private int m_ShieldColdRandom;
        private int m_ShieldSpellChanneling;
        private int m_ShieldLuck;
        private int m_ShieldLowerRequirements;
        private int m_ShieldRegenHits;
        private int m_ShieldBonusDex;
        private int m_ShieldBonusStr;
        private int m_ShieldReflectPhys;
        private int m_SelfRepair;

        private int m_OtherSpellChanneling;
        private int m_OtherLuck;
        private int m_OtherRegenHits;
        private int m_OtherLowerRequirements;

        private int m_RunicMinAttributes;
        private int m_RunicMaxAttributes;
        private int m_RunicMinIntensity;
        private int m_RunicMaxIntensity;

        public int WeaponFireDamage { get { return m_WeaponFireDamage; } set { m_WeaponFireDamage = value; } }
        public int WeaponColdDamage { get { return m_WeaponColdDamage; } set { m_WeaponColdDamage = value; } }
        public int WeaponPoisonDamage { get { return m_WeaponPoisonDamage; } set { m_WeaponPoisonDamage = value; } }
        public int WeaponEnergyDamage { get { return m_WeaponEnergyDamage; } set { m_WeaponEnergyDamage = value; } }
        public int WeaponChaosDamage { get { return m_WeaponChaosDamage; } set { m_WeaponChaosDamage = value; } }
        public int WeaponDirectDamage { get { return m_WeaponDirectDamage; } set { m_WeaponDirectDamage = value; } }
        public int WeaponDurability { get { return m_WeaponDurability; } set { m_WeaponDurability = value; } }
        public int WeaponLuck { get { return m_WeaponLuck; } set { m_WeaponLuck = value; } }
        public int WeaponGoldIncrease { get { return m_WeaponGoldIncrease; } set { m_WeaponGoldIncrease = value; } }
        public int WeaponLowerRequirements { get { return m_WeaponLowerRequirements; } set { m_WeaponLowerRequirements = value; } }
        public int WeaponDamage { get { return m_WeaponDamage; } set { m_WeaponDamage = value; } }
        public int WeaponHitChance { get { return m_WeaponHitChance; } set { m_WeaponHitChance = value; } }
        public int WeaponHitLifeLeech { get { return m_WeaponHitLifeLeech; } set { m_WeaponHitLifeLeech = value; } }
        public int WeaponRegenHits { get { return m_WeaponRegenHits; } set { m_WeaponRegenHits = value; } }
        public int WeaponSwingSpeed { get { return m_WeaponSwingSpeed; } set { m_WeaponSwingSpeed = value; } }

        public int ArmorPhysicalResist { get { return m_ArmorPhysicalResist; } set { m_ArmorPhysicalResist = value; } }
        public int ArmorFireResist { get { return m_ArmorFireResist; } set { m_ArmorFireResist = value; } }
        public int ArmorColdResist { get { return m_ArmorColdResist; } set { m_ArmorColdResist = value; } }
        public int ArmorPoisonResist { get { return m_ArmorPoisonResist; } set { m_ArmorPoisonResist = value; } }
        public int ArmorEnergyResist { get { return m_ArmorEnergyResist; } set { m_ArmorEnergyResist = value; } }
        public int ArmorDurability { get { return m_ArmorDurability; } set { m_ArmorDurability = value; } }
        public int ArmorLuck { get { return m_ArmorLuck; } set { m_ArmorLuck = value; } }
        public int ArmorGoldIncrease { get { return m_ArmorGoldIncrease; } set { m_ArmorGoldIncrease = value; } }
        public int ArmorLowerRequirements { get { return m_ArmorLowerRequirements; } set { m_ArmorLowerRequirements = value; } }
        public int ArmorDamage { get { return m_ArmorDamage; } set { m_ArmorDamage = value; } }
        public int ArmorHitChance { get { return m_ArmorHitChance; } set { m_ArmorHitChance = value; } }
        public int ArmorRegenHits { get { return m_ArmorRegenHits; } set { m_ArmorRegenHits = value; } }
        public int ArmorMage { get { return m_ArmorMage; } set { m_ArmorMage = value; } }

        public int ShieldPhysicalResist { get { return m_ShieldPhysicalResist; } set { m_ShieldPhysicalResist = value; } }
        public int ShieldFireResist { get { return m_ShieldFireResist; } set { m_ShieldFireResist = value; } }
        public int ShieldColdResist { get { return m_ShieldColdResist; } set { m_ShieldColdResist = value; } }
        public int ShieldPoisonResist { get { return m_ShieldPoisonResist; } set { m_ShieldPoisonResist = value; } }
        public int ShieldEnergyResist { get { return m_ShieldEnergyResist; } set { m_ShieldEnergyResist = value; } }
        public int ShieldPhysicalRandom { get { return m_ShieldPhysicalRandom; } set { m_ShieldPhysicalRandom = value; } }
        public int ShieldColdRandom { get { return m_ShieldColdRandom; } set { m_ShieldColdRandom = value; } }
        public int ShieldSpellChanneling { get { return m_ShieldSpellChanneling; } set { m_ShieldSpellChanneling = value; } }
        public int ShieldLuck { get { return m_ShieldLuck; } set { m_ShieldLuck = value; } }
        public int ShieldLowerRequirements { get { return m_ShieldLowerRequirements; } set { m_ShieldLowerRequirements = value; } }
        public int ShieldRegenHits { get { return m_ShieldRegenHits; } set { m_ShieldRegenHits = value; } }
        public int ShieldBonusDex { get { return m_ShieldBonusDex; } set { m_ShieldBonusDex = value; } }
        public int ShieldBonusStr { get { return m_ShieldBonusStr; } set { m_ShieldBonusStr = value; } }
        public int ShieldReflectPhys { get { return m_ShieldReflectPhys; } set { m_ShieldReflectPhys = value; } }
        public int ShieldSelfRepair { get { return m_SelfRepair; } set { m_SelfRepair = value; } }

        public int OtherSpellChanneling { get { return m_OtherSpellChanneling; } set { m_OtherSpellChanneling = value; } }
        public int OtherLuck { get { return m_OtherLuck; } set { m_OtherLuck = value; } }
        public int OtherRegenHits { get { return m_OtherRegenHits; } set { m_OtherRegenHits = value; } }
        public int OtherLowerRequirements { get { return m_OtherLowerRequirements; } set { m_OtherLowerRequirements = value; } }

        public int RunicMinAttributes { get { return m_RunicMinAttributes; } set { m_RunicMinAttributes = value; } }
        public int RunicMaxAttributes { get { return m_RunicMaxAttributes; } set { m_RunicMaxAttributes = value; } }
        public int RunicMinIntensity { get { return m_RunicMinIntensity; } set { m_RunicMinIntensity = value; } }
        public int RunicMaxIntensity { get { return m_RunicMaxIntensity; } set { m_RunicMaxIntensity = value; } }

        public static readonly CraftAttributeInfo Blank;
        public static readonly CraftAttributeInfo DullCopper, ShadowIron, /*Copper, Bronze, Golden, */Agapite, Verite, Valorite/*, Mytheril*/;
		public static readonly CraftAttributeInfo Bronze, Cuivre, Sonne, Argent, Boreale, Chrysteliar, Glacias, Lithiar, Acier, Durian, Equilibrum, Or, Jolinar, Justicium, Abyssium;
		public static readonly CraftAttributeInfo Bloodirium, Herbrosite, Khandarium, Mytheril, Sombralir, Draconyr, Heptazion, Oceanis, Brazium, Lunerium, Marinar, Nostalgium;
		public static readonly CraftAttributeInfo PlainoisLeather, ForestierLeather, DesertiqueLeather, CollinoisLeather, SavanoisLeather, ToundroisLeather, TropicauxLeather, MontagnardLeather, VolcaniqueLeather, AncienLeather;
        public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales;
        public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;
		public static readonly CraftAttributeInfo PlainoisBone, ForestierBone, DesertiqueBone, CollinoisBone, SavanoisBone, ToundroisBone, VolcaniqueBone, TropicauxBone, MontagnardBone, AncienBone;

		static CraftAttributeInfo()
        {
            Blank = new CraftAttributeInfo();

            CraftAttributeInfo dullCopper = DullCopper = new CraftAttributeInfo();

            dullCopper.ArmorPhysicalResist = 0;
            dullCopper.ArmorDurability = 50;
            dullCopper.ArmorLowerRequirements = 20;
            dullCopper.WeaponDurability = 100;
            dullCopper.WeaponLowerRequirements = 50;
            dullCopper.RunicMinAttributes = 1;
            dullCopper.RunicMaxAttributes = 2;

            dullCopper.RunicMinIntensity = 40;
            dullCopper.RunicMaxIntensity = 100;

            CraftAttributeInfo shadowIron = ShadowIron = new CraftAttributeInfo();

            shadowIron.ArmorPhysicalResist = 0;
            shadowIron.ArmorFireResist = 2;
            shadowIron.ArmorEnergyResist = 7;
            shadowIron.ArmorDurability = 100;

            shadowIron.WeaponColdDamage = 20;
            shadowIron.WeaponDurability = 50;

            shadowIron.RunicMinAttributes = 2;
            shadowIron.RunicMaxAttributes = 2;

            shadowIron.RunicMinIntensity = 45;
            shadowIron.RunicMaxIntensity = 100;

            //CraftAttributeInfo copper = Copper = new CraftAttributeInfo();

            //copper.ArmorPhysicalResist = 0;
            //copper.ArmorFireResist = 2;
            //copper.ArmorPoisonResist = 7;
            //copper.ArmorEnergyResist = 2;
            //copper.WeaponPoisonDamage = 10;
            //copper.WeaponEnergyDamage = 20;
            //copper.RunicMinAttributes = 2;
            //copper.RunicMaxAttributes = 3;

            //copper.RunicMinIntensity = 50;
            //copper.RunicMaxIntensity = 100;

            //CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

            //bronze.ArmorPhysicalResist = 0;
            //bronze.ArmorColdResist = 7;
            //bronze.ArmorPoisonResist = 2;
            //bronze.ArmorEnergyResist = 2;
            //bronze.WeaponFireDamage = 40;
            //bronze.RunicMinAttributes = 3;
            //bronze.RunicMaxAttributes = 3;

            //bronze.RunicMinIntensity = 55;
            //bronze.RunicMaxIntensity = 100;

            //CraftAttributeInfo golden = Golden = new CraftAttributeInfo();

            //golden.ArmorPhysicalResist = 0;
            //golden.ArmorFireResist = 2;
            //golden.ArmorColdResist = 2;
            //golden.ArmorEnergyResist = 3;
            //golden.ArmorLuck = 40;
            //golden.ArmorLowerRequirements = 30;
            //golden.WeaponLuck = 40;
            //golden.WeaponLowerRequirements = 50;
            //golden.RunicMinAttributes = 3;
            //golden.RunicMaxAttributes = 4;

            //golden.RunicMinIntensity = 60;
            //golden.RunicMaxIntensity = 100;

            CraftAttributeInfo agapite = Agapite = new CraftAttributeInfo();

            agapite.ArmorPhysicalResist = 1;
            agapite.ArmorFireResist = 7;
            agapite.ArmorColdResist = 2;
            agapite.ArmorPoisonResist = 2;
            agapite.ArmorEnergyResist = 2;
            agapite.WeaponColdDamage = 30;
            agapite.WeaponEnergyDamage = 20;
            agapite.RunicMinAttributes = 4;
            agapite.RunicMaxAttributes = 4;

            agapite.RunicMinIntensity = 65;
            agapite.RunicMaxIntensity = 100;

            CraftAttributeInfo verite = Verite = new CraftAttributeInfo();

            verite.ArmorPhysicalResist = 1;
            verite.ArmorFireResist = 4;
            verite.ArmorColdResist = 3;
            verite.ArmorPoisonResist = 4;
            verite.ArmorEnergyResist = 1;
            verite.WeaponPoisonDamage = 40;
            verite.WeaponEnergyDamage = 20;
            verite.RunicMinAttributes = 4;
            verite.RunicMaxAttributes = 5;

            verite.RunicMinIntensity = 70;
            verite.RunicMaxIntensity = 100;

			CraftAttributeInfo valorite = Valorite = new CraftAttributeInfo();

            valorite.ArmorPhysicalResist = 1;
            valorite.ArmorColdResist = 4;
            valorite.ArmorPoisonResist = 4;
            valorite.ArmorEnergyResist = 4;
            valorite.ArmorDurability = 50;
            valorite.WeaponFireDamage = 10;
            valorite.WeaponColdDamage = 20;
            valorite.WeaponPoisonDamage = 10;
            valorite.WeaponEnergyDamage = 20;
            valorite.RunicMinAttributes = 5;
            valorite.RunicMaxAttributes = 5;

            valorite.RunicMinIntensity = 85;
            valorite.RunicMaxIntensity = 100;

			//CraftAttributeInfo mytheril = Mytheril = new CraftAttributeInfo();

			//mytheril.ArmorPhysicalResist = 1;
			//mytheril.ArmorFireResist = 5;
			//mytheril.ArmorColdResist = 2;
			//mytheril.ArmorPoisonResist = 2;
			//mytheril.ArmorEnergyResist = 3;
			//mytheril.WeaponFireDamage = 20;
			//mytheril.WeaponPoisonDamage = 20;
			//mytheril.WeaponEnergyDamage = 20;
			//mytheril.RunicMinAttributes = 4;
			//mytheril.RunicMaxAttributes = 5;

			//mytheril.RunicMinIntensity = 70;
			//mytheril.RunicMaxIntensity = 100;


			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

			bronze.ArmorPhysicalResist = 1;
			bronze.ArmorColdResist = 1;
			bronze.ArmorPoisonResist = 1;

			CraftAttributeInfo cuivre = Cuivre = new CraftAttributeInfo();

			cuivre.ArmorPhysicalResist = 1;
			cuivre.ArmorFireResist = 1;
			cuivre.ArmorEnergyResist = 1;

			CraftAttributeInfo sonne = Sonne = new CraftAttributeInfo();

			sonne.ArmorPhysicalResist = 2;
			sonne.ArmorFireResist = 2;
			sonne.ArmorPoisonResist = 2;

			CraftAttributeInfo argent = Argent = new CraftAttributeInfo();

			argent.ArmorPhysicalResist = 2;
			argent.ArmorFireResist = 2;
			argent.ArmorEnergyResist = 2;

			CraftAttributeInfo boreale = Boreale = new CraftAttributeInfo();

			boreale.ArmorPhysicalResist = 2;
			boreale.ArmorFireResist = 2;
			boreale.ArmorColdResist = 2;

			CraftAttributeInfo chrysteliar = Chrysteliar = new CraftAttributeInfo();

			chrysteliar.ArmorPhysicalResist = 2;
			chrysteliar.ArmorColdResist = 2;
			chrysteliar.ArmorPoisonResist = 2;

			CraftAttributeInfo glacias = Glacias = new CraftAttributeInfo();

			glacias.ArmorPhysicalResist = 2;
			glacias.ArmorColdResist = 2;
			glacias.ArmorEnergyResist = 2;

			CraftAttributeInfo lithiar = Lithiar = new CraftAttributeInfo();

			lithiar.ArmorPhysicalResist = 2;
			lithiar.ArmorPoisonResist = 2;
			lithiar.ArmorEnergyResist = 2;

			CraftAttributeInfo acier = Acier = new CraftAttributeInfo();

			acier.ArmorPhysicalResist = 3;
			acier.ArmorFireResist = 3;
			acier.ArmorPoisonResist = 3;

			CraftAttributeInfo durian = Durian = new CraftAttributeInfo();

			durian.ArmorPhysicalResist = 3;
			durian.ArmorFireResist = 3;
			durian.ArmorPoisonResist = 3;

			CraftAttributeInfo equilibrum = Equilibrum = new CraftAttributeInfo();

			equilibrum.ArmorPhysicalResist = 3;
			equilibrum.ArmorFireResist = 3;
			equilibrum.ArmorColdResist = 3;

			CraftAttributeInfo or = Or = new CraftAttributeInfo();

			or.ArmorPhysicalResist = 3;
			or.ArmorColdResist = 3;
			or.ArmorPoisonResist = 3;

			CraftAttributeInfo jolinar = Jolinar = new CraftAttributeInfo();

			jolinar.ArmorPhysicalResist = 3;
			jolinar.ArmorColdResist = 3;
			jolinar.ArmorEnergyResist = 3;

			CraftAttributeInfo justicium = Justicium = new CraftAttributeInfo();

			justicium.ArmorPhysicalResist = 3;
			justicium.ArmorPoisonResist = 3;
			justicium.ArmorEnergyResist = 3;

			CraftAttributeInfo abyssium = Abyssium = new CraftAttributeInfo();

			abyssium.ArmorPhysicalResist = 4;
			abyssium.ArmorFireResist = 4;
			abyssium.ArmorPoisonResist = 4;

			CraftAttributeInfo bloodirium = Bloodirium = new CraftAttributeInfo();

			bloodirium.ArmorPhysicalResist = 4;
			bloodirium.ArmorFireResist = 4;
			bloodirium.ArmorEnergyResist = 4;

			CraftAttributeInfo herbrosite = Herbrosite = new CraftAttributeInfo();

			herbrosite.ArmorPhysicalResist = 4;
			herbrosite.ArmorFireResist = 4;
			herbrosite.ArmorColdResist = 4;

			CraftAttributeInfo khandarium = Khandarium = new CraftAttributeInfo();

			khandarium.ArmorPhysicalResist = 4;
			khandarium.ArmorColdResist = 4;
			khandarium.ArmorPoisonResist = 4;

			CraftAttributeInfo mytheril = Mytheril = new CraftAttributeInfo();

			mytheril.ArmorPhysicalResist = 4;
			mytheril.ArmorColdResist = 4;
			mytheril.ArmorEnergyResist = 4;

			CraftAttributeInfo sombralir = Sombralir = new CraftAttributeInfo();

			sombralir.ArmorPhysicalResist = 4;
			sombralir.ArmorPoisonResist = 4;
			sombralir.ArmorEnergyResist = 4;

			CraftAttributeInfo draconyr = Draconyr = new CraftAttributeInfo();

			draconyr.ArmorPhysicalResist = 5;
			draconyr.ArmorFireResist = 5;
			draconyr.ArmorPoisonResist = 5;

			CraftAttributeInfo heptazion = Heptazion = new CraftAttributeInfo();

			heptazion.ArmorPhysicalResist = 5;
			heptazion.ArmorFireResist = 5;
			heptazion.ArmorEnergyResist = 5;

			CraftAttributeInfo oceanis = Oceanis = new CraftAttributeInfo();

			oceanis.ArmorPhysicalResist = 5;
			oceanis.ArmorFireResist = 5;
			oceanis.ArmorColdResist = 5;

			CraftAttributeInfo brazium = Brazium = new CraftAttributeInfo();

			brazium.ArmorPhysicalResist = 5;
			brazium.ArmorColdResist = 5;
			brazium.ArmorPoisonResist = 5;

			CraftAttributeInfo lunerium = Lunerium = new CraftAttributeInfo();

			lunerium.ArmorPhysicalResist = 5;
			lunerium.ArmorColdResist = 5;
			lunerium.ArmorEnergyResist = 5;

			CraftAttributeInfo marinar = Marinar = new CraftAttributeInfo();

			marinar.ArmorPhysicalResist = 5;
			marinar.ArmorPoisonResist = 5;
			marinar.ArmorEnergyResist = 5;

			CraftAttributeInfo nostalgium = Nostalgium = new CraftAttributeInfo();

			nostalgium.ArmorPhysicalResist = 5;
			nostalgium.ArmorPoisonResist = 5;
			nostalgium.ArmorEnergyResist = 5;

			// Cuir

			CraftAttributeInfo plainoisLeather = PlainoisLeather = new CraftAttributeInfo();

			plainoisLeather.ArmorPhysicalResist = 1;

			CraftAttributeInfo forestierLeather = ForestierLeather = new CraftAttributeInfo();

			forestierLeather.ArmorPhysicalResist = 2;
			forestierLeather.ArmorPoisonResist = 2;
			forestierLeather.ArmorColdResist = 2;

			CraftAttributeInfo collinoisLeather = CollinoisLeather = new CraftAttributeInfo();

			collinoisLeather.ArmorPhysicalResist = 2;
			collinoisLeather.ArmorColdResist = 2;
			collinoisLeather.ArmorEnergyResist = 2;

			CraftAttributeInfo desertiqueLeather = DesertiqueLeather = new CraftAttributeInfo();

			desertiqueLeather.ArmorPhysicalResist = 3;
			desertiqueLeather.ArmorFireResist = 3;
			desertiqueLeather.ArmorPoisonResist = 3;

			CraftAttributeInfo savanoisLeather = SavanoisLeather = new CraftAttributeInfo();

			savanoisLeather.ArmorPhysicalResist = 3;
			savanoisLeather.ArmorFireResist = 3;
			savanoisLeather.ArmorEnergyResist = 3;

			CraftAttributeInfo toundroisLeather = ToundroisLeather = new CraftAttributeInfo();

			toundroisLeather.ArmorPhysicalResist = 4;
			toundroisLeather.ArmorPoisonResist = 4;
			toundroisLeather.ArmorColdResist = 4;

			CraftAttributeInfo tropicauxLeather = TropicauxLeather = new CraftAttributeInfo();

			tropicauxLeather.ArmorPhysicalResist = 4;
			tropicauxLeather.ArmorFireResist = 4;
			tropicauxLeather.ArmorEnergyResist = 4;

			CraftAttributeInfo montagnardLeather = MontagnardLeather = new CraftAttributeInfo();

			montagnardLeather.ArmorPhysicalResist = 5;
			montagnardLeather.ArmorColdResist = 5;
			montagnardLeather.ArmorPoisonResist = 5;

			CraftAttributeInfo volcaniqueLeather = VolcaniqueLeather = new CraftAttributeInfo();

			volcaniqueLeather.ArmorPhysicalResist = 5;
			volcaniqueLeather.ArmorFireResist = 5;
			volcaniqueLeather.ArmorEnergyResist = 5;

			CraftAttributeInfo ancienLeather = AncienLeather = new CraftAttributeInfo();

			ancienLeather.ArmorPhysicalResist = 6;
			ancienLeather.ArmorFireResist = 6;
			ancienLeather.ArmorColdResist = 6;
			ancienLeather.ArmorPoisonResist = 6;
			ancienLeather.ArmorEnergyResist = 6;

			// Os
			CraftAttributeInfo plainoisBone = PlainoisBone = new CraftAttributeInfo();

			plainoisBone.ArmorPhysicalResist = 1;

			CraftAttributeInfo forestierBone = ForestierBone = new CraftAttributeInfo();

			forestierBone.ArmorPhysicalResist = 2;
			forestierBone.ArmorPoisonResist = 2;
			forestierBone.ArmorColdResist = 2;

			CraftAttributeInfo collinoisBone = CollinoisBone = new CraftAttributeInfo();

			collinoisBone.ArmorPhysicalResist = 2;
			collinoisBone.ArmorColdResist = 2;
			collinoisBone.ArmorEnergyResist = 2;

			CraftAttributeInfo desertiqueBone = DesertiqueBone = new CraftAttributeInfo();

			desertiqueBone.ArmorPhysicalResist = 3;
			desertiqueBone.ArmorFireResist = 3;
			desertiqueBone.ArmorPoisonResist = 3;

			CraftAttributeInfo savanoisBone = SavanoisBone = new CraftAttributeInfo();

			savanoisBone.ArmorPhysicalResist = 3;
			savanoisBone.ArmorFireResist = 3;
			savanoisBone.ArmorEnergyResist = 3;

			CraftAttributeInfo toundroisBone = ToundroisBone = new CraftAttributeInfo();

			toundroisBone.ArmorPhysicalResist = 4;
			toundroisBone.ArmorPoisonResist = 4;
			toundroisBone.ArmorColdResist = 4;

			CraftAttributeInfo tropicauxBone = TropicauxBone = new CraftAttributeInfo();

			tropicauxBone.ArmorPhysicalResist = 4;
			tropicauxBone.ArmorFireResist = 4;
			tropicauxBone.ArmorEnergyResist = 4;

			CraftAttributeInfo montagnardBone = MontagnardBone = new CraftAttributeInfo();

			montagnardBone.ArmorPhysicalResist = 5;
			montagnardBone.ArmorColdResist = 5;
			montagnardBone.ArmorPoisonResist = 5;

			CraftAttributeInfo volcaniqueBone = VolcaniqueBone = new CraftAttributeInfo();

			volcaniqueBone.ArmorPhysicalResist = 5;
			volcaniqueBone.ArmorFireResist = 5;
			volcaniqueBone.ArmorEnergyResist = 5;

			CraftAttributeInfo ancienBone = AncienBone = new CraftAttributeInfo();

			ancienBone.ArmorPhysicalResist = 6;
			ancienBone.ArmorFireResist = 6;
			ancienBone.ArmorColdResist = 6;
			ancienBone.ArmorPoisonResist = 6;
			ancienBone.ArmorEnergyResist = 6;


			CraftAttributeInfo red = RedScales = new CraftAttributeInfo();
            red.ArmorPhysicalResist = 1;
            red.ArmorFireResist = 11;
            red.ArmorColdResist = -3;
            red.ArmorPoisonResist = 1;
            red.ArmorEnergyResist = 1;

            CraftAttributeInfo yellow = YellowScales = new CraftAttributeInfo();

            yellow.ArmorPhysicalResist = -3;
            yellow.ArmorFireResist = 1;
            yellow.ArmorColdResist = 1;
            yellow.ArmorPoisonResist = 1;
            yellow.ArmorPoisonResist = 1;
            yellow.ArmorLuck = 20;

            CraftAttributeInfo black = BlackScales = new CraftAttributeInfo();

            black.ArmorPhysicalResist = 11;
            black.ArmorEnergyResist = -3;
            black.ArmorFireResist = 1;
            black.ArmorPoisonResist = 1;
            black.ArmorColdResist = 1;

            CraftAttributeInfo green = GreenScales = new CraftAttributeInfo();

            green.ArmorFireResist = -3;
            green.ArmorPhysicalResist = 1;
            green.ArmorColdResist = 1;
            green.ArmorEnergyResist = 1;
            green.ArmorPoisonResist = 11;

            CraftAttributeInfo white = WhiteScales = new CraftAttributeInfo();

            white.ArmorPhysicalResist = -3;
            white.ArmorFireResist = 1;
            white.ArmorEnergyResist = 1;
            white.ArmorPoisonResist = 1;
            white.ArmorColdResist = 11;

            CraftAttributeInfo blue = BlueScales = new CraftAttributeInfo();

            blue.ArmorPhysicalResist = 1;
            blue.ArmorFireResist = 1;
            blue.ArmorColdResist = 1;
            blue.ArmorPoisonResist = -3;
            blue.ArmorEnergyResist = 11;

            #region Mondain's Legacy
            CraftAttributeInfo oak = OakWood = new CraftAttributeInfo();

            oak.ArmorPhysicalResist = 3;
            oak.ArmorFireResist = 3;
            oak.ArmorPoisonResist = 2;
            oak.ArmorEnergyResist = 3;
            oak.ArmorLuck = 40;

            oak.ShieldPhysicalResist = 1;
            oak.ShieldFireResist = 1;
            oak.ShieldColdResist = 1;
            oak.ShieldPoisonResist = 1;
            oak.ShieldEnergyResist = 1;

            oak.WeaponLuck = 40;
            oak.WeaponDamage = 5;

            oak.RunicMinAttributes = 1;
            oak.RunicMaxAttributes = 2;
            oak.RunicMinIntensity = 1;
            oak.RunicMaxIntensity = 50;

            CraftAttributeInfo ash = AshWood = new CraftAttributeInfo();

            ash.ArmorPhysicalResist = 2;
            ash.ArmorColdResist = 4;
            ash.ArmorPoisonResist = 1;
            ash.ArmorEnergyResist = 6;
            ash.ArmorLowerRequirements = 20;

            ash.ShieldEnergyResist = 3;
            ash.ShieldLowerRequirements = 3;

            ash.WeaponSwingSpeed = 10;
            ash.WeaponLowerRequirements = 20;

            ash.OtherLowerRequirements = 20;

            ash.RunicMinAttributes = 2;
            ash.RunicMaxAttributes = 3;
            ash.RunicMinIntensity = 35;
            ash.RunicMaxIntensity = 75;

            CraftAttributeInfo yew = YewWood = new CraftAttributeInfo();

            yew.ArmorPhysicalResist = 6;
            yew.ArmorFireResist = 3;
            yew.ArmorColdResist = 3;
            yew.ArmorEnergyResist = 3;
            yew.ArmorRegenHits = 1;

            yew.ShieldPhysicalResist = 3;
            yew.ShieldRegenHits = 1;

            yew.WeaponHitChance = 5;
            yew.WeaponDamage = 10;

            yew.OtherRegenHits = 2;

            yew.RunicMinAttributes = 3;
            yew.RunicMaxAttributes = 3;
            yew.RunicMinIntensity = 40;
            yew.RunicMaxIntensity = 90;

            CraftAttributeInfo heartwood = Heartwood = new CraftAttributeInfo();

            heartwood.ArmorPhysicalResist = 2;
            heartwood.ArmorFireResist = 3;
            heartwood.ArmorColdResist = 2;
            heartwood.ArmorPoisonResist = 7;
            heartwood.ArmorEnergyResist = 2;

            // one of below
            heartwood.ArmorDamage = 10;
            heartwood.ArmorHitChance = 5;
            heartwood.ArmorLuck = 40;
            heartwood.ArmorLowerRequirements = 20;
            heartwood.ArmorMage = 1;

            // one of below
            heartwood.WeaponDamage = 10;
            heartwood.WeaponHitChance = 5;
            heartwood.WeaponHitLifeLeech = 13;
            heartwood.WeaponLuck = 40;
            heartwood.WeaponLowerRequirements = 20;
            heartwood.WeaponSwingSpeed = 10;

            heartwood.ShieldBonusDex = 2;
            heartwood.ShieldBonusStr = 2;
            heartwood.ShieldPhysicalRandom = 5;
            heartwood.ShieldReflectPhys = 5;
            heartwood.ShieldSelfRepair = 2;
            heartwood.ShieldColdRandom = 3;
            heartwood.ShieldSpellChanneling = 1;

            heartwood.RunicMinAttributes = 4;
            heartwood.RunicMaxAttributes = 4;
            heartwood.RunicMinIntensity = 50;
            heartwood.RunicMaxIntensity = 100;

            CraftAttributeInfo bloodwood = Bloodwood = new CraftAttributeInfo();

            bloodwood.ArmorPhysicalResist = 3;
            bloodwood.ArmorFireResist = 8;
            bloodwood.ArmorColdResist = 1;
            bloodwood.ArmorPoisonResist = 3;
            bloodwood.ArmorEnergyResist = 3;
            bloodwood.ArmorRegenHits = 2;

            bloodwood.ShieldFireResist = 3;
            bloodwood.ShieldLuck = 40;
            bloodwood.ShieldRegenHits = 2;

            bloodwood.WeaponRegenHits = 2;
            bloodwood.WeaponHitLifeLeech = 16;

            bloodwood.OtherLuck = 20;
            bloodwood.OtherRegenHits = 2;

            CraftAttributeInfo frostwood = Frostwood = new CraftAttributeInfo();

            frostwood.ArmorPhysicalResist = 2;
            frostwood.ArmorFireResist = 1;
            frostwood.ArmorColdResist = 8;
            frostwood.ArmorPoisonResist = 3;
            frostwood.ArmorEnergyResist = 4;

            frostwood.ShieldColdResist = 3;
            frostwood.ShieldSpellChanneling = 1;

            frostwood.WeaponColdDamage = 40;
            frostwood.WeaponDamage = 12;

            frostwood.OtherSpellChanneling = 1;
            #endregion
        }
    }

    public class CraftResourceInfo
    {
        public int Hue { get; set; }
        public int Number { get; set; }
		public string Name { get; set; }
        public int Level { get; set; }
		public CraftAttributeInfo AttributeInfo { get; set; }
		public CraftResource Resource { get; set; }
		public Type[] ResourceTypes { get; set; }

		public CraftResourceInfo(int hue, int number, string name, int level, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes)
        {
            Hue = hue;
            Number = number;
            Name = name;
			Level = level;
            AttributeInfo = attributeInfo;
            Resource = resource;
            ResourceTypes = resourceTypes;

            for (int i = 0; i < resourceTypes.Length; ++i)
                CraftResources.RegisterType(resourceTypes[i], resource);
        }
    }

    public class CraftResources
    {
        private static readonly CraftResourceInfo[] m_MetalInfo = new[]
        {
            new CraftResourceInfo( 0,		0, "Iron",			1, CraftAttributeInfo.Blank,		CraftResource.Iron,			typeof( IronIngot ),		typeof( IronOre ) ),
			new CraftResourceInfo( 1122,	0, "Bronze",		1, CraftAttributeInfo.Bronze,		CraftResource.Bronze,		typeof( BronzeIngot ),		typeof( BronzeOre ) ),
			new CraftResourceInfo( 1134,	0, "Cuivre",		1, CraftAttributeInfo.Cuivre,		CraftResource.Copper,       typeof( CopperIngot ),      typeof( CopperOre ) ),
			new CraftResourceInfo( 1124,	0, "Sonne",			2, CraftAttributeInfo.Sonne,		CraftResource.Sonne,        typeof( SonneIngot ),       typeof( SonneOre ) ),
			new CraftResourceInfo( 2500,	0, "Argent",		2, CraftAttributeInfo.Argent,		CraftResource.Argent,       typeof( ArgentIngot ),      typeof( ArgentOre ) ),
			new CraftResourceInfo( 1767,	0, "Boréale",		2, CraftAttributeInfo.Boreale,		CraftResource.Boreale,      typeof( BorealeIngot ),     typeof( BorealeOre ) ),
			new CraftResourceInfo( 1759,	0, "Chrysteliar",	2, CraftAttributeInfo.Chrysteliar,  CraftResource.Chrysteliar,  typeof( ChrysteliarIngot ), typeof( ChrysteliarOre ) ),
			new CraftResourceInfo( 1365,	0, "Glacias",		2, CraftAttributeInfo.Glacias,		CraftResource.Glacias,      typeof( GlaciasIngot ),     typeof( GlaciasOre ) ),
			new CraftResourceInfo( 1448,	0, "Lithiar",		2, CraftAttributeInfo.Lithiar,		CraftResource.Lithiar,      typeof( LithiarIngot ),     typeof( LithiarOre ) ),
			new CraftResourceInfo( 1102,	0, "Acier",			3, CraftAttributeInfo.Acier,		CraftResource.Acier,        typeof( AcierIngot ),       typeof( AcierOre ) ),
			new CraftResourceInfo( 1160,	0, "Durian",		3, CraftAttributeInfo.Durian,		CraftResource.Durian,       typeof( DurianIngot ),      typeof( DurianOre ) ),
			new CraftResourceInfo( 2212,	0, "Equilibrum",	3, CraftAttributeInfo.Equilibrum,   CraftResource.Equilibrum,   typeof( EquilibrumIngot ),  typeof( EquilibrumOre ) ),
			new CraftResourceInfo( 2125,	0, "Or",			3, CraftAttributeInfo.Or,			CraftResource.Gold,			typeof( GoldIngot ),		typeof( GoldOre ) ),
			new CraftResourceInfo( 2205,	0, "Jolinar",		3, CraftAttributeInfo.Jolinar,		CraftResource.Jolinar,      typeof( JolinarIngot ),     typeof( JolinarOre ) ),
			new CraftResourceInfo( 2219,	0, "Justicium",		3, CraftAttributeInfo.Justicium,    CraftResource.Justicium,    typeof( JusticiumIngot ),   typeof( JusticiumOre ) ),
			new CraftResourceInfo( 1149,	0, "Abyssium",		4, CraftAttributeInfo.Abyssium,		CraftResource.Abyssium,     typeof( AbyssiumIngot ),    typeof( AbyssiumOre ) ),
			new CraftResourceInfo( 1777,	0, "Bloodirium",	4, CraftAttributeInfo.Bloodirium,	CraftResource.Bloodirium,   typeof( BloodiriumIngot ),  typeof( BloodiriumOre ) ),
			new CraftResourceInfo( 1445,	0, "Herbrosite",	4, CraftAttributeInfo.Herbrosite,	CraftResource.Herbrosite,   typeof( HerbrositeIngot ),  typeof( HerbrositeOre ) ),
			new CraftResourceInfo( 1746,	0, "Khandarium",	4, CraftAttributeInfo.Khandarium,	CraftResource.Khandarium,   typeof( KhandariumIngot ),  typeof( KhandariumOre ) ),
			new CraftResourceInfo( 1757,	0, "Mytheril",		4, CraftAttributeInfo.Mytheril,		CraftResource.Mytheril,		typeof( MytherilIngot ),	typeof( MytherilOre ) ),
			new CraftResourceInfo( 2051,	0, "Sombralir",		4, CraftAttributeInfo.Sombralir,	CraftResource.Sombralir,	typeof( SombralirIngot ),   typeof( SombralirOre ) ),
			new CraftResourceInfo( 2591,	0, "Draconyr",		5, CraftAttributeInfo.Draconyr,		CraftResource.Draconyr,		typeof( DraconyrIngot ),    typeof( DraconyrOre ) ),
			new CraftResourceInfo( 2130,	0, "Heptazion",		5, CraftAttributeInfo.Heptazion,    CraftResource.Heptazion,	typeof( HeptazionIngot ),   typeof( HeptazionOre ) ),
			new CraftResourceInfo( 1770,	0, "Oceanis",		5, CraftAttributeInfo.Oceanis,		CraftResource.Oceanis,		typeof( OceanisIngot ),     typeof( OceanisOre ) ),
			new CraftResourceInfo( 1509,	0, "Brazium",		5, CraftAttributeInfo.Brazium,		CraftResource.Brazium,		typeof( BraziumIngot ),     typeof( BraziumOre ) ),
			new CraftResourceInfo( 2656,	0, "Lunerium",		5, CraftAttributeInfo.Lunerium,		CraftResource.Lunerium,		typeof( LuneriumIngot ),    typeof( LuneriumOre ) ),
			new CraftResourceInfo( 1411,	0, "Marinar",		5, CraftAttributeInfo.Marinar,		CraftResource.Marinar,		typeof( MarinarIngot ),     typeof( MarinarOre ) ),
			new CraftResourceInfo( 1755,	0, "Nostalgium",	6, CraftAttributeInfo.Nostalgium,	CraftResource.Nostalgium,   typeof( NostalgiumIngot ),  typeof( NostalgiumOre ) ),

			new CraftResourceInfo(0x973, 1053108, "Dull Copper",    1, CraftAttributeInfo.DullCopper,	CraftResource.DullCopper, typeof(DullCopperIngot),  typeof(DullCopperOre),  typeof(DullCopperGranite)),
			new CraftResourceInfo(0x966, 1053107, "Shadow Iron",    1, CraftAttributeInfo.ShadowIron,	CraftResource.ShadowIron, typeof(ShadowIronIngot),  typeof(ShadowIronOre),  typeof(ShadowIronGranite)),
			new CraftResourceInfo(1980,  1053103, "Agapite",        1, CraftAttributeInfo.Agapite,		CraftResource.Agapite, typeof(AgapiteIngot), typeof(AgapiteOre), typeof(AgapiteGranite)),
			new CraftResourceInfo(2841,  1053102, "Verite",         1, CraftAttributeInfo.Verite,		CraftResource.Verite, typeof(VeriteIngot), typeof(VeriteOre), typeof(VeriteGranite)),
			new CraftResourceInfo(2867,  1053101, "Valorite",       1, CraftAttributeInfo.Valorite,		CraftResource.Valorite, typeof(ValoriteIngot),  typeof(ValoriteOre), typeof(ValoriteGranite)),
		};

        private static readonly CraftResourceInfo[] m_ScaleInfo = new[]
        {
            new CraftResourceInfo(0x66D, 1053129, "Red Scales",		1, CraftAttributeInfo.RedScales, CraftResource.RedScales, typeof(RedScales)),
            new CraftResourceInfo(0x8A8, 1053130, "Yellow Scales",  2, CraftAttributeInfo.YellowScales,    CraftResource.YellowScales, typeof(YellowScales)),
            new CraftResourceInfo(0x455, 1053131, "Black Scales",   3, CraftAttributeInfo.BlackScales, CraftResource.BlackScales, typeof(BlackScales)),
            new CraftResourceInfo(0x851, 1053132, "Green Scales",   4, CraftAttributeInfo.GreenScales, CraftResource.GreenScales, typeof(GreenScales)),
            new CraftResourceInfo(0x8FD, 1053133, "White Scales",   5, CraftAttributeInfo.WhiteScales, CraftResource.WhiteScales, typeof(WhiteScales)),
            new CraftResourceInfo(0x8B0, 1053134, "Blue Scales",    6, CraftAttributeInfo.BlueScales, CraftResource.BlueScales, typeof(BlueScales)),
        };

        private static readonly CraftResourceInfo[] m_AOSLeatherInfo = new[]
        {
            new CraftResourceInfo(0x00, 1049353, "Plainois",	1, CraftAttributeInfo.Blank,				CraftResource.PlainoisLeather,		typeof( PlainoisLeather ),		typeof( PlainoisHides ) ),
			new CraftResourceInfo(1106, 1049356, "Forestier",	2, CraftAttributeInfo.ForestierLeather,     CraftResource.ForestierLeather,     typeof( ForestierLeather ),     typeof( ForestierHides ) ),
			new CraftResourceInfo(1711, 1049356, "Collinois",	2, CraftAttributeInfo.CollinoisLeather,		CraftResource.CollinoisLeather,     typeof( CollinoisLeather ),		typeof( CollinoisHides ) ),
			new CraftResourceInfo(1438, 1049354, "Désertique",	3, CraftAttributeInfo.DesertiqueLeather,	CraftResource.DesertiqueLeather,	typeof( DesertiqueLeather ),	typeof( DesertiqueHides ) ),
			new CraftResourceInfo(1635, 1049356, "Savanois",	3, CraftAttributeInfo.SavanoisLeather,		CraftResource.SavanoisLeather,		typeof( SavanoisLeather ),		typeof( SavanoisHides ) ),
			new CraftResourceInfo(2118, 1049356, "Montagnard",	4, CraftAttributeInfo.MontagnardLeather,	CraftResource.MontagnardLeather,	typeof( MontagnardLeather ),	typeof( MontagnardHides ) ),
			new CraftResourceInfo(2128, 1049356, "Volcanique",	4, CraftAttributeInfo.VolcaniqueLeather,	CraftResource.VolcaniqueLeather,	typeof( ToundroisLeather ),		typeof( ToundroisHides ) ),
			new CraftResourceInfo(2128, 1049356, "Toundrois",	5, CraftAttributeInfo.ToundroisLeather,     CraftResource.ToundroisLeather,		typeof( VolcaniqueLeather ),	typeof( VolcaniqueHides ) ),
			new CraftResourceInfo(2174, 1049356, "Tropicaux",	5, CraftAttributeInfo.TropicauxLeather,		CraftResource.TropicauxLeather,		typeof( TropicauxLeather ),		typeof( TropicauxHides ) ),
			new CraftResourceInfo(1940, 1049356, "Ancien",		6, CraftAttributeInfo.AncienLeather,		CraftResource.AncienLeather,		typeof( AncienLeather ),		typeof( AncienHides ) ),


		};

		private static readonly CraftResourceInfo[] m_BoneInfo = new[]
	   {
			new CraftResourceInfo(0x00, 1049353, "Plainois",	1, CraftAttributeInfo.Blank,			CraftResource.PlainoisBone,		typeof( PlainoisBone ) ),
			new CraftResourceInfo(1106, 1049356, "Forestier",	2, CraftAttributeInfo.ForestierBone,    CraftResource.ForestierBone,    typeof( LupusBone ) ),
			new CraftResourceInfo(1711, 1049356, "Collinois",	2, CraftAttributeInfo.CollinoisBone,	CraftResource.CollinoisBone,    typeof( CollinoisBone ) ),
			new CraftResourceInfo(1438, 1049354, "Désertique",	3, CraftAttributeInfo.DesertiqueBone,	CraftResource.DesertiqueBone,	typeof( DesertiqueBone ) ),
			new CraftResourceInfo(2118, 1049356, "Savanois",	3, CraftAttributeInfo.MontagnardBone,	CraftResource.MontagnardBone,	typeof( MontagnardBone ) ),
			new CraftResourceInfo(1635, 1049356, "Montagnard",	4, CraftAttributeInfo.SavanoisBone,		CraftResource.SavanoisBone,		typeof( SavanoisBone ) ),
			new CraftResourceInfo(1635, 1049356, "Volcanique",	4, CraftAttributeInfo.VolcaniqueBone,	CraftResource.VolcaniqueBone,	typeof( VolcaniqueBone ) ),
			new CraftResourceInfo(2128, 1049356, "Toundrois",	5, CraftAttributeInfo.ToundroisBone,	CraftResource.ToundroisBone,	typeof( ToundroisBone ) ),
			new CraftResourceInfo(2174, 1049356, "Tropicaux",	5, CraftAttributeInfo.TropicauxBone,	CraftResource.TropicauxBone,	typeof( TropicauxBone ) ),
			new CraftResourceInfo(1940, 1049356, "Ancien",		6, CraftAttributeInfo.AncienBone,		CraftResource.AncienBone,		typeof( AncienBone ) ),
		};

		private static readonly CraftResourceInfo[] m_WoodInfo = new[]
        {
            new CraftResourceInfo(0x000, 1011542, "Normal",		1, CraftAttributeInfo.Blank,		CraftResource.RegularWood,  typeof(Log),			typeof(Board)),
            new CraftResourceInfo(0x7DA, 1072533, "Oak",		2, CraftAttributeInfo.OakWood,		CraftResource.OakWood,		typeof(OakLog),			typeof(OakBoard)),
            new CraftResourceInfo(0x4A7, 1072534, "Ash",		3, CraftAttributeInfo.AshWood,		CraftResource.AshWood,		typeof(AshLog),			typeof(AshBoard)),
            new CraftResourceInfo(0x4A8, 1072535, "Yew",		4, CraftAttributeInfo.YewWood,		CraftResource.YewWood,		typeof(YewLog),			typeof(YewBoard)),
            new CraftResourceInfo(0x4A9, 1072536, "Heartwood",	5, CraftAttributeInfo.Heartwood,    CraftResource.Heartwood,    typeof(HeartwoodLog),   typeof(HeartwoodBoard)),
            new CraftResourceInfo(0x4AA, 1072538, "Bloodwood",	6, CraftAttributeInfo.Bloodwood,    CraftResource.Bloodwood,    typeof(BloodwoodLog),   typeof(BloodwoodBoard)),
            new CraftResourceInfo(0x47F, 1072539, "Frostwood",	6, CraftAttributeInfo.Frostwood,    CraftResource.Frostwood,    typeof(FrostwoodLog),   typeof(FrostwoodBoard)),
        };

		public static int GetLevel(CraftResource resource)
		{
			CraftResourceInfo info = GetInfo(resource);

			return info != null ? info.Level : 1;
		}

        /// <summary>
        /// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
        /// </summary>
        public static bool IsStandard(CraftResource resource)
        {
            return (resource == CraftResource.None || resource == CraftResource.Iron || resource == CraftResource.PlainoisLeather || resource == CraftResource.RegularWood);
        }

        private static Hashtable m_TypeTable;

        /// <summary>
        /// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="GetFromType"/>
        /// </summary>
        public static void RegisterType(Type resourceType, CraftResource resource)
        {
            if (m_TypeTable == null)
                m_TypeTable = new Hashtable();

            m_TypeTable[resourceType] = resource;
        }

        /// <summary>
        /// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
        /// </summary>
        public static CraftResource GetFromType(Type resourceType)
        {
            if (m_TypeTable == null)
                return CraftResource.None;

            object obj = m_TypeTable[resourceType];

            if (!(obj is CraftResource))
                return CraftResource.None;

            return (CraftResource)obj;
        }

        /// <summary>
        /// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
        /// </summary>
        public static CraftResourceInfo GetInfo(CraftResource resource)
        {
            CraftResourceInfo[] list = null;

            switch (GetType(resource))
            {
                case CraftResourceType.Metal:
                    list = m_MetalInfo;
                    break;
                case CraftResourceType.Leather:
                    list = m_AOSLeatherInfo;
                    break;
                case CraftResourceType.Scales:
                    list = m_ScaleInfo;
                    break;
                case CraftResourceType.Wood:
                    list = m_WoodInfo;
                    break;
				case CraftResourceType.Bone:
					list = m_BoneInfo;
					break;
			}

            if (list != null)
            {
                int index = GetIndex(resource);

                if (index >= 0 && index < list.Length)
                    return list[index];
            }

            return null;
        }

        /// <summary>
        /// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
        /// </summary>
        public static CraftResourceType GetType(CraftResource resource)
        {
            if (resource >= CraftResource.Iron && resource <= CraftResource.Nostalgium)
                return CraftResourceType.Metal;

            if (resource >= CraftResource.PlainoisLeather && resource <= CraftResource.AncienLeather)
                return CraftResourceType.Leather;

            if (resource >= CraftResource.RedScales && resource <= CraftResource.BlueScales)
                return CraftResourceType.Scales;

            if (resource >= CraftResource.RegularWood && resource <= CraftResource.Frostwood)
                return CraftResourceType.Wood;

			if (resource >= CraftResource.PlainoisBone && resource <= CraftResource.AncienBone)
				return CraftResourceType.Bone;

			return CraftResourceType.None;
        }

        /// <summary>
        /// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
        /// </summary>
        public static CraftResource GetStart(CraftResource resource)
        {
            switch (GetType(resource))
            {
                case CraftResourceType.Metal:
                    return CraftResource.Iron;
                case CraftResourceType.Leather:
                    return CraftResource.PlainoisLeather;
                case CraftResourceType.Scales:
                    return CraftResource.RedScales;
                case CraftResourceType.Wood:
                    return CraftResource.RegularWood;
				case CraftResourceType.Bone:
					return CraftResource.PlainoisBone;
			}

            return CraftResource.None;
        }

        /// <summary>
        /// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
        /// </summary>
        public static int GetIndex(CraftResource resource)
        {
            CraftResource start = GetStart(resource);

            if (start == CraftResource.None)
                return 0;

            return resource - start;
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
        /// </summary>
        public static int GetLocalizationNumber(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? 0 : info.Number);
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
        /// </summary>
        public static int GetHue(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? 0 : info.Hue);
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
        /// </summary>
        public static string GetName(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? string.Empty : info.Name);
        }


		public static string GetDescription(CraftResource resource)
		{
			FieldInfo field = resource.GetType().GetField(resource.ToString());
			DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			return attribute == null ? resource.ToString() : attribute.Description;
		}



		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
		/// </summary>
		public static CraftResource GetFromOreInfo(OreInfo info)
        {
            if (info.Name.IndexOf("Lupus") >= 0)
                return CraftResource.ForestierLeather;
            else if (info.Name.IndexOf("Reptilien") >= 0)
                return CraftResource.DesertiqueLeather;
            else if (info.Name.IndexOf("Geant") >= 0)
                return CraftResource.CollinoisLeather;

			else if (info.Name.IndexOf("Ophidien") >= 0)
				return CraftResource.SavanoisLeather;
			else if (info.Name.IndexOf("Arachnide") >= 0)
				return CraftResource.ToundroisLeather;
			else if (info.Name.IndexOf("Dragonique") >= 0)
				return CraftResource.TropicauxLeather;
			else if (info.Name.IndexOf("Demoniaque") >= 0)
				return CraftResource.MontagnardLeather;
			else if (info.Name.IndexOf("Ancien") >= 0)
				return CraftResource.AncienLeather;


			else if (info.Name.IndexOf("Leather") >= 0)
                return CraftResource.PlainoisLeather;

            if (info.Level == 0)
                return CraftResource.Iron;
            else if (info.Level == 1)
                return CraftResource.DullCopper;
            else if (info.Level == 2)
                return CraftResource.ShadowIron;
            else if (info.Level == 3)
                return CraftResource.Copper;
            else if (info.Level == 4)
                return CraftResource.Bronze;
            else if (info.Level == 5)
                return CraftResource.Gold;
            else if (info.Level == 6)
                return CraftResource.Agapite;
            else if (info.Level == 7)
                return CraftResource.Verite;
            else if (info.Level == 8)
                return CraftResource.Valorite;
			else if (info.Level == 16)
				return CraftResource.Mytheril;

			return CraftResource.None;
        }

        /// <summary>
        /// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
        /// </summary>
        public static CraftResource GetFromOreInfo(OreInfo info, ArmorMaterialType material)
        {
            if (material == ArmorMaterialType.Studded || material == ArmorMaterialType.Leather )
            {
                if (info.Level == 0)
                    return CraftResource.PlainoisLeather;
                else if (info.Level == 1)
                    return CraftResource.ForestierLeather;
                else if (info.Level == 2)
                    return CraftResource.DesertiqueLeather;
                else if (info.Level == 3)
                    return CraftResource.CollinoisLeather;
				else if (info.Level == 4)
					return CraftResource.SavanoisLeather;
				else if (info.Level == 5)
					return CraftResource.ToundroisLeather;
				else if (info.Level == 6)
					return CraftResource.TropicauxLeather;
				else if (info.Level == 7)
					return CraftResource.MontagnardLeather;
				else if (info.Level == 8)
					return CraftResource.AncienLeather;
				else if (info.Level == 9)

				return CraftResource.None;
            }

            return GetFromOreInfo(info);
        }
    }

    // NOTE: This class is only for compatability with very old RunUO versions.
    // No changes to it should be required for custom resources.
    public class OreInfo
    {
        public static readonly OreInfo Iron = new OreInfo(0, 0x000, "Iron");
        public static readonly OreInfo DullCopper = new OreInfo(1, 0x973, "Dull Copper");
        public static readonly OreInfo ShadowIron = new OreInfo(2, 0x966, "Shadow Iron");
        public static readonly OreInfo Copper = new OreInfo(3, 0x96D, "Copper");
        public static readonly OreInfo Bronze = new OreInfo(4, 0x972, "Bronze");
        public static readonly OreInfo Gold = new OreInfo(5, 0x8A5, "Gold");
        public static readonly OreInfo Agapite = new OreInfo(6, 0x979, "Agapite");
        public static readonly OreInfo Verite = new OreInfo(7, 0x89F, "Verite");
        public static readonly OreInfo Valorite = new OreInfo(8, 0x8AB, "Valorite");
		public static readonly OreInfo Mytheril = new OreInfo(16, 1342, "Mytheril");

		private readonly int m_Level;
        private readonly int m_Hue;
        private readonly string m_Name;

        public OreInfo(int level, int hue, string name)
        {
            m_Level = level;
            m_Hue = hue;
            m_Name = name;
        }

        public int Level => m_Level;

        public int Hue => m_Hue;

        public string Name => m_Name;
    }
}
