using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Items
{
    /// <summary>
    /// This attack allows you to disarm your foe.
    /// Now in Age of Shadows, a successful Disarm leaves the victim unable to re-arm another weapon for several seconds.
    /// </summary>
    public class Disarm : WeaponAbility
    {
        public static readonly TimeSpan BlockEquipDuration = TimeSpan.FromSeconds(20.0);

        public override int BaseStamina => 20;

		public override string Name => "Désarmer";
		public override int Id => 5;

        public override void OnHit(Mobile attacker, Mobile defender, int damage)
        {
            if (!Validate(attacker))
                return;

            ClearCurrentAbility(attacker);

			if (CheckStamina(attacker, true))
				DoEffect(attacker, defender);
		}

		public static bool DoEffect(Mobile attacker, Mobile defender)
		{
			if (IsImmune(defender))
			{
				attacker.SendLocalizedMessage(1111827); // Your opponent is gripping their weapon too tightly to be disarmed.
				defender.SendLocalizedMessage(1111828); // You will not be caught off guard by another disarm attack for some time.
				return false;
			}

			Item toDisarm = defender.FindItemOnLayer(Layer.OneHanded);

			if (toDisarm == null || !toDisarm.Movable)
				toDisarm = defender.FindItemOnLayer(Layer.TwoHanded);

			Container pack = defender.Backpack;

			if (pack == null || (toDisarm != null && !toDisarm.Movable))
			{
				attacker.SendLocalizedMessage(1004001); // You cannot disarm your opponent.
				return false;
			}
			else if (toDisarm == null || toDisarm is BaseShield)
			{
				attacker.SendLocalizedMessage(1060849); // Your target is already unarmed!
				return false;
			}

			attacker.SendLocalizedMessage(1060092); // You disarm their weapon!
			defender.SendLocalizedMessage(1060093); // Your weapon has been disarmed!

			defender.PlaySound(0x3B9);
			defender.FixedParticles(0x37BE, 232, 25, 9948, EffectLayer.LeftHand);

			pack.DropItem(toDisarm);

			BuffInfo.AddBuff(defender, new BuffInfo(BuffIcon.NoRearm, 1075637, BlockEquipDuration, defender));

			BaseWeapon.BlockEquip(defender, BlockEquipDuration);

			AddImmunity(defender, attacker.Weapon is Fists ? TimeSpan.FromSeconds(30) : TimeSpan.FromSeconds(40));

			return true;
		}

		public static List<Mobile> _Immunity;

        public static bool IsImmune(Mobile m)
        {
            return _Immunity != null && _Immunity.Contains(m);
        }

        public static void AddImmunity(Mobile m, TimeSpan duration)
        {
            if (_Immunity == null)
                _Immunity = new List<Mobile>();

            _Immunity.Add(m);

            Timer.DelayCall(duration, mob =>
                {
                    if (_Immunity != null && _Immunity.Contains(mob))
                        _Immunity.Remove(mob);
                }, m);
        }
    }
}
