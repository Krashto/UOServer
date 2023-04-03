using Server.Commands;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Scripts.Commands
{
	public class FioleAncestraleCommand
	{
		public static void Initialize()
		{
			CommandSystem.Register("FioleAncestrale", AccessLevel.GameMaster, new CommandEventHandler(FioleAncestraleCommand_OnCommand));
		}

		public static void FioleAncestraleCommand_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			from.SendMessage("À qui voulez-vous donner une fiole ancestrale ?");
			from.Target = new InternalTarget(); // Call our target
		}

		public class InternalTarget : Target
		{
			public InternalTarget() : base(12, false, TargetFlags.None)
			{

			}

			protected override void OnTarget(Mobile from, object target)
			{
				if (target is CustomPlayerMobile pm)
				{
					var points = 1;
					pm.PointsAncestraux.AddPoints(points);
					pm.SendMessage($"Vous recevez {points} point{(points > 1 ? "s" : "")} ancestra{(points > 1 ? "ux" : "l")}");
				}
				else
					from.SendMessage("Vous devez cibler un joueur.");
			}
		}
	}
}