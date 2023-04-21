namespace Server.Items
{
    public class BagOfReagents : Bag
    {
        [Constructable]
        public BagOfReagents()
            : this(50)
        {
        }

        [Constructable]
        public BagOfReagents(int amount)
        {
            DropItem(new BlackPearl(amount));
            DropItem(new Bloodmoss(amount));
            DropItem(new Garlic(amount));
            DropItem(new Ginseng(amount));
            DropItem(new MandrakeRoot(amount));
            DropItem(new Nightshade(amount));
            DropItem(new SulfurousAsh(amount));
            DropItem(new SpidersSilk(amount));

			DropItem(new EssenceAeromancie(amount));
			DropItem(new EssenceChasseur(amount));
			DropItem(new EssenceDefenseur(amount));
			DropItem(new EssenceGeomancie(amount));
			DropItem(new EssenceGuerison(amount));
			DropItem(new EssenceHydromancie(amount));
			DropItem(new EssenceMartial(amount));
			DropItem(new EssenceMusique(amount));
			DropItem(new EssenceNecromancie(amount));
			DropItem(new EssencePolymorphie(amount));
			DropItem(new EssencePyromancie(amount));
			DropItem(new EssenceRoublardise(amount));
			DropItem(new EssenceTotemique(amount));




		}

		public BagOfReagents(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}