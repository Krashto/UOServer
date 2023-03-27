using System;
using System.IO;
using System.Collections;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Multis;
using Server.Engines.Help;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Targets;
using System.Reflection;
using Server.Spells;

using Server.ContextMenus;
using Server.Regions;
//using Server.StaticHousing;
using Server.Accounting;
using Server.Prompts;
namespace Server.Targets
{
    public class RepairTarget : Target
		{
			public RepairTarget() :  base ( 1, false, TargetFlags.None )
			{
			}
			protected override void OnTarget( Mobile from, object targeted )
			{
				int number;
				if ( targeted is BaseArmor )
				{
					BaseArmor repairing = (BaseArmor)targeted;
					if ( !repairing.IsChildOf( from.Backpack ) )
					{
						from.SendLocalizedMessage( 1044275 ); // The item must be in your backpack to repair it.
					}
					else if ( repairing.MaxHitPoints <= 0 || repairing.HitPoints == repairing.MaxHitPoints )
					{
						from.SendLocalizedMessage( 1044281 );// That item is in full repair
					}
					else
					{
						from.SendLocalizedMessage( 1044279 ); // You repair the item.
						repairing.HitPoints = repairing.MaxHitPoints;
					}
				}
				else if ( targeted is BaseWeapon )
				{
					BaseWeapon repairing2 = (BaseWeapon)targeted;
					if ( !repairing2.IsChildOf( from.Backpack ) )
					{
						from.SendLocalizedMessage( 1044275 ); // The item must be in your backpack to repair it.
					}
					else if ( repairing2.MaxHitPoints <= 0 || repairing2.HitPoints == repairing2.MaxHitPoints )
					{
						from.SendLocalizedMessage( 1044281 );// That item is in full repair
					}
					else
					{
						from.SendLocalizedMessage( 1044279 ); // You repair the item.
						repairing2.HitPoints = repairing2.MaxHitPoints;
					}
				}
				else if ( targeted is Item )
				{
					from.SendLocalizedMessage( 1044277 ); // That item cannot be repaired.
				}
				else
				{
				   from.SendLocalizedMessage( 500426 ); // You can't repair that.
				}
				}
		}
    
}
