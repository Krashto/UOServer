using Server.Engines.Craft;
using Server.Engines.CreatureStealing;
using Server.Mobiles;

namespace Server.Items
{
    [Alterable(typeof(DefTinkering), typeof(SmugglersEdge))]
    public class SmugglersEdge : ButcherKnife
    {
        public override int LabelNumber => 1071499;  // Smuggler's Edge
        public override bool CanFortify => false;
        public override bool IsArtifact => true;

        [Constructable]
        public SmugglersEdge()
        {
            Hue = 1461;

            WeaponAttributes.UseBestSkill = 1;
            Attributes.SpellChanneling = 1;
            Attributes.WeaponSpeed = 30;

            if (!Siege.SiegeShard)
                LootType = LootType.Blessed;
        }

        public override int InitMinHits => 255;
        public override int InitMaxHits => 255;
        public override int MinDamage => 9;
        public override int MaxDamage => 11;

        public SmugglersEdge(Serial serial)
            : base(serial)
        {
        }

        public override void OnHit(Mobile attacker, IDamageable damageable, double damageBonus)
        {
            base.OnHit(attacker, damageable, damageBonus);

            if (damageable is BaseCreature)
            {
                if (attacker.FindItemOnLayer(Layer.TwoHanded) != null)
                {
                    attacker.SendLocalizedMessage(1071501); // Your left hand must be free to steal an item from the creature.
                }
                else if (attacker is PlayerMobile)
                {
                    StealingHandler.HandleSmugglersEdgeSteal((BaseCreature)damageable, (PlayerMobile)attacker);
                }
            }
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            list.Add(1071500); // Monster Stealing
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

}
