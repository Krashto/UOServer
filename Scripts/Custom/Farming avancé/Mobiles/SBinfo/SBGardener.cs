﻿using System;
using System.Collections.Generic;
using Server.Items;
using Server.Items.Crops;

namespace Server.Mobiles
{
	public class SBGardener : SBInfo
	{
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGardener(){}

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return this.m_BuyInfo;
            }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				//this.Add( new GenericBuyInfo( typeof( MilkBucket ), 300, 10, 0x0FFA, 0 ) );
				//this.Add( new GenericBuyInfo( typeof( CheeseForm ), 300, 10, 0x0E78, 0 ) );

					this.Add( new GenericBuyInfo( "Plant Bowl", typeof( Engines.Plants.PlantBowl ), 10, 50, 0x15FD, 0 ) );
					this.Add( new GenericBuyInfo( "Fertile Dirt", typeof( FertileDirt ), 5, 999, 0xF81, 0 ) );
					this.Add( new GenericBuyInfo( "Random Plant Seed", typeof( Engines.Plants.Seed ), 20, 100, 0xDCF, 0 ) );
				//	//	this.Add( new GenericBuyInfo( typeof( GreaterCurePotion ), 45, 20, 0xF07, 0 ) );
				////	this.Add( new GenericBuyInfo( typeof( GreaterPoisonPotion ), 45, 20, 0xF0A, 0 ) );
				////	this.Add( new GenericBuyInfo( typeof( GreaterStrengthPotion ), 45, 20, 0xF09, 0 ) );
				////	this.Add( new GenericBuyInfo( typeof( GreaterHealPotion ), 45, 20, 0xF0C, 0 ) );
				///
				this.Add(new GenericBuyInfo("Baie Tribale", typeof(TribalBerry), 5, 25, 0x9D0, 0));
				this.Add(new GenericBuyInfo("Gingembre frais", typeof(FreshGinger), 5, 20, 0x2BE3, 0));
				this.Add(new GenericBuyInfo("Asparagus Seed", typeof(AsparagusSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Beet Seed", typeof(BeetSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Broccoli Seed", typeof(BroccoliSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Cabbage Seed", typeof(CabbageSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Carrot Seed", typeof(CarrotSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Cauliflower Seed", typeof(CauliflowerSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Celery Seed", typeof(CelerySeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Eggplant Seed", typeof(EggplantSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("GreenBean Seed", typeof(GreenBeanSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Lettuce Seed", typeof(LettuceSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Onion Seed", typeof(OnionSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Peanut Seed", typeof(PeanutSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Peas Seed", typeof(PeasSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Potato Seed", typeof(PotatoSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Radish Seed", typeof(RadishSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("SnowPeas Seed", typeof(SnowPeasSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Soy Seed", typeof(SoySeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Spinach Seed", typeof(SpinachSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Strawberry Seed", typeof(StrawberrySeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("SweetPotato Seed", typeof(SweetPotatoSeed), 5, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Turnip Seed", typeof(TurnipSeed), 5, 20, 0xF27, 0));

				this.Add(new GenericBuyInfo("Blackberry Seed", typeof(BlackberrySeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("BlackRaspberry Seed", typeof(BlackRaspberrySeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Blueberry Seed", typeof(BlueberrySeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Cranberry Seed", typeof(CranberrySeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Pineapple Seed", typeof(PineappleSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("RedRaspberry Seed", typeof(RedRaspberrySeed), 5, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Red Rose Seed", typeof(RedRoseSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("White Rose Seed", typeof(WhiteRoseSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Black Rose Seed", typeof(BlackRoseSeed), 5, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Cotton Seed", typeof(CottonSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Flax Seed", typeof(FlaxSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Hay Seed", typeof(HaySeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Oats Seed", typeof(OatsSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Rice Seed", typeof(RiceSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Sugarcane Seed", typeof(SugarcaneSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Wheat Seed", typeof(WheatSeed), 5, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Garlic Seed", typeof(GarlicSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Tan Ginger Seed", typeof(TanGingerSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Ginseng Seed", typeof(GinsengSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mandrake Seed", typeof(MandrakeSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Nightshade Seed", typeof(NightshadeSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Tan Mushroom Seed", typeof(TanMushroomSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Red Mushroom Seed", typeof(RedMushroomSeed), 5, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Bitter Hops Seed", typeof(BitterHopsSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Elven Hops Seed", typeof(ElvenHopsSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Snow Hops Seed", typeof(SnowHopsSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Sweet Hops Seed", typeof(SweetHopsSeed), 5, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Corn Seed", typeof(CornSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Field Corn Seed", typeof(FieldCornSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Sun Flower Seed", typeof(SunFlowerSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Tea Seed", typeof(TeaSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("VanillaSeed", typeof(VanillaSeed), 5, 20, 0xF27, 0));


			//	this.Add(new GenericBuyInfo("Pommier", typeof(AppleSapling), 5, 20, 0xF27, 0));
			//	this.Add(new GenericBuyInfo("Pêcher", typeof(PeachSapling), 5, 20, 0xF27, 0));
			//	this.Add(new GenericBuyInfo("Poirier", typeof(PearSapling), 5, 20, 0xF27, 0));

				//this.Add(new GenericBuyInfo("Chili Pepper Seed", typeof(ChiliPepperSeed), 5, 20, 0xF27, 0));
				//this.Add(new GenericBuyInfo("Cucumber Seed", typeof(CucumberSeed), 5, 20, 0xF27, 0));
				//this.Add(new GenericBuyInfo("Green Pepper Seed", typeof(GreenPepperSeed), 5, 20, 0xF27, 0));
				//this.Add(new GenericBuyInfo("Orange Pepper Seed", typeof(OrangePepperSeed), 5, 20, 0xF27, 0));
				//this.Add(new GenericBuyInfo("Red Pepper Seed", typeof(RedPepperSeed), 5, 20, 0xF27, 0));
				//this.Add(new GenericBuyInfo("Tomato Seed", typeof(TomatoSeed), 5, 20, 0xF27, 0));
				//this.Add(new GenericBuyInfo("Yellow Pepper Seed", typeof(YellowPepperSeed), 5, 20, 0xF27, 0));

				this.Add(new GenericBuyInfo("Cantaloupe Seed", typeof(CantaloupeSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Green Squash Seed", typeof(GreenSquashSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Honeydew Melon Seed", typeof(HoneydewMelonSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Pumpkin Seed", typeof(PumpkinSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Squash Seed", typeof(SquashSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Watermelon Seed", typeof(WatermelonSeed), 5, 20, 0xF27, 0));

				this.Add(new GenericBuyInfo("Banana Seed", typeof(BananaSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Coconut Seed", typeof(CoconutSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Date Seed", typeof(DateSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Almond Seed", typeof(MiniAlmondSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Apple Seed", typeof(MiniAppleSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Apricot Seed", typeof(MiniApricotSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Avocado Seed", typeof(MiniAvocadoSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Cherry Seed", typeof(MiniCherrySeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Cocoa Seed", typeof(MiniCocoaSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Coffee Seed", typeof(MiniCoffeeSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Grapefruit Seed", typeof(MiniGrapefruitSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Kiwi Seed", typeof(MiniKiwiSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Lemon Seed", typeof(MiniLemonSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Lime Seed", typeof(MiniLimeSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Mango Seed", typeof(MiniMangoSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Orange Seed", typeof(MiniOrangeSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Peach Seed", typeof(MiniPeachSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Pear Seed", typeof(MiniPearSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Pistacio Seed", typeof(MiniPistacioSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Pomegranate Seed", typeof(MiniPomegranateSeed), 5, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Small Banana Seed", typeof(SmallBananaSeed), 5, 20, 0xF27, 0));










			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				//Add( typeof( MilkBucket ), 40 );
				//Add( typeof( CheeseForm ), 40 );

				Add( typeof( Apple ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Watermelon ), 1 );
				Add( typeof( YellowGourd ), 1 );
				Add( typeof( Pumpkin ), 1 );
				Add( typeof( Onion ), 1 );
				Add( typeof( Lettuce ), 2 );
				Add( typeof( Squash ), 1 );
				Add( typeof( Carrot ), 1 );
				Add( typeof( HoneydewMelon ), 1 );
				Add( typeof( Cantaloupe ), 1 );
				Add( typeof( Cabbage ), 1 );
				Add( typeof( Lemon ), 1 );
				Add( typeof( Lime ), 1 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
			}
		}
	}
}