using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 8003, 8004 )]
	public class NourritureScroll : SpellScroll
	{
		[Constructable]
		public NourritureScroll() : this( 1 )
		{
		}

		[Constructable]
		public NourritureScroll( int amount ) : base( 600, 8003, amount )
		{
			Name = "Nourriture";
		}

		public NourritureScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class VisionDeNuitScroll : SpellScroll
	{
		[Constructable]
		public VisionDeNuitScroll() : this( 1 )
		{
		}

		[Constructable]
		public VisionDeNuitScroll( int amount ) : base( 601, 8003, amount )
		{
			Name = "Vision de nuit";
		}

		public VisionDeNuitScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class FlecheMagiqueScroll : SpellScroll
	{
		[Constructable]
		public FlecheMagiqueScroll() : this( 1 )
		{
		}

		[Constructable]
		public FlecheMagiqueScroll( int amount ) : base( 602, 8003, amount )
		{
			Name = "Flèche magique";
		}

		public FlecheMagiqueScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class BlessureScroll : SpellScroll
	{
		[Constructable]
		public BlessureScroll() : this( 1 )
		{
		}

		[Constructable]
		public BlessureScroll( int amount ) : base( 603, 8001, amount )
		{
			Name = "Blessure";
		}

		public BlessureScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class PieuxDeTerreScroll : SpellScroll
	{
		[Constructable]
		public PieuxDeTerreScroll() : this( 1 )
		{
		}

		[Constructable]
		public PieuxDeTerreScroll( int amount ) : base( 604, 8001, amount )
		{
			Name = "Pieux de terre";
		}

		public PieuxDeTerreScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class TelekinesieScroll : SpellScroll
	{
		[Constructable]
		public TelekinesieScroll() : this( 1 )
		{
		}

		[Constructable]
		public TelekinesieScroll( int amount ) : base( 606, 8001, amount )
		{
			Name = "Télékinésie";
		}

		public TelekinesieScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class ForceScroll : SpellScroll
	{
		[Constructable]
		public ForceScroll() : this( 1 )
		{
		}

		[Constructable]
		public ForceScroll( int amount ) : base( 607, 8003, amount )
		{
			Name = "Force";
		}

		public ForceScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class AgiliteScroll : SpellScroll
	{
		[Constructable]
		public AgiliteScroll() : this( 1 )
		{
		}

		[Constructable]
		public AgiliteScroll( int amount ) : base( 608, 8003, amount )
		{
			Name = "Agilite";
		}

		public AgiliteScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class FaiblesseScroll : SpellScroll
	{
		[Constructable]
		public FaiblesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public FaiblesseScroll( int amount ) : base( 609, 8003, amount )
		{
			Name = "Faiblesse";
		}

		public FaiblesseScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class MaladresseScroll : SpellScroll
	{
		[Constructable]
		public MaladresseScroll() : this( 1 )
		{
		}

		[Constructable]
		public MaladresseScroll( int amount ) : base( 610, 8003, amount )
		{
			Name = "Maladresse";
		}

		public MaladresseScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class IntelligenceScroll : SpellScroll
	{
		[Constructable]
		public IntelligenceScroll() : this( 1 )
		{
		}

		[Constructable]
		public IntelligenceScroll( int amount ) : base( 611, 8001, amount )
		{
			Name = "Intelligence";
		}

		public IntelligenceScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class StupiditeScroll : SpellScroll
	{
		[Constructable]
		public StupiditeScroll() : this( 1 )
		{
		}

		[Constructable]
		public StupiditeScroll( int amount ) : base( 612, 8001, amount )
		{
			Name = "Stupidité";
		}

		public StupiditeScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class BenedictionScroll : SpellScroll
	{
		[Constructable]
		public BenedictionScroll() : this( 1 )
		{
		}

		[Constructable]
		public BenedictionScroll( int amount ) : base( 613, 7997, amount )
		{
			Name = "Bénédiction";
		}

		public BenedictionScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class MaledictionScroll : SpellScroll
	{
		[Constructable]
		public MaledictionScroll() : this( 1 )
		{
		}

		[Constructable]
		public MaledictionScroll( int amount ) : base( 614, 7993, amount )
		{
			Name = "Malédiction";
		}

		public MaledictionScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class ReversScroll : SpellScroll
	{
		[Constructable]
		public ReversScroll() : this( 1 )
		{
		}

		[Constructable]
		public ReversScroll( int amount ) : base( 615, 7989, amount )
		{
			Name = "Revers";
		}

        public ReversScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class MurDeHaieScroll : SpellScroll
	{
		[Constructable]
		public MurDeHaieScroll() : this( 1 )
		{
		}

		[Constructable]
		public MurDeHaieScroll( int amount ) : base( 616, 8003, amount )
		{
			Name = "Mur de haies";
		}

		public MurDeHaieScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class MurDePierreScroll : SpellScroll
	{
		[Constructable]
		public MurDePierreScroll() : this( 1 )
		{
		}

		[Constructable]
		public MurDePierreScroll( int amount ) : base( 617, 8001, amount )
		{
			Name = "Mur de pierre";
		}

		public MurDePierreScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class GeyserScroll : SpellScroll
	{
		[Constructable]
		public GeyserScroll() : this( 1 )
		{
		}

		[Constructable]
		public GeyserScroll( int amount ) : base( 618, 7999, amount )
		{
			Name = "Geyser";
		}

		public GeyserScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class MurDeFeuScroll : SpellScroll
	{
		[Constructable]
		public MurDeFeuScroll() : this( 1 )
		{
		}

		[Constructable]
		public MurDeFeuScroll( int amount ) : base( 619, 7993, amount )
		{
			Name = "Mur de feu";
		}

		public MurDeFeuScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class MurDEnergieScroll : SpellScroll
	{
		[Constructable]
		public MurDEnergieScroll() : this( 1 )
		{
		}

		[Constructable]
		public MurDEnergieScroll( int amount ) : base( 620, 7987, amount )
		{
			Name = "Mur d'énergie";
		}

		public MurDEnergieScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class MurDeParalysieScroll : SpellScroll
	{
		[Constructable]
		public MurDeParalysieScroll() : this( 1 )
		{
		}

		[Constructable]
		public MurDeParalysieScroll( int amount ) : base( 621, 7989, amount )
		{
			Name = "Mur de paralysie";
		}

		public MurDeParalysieScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class RevelationScroll : SpellScroll
	{
		[Constructable]
		public RevelationScroll() : this( 1 )
		{
		}

		[Constructable]
		public RevelationScroll( int amount ) : base( 622, 8003, amount )
		{
			Name = "Révélation";
		}

		public RevelationScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class DissipationScroll : SpellScroll
	{
		[Constructable]
		public DissipationScroll() : this( 1 )
		{
		}

		[Constructable]
		public DissipationScroll( int amount ) : base( 623, 7999, amount )
		{
			Name = "Dissipation";
		}

		public DissipationScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class ArmureMagiqueScroll : SpellScroll
	{
		[Constructable]
		public ArmureMagiqueScroll() : this( 1 )
		{
		}

		[Constructable]
		public ArmureMagiqueScroll( int amount ) : base( 624, 7989, amount )
		{
			Name = "Armure magique";
		}

		public ArmureMagiqueScroll( Serial serial ) : base( serial )
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
	}

    [FlipableAttribute(7993, 7994)]
	public class DissipationDeMurScroll : SpellScroll
	{
		[Constructable]
		public DissipationDeMurScroll() : this( 1 )
		{
		}

		[Constructable]
		public DissipationDeMurScroll( int amount ) : base( 625, 7993, amount )
		{
			Name = "Dissipation de mur";
		}

		public DissipationDeMurScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class DissipationDeMasseScroll : SpellScroll
	{
		[Constructable]
		public DissipationDeMasseScroll() : this( 1 )
		{
		}

		[Constructable]
		public DissipationDeMasseScroll( int amount ) : base( 626, 7987, amount )
		{
			Name = "Dissipation massive";
		}

		public DissipationDeMasseScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class DerobadeScroll : SpellScroll
	{
		[Constructable]
		public DerobadeScroll() : this( 1 )
		{
		}

		[Constructable]
		public DerobadeScroll( int amount ) : base( 627, 7985, amount )
		{
			Name = "Derobade";
		}

        public DerobadeScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class AntidoteScroll : SpellScroll
	{
		[Constructable]
		public AntidoteScroll() : this( 1 )
		{
		}

		[Constructable]
		public AntidoteScroll( int amount ) : base( 628, 8003, amount )
		{
			Name = "Antidote";
		}

		public AntidoteScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class GuerisonScroll : SpellScroll
	{
		[Constructable]
		public GuerisonScroll() : this( 1 )
		{
		}

		[Constructable]
		public GuerisonScroll( int amount ) : base( 629, 8001, amount )
		{
			Name = "Guérison";
		}

		public GuerisonScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class AntidoteDeMasseScroll : SpellScroll
	{
		[Constructable]
		public AntidoteDeMasseScroll() : this( 1 )
		{
		}

		[Constructable]
		public AntidoteDeMasseScroll( int amount ) : base( 630, 7997, amount )
		{
			Name = "Antidote massif";
		}

		public AntidoteDeMasseScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class GuerisonMajeureScroll : SpellScroll
	{
		[Constructable]
		public GuerisonMajeureScroll() : this( 1 )
		{
		}

		[Constructable]
		public GuerisonMajeureScroll( int amount ) : base( 631, 7987, amount )
		{
			Name = "Guérison majeure";
		}

		public GuerisonMajeureScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class ZoneDeGuerisonScroll : SpellScroll
	{
		[Constructable]
		public ZoneDeGuerisonScroll() : this( 1 )
		{
		}

		[Constructable]
		public ZoneDeGuerisonScroll( int amount ) : base( 632, 7989, amount )
		{
			Name = "Zone de guérison";
		}

		public ZoneDeGuerisonScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class NResurrectionScroll : SpellScroll
	{
		[Constructable]
		public NResurrectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public NResurrectionScroll( int amount ) : base( 633, 7985, amount )
		{
			Name = "Résurrection";
		}

		public NResurrectionScroll( Serial serial ) : base( serial )
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
	}

    [FlipableAttribute(7985, 7986)]
	public class ArmureScroll : SpellScroll
	{
		[Constructable]
		public ArmureScroll() : this( 1 )
		{
		}

		[Constructable]
		public ArmureScroll( int amount ) : base( 634, 7985, amount )
		{
			Name = "Armure";
		}

		public ArmureScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class ReflectionScroll : SpellScroll
	{
		[Constructable]
		public ReflectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ReflectionScroll( int amount ) : base( 635, 8001, amount )
		{
			Name = "Réflection";
		}

		public ReflectionScroll( Serial serial ) : base( serial )
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
	}

    [FlipableAttribute(8003, 8004)]
	public class ProtectScroll : SpellScroll
	{
		[Constructable]
		public ProtectScroll() : this( 1 )
		{
		}

		[Constructable]
		public ProtectScroll( int amount ) : base( 636, 8003, amount )
		{
			Name = "Protection";
		}

		public ProtectScroll( Serial serial ) : base( serial )
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
	}

    [FlipableAttribute(7997, 7998)]
	public class SecoursScroll : SpellScroll
	{
		[Constructable]
		public SecoursScroll() : this( 1 )
		{
		}

		[Constructable]
		public SecoursScroll( int amount ) : base( 637, 7997, amount )
		{
			Name = "Secours";
		}

        public SecoursScroll(Serial serial)
            : base(serial)
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
	}

    [FlipableAttribute(7989, 7990)]
	public class CopieScroll : SpellScroll
	{
		[Constructable]
		public CopieScroll() : this( 1 )
		{
		}

		[Constructable]
		public CopieScroll( int amount ) : base( 638, 7989, amount )
		{
			Name = "Copie";
		}

        public CopieScroll(Serial serial)
            : base(serial)
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
	}

    [FlipableAttribute(7987, 7988)]
	public class ChampDeStaseScroll : SpellScroll
	{
		[Constructable]
		public ChampDeStaseScroll() : this( 1 )
		{
		}

		[Constructable]
		public ChampDeStaseScroll( int amount ) : base( 639, 7987, amount )
		{
			Name = "Champ de stase";
		}

        public ChampDeStaseScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class PoisonMineurScroll : SpellScroll
	{
		[Constructable]
		public PoisonMineurScroll() : this( 1 )
		{
		}

		[Constructable]
		public PoisonMineurScroll( int amount ) : base( 640, 8003, amount )
		{
			Name = "Poison mineur";
		}

		public PoisonMineurScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class NPoisonScroll : SpellScroll
	{
		[Constructable]
		public NPoisonScroll() : this( 1 )
		{
		}

		[Constructable]
		public NPoisonScroll( int amount ) : base( 641, 7999, amount )
		{
			Name = "Poison";
		}

        public NPoisonScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class JetDePoisonScroll : SpellScroll
	{
		[Constructable]
		public JetDePoisonScroll() : this( 1 )
		{
		}

		[Constructable]
		public JetDePoisonScroll( int amount ) : base( 642, 7997, amount )
		{
			Name = "Jet de poison";
		}

		public JetDePoisonScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class MurDePoisonScroll : SpellScroll
	{
		[Constructable]
		public MurDePoisonScroll() : this( 1 )
		{
		}

		[Constructable]
		public MurDePoisonScroll( int amount ) : base( 643, 7987, amount )
		{
			Name = "Mur de poison";
		}

		public MurDePoisonScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class PluieAcideScroll : SpellScroll
	{
		[Constructable]
		public PluieAcideScroll() : this( 1 )
		{
		}

		[Constructable]
		public PluieAcideScroll( int amount ) : base( 644, 7989, amount )
		{
			Name = "Pluie acide";
		}

		public PluieAcideScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class PinceeAcideScroll : SpellScroll
	{
		[Constructable]
		public PinceeAcideScroll() : this( 1 )
		{
		}

		[Constructable]
		public PinceeAcideScroll( int amount ) : base( 645, 8003, amount )
		{
			Name = "Pincée acide";
		}

		public PinceeAcideScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class RacinesScroll : SpellScroll
	{
		[Constructable]
		public RacinesScroll() : this( 1 )
		{
		}

		[Constructable]
		public RacinesScroll( int amount ) : base( 646, 8003, amount )
		{
			Name = "Racines";
		}

		public RacinesScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class AbeillesScroll : SpellScroll
	{
		[Constructable]
		public AbeillesScroll() : this( 1 )
		{
		}

		[Constructable]
		public AbeillesScroll( int amount ) : base( 647, 8001, amount )
		{
			Name = "Abeilles";
		}

		public AbeillesScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class EpinesScroll : SpellScroll
	{
		[Constructable]
		public EpinesScroll() : this( 1 )
		{
		}

		[Constructable]
		public EpinesScroll( int amount ) : base( 648, 7999, amount )
		{
			Name = "Épines";
		}

		public EpinesScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class CriDOursScroll : SpellScroll
	{
		[Constructable]
		public CriDOursScroll() : this( 1 )
		{
		}

		[Constructable]
		public CriDOursScroll( int amount ) : base( 649, 7993, amount )
		{
			Name = "Cri d'ours";
		}

		public CriDOursScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class ArmurePierreScroll : SpellScroll
	{
		[Constructable]
		public ArmurePierreScroll() : this( 1 )
		{
		}

		[Constructable]
		public ArmurePierreScroll( int amount ) : base( 650, 7987, amount )
		{
			Name = "Armure de pierre";
		}

		public ArmurePierreScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class JetDEpinesScroll : SpellScroll
	{
		[Constructable]
		public JetDEpinesScroll() : this( 1 )
		{
		}

		[Constructable]
		public JetDEpinesScroll( int amount ) : base( 651, 7989, amount )
		{
			Name = "Jet d'épines";
		}

		public JetDEpinesScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class BouleDeFeuScroll : SpellScroll
	{
		[Constructable]
		public BouleDeFeuScroll() : this( 1 )
		{
		}

		[Constructable]
		public BouleDeFeuScroll( int amount ) : base( 652, 8001, amount )
		{
			Name = "Boule de feu";
		}

		public BouleDeFeuScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class EclairScroll : SpellScroll
	{
		[Constructable]
		public EclairScroll() : this( 1 )
		{
		}

		[Constructable]
		public EclairScroll( int amount ) : base( 653, 7997, amount )
		{
			Name = "Éclair";
		}

		public EclairScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class BouleDeGlaceScroll : SpellScroll
	{
		[Constructable]
		public BouleDeGlaceScroll() : this( 1 )
		{
		}

		[Constructable]
		public BouleDeGlaceScroll( int amount ) : base( 654, 7993, amount )
		{
			Name = "Boule de glace";
		}

		public BouleDeGlaceScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class BouleDEnergieScroll : SpellScroll
	{
		[Constructable]
		public BouleDEnergieScroll() : this( 1 )
		{
		}

		[Constructable]
		public BouleDEnergieScroll( int amount ) : base( 655, 7987, amount )
		{
			Name = "Boule d'énergie";
		}

		public BouleDEnergieScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class JetDeFeuScroll : SpellScroll
	{
		[Constructable]
		public JetDeFeuScroll() : this( 1 )
		{
		}

		[Constructable]
		public JetDeFeuScroll( int amount ) : base( 656, 7989, amount )
		{
			Name = "Jet de feu";
		}

		public JetDeFeuScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class FulgurationScroll : SpellScroll
	{
		[Constructable]
		public FulgurationScroll() : this( 1 )
		{
		}

		[Constructable]
		public FulgurationScroll( int amount ) : base( 657, 7985, amount )
		{
			Name = "Fulguration";
		}

		public FulgurationScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class TremblementsScroll : SpellScroll
	{
		[Constructable]
		public TremblementsScroll() : this( 1 )
		{
		}

		[Constructable]
		public TremblementsScroll( int amount ) : base( 658, 7999, amount )
		{
			Name = "Tremblements";
		}

		public TremblementsScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class ExplosionsScroll : SpellScroll
	{
		[Constructable]
		public ExplosionsScroll() : this( 1 )
		{
		}

		[Constructable]
		public ExplosionsScroll( int amount ) : base( 659, 7997, amount )
		{
			Name = "Explosion";
		}

		public ExplosionsScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class SeismeScroll : SpellScroll
	{
		[Constructable]
		public SeismeScroll() : this( 1 )
		{
		}

		[Constructable]
		public SeismeScroll( int amount ) : base( 660, 7993, amount )
		{
			Name = "Séisme";
		}

		public SeismeScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class EclairEnChaineScroll : SpellScroll
	{
		[Constructable]
		public EclairEnChaineScroll() : this( 1 )
		{
		}

		[Constructable]
		public EclairEnChaineScroll( int amount ) : base( 661, 7989, amount )
		{
			Name = "Éclair en chaîne";
		}

		public EclairEnChaineScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class MeteoresScroll : SpellScroll
	{
		[Constructable]
		public MeteoresScroll() : this( 1 )
		{
		}

		[Constructable]
		public MeteoresScroll( int amount ) : base( 662, 7985, amount )
		{
			Name = "Météores";
		}

		public MeteoresScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class VortexScroll : SpellScroll
	{
		[Constructable]
		public VortexScroll() : this( 1 )
		{
		}

		[Constructable]
		public VortexScroll( int amount ) : base( 663, 7985, amount )
		{
			Name = "Vortex";
		}

		public VortexScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class CreatureScroll : SpellScroll
	{
		[Constructable]
		public CreatureScroll() : this( 1 )
		{
		}

		[Constructable]
		public CreatureScroll( int amount ) : base( 664, 8003, amount )
		{
			Name = "Créatures";
		}

		public CreatureScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class ElementaireTerreScroll : SpellScroll
	{
		[Constructable]
		public ElementaireTerreScroll() : this( 1 )
		{
		}

		[Constructable]
		public ElementaireTerreScroll( int amount ) : base( 665, 7999, amount )
		{
			Name = "Élém. : Terre";
		}

		public ElementaireTerreScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class ElementaireAirScroll : SpellScroll
	{
		[Constructable]
		public ElementaireAirScroll() : this( 1 )
		{
		}

		[Constructable]
		public ElementaireAirScroll( int amount ) : base( 666, 7997, amount )
		{
			Name = "Élém. : Air";
		}

		public ElementaireAirScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class ElementaireFeuScroll : SpellScroll
	{
		[Constructable]
		public ElementaireFeuScroll() : this( 1 )
		{
		}

		[Constructable]
		public ElementaireFeuScroll( int amount ) : base( 667, 7987, amount )
		{
			Name = "Élém. : Feu";
		}

		public ElementaireFeuScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class ElementaireEauScroll : SpellScroll
	{
		[Constructable]
		public ElementaireEauScroll() : this( 1 )
		{
		}

		[Constructable]
		public ElementaireEauScroll( int amount ) : base( 668, 7989, amount )
		{
			Name = "Élém. : Eau";
		}

		public ElementaireEauScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class ElementaireCristalScroll : SpellScroll
	{
		[Constructable]
		public ElementaireCristalScroll() : this( 1 )
		{
		}

		[Constructable]
		public ElementaireCristalScroll( int amount ) : base( 669, 7985, amount )
		{
			Name = "Élém. : Cristal";
		}

		public ElementaireCristalScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class EspritAnimalScroll : SpellScroll
	{
		[Constructable]
		public EspritAnimalScroll() : this( 1 )
		{
		}

		[Constructable]
		public EspritAnimalScroll( int amount ) : base( 670, 7999, amount )
		{
			Name = "Esprit animal";
		}

		public EspritAnimalScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class EspritDeLamesScroll : SpellScroll
	{
		[Constructable]
		public EspritDeLamesScroll() : this( 1 )
		{
		}

		[Constructable]
		public EspritDeLamesScroll( int amount ) : base( 671, 7993, amount )
		{
			Name = "Esprit de lames";
		}

		public EspritDeLamesScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class EspritDEnergieScroll : SpellScroll
	{
		[Constructable]
		public EspritDEnergieScroll() : this( 1 )
		{
		}

		[Constructable]
		public EspritDEnergieScroll( int amount ) : base( 672, 7987, amount )
		{
			Name = "Esprit d'énergie";
		}

		public EspritDEnergieScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class DragonScroll : SpellScroll
	{
		[Constructable]
		public DragonScroll() : this( 1 )
		{
		}

		[Constructable]
		public DragonScroll( int amount ) : base( 673, 7989, amount )
		{
			Name = "Esprit du dragon";
		}

		public DragonScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class DemonScroll : SpellScroll
	{
		[Constructable]
		public DemonScroll() : this( 1 )
		{
		}

		[Constructable]
		public DemonScroll( int amount ) : base( 674, 7985, amount )
		{
			Name = "Démon";
		}

		public DemonScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class EspritVengeurScroll : SpellScroll
	{
		[Constructable]
		public EspritVengeurScroll() : this( 1 )
		{
		}

		[Constructable]
		public EspritVengeurScroll( int amount ) : base( 675, 7985, amount )
		{
			Name = "Esprit vengeur";
		}

		public EspritVengeurScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class PourritureDEspritScroll : SpellScroll
	{
		[Constructable]
		public PourritureDEspritScroll() : this( 1 )
		{
		}

		[Constructable]
		public PourritureDEspritScroll( int amount ) : base( 676, 8003, amount )
		{
			Name = "Pourriture d'esprit";
		}

		public PourritureDEspritScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class DrainDeManaScroll : SpellScroll
	{
		[Constructable]
		public DrainDeManaScroll() : this( 1 )
		{
		}

		[Constructable]
		public DrainDeManaScroll( int amount ) : base( 677, 8001, amount )
		{
			Name = "Drain de mana";
		}

		public DrainDeManaScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class MalaiseScroll : SpellScroll
	{
		[Constructable]
		public MalaiseScroll() : this( 1 )
		{
		}

		[Constructable]
		public MalaiseScroll( int amount ) : base( 678, 7997, amount )
		{
			Name = "Malaise";
		}

		public MalaiseScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class SouffleDEspritScroll : SpellScroll
	{
		[Constructable]
		public SouffleDEspritScroll() : this( 1 )
		{
		}

		[Constructable]
		public SouffleDEspritScroll( int amount ) : base( 679, 7993, amount )
		{
			Name = "Souffle d'esprit";
		}

		public SouffleDEspritScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class DrainVampiriqueScroll : SpellScroll
	{
		[Constructable]
		public DrainVampiriqueScroll() : this( 1 )
		{
		}

		[Constructable]
		public DrainVampiriqueScroll( int amount ) : base( 680, 7987, amount )
		{
			Name = "Drain vampirique";
		}

		public DrainVampiriqueScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class EtouffementsScroll : SpellScroll
	{
		[Constructable]
		public EtouffementsScroll() : this( 1 )
		{
		}

		[Constructable]
		public EtouffementsScroll( int amount ) : base( 681, 7989, amount )
		{
			Name = "Étouffements";
		}

		public EtouffementsScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class EnduranceScroll : SpellScroll
	{
		[Constructable]
		public EnduranceScroll() : this( 1 )
		{
		}

		[Constructable]
		public EnduranceScroll( int amount ) : base( 682, 8001, amount )
		{
			Name = "Endurance";
		}

		public EnduranceScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class TeleportationScroll : SpellScroll
	{
		[Constructable]
		public TeleportationScroll() : this( 1 )
		{
		}

		[Constructable]
		public TeleportationScroll( int amount ) : base( 683, 7999, amount )
		{
			Name = "Téléportation";
		}

		public TeleportationScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class RappelScroll : SpellScroll
	{
		[Constructable]
		public RappelScroll() : this( 1 )
		{
		}

		[Constructable]
		public RappelScroll( int amount ) : base( 684, 7993, amount )
		{
			Name = "Rappel";
		}

		public RappelScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class EvasionScroll : SpellScroll
	{
		[Constructable]
		public EvasionScroll() : this( 1 )
		{
		}

		[Constructable]
		public EvasionScroll( int amount ) : base( 685, 8003, amount )
		{
			Name = "Évasion";
		}

		public EvasionScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class TrouDeVerScroll : SpellScroll
	{
		[Constructable]
		public TrouDeVerScroll() : this( 1 )
		{
		}

		[Constructable]
		public TrouDeVerScroll( int amount ) : base( 686, 7989, amount )
		{
			Name = "Trou de ver";
		}

		public TrouDeVerScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class MarquageScroll : SpellScroll
	{
		[Constructable]
		public MarquageScroll() : this( 1 )
		{
		}

		[Constructable]
		public MarquageScroll( int amount ) : base( 687, 7985, amount )
		{
			Name = "Marquage";
		}

		public MarquageScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class PiegeScroll : SpellScroll
	{
		[Constructable]
		public PiegeScroll() : this( 1 )
		{
		}

		[Constructable]
		public PiegeScroll( int amount ) : base( 688, 8001, amount )
		{
			Name = "Piège";
		}

		public PiegeScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class DesamorcageScroll : SpellScroll
	{
		[Constructable]
		public DesamorcageScroll() : this( 1 )
		{
		}

		[Constructable]
		public DesamorcageScroll( int amount ) : base( 689, 8001, amount )
		{
			Name = "Désamorçage";
		}

		public DesamorcageScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class SerrureScroll : SpellScroll
	{
		[Constructable]
		public SerrureScroll() : this( 1 )
		{
		}

		[Constructable]
		public SerrureScroll( int amount ) : base( 690, 7999, amount )
		{
			Name = "Serrure";
		}

		public SerrureScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class CrochetageScroll : SpellScroll
	{
		[Constructable]
		public CrochetageScroll() : this( 1 )
		{
		}

		[Constructable]
		public CrochetageScroll( int amount ) : base( 691, 7999, amount )
		{
			Name = "Crochetage";
		}

		public CrochetageScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class NIncognitoScroll : SpellScroll
	{
		[Constructable]
		public NIncognitoScroll() : this( 1 )
		{
		}

		[Constructable]
		public NIncognitoScroll( int amount ) : base( 692, 7997, amount )
		{
			Name = "Incognito";
		}

        public NIncognitoScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class InvisibiliteScroll : SpellScroll
	{
		[Constructable]
		public InvisibiliteScroll() : this( 1 )
		{
		}

		[Constructable]
		public InvisibiliteScroll( int amount ) : base( 693, 7993, amount )
		{
			Name = "Invisibilité";
		}

		public InvisibiliteScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class HallucinationsScroll : SpellScroll
	{
		[Constructable]
		public HallucinationsScroll() : this( 1 )
		{
		}

		[Constructable]
		public HallucinationsScroll( int amount ) : base( 694, 7987, amount )
		{
			Name = "Hallucinations";
		}

		public HallucinationsScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class DisparitionScroll : SpellScroll
	{
		[Constructable]
		public DisparitionScroll() : this( 1 )
		{
		}

		[Constructable]
		public DisparitionScroll( int amount ) : base( 695, 7989, amount )
		{
			Name = "Disparition";
		}

		public DisparitionScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8003, 8004 )]
	public class AlterationScroll : SpellScroll
	{
		[Constructable]
		public AlterationScroll() : this( 1 )
		{
		}

		[Constructable]
		public AlterationScroll( int amount ) : base( 696, 8003, amount )
		{
			Name = "Altération";
		}

		public AlterationScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class SubterfugeScroll : SpellScroll
	{
		[Constructable]
		public SubterfugeScroll() : this( 1 )
		{
		}

		[Constructable]
		public SubterfugeScroll( int amount ) : base( 697, 8001, amount )
		{
			Name = "Subterfuge";
		}

        public SubterfugeScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class ChimereScroll : SpellScroll
	{
		[Constructable]
		public ChimereScroll() : this( 1 )
		{
		}

		[Constructable]
		public ChimereScroll( int amount ) : base( 698, 7997, amount )
		{
			Name = "Chimère";
		}

        public ChimereScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class TransmutationScroll : SpellScroll
	{
		[Constructable]
		public TransmutationScroll() : this( 1 )
		{
		}

		[Constructable]
		public TransmutationScroll( int amount ) : base( 699, 7993, amount )
		{
			Name = "Transmutation";
		}

        public TransmutationScroll(Serial serial)
            : base(serial)
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class MetamorphoseScroll : SpellScroll
	{
		[Constructable]
		public MetamorphoseScroll() : this( 1 )
		{
		}

		[Constructable]
		public MetamorphoseScroll( int amount ) : base( 700, 7989, amount )
		{
			Name = "Métamorphose";
		}

		public MetamorphoseScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class MutationScroll : SpellScroll
	{
		[Constructable]
		public MutationScroll() : this( 1 )
		{
		}

		[Constructable]
		public MutationScroll( int amount ) : base( 701, 7985, amount )
		{
			Name = "Mutation";
		}

		public MutationScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class CalamiteScroll : SpellScroll
	{
		[Constructable]
		public CalamiteScroll() : this( 1 )
		{
		}

		[Constructable]
		public CalamiteScroll( int amount ) : base( 702, 8001, amount )
		{
			Name = "Calamité";
		}

		public CalamiteScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7997, 7998 )]
	public class PeauDeMortScroll : SpellScroll
	{
		[Constructable]
		public PeauDeMortScroll() : this( 1 )
		{
		}

		[Constructable]
		public PeauDeMortScroll( int amount ) : base( 703, 7997, amount )
		{
			Name = "Peau des morts";
		}

		public PeauDeMortScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class MauvaisPresageScroll : SpellScroll
	{
		[Constructable]
		public MauvaisPresageScroll() : this( 1 )
		{
		}

		[Constructable]
		public MauvaisPresageScroll( int amount ) : base( 704, 7993, amount )
		{
			Name = "Mauvais présage";
		}

		public MauvaisPresageScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class LanceOsScroll : SpellScroll
	{
		[Constructable]
		public LanceOsScroll() : this( 1 )
		{
		}

		[Constructable]
		public LanceOsScroll( int amount ) : base( 705, 7987, amount )
		{
			Name = "Lance d'os";
		}

		public LanceOsScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7989, 7990 )]
	public class SermentDeSangScroll : SpellScroll
	{
		[Constructable]
		public SermentDeSangScroll() : this( 1 )
		{
		}

		[Constructable]
		public SermentDeSangScroll( int amount ) : base( 706, 7989, amount )
		{
			Name = "Serment de sang";
		}

		public SermentDeSangScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class JetDeDouleurScroll : SpellScroll
	{
		[Constructable]
		public JetDeDouleurScroll() : this( 1 )
		{
		}

		[Constructable]
		public JetDeDouleurScroll( int amount ) : base( 707, 7985, amount )
		{
			Name = "Jet de douleur";
		}

		public JetDeDouleurScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 8001, 8002 )]
	public class FamilierScroll : SpellScroll
	{
		[Constructable]
		public FamilierScroll() : this( 1 )
		{
		}

		[Constructable]
		public FamilierScroll( int amount ) : base( 708, 8001, amount )
		{
			Name = "Familier";
		}

		public FamilierScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7999, 8000 )]
	public class DefraicheurScroll : SpellScroll
	{
		[Constructable]
		public DefraicheurScroll() : this( 1 )
		{
		}

		[Constructable]
		public DefraicheurScroll( int amount ) : base( 709, 7999, amount )
		{
			Name = "Défraîcheur";
		}

		public DefraicheurScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7993, 7994 )]
	public class StrangulaireScroll : SpellScroll
	{
		[Constructable]
		public StrangulaireScroll() : this( 1 )
		{
		}

		[Constructable]
		public StrangulaireScroll( int amount ) : base( 710, 7993, amount )
		{
			Name = "Strangulaire";
		}

		public StrangulaireScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7987, 7988 )]
	public class ReanimationScroll : SpellScroll
	{
		[Constructable]
		public ReanimationScroll() : this( 1 )
		{
		}

		[Constructable]
		public ReanimationScroll( int amount ) : base( 711, 7987, amount )
		{
			Name = "Réanimation";
		}

		public ReanimationScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class AppelDeLaLicheScroll : SpellScroll
	{
		[Constructable]
		public AppelDeLaLicheScroll() : this( 1 )
		{
		}

		[Constructable]
		public AppelDeLaLicheScroll( int amount ) : base( 712, 7985, amount )
		{
			Name = "Appel de la liche";
		}

		public AppelDeLaLicheScroll( Serial serial ) : base( serial )
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
	}

	[FlipableAttribute( 7985, 7986 )]
	public class InsurectionScroll : SpellScroll
	{
		[Constructable]
		public InsurectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public InsurectionScroll( int amount ) : base( 713, 7985, amount )
		{
			Name = "Insurrection";
		}

		public InsurectionScroll( Serial serial ) : base( serial )
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
	}
}