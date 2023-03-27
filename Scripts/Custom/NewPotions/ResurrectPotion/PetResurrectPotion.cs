using System;
using Server.Network;
using Server;
using Server.Targets;
using Server.Targeting;
using Server.Mobiles;
using Server.Gumps;
namespace Server.Items
{
public class PetResurrectPotion : BasePotion
{
private BaseCreature pet;
[Constructable]
public PetResurrectPotion() : base( 0xF0B, PotionEffect.Resurrect )
{
Weight = 1.0;
Movable = true;
Hue = 871;
Name = "Cody's Pet Resurrect Potion";
}

public PetResurrectPotion( Serial serial ) : base( serial )
{
}

public override void Serialize( GenericWriter writer )
{
base.Serialize( writer );

writer.Write( (int) 0 ); // version
}

public override void Deserialize( GenericReader reader )
{
base.Deserialize( reader );

int version = reader.ReadInt();
}

public override void Drink( Mobile m )
{
if ( m.InRange( this.GetWorldLocation(), 1 ) )
{
m.Target = new PetResTarget();
m.SendMessage( "What pet do you want to bring back!" );
this.Consume();
				//this.Delete();
//m.AddToBackpack( new Bottle() );
}
else
{
m.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that.
}
}
}

public class PetResTarget : Target
{
public PetResTarget() : base( 12, false, TargetFlags.None )
{
}
protected override void OnTarget( Mobile from, object targeted )
{
if (targeted is Item || targeted is PlayerMobile || targeted is StaticTarget)
                                {
				from.SendMessage( "That was not a dead bonded pet!" );
                                return;
				}
BaseCreature pet = targeted as BaseCreature;

if ( pet.Deleted || !pet.IsBonded || !pet.IsDeadPet )
{
from.SendMessage( "That was not a dead bonded pet!" );
from.Target = new PetResTarget();
}
else if ( !pet.InRange( from, 1 ) )
{
from.SendMessage( "You must be closer to do that!" );
from.Target = new PetResTarget();
}
else
{
if (((pet != null) /*&& (pet is BaseCreature)*/))
{
pet.ResurrectPet();
from.SendMessage( "The pet has been resurrected!" );
}
else
{
from.SendMessage( "That was not a dead pet!" );
from.Target = new PetResTarget();
}
}
}
}
}

