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

		[Description("Régulier")]
        RegularWood = 401,
		[Description("Plainois")]
		PlainoisWood,
		[Description("Forestier")]
		ForestierWood,
		[Description("Collinois")]
		CollinoisWood,
		[Description("Désertique")]
		DesertiqueWood,
		[Description("Savanois")]
		SavanoisWood,
		[Description("Montagnard")]
		MontagnardWood,
		[Description("Volcanique")]
		VolcaniqueWood,
		[Description("Tropicaux")]
		TropicauxWood,
		[Description("Toundrois")]
		ToundroisWood,
		[Description("Ancien")]
		AncienWood,
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
		[Description("Collinois")]
		CollinoisBone,
		[Description("Désertique")]
		DesertiqueBone,
		[Description("Savanois")]
		SavanoisBone,
		[Description("Montagnard")]
		MontagnardBone,
		[Description("Volcanique")]
		VolcaniqueBone,
		[Description("Tropicaux")]
		TropicauxBone,
		[Description("Toundrois")]
		ToundroisBone,
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
		public static readonly CraftAttributeInfo RegularWood, PlainoisWood, ForestierWood, DesertiqueWood, CollinoisWood,  SavanoisWood, MontagnardWood, VolcaniqueWood, TropicauxWood, ToundroisWood, AncienWood;
		public static readonly CraftAttributeInfo RegularBone, PlainoisBone, ForestierBone, DesertiqueBone, CollinoisBone, SavanoisBone, MontagnardBone, VolcaniqueBone, TropicauxBone, ToundroisBone, AncienBone;

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

			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

			bronze.ArmorPhysicalResist = 1;
			bronze.ArmorColdResist = 1;
			bronze.ArmorPoisonResist = 1;

			bronze.WeaponColdDamage = 10;
			bronze.WeaponPoisonDamage = 10;

			CraftAttributeInfo cuivre = Cuivre = new CraftAttributeInfo();

			cuivre.ArmorPhysicalResist = 1;
			cuivre.ArmorFireResist = 1;
			cuivre.ArmorEnergyResist = 1;

			cuivre.WeaponFireDamage = 10;
			cuivre.WeaponEnergyDamage = 10;

			CraftAttributeInfo sonne = Sonne = new CraftAttributeInfo();

			sonne.ArmorPhysicalResist = 2;
			sonne.ArmorFireResist = 2;
			sonne.ArmorPoisonResist = 2;

			sonne.WeaponFireDamage = 20;
			sonne.WeaponPoisonDamage = 20;

			CraftAttributeInfo argent = Argent = new CraftAttributeInfo();

			argent.ArmorPhysicalResist = 2;
			argent.ArmorFireResist = 2;
			argent.ArmorEnergyResist = 2;

			argent.WeaponFireDamage = 20;
			argent.WeaponEnergyDamage = 20;

			CraftAttributeInfo boreale = Boreale = new CraftAttributeInfo();

			boreale.ArmorPhysicalResist = 2;
			boreale.ArmorFireResist = 2;
			boreale.ArmorColdResist = 2;

			boreale.WeaponFireDamage = 20;
			boreale.WeaponColdDamage = 20;

			CraftAttributeInfo chrysteliar = Chrysteliar = new CraftAttributeInfo();

			chrysteliar.ArmorPhysicalResist = 2;
			chrysteliar.ArmorColdResist = 2;
			chrysteliar.ArmorPoisonResist = 2;

			chrysteliar.WeaponColdDamage = 20;
			chrysteliar.WeaponPoisonDamage = 20;

			CraftAttributeInfo glacias = Glacias = new CraftAttributeInfo();

			glacias.ArmorPhysicalResist = 2;
			glacias.ArmorColdResist = 2;
			glacias.ArmorEnergyResist = 2;

			glacias.WeaponDamage = 20;
			glacias.WeaponDamage = 20;

			CraftAttributeInfo lithiar = Lithiar = new CraftAttributeInfo();

			lithiar.ArmorPhysicalResist = 2;
			lithiar.ArmorPoisonResist = 2;
			lithiar.ArmorEnergyResist = 2;

			lithiar.WeaponPoisonDamage = 20;
			lithiar.WeaponEnergyDamage = 20;

			CraftAttributeInfo acier = Acier = new CraftAttributeInfo();

			acier.ArmorPhysicalResist = 3;
			acier.ArmorFireResist = 3;
			acier.ArmorPoisonResist = 3;

			acier.WeaponFireDamage = 30;
			acier.WeaponPoisonDamage = 30;

			CraftAttributeInfo durian = Durian = new CraftAttributeInfo();

			durian.ArmorPhysicalResist = 3;
			durian.ArmorFireResist = 3;
			durian.ArmorEnergyResist = 3;

			durian.WeaponFireDamage = 30;
			durian.WeaponEnergyDamage = 30;

			CraftAttributeInfo equilibrum = Equilibrum = new CraftAttributeInfo();

			equilibrum.ArmorPhysicalResist = 3;
			equilibrum.ArmorFireResist = 3;
			equilibrum.ArmorColdResist = 3;

			equilibrum.WeaponFireDamage = 30;
			equilibrum.WeaponColdDamage = 30;

			CraftAttributeInfo or = Or = new CraftAttributeInfo();

			or.ArmorPhysicalResist = 3;
			or.ArmorColdResist = 3;
			or.ArmorPoisonResist = 3;

			or.WeaponColdDamage = 30;
			or.WeaponPoisonDamage = 30;

			CraftAttributeInfo jolinar = Jolinar = new CraftAttributeInfo();

			jolinar.ArmorPhysicalResist = 3;
			jolinar.ArmorColdResist = 3;
			jolinar.ArmorEnergyResist = 3;

			jolinar.WeaponColdDamage = 30;
			jolinar.WeaponEnergyDamage = 30;

			CraftAttributeInfo justicium = Justicium = new CraftAttributeInfo();

			justicium.ArmorPhysicalResist = 3;
			justicium.ArmorPoisonResist = 3;
			justicium.ArmorEnergyResist = 3;

			justicium.WeaponPoisonDamage = 30;
			justicium.WeaponEnergyDamage = 30;

			CraftAttributeInfo abyssium = Abyssium = new CraftAttributeInfo();

			abyssium.ArmorPhysicalResist = 4;
			abyssium.ArmorFireResist = 4;
			abyssium.ArmorPoisonResist = 4;

			abyssium.WeaponFireDamage = 40;
			abyssium.WeaponPoisonDamage = 40;

			CraftAttributeInfo bloodirium = Bloodirium = new CraftAttributeInfo();

			bloodirium.ArmorPhysicalResist = 4;
			bloodirium.ArmorFireResist = 4;
			bloodirium.ArmorEnergyResist = 4;

			bloodirium.WeaponFireDamage = 40;
			bloodirium.WeaponEnergyDamage = 40;

			CraftAttributeInfo herbrosite = Herbrosite = new CraftAttributeInfo();

			herbrosite.ArmorPhysicalResist = 4;
			herbrosite.ArmorFireResist = 4;
			herbrosite.ArmorColdResist = 4;

			herbrosite.WeaponFireDamage = 40;
			herbrosite.WeaponColdDamage = 40;

			CraftAttributeInfo khandarium = Khandarium = new CraftAttributeInfo();

			khandarium.ArmorPhysicalResist = 4;
			khandarium.ArmorColdResist = 4;
			khandarium.ArmorPoisonResist = 4;

			khandarium.WeaponColdDamage = 40;
			khandarium.WeaponPoisonDamage = 40;

			CraftAttributeInfo mytheril = Mytheril = new CraftAttributeInfo();

			mytheril.ArmorPhysicalResist = 4;
			mytheril.ArmorColdResist = 4;
			mytheril.ArmorEnergyResist = 4;

			mytheril.WeaponColdDamage = 40;
			mytheril.WeaponEnergyDamage = 40;

			CraftAttributeInfo sombralir = Sombralir = new CraftAttributeInfo();

			sombralir.ArmorPhysicalResist = 4;
			sombralir.ArmorPoisonResist = 4;
			sombralir.ArmorEnergyResist = 4;

			sombralir.WeaponPoisonDamage = 40;
			sombralir.WeaponEnergyDamage = 40;

			CraftAttributeInfo draconyr = Draconyr = new CraftAttributeInfo();

			draconyr.ArmorPhysicalResist = 5;
			draconyr.ArmorFireResist = 7;
			draconyr.ArmorColdResist = 2;
			draconyr.ArmorPoisonResist = 7;
			draconyr.ArmorEnergyResist = 2;

			draconyr.WeaponFireDamage = 50;
			draconyr.WeaponPoisonDamage = 50;

			CraftAttributeInfo heptazion = Heptazion = new CraftAttributeInfo();

			heptazion.ArmorPhysicalResist = 5;
			heptazion.ArmorFireResist = 7;
			heptazion.ArmorColdResist = 2;
			heptazion.ArmorPoisonResist = 2;
			heptazion.ArmorEnergyResist = 7;

			heptazion.WeaponFireDamage = 50;
			heptazion.WeaponEnergyDamage = 50;

			CraftAttributeInfo oceanis = Oceanis = new CraftAttributeInfo();

			oceanis.ArmorPhysicalResist = 5;
			oceanis.ArmorFireResist = 7;
			oceanis.ArmorColdResist = 7;
			oceanis.ArmorPoisonResist = 2;
			oceanis.ArmorEnergyResist = 2;

			oceanis.WeaponFireDamage = 50;
			oceanis.WeaponColdDamage = 50;

			CraftAttributeInfo brazium = Brazium = new CraftAttributeInfo();

			brazium.ArmorPhysicalResist = 5;
			brazium.ArmorFireResist = 2;
			brazium.ArmorColdResist = 7;
			brazium.ArmorPoisonResist = 7;
			brazium.ArmorEnergyResist = 2;

			brazium.WeaponColdDamage = 50;
			brazium.WeaponPoisonDamage = 50;

			CraftAttributeInfo lunerium = Lunerium = new CraftAttributeInfo();

			lunerium.ArmorPhysicalResist = 5;
			lunerium.ArmorFireResist = 2;
			lunerium.ArmorColdResist = 7;
			lunerium.ArmorPoisonResist = 2;
			lunerium.ArmorEnergyResist = 7;

			lunerium.WeaponColdDamage = 50;
			lunerium.WeaponEnergyDamage = 50;

			CraftAttributeInfo marinar = Marinar = new CraftAttributeInfo();

			marinar.ArmorPhysicalResist = 5;
			marinar.ArmorFireResist = 2;
			marinar.ArmorColdResist = 2;
			marinar.ArmorPoisonResist = 7;
			marinar.ArmorEnergyResist = 7;

			marinar.ArmorPoisonResist = 50;
			marinar.WeaponEnergyDamage = 50;

			CraftAttributeInfo nostalgium = Nostalgium = new CraftAttributeInfo();

			nostalgium.ArmorPhysicalResist = 6;
			nostalgium.ArmorFireResist = 8;
			nostalgium.ArmorColdResist = 8;
			nostalgium.ArmorPoisonResist = 8;
			nostalgium.ArmorEnergyResist = 8;

			nostalgium.WeaponFireDamage = 20;
			nostalgium.WeaponColdDamage = 20;
			nostalgium.WeaponPoisonDamage = 20;
			nostalgium.WeaponEnergyDamage = 20;
			nostalgium.WeaponDamage = 20;

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
			ancienLeather.ArmorFireResist = 8;
			ancienLeather.ArmorColdResist = 8;
			ancienLeather.ArmorPoisonResist = 8;
			ancienLeather.ArmorEnergyResist = 8;

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
			ancienBone.ArmorFireResist = 8;
			ancienBone.ArmorColdResist = 8;
			ancienBone.ArmorPoisonResist = 8;
			ancienBone.ArmorEnergyResist = 8;

			// Os
			CraftAttributeInfo plainoisWood = PlainoisWood = new CraftAttributeInfo();

			plainoisWood.ArmorPhysicalResist = 1;

			CraftAttributeInfo forestierWood = ForestierWood = new CraftAttributeInfo();

			forestierWood.ArmorPhysicalResist = 2;
			forestierWood.ArmorPoisonResist = 2;
			forestierWood.ArmorColdResist = 2;

			forestierWood.WeaponPoisonDamage = 20;
			forestierWood.WeaponColdDamage = 20;

			CraftAttributeInfo collinoisWood = CollinoisWood = new CraftAttributeInfo();

			collinoisWood.ArmorPhysicalResist = 2;
			collinoisWood.ArmorColdResist = 2;
			collinoisWood.ArmorEnergyResist = 2;

			collinoisWood.WeaponPoisonDamage = 20;
			collinoisWood.WeaponEnergyDamage = 20;

			CraftAttributeInfo desertiqueWood = DesertiqueWood = new CraftAttributeInfo();

			desertiqueWood.ArmorPhysicalResist = 3;
			desertiqueWood.ArmorFireResist = 3;
			desertiqueWood.ArmorPoisonResist = 3;

			desertiqueWood.WeaponFireDamage = 30;
			desertiqueWood.WeaponPoisonDamage = 30;

			CraftAttributeInfo savanoisWood = SavanoisWood = new CraftAttributeInfo();

			savanoisWood.ArmorPhysicalResist = 3;
			savanoisWood.ArmorFireResist = 3;
			savanoisWood.ArmorEnergyResist = 3;

			savanoisWood.WeaponFireDamage = 30;
			savanoisWood.WeaponEnergyDamage = 30;

			CraftAttributeInfo toundroisWood = ToundroisWood = new CraftAttributeInfo();

			toundroisWood.ArmorPhysicalResist = 4;
			toundroisWood.ArmorPoisonResist = 4;
			toundroisWood.ArmorColdResist = 4;

			toundroisWood.WeaponPoisonDamage = 40;
			toundroisWood.WeaponColdDamage = 40;

			CraftAttributeInfo tropicauxWood = TropicauxWood = new CraftAttributeInfo();

			tropicauxWood.ArmorPhysicalResist = 4;
			tropicauxWood.ArmorFireResist = 4;
			tropicauxWood.ArmorEnergyResist = 4;

			tropicauxWood.WeaponFireDamage = 40;
			tropicauxWood.WeaponEnergyDamage = 40;

			CraftAttributeInfo montagnardWood = MontagnardWood = new CraftAttributeInfo();

			montagnardWood.ArmorPhysicalResist = 5;
			montagnardWood.ArmorColdResist = 5;
			montagnardWood.ArmorPoisonResist = 5;

			montagnardWood.WeaponColdDamage = 50;
			montagnardWood.WeaponPoisonDamage = 50;

			CraftAttributeInfo volcaniqueWood = VolcaniqueWood = new CraftAttributeInfo();

			volcaniqueWood.ArmorPhysicalResist = 5;
			volcaniqueWood.ArmorFireResist = 5;
			volcaniqueWood.ArmorEnergyResist = 5;

			volcaniqueWood.WeaponFireDamage = 50;
			volcaniqueWood.WeaponEnergyDamage = 50;

			CraftAttributeInfo ancienWood = AncienWood = new CraftAttributeInfo();

			ancienWood.ArmorPhysicalResist = 6;
			ancienWood.ArmorFireResist = 8;
			ancienWood.ArmorColdResist = 8;
			ancienWood.ArmorPoisonResist = 8;
			ancienWood.ArmorEnergyResist = 8;

			ancienWood.WeaponFireDamage = 20;
			ancienWood.WeaponColdDamage = 20;
			ancienWood.WeaponPoisonDamage = 20;
			ancienWood.WeaponEnergyDamage = 20;
			ancienWood.WeaponDamage = 20;

			//Scales

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
            new CraftResourceInfo( 0,		0, "Fer",			0, CraftAttributeInfo.Blank,		CraftResource.Iron,			typeof( IronIngot ),		typeof( IronOre ) ),
			new CraftResourceInfo( 1122,	0, "Bronze",		0, CraftAttributeInfo.Bronze,		CraftResource.Bronze,		typeof( BronzeIngot ),		typeof( BronzeOre ) ),
			new CraftResourceInfo( 1134,	0, "Cuivre",		0, CraftAttributeInfo.Cuivre,		CraftResource.Copper,       typeof( CopperIngot ),      typeof( CopperOre ) ),
			new CraftResourceInfo( 1124,	0, "Sonne",			1, CraftAttributeInfo.Sonne,		CraftResource.Sonne,        typeof( SonneIngot ),       typeof( SonneOre ) ),
			new CraftResourceInfo( 2500,	0, "Argent",		1, CraftAttributeInfo.Argent,		CraftResource.Argent,       typeof( ArgentIngot ),      typeof( ArgentOre ) ),
			new CraftResourceInfo( 1767,	0, "Boréale",		1, CraftAttributeInfo.Boreale,		CraftResource.Boreale,      typeof( BorealeIngot ),     typeof( BorealeOre ) ),
			new CraftResourceInfo( 1759,	0, "Chrysteliar",	1, CraftAttributeInfo.Chrysteliar,  CraftResource.Chrysteliar,  typeof( ChrysteliarIngot ), typeof( ChrysteliarOre ) ),
			new CraftResourceInfo( 1365,	0, "Glacias",		1, CraftAttributeInfo.Glacias,		CraftResource.Glacias,      typeof( GlaciasIngot ),     typeof( GlaciasOre ) ),
			new CraftResourceInfo( 1448,	0, "Lithiar",		1, CraftAttributeInfo.Lithiar,		CraftResource.Lithiar,      typeof( LithiarIngot ),     typeof( LithiarOre ) ),
			new CraftResourceInfo( 1102,	0, "Acier",			2, CraftAttributeInfo.Acier,		CraftResource.Acier,        typeof( AcierIngot ),       typeof( AcierOre ) ),
			new CraftResourceInfo( 1160,	0, "Durian",		2, CraftAttributeInfo.Durian,		CraftResource.Durian,       typeof( DurianIngot ),      typeof( DurianOre ) ),
			new CraftResourceInfo( 2212,	0, "Equilibrum",	2, CraftAttributeInfo.Equilibrum,   CraftResource.Equilibrum,   typeof( EquilibrumIngot ),  typeof( EquilibrumOre ) ),
			new CraftResourceInfo( 2125,	0, "Or",			2, CraftAttributeInfo.Or,			CraftResource.Gold,			typeof( GoldIngot ),		typeof( GoldOre ) ),
			new CraftResourceInfo( 2205,	0, "Jolinar",		2, CraftAttributeInfo.Jolinar,		CraftResource.Jolinar,      typeof( JolinarIngot ),     typeof( JolinarOre ) ),
			new CraftResourceInfo( 2219,	0, "Justicium",		2, CraftAttributeInfo.Justicium,    CraftResource.Justicium,    typeof( JusticiumIngot ),   typeof( JusticiumOre ) ),
			new CraftResourceInfo( 1149,	0, "Abyssium",		3, CraftAttributeInfo.Abyssium,		CraftResource.Abyssium,     typeof( AbyssiumIngot ),    typeof( AbyssiumOre ) ),
			new CraftResourceInfo( 1777,	0, "Bloodirium",	3, CraftAttributeInfo.Bloodirium,	CraftResource.Bloodirium,   typeof( BloodiriumIngot ),  typeof( BloodiriumOre ) ),
			new CraftResourceInfo( 1445,	0, "Herbrosite",	3, CraftAttributeInfo.Herbrosite,	CraftResource.Herbrosite,   typeof( HerbrositeIngot ),  typeof( HerbrositeOre ) ),
			new CraftResourceInfo( 1746,	0, "Khandarium",	3, CraftAttributeInfo.Khandarium,	CraftResource.Khandarium,   typeof( KhandariumIngot ),  typeof( KhandariumOre ) ),
			new CraftResourceInfo( 1757,	0, "Mytheril",		3, CraftAttributeInfo.Mytheril,		CraftResource.Mytheril,		typeof( MytherilIngot ),	typeof( MytherilOre ) ),
			new CraftResourceInfo( 2051,	0, "Sombralir",		3, CraftAttributeInfo.Sombralir,	CraftResource.Sombralir,	typeof( SombralirIngot ),   typeof( SombralirOre ) ),
			new CraftResourceInfo( 2591,	0, "Draconyr",		4, CraftAttributeInfo.Draconyr,		CraftResource.Draconyr,		typeof( DraconyrIngot ),    typeof( DraconyrOre ) ),
			new CraftResourceInfo( 2130,	0, "Heptazion",		4, CraftAttributeInfo.Heptazion,    CraftResource.Heptazion,	typeof( HeptazionIngot ),   typeof( HeptazionOre ) ),
			new CraftResourceInfo( 1770,	0, "Oceanis",		4, CraftAttributeInfo.Oceanis,		CraftResource.Oceanis,		typeof( OceanisIngot ),     typeof( OceanisOre ) ),
			new CraftResourceInfo( 1509,	0, "Brazium",		4, CraftAttributeInfo.Brazium,		CraftResource.Brazium,		typeof( BraziumIngot ),     typeof( BraziumOre ) ),
			new CraftResourceInfo( 2656,	0, "Lunerium",		4, CraftAttributeInfo.Lunerium,		CraftResource.Lunerium,		typeof( LuneriumIngot ),    typeof( LuneriumOre ) ),
			new CraftResourceInfo( 1411,	0, "Marinar",		4, CraftAttributeInfo.Marinar,		CraftResource.Marinar,		typeof( MarinarIngot ),     typeof( MarinarOre ) ),
			new CraftResourceInfo( 1755,	0, "Nostalgium",	5, CraftAttributeInfo.Nostalgium,	CraftResource.Nostalgium,   typeof( NostalgiumIngot ),  typeof( NostalgiumOre ) ),

			new CraftResourceInfo(0x973, 0, "Dull Copper",    99, CraftAttributeInfo.DullCopper,	CraftResource.DullCopper, typeof(DullCopperIngot),  typeof(DullCopperOre),  typeof(DullCopperGranite)),
			new CraftResourceInfo(0x966, 0, "Shadow Iron",    99, CraftAttributeInfo.ShadowIron,	CraftResource.ShadowIron, typeof(ShadowIronIngot),  typeof(ShadowIronOre),  typeof(ShadowIronGranite)),
			new CraftResourceInfo(1980,  0, "Agapite",        99, CraftAttributeInfo.Agapite,		CraftResource.Agapite, typeof(AgapiteIngot), typeof(AgapiteOre), typeof(AgapiteGranite)),
			new CraftResourceInfo(2841,  0, "Verite",         99, CraftAttributeInfo.Verite,		CraftResource.Verite, typeof(VeriteIngot), typeof(VeriteOre), typeof(VeriteGranite)),
			new CraftResourceInfo(2867,  0, "Valorite",       99, CraftAttributeInfo.Valorite,		CraftResource.Valorite, typeof(ValoriteIngot),  typeof(ValoriteOre), typeof(ValoriteGranite)),
		};

        private static readonly CraftResourceInfo[] m_ScaleInfo = new[]
        {
            new CraftResourceInfo(0x66D, 0, "Red Scales",		0, CraftAttributeInfo.RedScales, CraftResource.RedScales, typeof(RedScales)),
            new CraftResourceInfo(0x8A8, 0, "Yellow Scales",  1, CraftAttributeInfo.YellowScales,    CraftResource.YellowScales, typeof(YellowScales)),
            new CraftResourceInfo(0x455, 0, "Black Scales",   2, CraftAttributeInfo.BlackScales, CraftResource.BlackScales, typeof(BlackScales)),
            new CraftResourceInfo(0x851, 0, "Green Scales",   3, CraftAttributeInfo.GreenScales, CraftResource.GreenScales, typeof(GreenScales)),
            new CraftResourceInfo(0x8FD, 0, "White Scales",   4, CraftAttributeInfo.WhiteScales, CraftResource.WhiteScales, typeof(WhiteScales)),
            new CraftResourceInfo(0x8B0, 0, "Blue Scales",    5, CraftAttributeInfo.BlueScales, CraftResource.BlueScales, typeof(BlueScales)),
        };

        private static readonly CraftResourceInfo[] m_AOSLeatherInfo = new[]
        {
            new CraftResourceInfo(1355, 0, "Plainois",	0, CraftAttributeInfo.Blank,				CraftResource.PlainoisLeather,		typeof( PlainoisLeather ),		typeof( PlainoisHides ) ),
			new CraftResourceInfo(1411, 0, "Forestier",	1, CraftAttributeInfo.ForestierLeather,     CraftResource.ForestierLeather,     typeof( ForestierLeather ),     typeof( ForestierHides ) ),
			new CraftResourceInfo(1191, 0, "Collinois",	1, CraftAttributeInfo.CollinoisLeather,		CraftResource.CollinoisLeather,     typeof( CollinoisLeather ),		typeof( CollinoisHides ) ),
			new CraftResourceInfo(1126, 0, "Désertique",	2, CraftAttributeInfo.DesertiqueLeather,	CraftResource.DesertiqueLeather,	typeof( DesertiqueLeather ),	typeof( DesertiqueHides ) ),
			new CraftResourceInfo(1008, 0, "Savanois",	2, CraftAttributeInfo.SavanoisLeather,		CraftResource.SavanoisLeather,		typeof( SavanoisLeather ),		typeof( SavanoisHides ) ),
			new CraftResourceInfo(2219, 0, "Montagnard",	3, CraftAttributeInfo.MontagnardLeather,	CraftResource.MontagnardLeather,	typeof( MontagnardLeather ),	typeof( MontagnardHides ) ),
			new CraftResourceInfo(1109, 0, "Volcanique",	4, CraftAttributeInfo.VolcaniqueLeather,	CraftResource.VolcaniqueLeather,	typeof( VolcaniqueLeather ),	typeof( VolcaniqueHides ) ),
			new CraftResourceInfo(2500, 0, "Toundrois",	4, CraftAttributeInfo.ToundroisLeather,     CraftResource.ToundroisLeather,		typeof( ToundroisLeather ),		typeof( ToundroisHides ) ),
			new CraftResourceInfo(2210, 0, "Tropicaux",	4, CraftAttributeInfo.TropicauxLeather,		CraftResource.TropicauxLeather,		typeof( TropicauxLeather ),		typeof( TropicauxHides ) ),
			new CraftResourceInfo(1779, 0, "Ancien",		5, CraftAttributeInfo.AncienLeather,		CraftResource.AncienLeather,		typeof( AncienLeather ),		typeof( AncienHides ) ),
		};

		private static readonly CraftResourceInfo[] m_BoneInfo = new[]
		{
			new CraftResourceInfo(1355, 0, "Plainois",	0, CraftAttributeInfo.Blank,			CraftResource.PlainoisBone,		typeof( PlainoisBone ) ),
			new CraftResourceInfo(1411, 0, "Forestier",	1, CraftAttributeInfo.ForestierBone,    CraftResource.ForestierBone,    typeof( ForestierBone ) ),
			new CraftResourceInfo(1191, 0, "Collinois",	1, CraftAttributeInfo.CollinoisBone,	CraftResource.CollinoisBone,    typeof( CollinoisBone ) ),
			new CraftResourceInfo(1126, 0, "Désertique",	2, CraftAttributeInfo.DesertiqueBone,	CraftResource.DesertiqueBone,	typeof( DesertiqueBone ) ),
			new CraftResourceInfo(1008, 0, "Savanois",	2, CraftAttributeInfo.SavanoisBone,		CraftResource.SavanoisBone,		typeof( SavanoisBone ) ),
			new CraftResourceInfo(2219, 0, "Montagnard",	3, CraftAttributeInfo.MontagnardBone,	CraftResource.MontagnardBone,	typeof( MontagnardBone ) ),
			new CraftResourceInfo(1109, 0, "Volcanique",	3, CraftAttributeInfo.VolcaniqueBone,	CraftResource.VolcaniqueBone,	typeof( VolcaniqueBone ) ),
			new CraftResourceInfo(2210, 0, "Tropicaux",	4, CraftAttributeInfo.TropicauxBone,	CraftResource.TropicauxBone,	typeof( TropicauxBone ) ),
			new CraftResourceInfo(2500, 0, "Toundrois", 4, CraftAttributeInfo.ToundroisBone,    CraftResource.ToundroisBone,    typeof( ToundroisBone ) ),
			new CraftResourceInfo(1779, 0, "Ancien",		5, CraftAttributeInfo.AncienBone,		CraftResource.AncienBone,		typeof( AncienBone ) ),
		};

		private static readonly CraftResourceInfo[] m_WoodInfo = new[]
        {
            new CraftResourceInfo(0000, 0, "Commun",	  0,	CraftAttributeInfo.Blank,				CraftResource.RegularWood,		typeof( RegularBoard ),		typeof(RegularLog)),
            new CraftResourceInfo(1355, 0, "Plainois",	  0,	CraftAttributeInfo.Blank,				CraftResource.PlainoisWood,		typeof( PlainoisBoard ),	typeof(PlainoisLog)),
			new CraftResourceInfo(1411, 0, "Forestier",   1,	CraftAttributeInfo.ForestierWood,		CraftResource.ForestierWood,    typeof( ForestierBoard ),	typeof(ForestierLog)),
			new CraftResourceInfo(1191, 0, "Collinois",   1,	CraftAttributeInfo.CollinoisWood,		CraftResource.CollinoisWood,    typeof( CollinoisBoard ),	typeof(CollinoisLog)),
			new CraftResourceInfo(1126, 0, "Désertique",  2,	CraftAttributeInfo.DesertiqueWood,		CraftResource.DesertiqueWood,   typeof( DesertiqueBoard ),	typeof(DesertiqueLog)),
			new CraftResourceInfo(1008, 0, "Savanois",    2,	CraftAttributeInfo.SavanoisWood,		CraftResource.SavanoisWood,		typeof( SavanoisBoard ),	typeof(SavanoisLog)),
			new CraftResourceInfo(2219, 0, "Montagnard",  3,	CraftAttributeInfo.MontagnardWood,		CraftResource.MontagnardWood,   typeof( MontagnardBoard ),	typeof(MontagnardLog)),
			new CraftResourceInfo(1109, 0, "Volcanique",  3,	CraftAttributeInfo.VolcaniqueWood,		CraftResource.VolcaniqueWood,   typeof( VolcaniqueBoard ),	typeof(VolcaniqueLog)),
			new CraftResourceInfo(2210, 0, "Tropicaux",   4,	CraftAttributeInfo.TropicauxWood,		CraftResource.TropicauxWood,    typeof( TropicauxBoard ),	typeof(TropicauxLog)),
			new CraftResourceInfo(2500, 0, "Toundrois",   4,	CraftAttributeInfo.ToundroisWood,		CraftResource.ToundroisWood,    typeof( ToundroisBoard ),	typeof(ToundroisLog)),
			new CraftResourceInfo(1779, 0, "Ancien",      5,	CraftAttributeInfo.AncienWood,			CraftResource.AncienWood,       typeof( AncienBoard ),		typeof(AncienLog)),

			new CraftResourceInfo(0x7DA, 0, "Oak",        99, CraftAttributeInfo.OakWood,      CraftResource.OakWood,      typeof(OakLog),         typeof(OakBoard)),
			new CraftResourceInfo(0x4A7, 0, "Ash",        99, CraftAttributeInfo.AshWood,      CraftResource.AshWood,      typeof(AshLog),         typeof(AshBoard)),
			new CraftResourceInfo(0x4A8, 0, "Yew",        99, CraftAttributeInfo.YewWood,      CraftResource.YewWood,      typeof(YewLog),         typeof(YewBoard)),
			new CraftResourceInfo(0x4A9, 0, "Heartwood",  99, CraftAttributeInfo.Heartwood,    CraftResource.Heartwood,    typeof(HeartwoodLog),   typeof(HeartwoodBoard)),
			new CraftResourceInfo(0x4AA, 0, "Bloodwood",  99, CraftAttributeInfo.Bloodwood,    CraftResource.Bloodwood,    typeof(BloodwoodLog),   typeof(BloodwoodBoard)),
			new CraftResourceInfo(0x47F, 0, "Frostwood",  99, CraftAttributeInfo.Frostwood,    CraftResource.Frostwood,    typeof(FrostwoodLog),   typeof(FrostwoodBoard)),
		};

		public static int GetLevel(CraftResource resource)
		{
			CraftResourceInfo info = GetInfo(resource);

			return info != null ? info.Level : 0;
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
					return CraftResource.VolcaniqueLeather;
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
