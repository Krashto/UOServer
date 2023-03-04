using System;
using Server.Items;
using Server.Custom.Aptitudes;

namespace Server.Spells
{
	public class NourritureSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Nourriture", "In Mani Ylem",
				SpellCircle.First,
				224,
				9011,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.MandrakeRoot
            );

        public override int RequiredAptitudeValue { get { return 1; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Arcanique }; } }

        public NourritureSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		private static FoodInfo[] m_Food = new FoodInfo[]
			{
				new FoodInfo( typeof( Grapes ), "des raisins" ),
				new FoodInfo( typeof( Ham ), "un jambon" ),
				new FoodInfo( typeof( CheeseWheel ), "un fromage" ),
				new FoodInfo( typeof( Muffins ), "un muffin" ),
				new FoodInfo( typeof( CookedBird ), "un oiseau cuit" ),
				new FoodInfo( typeof( Apple ), "une pomme" ),
				new FoodInfo( typeof( Peach ), "une p�che" )
			};

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				FoodInfo foodInfo = m_Food[Utility.Random( m_Food.Length )];
				Item food = foodInfo.Create();

				if ( food != null )
				{
					Caster.AddToBackpack( food );

					// You magically create food in your backpack:
					Caster.SendLocalizedMessage( 1042695, true, " " + foodInfo.Name );

					Caster.FixedParticles( 0, 10, 5, 2003, EffectLayer.RightHand );
					Caster.PlaySound( 0x1E2 );
				}
			}

			FinishSequence();
		}
	}

	public class FoodInfo
	{
		private Type m_Type;
		private string m_Name;

		public Type Type{ get{ return m_Type; } set{ m_Type = value; } }
		public string Name{ get{ return m_Name; } set{ m_Name = value; } }

		public FoodInfo( Type type, string name )
		{
			m_Type = type;
			m_Name = name;
		}

		public Item Create()
		{
			Item item;

			try
			{
				item = (Item)Activator.CreateInstance( m_Type );
			}
			catch
			{
				item = null;
			}

			return item;
		}
	}
}