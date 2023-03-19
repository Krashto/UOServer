using System;
using Server;

namespace Server.Items
{
	public class AveuglementScroll : SpellScroll
	{
		[Constructable]
		public AveuglementScroll() : this( 1 )
		{
		}

		[Constructable]
		public AveuglementScroll( int amount ) : base( 600, 0x2260, amount )
		{
			Name = "Aveuglement";
		}

		public AveuglementScroll( Serial serial ) : base( serial )
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
	public class BrouillardScroll : SpellScroll
	{
		[Constructable]
		public BrouillardScroll() : this(1)
		{
		}

		[Constructable]
		public BrouillardScroll(int amount) : base(601, 0x2260, amount)
		{
			Name = "Brouillard";
		}

		public BrouillardScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class TeleportationScroll : SpellScroll
	{
		[Constructable]
		public TeleportationScroll() : this(1)
		{
		}

		[Constructable]
		public TeleportationScroll(int amount) : base(602, 0x2260, amount)
		{
			Name = "Teleportation";
		}

		public TeleportationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class TornadoScroll : SpellScroll
	{
		[Constructable]
		public TornadoScroll() : this(1)
		{
		}

		[Constructable]
		public TornadoScroll(int amount) : base(603, 0x2260, amount)
		{
			Name = "Tornado";
		}

		public TornadoScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraEvasiveScroll : SpellScroll
	{
		[Constructable]
		public AuraEvasiveScroll() : this(1)
		{
		}

		[Constructable]
		public AuraEvasiveScroll(int amount) : base(604, 0x2260, amount)
		{
			Name = "AuraEvasive";
		}

		public AuraEvasiveScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ExTeleportationScroll : SpellScroll
	{
		[Constructable]
		public ExTeleportationScroll() : this(1)
		{
		}

		[Constructable]
		public ExTeleportationScroll(int amount) : base(605, 0x2260, amount)
		{
			Name = "ExTeleportation";
		}

		public ExTeleportationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ToucheSuffosantScroll : SpellScroll
	{
		[Constructable]
		public ToucheSuffosantScroll() : this(1)
		{
		}

		[Constructable]
		public ToucheSuffosantScroll(int amount) : base(606, 0x2260, amount)
		{
			Name = "Touché suffosant";
		}

		public ToucheSuffosantScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraDeBrouillardScroll : SpellScroll
	{
		[Constructable]
		public AuraDeBrouillardScroll() : this(1)
		{
		}

		[Constructable]
		public AuraDeBrouillardScroll(int amount) : base(607, 0x2260, amount)
		{
			Name = "AuraDeBrouillard";
		}

		public AuraDeBrouillardScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class VentFavorableScroll : SpellScroll
	{
		[Constructable]
		public VentFavorableScroll() : this(1)
		{
		}

		[Constructable]
		public VentFavorableScroll(int amount) : base(608, 0x2260, amount)
		{
			Name = "VentFavorable";
		}

		public VentFavorableScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class VortexScroll : SpellScroll
	{
		[Constructable]
		public VortexScroll() : this(1)
		{
		}

		[Constructable]
		public VortexScroll(int amount) : base(609, 0x2260, amount)
		{
			Name = "Vortex";
		}

		public VortexScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AntidoteScroll : SpellScroll
	{
		[Constructable]
		public AntidoteScroll() : this(1)
		{
		}

		[Constructable]
		public AntidoteScroll(int amount) : base(610, 0x2262, amount)
		{
			Name = "Antidote";
		}

		public AntidoteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MarquerScroll : SpellScroll
	{
		[Constructable]
		public MarquerScroll() : this(1)
		{
		}

		[Constructable]
		public MarquerScroll(int amount) : base(611, 0x2262, amount)
		{
			Name = "Marquer";
		}

		public MarquerScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CompagnonAnimalScroll : SpellScroll
	{
		[Constructable]
		public CompagnonAnimalScroll() : this(1)
		{
		}

		[Constructable]
		public CompagnonAnimalScroll(int amount) : base(612, 0x2262, amount)
		{
			Name = "CompagnonAnimal";
		}

		public CompagnonAnimalScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SoinAnimalierScroll : SpellScroll
	{
		[Constructable]
		public SoinAnimalierScroll() : this(1)
		{
		}

		[Constructable]
		public SoinAnimalierScroll(int amount) : base(613, 0x2262, amount)
		{
			Name = "SoinAnimalier";
		}

		public SoinAnimalierScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class RugissementScroll : SpellScroll
	{
		[Constructable]
		public RugissementScroll() : this(1)
		{
		}

		[Constructable]
		public RugissementScroll(int amount) : base(614, 0x2262, amount)
		{
			Name = "Rugissement";
		}

		public RugissementScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FrappeEnsanglanteeScroll : SpellScroll
	{
		[Constructable]
		public FrappeEnsanglanteeScroll() : this(1)
		{
		}

		[Constructable]
		public FrappeEnsanglanteeScroll(int amount) : base(615, 0x2262, amount)
		{
			Name = "FrappeEnsanglantee";
		}

		public FrappeEnsanglanteeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SautAggressifScroll : SpellScroll
	{
		[Constructable]
		public SautAggressifScroll() : this(1)
		{
		}

		[Constructable]
		public SautAggressifScroll(int amount) : base(616, 0x2262, amount)
		{
			Name = "SautAggressif";
		}

		public SautAggressifScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CoupDansLeGenouScroll : SpellScroll
	{
		[Constructable]
		public CoupDansLeGenouScroll() : this(1)
		{
		}

		[Constructable]
		public CoupDansLeGenouScroll(int amount) : base(617, 0x2262, amount)
		{
			Name = "CoupDansLeGenou";
		}

		public CoupDansLeGenouScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ChasseurDePrimeScroll : SpellScroll
	{
		[Constructable]
		public ChasseurDePrimeScroll() : this(1)
		{
		}

		[Constructable]
		public ChasseurDePrimeScroll(int amount) : base(618, 0x2262, amount)
		{
			Name = "ChasseurDePrime";
		}

		public ChasseurDePrimeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ContratResoluScroll : SpellScroll
	{
		[Constructable]
		public ContratResoluScroll() : this(1)
		{
		}

		[Constructable]
		public ContratResoluScroll(int amount) : base(619, 0x2262, amount)
		{
			Name = "ContratResolu";
		}

		public ContratResoluScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CoupDeBouclierScroll : SpellScroll
	{
		[Constructable]
		public CoupDeBouclierScroll() : this(1)
		{
		}

		[Constructable]
		public CoupDeBouclierScroll(int amount) : base(620, 0x2264, amount)
		{
			Name = "CoupDeBouclier";
		}

		public CoupDeBouclierScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class BravadeScroll : SpellScroll
	{
		[Constructable]
		public BravadeScroll() : this(1)
		{
		}

		[Constructable]
		public BravadeScroll(int amount) : base(621, 0x2264, amount)
		{
			Name = "Bravade";
		}

		public BravadeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class DevotionScroll : SpellScroll
	{
		[Constructable]
		public DevotionScroll() : this(1)
		{
		}

		[Constructable]
		public DevotionScroll(int amount) : base(622, 0x2264, amount)
		{
			Name = "Devotion";
		}

		public DevotionScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MutinerieScroll : SpellScroll
	{
		[Constructable]
		public MutinerieScroll() : this(1)
		{
		}

		[Constructable]
		public MutinerieScroll(int amount) : base(623, 0x2264, amount)
		{
			Name = "Mutinerie";
		}

		public MutinerieScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MentorScroll : SpellScroll
	{
		[Constructable]
		public MentorScroll() : this(1)
		{
		}

		[Constructable]
		public MentorScroll(int amount) : base(624, 0x2264, amount)
		{
			Name = "Mentor";
		}

		public MentorScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class LienDeVieScroll : SpellScroll
	{
		[Constructable]
		public LienDeVieScroll() : this(1)
		{
		}

		[Constructable]
		public LienDeVieScroll(int amount) : base(625, 0x2264, amount)
		{
			Name = "LienDeVie";
		}

		public LienDeVieScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MiracleScroll : SpellScroll
	{
		[Constructable]
		public MiracleScroll() : this(1)
		{
		}

		[Constructable]
		public MiracleScroll(int amount) : base(626, 0x2264, amount)
		{
			Name = "Miracle";
		}

		public MiracleScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class IndomptableScroll : SpellScroll
	{
		[Constructable]
		public IndomptableScroll() : this(1)
		{
		}

		[Constructable]
		public IndomptableScroll(int amount) : base(627, 0x2264, amount)
		{
			Name = "Indomptable";
		}

		public IndomptableScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class InsensibleScroll : SpellScroll
	{
		[Constructable]
		public InsensibleScroll() : this(1)
		{
		}

		[Constructable]
		public InsensibleScroll(int amount) : base(628, 0x2264, amount)
		{
			Name = "Insensible";
		}

		public InsensibleScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class PiedsAuSolScroll : SpellScroll
	{
		[Constructable]
		public PiedsAuSolScroll() : this(1)
		{
		}

		[Constructable]
		public PiedsAuSolScroll(int amount) : base(629, 0x2264, amount)
		{
			Name = "PiedsAuSol";
		}

		public PiedsAuSolScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FortifieScroll : SpellScroll
	{
		[Constructable]
		public FortifieScroll() : this(1)
		{
		}

		[Constructable]
		public FortifieScroll(int amount) : base(630, 0x2266, amount)
		{
			Name = "Fortifie";
		}

		public FortifieScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class RocheScroll : SpellScroll
	{
		[Constructable]
		public RocheScroll() : this(1)
		{
		}

		[Constructable]
		public RocheScroll(int amount) : base(631, 0x2266, amount)
		{
			Name = "Roche";
		}

		public RocheScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ContaminationScroll : SpellScroll
	{
		[Constructable]
		public ContaminationScroll() : this(1)
		{
		}

		[Constructable]
		public ContaminationScroll(int amount) : base(632, 0x2266, amount)
		{
			Name = "Contamination";
		}

		public ContaminationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class EmpalementScroll : SpellScroll
	{
		[Constructable]
		public EmpalementScroll() : this(1)
		{
		}

		[Constructable]
		public EmpalementScroll(int amount) : base(633, 0x2266, amount)
		{
			Name = "Empalement";
		}

		public EmpalementScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraFortifianteScroll : SpellScroll
	{
		[Constructable]
		public AuraFortifianteScroll() : this(1)
		{
		}

		[Constructable]
		public AuraFortifianteScroll(int amount) : base(634, 0x2266, amount)
		{
			Name = "AuraFortifiante";
		}

		public AuraFortifianteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MurDePlanteScroll : SpellScroll
	{
		[Constructable]
		public MurDePlanteScroll() : this(1)
		{
		}

		[Constructable]
		public MurDePlanteScroll(int amount) : base(635, 0x2266, amount)
		{
			Name = "MurDePlante";
		}

		public MurDePlanteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ExplosionDeRocheScroll : SpellScroll
	{
		[Constructable]
		public ExplosionDeRocheScroll() : this(1)
		{
		}

		[Constructable]
		public ExplosionDeRocheScroll(int amount) : base(636, 0x2266, amount)
		{
			Name = "ExplosionDeRoche";
		}

		public ExplosionDeRocheScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraPreservationManiaqueScroll : SpellScroll
	{
		[Constructable]
		public AuraPreservationManiaqueScroll() : this(1)
		{
		}

		[Constructable]
		public AuraPreservationManiaqueScroll(int amount) : base(637, 0x2266, amount)
		{
			Name = "AuraPreservationManiaque";
		}

		public AuraPreservationManiaqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class RacinesScroll : SpellScroll
	{
		[Constructable]
		public RacinesScroll() : this(1)
		{
		}

		[Constructable]
		public RacinesScroll(int amount) : base(638, 0x2266, amount)
		{
			Name = "Racines";
		}

		public RacinesScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FleauTerrestreScroll : SpellScroll
	{
		[Constructable]
		public FleauTerrestreScroll() : this(1)
		{
		}

		[Constructable]
		public FleauTerrestreScroll(int amount) : base(639, 0x2266, amount)
		{
			Name = "FleauTerrestre";
		}

		public FleauTerrestreScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MainCicatrisanteScroll : SpellScroll
	{
		[Constructable]
		public MainCicatrisanteScroll() : this(1)
		{
		}

		[Constructable]
		public MainCicatrisanteScroll(int amount) : base(640, 0x2268, amount)
		{
			Name = "MainCicatrisante";
		}

		public MainCicatrisanteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class RemedeScroll : SpellScroll
	{
		[Constructable]
		public RemedeScroll() : this(1)
		{
		}

		[Constructable]
		public RemedeScroll(int amount) : base(641, 0x2268, amount)
		{
			Name = "Remede";
		}

		public RemedeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MurDePierreScroll : SpellScroll
	{
		[Constructable]
		public MurDePierreScroll() : this(1)
		{
		}

		[Constructable]
		public MurDePierreScroll(int amount) : base(642, 0x2268, amount)
		{
			Name = "MurDePierre";
		}

		public MurDePierreScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class RayonCelesteScroll : SpellScroll
	{
		[Constructable]
		public RayonCelesteScroll() : this(1)
		{
		}

		[Constructable]
		public RayonCelesteScroll(int amount) : base(643, 0x2268, amount)
		{
			Name = "RayonCeleste";
		}

		public RayonCelesteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class LumiereSacreeScroll : SpellScroll
	{
		[Constructable]
		public LumiereSacreeScroll() : this(1)
		{
		}

		[Constructable]
		public LumiereSacreeScroll(int amount) : base(644, 0x2268, amount)
		{
			Name = "LumiereSacree";
		}

		public LumiereSacreeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FrayeurScroll : SpellScroll
	{
		[Constructable]
		public FrayeurScroll() : this(1)
		{
		}

		[Constructable]
		public FrayeurScroll(int amount) : base(645, 0x2268, amount)
		{
			Name = "Frayeur";
		}

		public FrayeurScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FerveurDivineScroll : SpellScroll
	{
		[Constructable]
		public FerveurDivineScroll() : this(1)
		{
		}

		[Constructable]
		public FerveurDivineScroll(int amount) : base(646, 0x2268, amount)
		{
			Name = "FerveurDivine";
		}

		public FerveurDivineScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class InquisitionScroll : SpellScroll
	{
		[Constructable]
		public InquisitionScroll() : this(1)
		{
		}

		[Constructable]
		public InquisitionScroll(int amount) : base(647, 0x2268, amount)
		{
			Name = "Inquisition";
		}

		public InquisitionScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MurDeLumiereScroll : SpellScroll
	{
		[Constructable]
		public MurDeLumiereScroll() : this(1)
		{
		}

		[Constructable]
		public MurDeLumiereScroll(int amount) : base(648, 0x2268, amount)
		{
			Name = "MurDeLumiere";
		}

		public MurDeLumiereScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class DonDeLaVieScroll : SpellScroll
	{
		[Constructable]
		public DonDeLaVieScroll() : this(1)
		{
		}

		[Constructable]
		public DonDeLaVieScroll(int amount) : base(649, 0x2268, amount)
		{
			Name = "DonDeLaVie";
		}

		public DonDeLaVieScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ArmureDeGlaceScroll : SpellScroll
	{
		[Constructable]
		public ArmureDeGlaceScroll() : this(1)
		{
		}

		[Constructable]
		public ArmureDeGlaceScroll(int amount) : base(650, 0x226A, amount)
		{
			Name = "ArmureDeGlace";
		}

		public ArmureDeGlaceScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class RestaurationScroll : SpellScroll
	{
		[Constructable]
		public RestaurationScroll() : this(1)
		{
		}

		[Constructable]
		public RestaurationScroll(int amount) : base(651, 0x226A, amount)
		{
			Name = "Restauration";
		}

		public RestaurationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SoinPreventifScroll : SpellScroll
	{
		[Constructable]
		public SoinPreventifScroll() : this(1)
		{
		}

		[Constructable]
		public SoinPreventifScroll(int amount) : base(652, 0x226A, amount)
		{
			Name = "SoinPreventif";
		}

		public SoinPreventifScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CageDeGlaceScroll : SpellScroll
	{
		[Constructable]
		public CageDeGlaceScroll() : this(1)
		{
		}

		[Constructable]
		public CageDeGlaceScroll(int amount) : base(653, 0x226A, amount)
		{
			Name = "CageDeGlace";
		}

		public CageDeGlaceScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraCryogeniseeScroll : SpellScroll
	{
		[Constructable]
		public AuraCryogeniseeScroll() : this(1)
		{
		}

		[Constructable]
		public AuraCryogeniseeScroll(int amount) : base(654, 0x226A, amount)
		{
			Name = "AuraCryogenisee";
		}

		public AuraCryogeniseeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class PieuxDeGlaceScroll : SpellScroll
	{
		[Constructable]
		public PieuxDeGlaceScroll() : this(1)
		{
		}

		[Constructable]
		public PieuxDeGlaceScroll(int amount) : base(655, 0x226A, amount)
		{
			Name = "PieuxDeGlace";
		}

		public PieuxDeGlaceScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CerveauGeleScroll : SpellScroll
	{
		[Constructable]
		public CerveauGeleScroll() : this(1)
		{
		}

		[Constructable]
		public CerveauGeleScroll(int amount) : base(656, 0x226A, amount)
		{
			Name = "CerveauGele";
		}

		public CerveauGeleScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraRefrigeranteScroll : SpellScroll
	{
		[Constructable]
		public AuraRefrigeranteScroll() : this(1)
		{
		}

		[Constructable]
		public AuraRefrigeranteScroll(int amount) : base(657, 0x226A, amount)
		{
			Name = "AuraRefrigerante";
		}

		public AuraRefrigeranteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AvatarDuFroidScroll : SpellScroll
	{
		[Constructable]
		public AvatarDuFroidScroll() : this(1)
		{
		}

		[Constructable]
		public AvatarDuFroidScroll(int amount) : base(658, 0x226A, amount)
		{
			Name = "AvatarDuFroid";
		}

		public AvatarDuFroidScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class BlizzardScroll : SpellScroll
	{
		[Constructable]
		public BlizzardScroll() : this(1)
		{
		}

		[Constructable]
		public BlizzardScroll(int amount) : base(659, 0x226A, amount)
		{
			Name = "Blizzard";
		}

		public BlizzardScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SecondSouffleScroll : SpellScroll
	{
		[Constructable]
		public SecondSouffleScroll() : this(1)
		{
		}

		[Constructable]
		public SecondSouffleScroll(int amount) : base(660, 0x226C, amount)
		{
			Name = "SecondSouffle";
		}

		public SecondSouffleScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ProvocationScroll : SpellScroll
	{
		[Constructable]
		public ProvocationScroll() : this(1)
		{
		}

		[Constructable]
		public ProvocationScroll(int amount) : base(661, 0x226C, amount)
		{
			Name = "Provocation";
		}

		public ProvocationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SautDevastateurScroll : SpellScroll
	{
		[Constructable]
		public SautDevastateurScroll() : this(1)
		{
		}

		[Constructable]
		public SautDevastateurScroll(int amount) : base(662, 0x226C, amount)
		{
			Name = "SautDevastateur";
		}

		public SautDevastateurScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class DuelScroll : SpellScroll
	{
		[Constructable]
		public DuelScroll() : this(1)
		{
		}

		[Constructable]
		public DuelScroll(int amount) : base(663, 0x226C, amount)
		{
			Name = "Duel";
		}

		public DuelScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ChargeFurieuseScroll : SpellScroll
	{
		[Constructable]
		public ChargeFurieuseScroll() : this(1)
		{
		}

		[Constructable]
		public ChargeFurieuseScroll(int amount) : base(664, 0x226C, amount)
		{
			Name = "ChargeFurieuse";
		}

		public ChargeFurieuseScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class EnrageScroll : SpellScroll
	{
		[Constructable]
		public EnrageScroll() : this(1)
		{
		}

		[Constructable]
		public EnrageScroll(int amount) : base(665, 0x226C, amount)
		{
			Name = "Enrage";
		}

		public EnrageScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class BouclierMagiqueScroll : SpellScroll
	{
		[Constructable]
		public BouclierMagiqueScroll() : this(1)
		{
		}

		[Constructable]
		public BouclierMagiqueScroll(int amount) : base(666, 0x226C, amount)
		{
			Name = "BouclierMagique";
		}

		public BouclierMagiqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CommandementScroll : SpellScroll
	{
		[Constructable]
		public CommandementScroll() : this(1)
		{
		}

		[Constructable]
		public CommandementScroll(int amount) : base(667, 0x226C, amount)
		{
			Name = "Commandement";
		}

		public CommandementScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class PresenceInspiranteScroll : SpellScroll
	{
		[Constructable]
		public PresenceInspiranteScroll() : this(1)
		{
		}

		[Constructable]
		public PresenceInspiranteScroll(int amount) : base(668, 0x226C, amount)
		{
			Name = "PresenceInspirante";
		}

		public PresenceInspiranteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AngeGardienScroll : SpellScroll
	{
		[Constructable]
		public AngeGardienScroll() : this(1)
		{
		}

		[Constructable]
		public AngeGardienScroll(int amount) : base(669, 0x226C, amount)
		{
			Name = "AngeGardien";
		}

		public AngeGardienScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class DiversionScroll : SpellScroll
	{
		[Constructable]
		public DiversionScroll() : this(1)
		{
		}

		[Constructable]
		public DiversionScroll(int amount) : base(670, 0x226E, amount)
		{
			Name = "Diversion";
		}

		public DiversionScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CalmeToiScroll : SpellScroll
	{
		[Constructable]
		public CalmeToiScroll() : this(1)
		{
		}

		[Constructable]
		public CalmeToiScroll(int amount) : base(671, 0x226E, amount)
		{
			Name = "CalmeToi";
		}

		public CalmeToiScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class DesorienterScroll : SpellScroll
	{
		[Constructable]
		public DesorienterScroll() : this(1)
		{
		}

		[Constructable]
		public DesorienterScroll(int amount) : base(672, 0x226E, amount)
		{
			Name = "Desorienter";
		}

		public DesorienterScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	
	public class DefiScroll : SpellScroll
	{
		[Constructable]
		public DefiScroll() : this(1)
		{
		}

		[Constructable]
		public DefiScroll(int amount) : base(673, 0x226E, amount)
		{
			Name = "Defi";
		}

		public DefiScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class DecrescendoManiaqueScroll : SpellScroll
	{
		[Constructable]
		public DecrescendoManiaqueScroll() : this(1)
		{
		}

		[Constructable]
		public DecrescendoManiaqueScroll(int amount) : base(674, 0x226E, amount)
		{
			Name = "DecrescendoManiaque";
		}

		public DecrescendoManiaqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class InspirationElementaireScroll : SpellScroll
	{
		[Constructable]
		public InspirationElementaireScroll() : this(1)
		{
		}

		[Constructable]
		public InspirationElementaireScroll(int amount) : base(675, 0x226E, amount)
		{
			Name = "InspirationElementaire";
		}

		public InspirationElementaireScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AbsorbationSonoreScroll : SpellScroll
	{
		[Constructable]
		public AbsorbationSonoreScroll() : this(1)
		{
		}

		[Constructable]
		public AbsorbationSonoreScroll(int amount) : base(676, 0x226E, amount)
		{
			Name = "AbsorbationSonore";
		}

		public AbsorbationSonoreScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ParfaiteAspirationScroll : SpellScroll
	{
		[Constructable]
		public ParfaiteAspirationScroll() : this(1)
		{
		}

		[Constructable]
		public ParfaiteAspirationScroll(int amount) : base(677, 0x226E, amount)
		{
			Name = "ParfaiteAspiration";
		}

		public ParfaiteAspirationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class RevelationDiscordanteScroll : SpellScroll
	{
		[Constructable]
		public RevelationDiscordanteScroll() : this(1)
		{
		}

		[Constructable]
		public RevelationDiscordanteScroll(int amount) : base(678, 0x226E, amount)
		{
			Name = "RevelationDiscordante";
		}

		public RevelationDiscordanteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class HavreDePaixScroll : SpellScroll
	{
		[Constructable]
		public HavreDePaixScroll() : this(1)
		{
		}

		[Constructable]
		public HavreDePaixScroll(int amount) : base(679, 0x226E, amount)
		{
			Name = "HavreDePaix";
		}

		public HavreDePaixScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SoifDeSangScroll : SpellScroll
	{
		[Constructable]
		public SoifDeSangScroll() : this(1)
		{
		}

		[Constructable]
		public SoifDeSangScroll(int amount) : base(680, 0x2270, amount)
		{
			Name = "SoifDeSang";
		}

		public SoifDeSangScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ToucheAbsorbantScroll : SpellScroll
	{
		[Constructable]
		public ToucheAbsorbantScroll() : this(1)
		{
		}

		[Constructable]
		public ToucheAbsorbantScroll(int amount) : base(681, 0x2270, amount)
		{
			Name = "ToucheAbsorbant";
		}

		public ToucheAbsorbantScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class InfectionScroll : SpellScroll
	{
		[Constructable]
		public InfectionScroll() : this(1)
		{
		}

		[Constructable]
		public InfectionScroll(int amount) : base(682, 0x2270, amount)
		{
			Name = "Infection";
		}

		public InfectionScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ArmureOsScroll : SpellScroll
	{
		[Constructable]
		public ArmureOsScroll() : this(1)
		{
		}

		[Constructable]
		public ArmureOsScroll(int amount) : base(683, 0x2270, amount)
		{
			Name = "ArmureOs";
		}

		public ArmureOsScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FamilierMorbideScroll : SpellScroll
	{
		[Constructable]
		public FamilierMorbideScroll() : this(1)
		{
		}

		[Constructable]
		public FamilierMorbideScroll(int amount) : base(684, 0x2270, amount)
		{
			Name = "FamilierMorbide";
		}

		public FamilierMorbideScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ReanimationScroll : SpellScroll
	{
		[Constructable]
		public ReanimationScroll() : this(1)
		{
		}

		[Constructable]
		public ReanimationScroll(int amount) : base(685, 0x2270, amount)
		{
			Name = "Reanimation";
		}

		public ReanimationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class ConsommationMortelleScroll : SpellScroll
	{
		[Constructable]
		public ConsommationMortelleScroll() : this(1)
		{
		}

		[Constructable]
		public ConsommationMortelleScroll(int amount) : base(686, 0x2270, amount)
		{
			Name = "ConsommationMortelle";
		}

		public ConsommationMortelleScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraVampiriqueScroll : SpellScroll
	{
		[Constructable]
		public AuraVampiriqueScroll() : this(1)
		{
		}

		[Constructable]
		public AuraVampiriqueScroll(int amount) : base(687, 0x2270, amount)
		{
			Name = "AuraVampirique";
		}

		public AuraVampiriqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AppelDuSangScroll : SpellScroll
	{
		[Constructable]
		public AppelDuSangScroll() : this(1)
		{
		}

		[Constructable]
		public AppelDuSangScroll(int amount) : base(688, 0x2270, amount)
		{
			Name = "AppelDuSang";
		}

		public AppelDuSangScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class PluieDeSangScroll : SpellScroll
	{
		[Constructable]
		public PluieDeSangScroll() : this(1)
		{
		}

		[Constructable]
		public PluieDeSangScroll(int amount) : base(689, 0x2270, amount)
		{
			Name = "PluieDeSang";
		}

		public PluieDeSangScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeCycloniqueScroll : SpellScroll
	{
		[Constructable]
		public FormeCycloniqueScroll() : this(1)
		{
		}

		[Constructable]
		public FormeCycloniqueScroll(int amount) : base(690, 0x2272, amount)
		{
			Name = "FormeCyclonique";
		}

		public FormeCycloniqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeMetalliqueScroll : SpellScroll
	{
		[Constructable]
		public FormeMetalliqueScroll() : this(1)
		{
		}

		[Constructable]
		public FormeMetalliqueScroll(int amount) : base(691, 0x2272, amount)
		{
			Name = "FormeMetallique";
		}

		public FormeMetalliqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeTerrestreScroll : SpellScroll
	{
		[Constructable]
		public FormeTerrestreScroll() : this(1)
		{
		}

		[Constructable]
		public FormeTerrestreScroll(int amount) : base(692, 0x2272, amount)
		{
			Name = "FormeTerrestre";
		}

		public FormeTerrestreScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeEmpoisonneeScroll : SpellScroll
	{
		[Constructable]
		public FormeEmpoisonneeScroll() : this(1)
		{
		}

		[Constructable]
		public FormeEmpoisonneeScroll(int amount) : base(693, 0x2272, amount)
		{
			Name = "FormeEmpoisonnee";
		}

		public FormeEmpoisonneeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeGivranteScroll : SpellScroll
	{
		[Constructable]
		public FormeGivranteScroll() : this(1)
		{
		}

		[Constructable]
		public FormeGivranteScroll(int amount) : base(694, 0x2272, amount)
		{
			Name = "FormeGivrante";
		}

		public FormeGivranteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeLiquideScroll : SpellScroll
	{
		[Constructable]
		public FormeLiquideScroll() : this(1)
		{
		}

		[Constructable]
		public FormeLiquideScroll(int amount) : base(695, 0x2272, amount)
		{
			Name = "FormeLiquide";
		}

		public FormeLiquideScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeCristallineScroll : SpellScroll
	{
		[Constructable]
		public FormeCristallineScroll() : this(1)
		{
		}

		[Constructable]
		public FormeCristallineScroll(int amount) : base(696, 0x2272, amount)
		{
			Name = "FormeCristalline";
		}

		public FormeCristallineScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeElectrisanteScroll : SpellScroll
	{
		[Constructable]
		public FormeElectrisanteScroll() : this(1)
		{
		}

		[Constructable]
		public FormeElectrisanteScroll(int amount) : base(697, 0x2272, amount)
		{
			Name = "FormeElectrisante";
		}

		public FormeElectrisanteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeEnflammeeScroll : SpellScroll
	{
		[Constructable]
		public FormeEnflammeeScroll() : this(1)
		{
		}

		[Constructable]
		public FormeEnflammeeScroll(int amount) : base(698, 0x2272, amount)
		{
			Name = "FormeEnflammee";
		}

		public FormeEnflammeeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FormeEnsanglanteeScroll : SpellScroll
	{
		[Constructable]
		public FormeEnsanglanteeScroll() : this(1)
		{
		}

		[Constructable]
		public FormeEnsanglanteeScroll(int amount) : base(699, 0x2272, amount)
		{
			Name = "FormeEnsanglantee";
		}

		public FormeEnsanglanteeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	
	public class BouclierDeFeuScroll : SpellScroll
	{
		[Constructable]
		public BouclierDeFeuScroll() : this(1)
		{
		}

		[Constructable]
		public BouclierDeFeuScroll(int amount) : base(700, 0x2274, amount)
		{
			Name = "BouclierDeFeu";
		}

		public BouclierDeFeuScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class BouleDeFeuScroll : SpellScroll
	{
		[Constructable]
		public BouleDeFeuScroll() : this(1)
		{
		}

		[Constructable]
		public BouleDeFeuScroll(int amount) : base(701, 0x2274, amount)
		{
			Name = "BouleDeFeu";
		}

		public BouleDeFeuScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CeleriteScroll : SpellScroll
	{
		[Constructable]
		public CeleriteScroll() : this(1)
		{
		}

		[Constructable]
		public CeleriteScroll(int amount) : base(702, 0x2274, amount)
		{
			Name = "Celerite";
		}

		public CeleriteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SupernovaScroll : SpellScroll
	{
		[Constructable]
		public SupernovaScroll() : this(1)
		{
		}

		[Constructable]
		public SupernovaScroll(int amount) : base(703, 0x2274, amount)
		{
			Name = "Supernova";
		}

		public SupernovaScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraRechauffanteScroll : SpellScroll
	{
		[Constructable]
		public AuraRechauffanteScroll() : this(1)
		{
		}

		[Constructable]
		public AuraRechauffanteScroll(int amount) : base(704, 0x2274, amount)
		{
			Name = "AuraRechauffante";
		}

		public AuraRechauffanteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FrenesieDouloureuseScroll : SpellScroll
	{
		[Constructable]
		public FrenesieDouloureuseScroll() : this(1)
		{
		}

		[Constructable]
		public FrenesieDouloureuseScroll(int amount) : base(705, 0x2274, amount)
		{
			Name = "FrenesieDouloureuse";
		}

		public FrenesieDouloureuseScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class FolieArdenteScroll : SpellScroll
	{
		[Constructable]
		public FolieArdenteScroll() : this(1)
		{
		}

		[Constructable]
		public FolieArdenteScroll(int amount) : base(706, 0x2274, amount)
		{
			Name = "FolieArdente";
		}

		public FolieArdenteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AuraExaltationScroll : SpellScroll
	{
		[Constructable]
		public AuraExaltationScroll() : this(1)
		{
		}

		[Constructable]
		public AuraExaltationScroll(int amount) : base(707, 0x2274, amount)
		{
			Name = "AuraExaltation";
		}

		public AuraExaltationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CageDeFeuScroll : SpellScroll
	{
		[Constructable]
		public CageDeFeuScroll() : this(1)
		{
		}

		[Constructable]
		public CageDeFeuScroll(int amount) : base(708, 0x2274, amount)
		{
			Name = "CageDeFeu";
		}

		public CageDeFeuScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class PassionArdenteScroll : SpellScroll
	{
		[Constructable]
		public PassionArdenteScroll() : this(1)
		{
		}

		[Constructable]
		public PassionArdenteScroll(int amount) : base(709, 0x2274, amount)
		{
			Name = "PassionArdente";
		}

		public PassionArdenteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AdrenalineScroll : SpellScroll
	{
		[Constructable]
		public AdrenalineScroll() : this(1)
		{
		}

		[Constructable]
		public AdrenalineScroll(int amount) : base(710, 0x2276, amount)
		{
			Name = "Adrenaline";
		}

		public AdrenalineScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SommeilScroll : SpellScroll
	{
		[Constructable]
		public SommeilScroll() : this(1)
		{
		}

		[Constructable]
		public SommeilScroll(int amount) : base(711, 0x2276, amount)
		{
			Name = "Sommeil";
		}

		public SommeilScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class LancerPrecisScroll : SpellScroll
	{
		[Constructable]
		public LancerPrecisScroll() : this(1)
		{
		}

		[Constructable]
		public LancerPrecisScroll(int amount) : base(712, 0x2276, amount)
		{
			Name = "LancerPrecis";
		}

		public LancerPrecisScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CoupArriereScroll : SpellScroll
	{
		[Constructable]
		public CoupArriereScroll() : this(1)
		{
		}

		[Constructable]
		public CoupArriereScroll(int amount) : base(713, 0x2276, amount)
		{
			Name = "CoupArriere";
		}

		public CoupArriereScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class EvasionScroll : SpellScroll
	{
		[Constructable]
		public EvasionScroll() : this(1)
		{
		}

		[Constructable]
		public EvasionScroll(int amount) : base(714, 0x2276, amount)
		{
			Name = "Evasion";
		}

		public EvasionScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AttiranceScroll : SpellScroll
	{
		[Constructable]
		public AttiranceScroll() : this(1)
		{
		}

		[Constructable]
		public AttiranceScroll(int amount) : base(715, 0x2276, amount)
		{
			Name = "Attirance";
		}

		public AttiranceScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MainBlesseeScroll : SpellScroll
	{
		[Constructable]
		public MainBlesseeScroll() : this(1)
		{
		}

		[Constructable]
		public MainBlesseeScroll(int amount) : base(716, 0x2276, amount)
		{
			Name = "MainBlessee";
		}

		public MainBlesseeScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CoupureDesTendonsScroll : SpellScroll
	{
		[Constructable]
		public CoupureDesTendonsScroll() : this(1)
		{
		}

		[Constructable]
		public CoupureDesTendonsScroll(int amount) : base(717, 0x2276, amount)
		{
			Name = "CoupureDesTendons";
		}

		public CoupureDesTendonsScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class GazEndormantScroll : SpellScroll
	{
		[Constructable]
		public GazEndormantScroll() : this(1)
		{
		}

		[Constructable]
		public GazEndormantScroll(int amount) : base(718, 0x2276, amount)
		{
			Name = "GazEndormant";
		}

		public GazEndormantScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class CoupMortelScroll : SpellScroll
	{
		[Constructable]
		public CoupMortelScroll() : this(1)
		{
		}

		[Constructable]
		public CoupMortelScroll(int amount) : base(719, 0x2276, amount)
		{
			Name = "CoupMortel";
		}

		public CoupMortelScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class TotemDeFeuScroll : SpellScroll
	{
		[Constructable]
		public TotemDeFeuScroll() : this(1)
		{
		}

		[Constructable]
		public TotemDeFeuScroll(int amount) : base(720, 0x2278, amount)
		{
			Name = "TotemDeFeu";
		}

		public TotemDeFeuScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class TotemDeauScroll : SpellScroll
	{
		[Constructable]
		public TotemDeauScroll() : this(1)
		{
		}

		[Constructable]
		public TotemDeauScroll(int amount) : base(721, 0x2276, amount)
		{
			Name = "TotemDeau";
		}

		public TotemDeauScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class TotemDeTerreScroll : SpellScroll
	{
		[Constructable]
		public TotemDeTerreScroll() : this(1)
		{
		}

		[Constructable]
		public TotemDeTerreScroll(int amount) : base(722, 0x2276, amount)
		{
			Name = "TotemDeTerre";
		}

		public TotemDeTerreScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class TotemDeVentScroll : SpellScroll
	{
		[Constructable]
		public TotemDeVentScroll() : this(1)
		{
		}

		[Constructable]
		public TotemDeVentScroll(int amount) : base(723, 0x2276, amount)
		{
			Name = "TotemDeVent";
		}

		public TotemDeVentScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AbsorbationScroll : SpellScroll
	{
		[Constructable]
		public AbsorbationScroll() : this(1)
		{
		}

		[Constructable]
		public AbsorbationScroll(int amount) : base(724, 0x2276, amount)
		{
			Name = "Absorbation";
		}

		public AbsorbationScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class LierParEspritScroll : SpellScroll
	{
		[Constructable]
		public LierParEspritScroll() : this(1)
		{
		}

		[Constructable]
		public LierParEspritScroll(int amount) : base(725, 0x2276, amount)
		{
			Name = "LierParEsprit";
		}

		public LierParEspritScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class SuperChargeurScroll : SpellScroll
	{
		[Constructable]
		public SuperChargeurScroll() : this(1)
		{
		}

		[Constructable]
		public SuperChargeurScroll(int amount) : base(726, 0x2276, amount)
		{
			Name = "SuperChargeur";
		}

		public SuperChargeurScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MurTotemiqueScroll : SpellScroll
	{
		[Constructable]
		public MurTotemiqueScroll() : this(1)
		{
		}

		[Constructable]
		public MurTotemiqueScroll(int amount) : base(727, 0x2276, amount)
		{
			Name = "MurTotemique";
		}

		public MurTotemiqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class AppelSpirituelScroll : SpellScroll
	{
		[Constructable]
		public AppelSpirituelScroll() : this(1)
		{
		}

		[Constructable]
		public AppelSpirituelScroll(int amount) : base(728, 0x2276, amount)
		{
			Name = "AppelSpirituel";
		}

		public AppelSpirituelScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
	public class MarcheAsuivreScroll : SpellScroll
	{
		[Constructable]
		public MarcheAsuivreScroll() : this(1)
		{
		}

		[Constructable]
		public MarcheAsuivreScroll(int amount) : base(729, 0x2276, amount)
		{
			Name = "MarcheAsuivre";
		}

		public MarcheAsuivreScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}