using System;
using Server.Items;

namespace Server.Spells
{
	public class Reagent
	{
		private static Type[] m_Types = new Type[26]
			{
				typeof( BlackPearl ),
				typeof( Bloodmoss ),
				typeof( Garlic ),
				typeof( Ginseng ),
				typeof( MandrakeRoot ),
				typeof( Nightshade ),
				typeof( SulfurousAsh ),
				typeof( SpidersSilk ),
				typeof( BatWing ),
				typeof( GraveDust ),
				typeof( DaemonBlood ),
				typeof( NoxCrystal ),
				typeof( PigIron ),
				typeof( EssenceAeromancie ),
				typeof( EssenceChasseur ),
				typeof( EssenceDefenseur ),
				typeof( EssenceGeomancie ),
				typeof( EssenceGuerison ),
				typeof( EssenceHydromancie ),
				typeof( EssenceMartial ),
				typeof( EssenceMusique ),
				typeof( EssenceNecromancie ),
				typeof( EssencePolymorphie ),
				typeof( EssencePyromancie ),
				typeof( EssenceRoublardise ),
				typeof( EssenceTotemique )
			};

		public Type[] Types
		{
			get{ return m_Types; }
		}

		public static Type BlackPearl
		{
			get{ return m_Types[0]; }
			set{ m_Types[0] = value; }
		}

		public static Type Bloodmoss
		{
			get{ return m_Types[1]; }
			set{ m_Types[1] = value; }
		}

		public static Type Garlic
		{
			get{ return m_Types[2]; }
			set{ m_Types[2] = value; }
		}

		public static Type Ginseng
		{
			get{ return m_Types[3]; }
			set{ m_Types[3] = value; }
		}

		public static Type MandrakeRoot
		{
			get{ return m_Types[4]; }
			set{ m_Types[4] = value; }
		}

		public static Type Nightshade
		{
			get{ return m_Types[5]; }
			set{ m_Types[5] = value; }
		}

		public static Type SulfurousAsh
		{
			get{ return m_Types[6]; }
			set{ m_Types[6] = value; }
		}

		public static Type SpidersSilk
		{
			get{ return m_Types[7]; }
			set{ m_Types[7] = value; }
		}

		public static Type BatWing
		{
			get{ return m_Types[8]; }
			set{ m_Types[8] = value; }
		}

		public static Type GraveDust
		{
			get{ return m_Types[9]; }
			set{ m_Types[9] = value; }
		}

		public static Type DaemonBlood
		{
			get{ return m_Types[10]; }
			set{ m_Types[10] = value; }
		}

		public static Type NoxCrystal
		{
			get{ return m_Types[11]; }
			set{ m_Types[11] = value; }
		}

		public static Type PigIron
		{
			get{ return m_Types[12]; }
			set{ m_Types[12] = value; }
		}
		public static Type EssenceAeromancie
		{
			get { return m_Types[13]; }
			set { m_Types[13] = value; }
		}
		public static Type EssenceChasseur
		{
			get { return m_Types[14]; }
			set { m_Types[14] = value; }
		}
		public static Type EssenceDefenseur
		{
			get { return m_Types[15]; }
			set { m_Types[15] = value; }
		}
		public static Type EssenceGeomancie
		{
			get { return m_Types[16]; }
			set { m_Types[16] = value; }
		}
		public static Type EssenceGuerison
		{
			get { return m_Types[17]; }
			set { m_Types[17] = value; }
		}
		public static Type EssenceHydromancie
		{
			get { return m_Types[18]; }
			set { m_Types[18] = value; }
		}
		public static Type EssenceMartial
		{
			get { return m_Types[19]; }
			set { m_Types[19] = value; }
		}
		public static Type EssenceMusique
		{
			get { return m_Types[20]; }
			set { m_Types[20] = value; }
		}
		public static Type EssenceNecromancie
		{
			get { return m_Types[21]; }
			set { m_Types[21] = value; }
		}
		public static Type EssencePolymorphie
		{
			get { return m_Types[22]; }
			set { m_Types[22] = value; }
		}
		public static Type EssencePyromancie
		{
			get { return m_Types[23]; }
			set { m_Types[23] = value; }
		}
		public static Type EssenceRoublardise
		{
			get { return m_Types[24]; }
			set { m_Types[24] = value; }
		}
		public static Type EssenceTotemique
		{
			get { return m_Types[25]; }
			set { m_Types[25] = value; }
		}
	}
}