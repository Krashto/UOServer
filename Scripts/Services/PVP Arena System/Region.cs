using Server.Items;
using Server.Mobiles;
using Server.Regions;
using Server.Spells;
using System;

namespace Server.Engines.ArenaSystem
{
    public class ArenaRegion : BaseRegion
    {
        public PVPArena Arena { get; set; }

        public ArenaRegion(PVPArena arena)
            : base(string.Format("Duel Arena {0}", arena.Definition.Name),
                    arena.Definition.Map,
                    DefaultPriority,
                    arena.Definition.RegionBounds)
        {
            Arena = arena;
        }

        public override bool OnDoubleClick(Mobile m, object o)
        {
            if (Arena.CurrentDuel != null)
            {
                ArenaDuel duel = Arena.CurrentDuel;

                if (o is BasePotion && duel.PotionRules != PotionRules.All)
                {
                    if (duel.PotionRules == PotionRules.None || o is BaseHealPotion)
                    {
                        return false;
                    }
                }
            }

            if (o is Corpse && ((Corpse)o).Owner != m)
            {
                m.SendLocalizedMessage(1010054); // You cannot loot that corpse!!
                return false;
            }

            if (o is BraceletOfBinding)
            {
                return false;
            }

            return base.OnDoubleClick(m, o);
        }

        public override bool AllowFlying(Mobile from)
        {
            if (Arena.CurrentDuel != null && !Arena.CurrentDuel.RidingFlyingAllowed)
            {
                return false;
            }

            return base.AllowFlying(from);
        }

        public override bool OnBeginSpellCast(Mobile m, ISpell spell)
        {
            if (Arena.CurrentDuel != null)
            {
                ArenaDuel duel = Arena.CurrentDuel;

                if (duel.InPreFight)
                {
                    m.SendLocalizedMessage(502629); // You cannot cast spells here.
                    return false;
                }
            }

            return base.OnBeginSpellCast(m, spell);
        }

        public override bool CheckTravel(Mobile traveller, Point3D p, TravelCheckType type)
        {
            if (type == TravelCheckType.TeleportTo)
            {
                if (Find(traveller.Location, traveller.Map) != this || traveller.Z != p.Z)
                {
                    traveller.SendLocalizedMessage(501035); // You cannot teleport from here to the destination.
                    return false;
                }
            }

            return type > TravelCheckType.Mark;
        }

        public override void OnDeath(Mobile m)
        {
            if (Arena != null && Arena.CurrentDuel != null && Arena.CurrentDuel.HasBegun && !Arena.CurrentDuel.InPreFight)
            {
                Arena.CurrentDuel.HandleDeath(m);
            }

            base.OnDeath(m);
        }

        public override bool AllowHarmful(Mobile from, IDamageable target)
        {
            if (Arena != null && Arena.CurrentDuel != null && Arena.CurrentDuel.Complete)
            {
                return false;
            }

            return true;
        }

        public override bool OnResurrect(Mobile m)
        {
            bool res = base.OnResurrect(m);

            if (Arena != null)
            {
                Timer.DelayCall(TimeSpan.FromSeconds(.2), mob => Arena.RemovePlayer(mob), m);
            }

            return res;
        }

        public bool AllowItemEquip(PlayerMobile pm, Item item)
        {
            ArenaDuel duel = Arena.CurrentDuel;

            if (duel != null && !duel.RangedWeaponsAllowed && item is BaseRanged)
            {
                pm.SendLocalizedMessage(1115996); // The rules prohibit the use of ranged weapons!
                return false;
            }

            return true;
        }
    }

    public class GuardedArenaRegion : GuardedRegion
    {
        public GuardedArenaRegion(string name, Map map, Rectangle2D[] rec)
            : base(name, map, 1, rec)
        {
        }

        public override bool AllowHarmful(Mobile from, IDamageable target)
        {
            Region theirs = Find(target.Location, target.Map);

            if (theirs is ArenaRegion)
            {
                return false;
            }

            return base.AllowHarmful(from, target);
        }

        public override bool AllowBeneficial(Mobile from, Mobile target)
        {
            Region theirs = Find(target.Location, target.Map);

            if (theirs is ArenaRegion)
            {
                return false;
            }

            return base.AllowBeneficial(from, target);
        }
    }
}
