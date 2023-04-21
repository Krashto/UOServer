using System;
using Server;
using Server.Custom.Spells.NewSpells.Aeromancie;
using Server.Spells;

namespace Server.Items
{
	public class AveuglementScroll : SpellScroll
	{
		[Constructable]
		public AveuglementScroll() : this( 1 )
		{
		}

		[Constructable]
		public AveuglementScroll( int amount ) : base( SpellRegistry.GetSpellIdFromType(typeof(AveuglementSpell)), 0x2260, amount )
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
		public BrouillardScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BrouillardSpell)), 0x2260, amount)
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
		public TeleportationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TeleportationSpell)), 0x2260, amount)
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
		public TornadoScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TornadoSpell)), 0x2260, amount)
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
		public AuraEvasiveScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraEvasiveSpell)), 0x2260, amount)
		{
			Name = "Aura Evasive";
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
		public ExTeleportationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ExTeleportationSpell)), 0x2260, amount)
		{
			Name = "Ex-Teleportation";
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
	public class ToucherSuffocantScroll : SpellScroll
	{
		[Constructable]
		public ToucherSuffocantScroll() : this(1)
		{
		}

		[Constructable]
		public ToucherSuffocantScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ToucherSuffocantSpell)), 0x2260, amount)
		{
			Name = "Toucher suffocant";
		}

		public ToucherSuffocantScroll(Serial serial) : base(serial)
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
		public AuraDeBrouillardScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraDeBrouillardSpell)), 0x2260, amount)
		{
			Name = "Aura De Brouillard";
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
		public VentFavorableScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(VentFavorableSpell)), 0x2260, amount)
		{
			Name = "Vent Favorable";
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
		public VortexScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(VortexSpell)), 0x2260, amount)
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
		public AntidoteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AntidoteScroll)), 0x2262, amount)
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
		public MarquerScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MarquerScroll)), 0x2262, amount)
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
		public CompagnonAnimalScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CompagnonAnimalScroll)), 0x2262, amount)
		{
			Name = "Compagnon Animal";
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
		public SoinAnimalierScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SoinAnimalierScroll)), 0x2262, amount)
		{
			Name = "Soin Animalier";
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
		public RugissementScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RugissementScroll)), 0x2262, amount)
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
		public FrappeEnsanglanteeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FrappeEnsanglanteeScroll)), 0x2262, amount)
		{
			Name = "Frappe Ensanglantee";
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
		public SautAggressifScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SautAggressifScroll)), 0x2262, amount)
		{
			Name = "Saut Aggressif";
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
		public CoupDansLeGenouScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupDansLeGenouScroll)), 0x2262, amount)
		{
			Name = "Coup Dans Le Genou";
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
		public ChasseurDePrimeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ChasseurDePrimeScroll)), 0x2262, amount)
		{
			Name = "Chasseur De Prime";
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
		public ContratResoluScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ContratResoluScroll)), 0x2262, amount)
		{
			Name = "Contrat Resolu";
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
		public CoupDeBouclierScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupDeBouclierScroll)), 0x2264, amount)
		{
			Name = "Coup De Bouclier";
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
		public BravadeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BravadeScroll)), 0x2264, amount)
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
		public DevotionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DevotionScroll)), 0x2264, amount)
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
		public MutinerieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MutinerieScroll)), 0x2264, amount)
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
		public MentorScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MentorScroll)), 0x2264, amount)
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
		public LienDeVieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LienDeVieScroll)), 0x2264, amount)
		{
			Name = "Lien De Vie";
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
		public MiracleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MiracleScroll)), 0x2264, amount)
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
		public IndomptableScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(IndomptableScroll)), 0x2264, amount)
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
		public InsensibleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InsensibleScroll)), 0x2264, amount)
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
		public PiedsAuSolScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PiedsAuSolScroll)), 0x2264, amount)
		{
			Name = "Pieds Au Sol";
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
		public FortifieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FortifieScroll)), 0x2266, amount)
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
		public RocheScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RocheScroll)), 0x2266, amount)
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
		public ContaminationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ContaminationScroll)), 0x2266, amount)
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
		public EmpalementScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(EmpalementScroll)), 0x2266, amount)
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
		public AuraFortifianteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraFortifianteScroll)), 0x2266, amount)
		{
			Name = "Aura Fortifiante";
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
		public MurDePlanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurDePlanteScroll)), 0x2266, amount)
		{
			Name = "Mur De Plante";
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
	public class ExplosionDeRochesScroll : SpellScroll
	{
		[Constructable]
		public ExplosionDeRochesScroll() : this(1)
		{
		}

		[Constructable]
		public ExplosionDeRochesScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ExplosionDeRochesScroll)), 0x2266, amount)
		{
			Name = "Explosion De Roches";
		}

		public ExplosionDeRochesScroll(Serial serial) : base(serial)
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
		public AuraPreservationManiaqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraPreservationManiaqueScroll)), 0x2266, amount)
		{
			Name = "Aura Preservation Maniaque";
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
		public RacinesScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RacinesScroll)), 0x2266, amount)
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
		public FleauTerrestreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FleauTerrestreScroll)), 0x2266, amount)
		{
			Name = "Fleau Terrestre";
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
		public MainCicatrisanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MainCicatrisanteScroll)), 0x2268, amount)
		{
			Name = "Main Cicatrisante";
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
		public RemedeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RemedeScroll)), 0x2268, amount)
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
		public MurDePierreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurDePierreScroll)), 0x2268, amount)
		{
			Name = "Mur De Pierre";
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
		public RayonCelesteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RayonCelesteScroll)), 0x2268, amount)
		{
			Name = "Rayon Celeste";
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
		public LumiereSacreeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LumiereSacreeScroll)), 0x2268, amount)
		{
			Name = "Lumiere Sacree";
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
		public FrayeurScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FrayeurScroll)), 0x2268, amount)
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
		public FerveurDivineScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FerveurDivineScroll)), 0x2268, amount)
		{
			Name = "Ferveur Divine";
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
		public InquisitionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InquisitionScroll)), 0x2268, amount)
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
		public MurDeLumiereScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurDeLumiereScroll)), 0x2268, amount)
		{
			Name = "Mur De Lumiere";
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
		public DonDeLaVieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DonDeLaVieScroll)), 0x2268, amount)
		{
			Name = "Don De La Vie";
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
		public ArmureDeGlaceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ArmureDeGlaceScroll)), 0x226A, amount)
		{
			Name = "Armure De Glace";
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
		public RestaurationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RestaurationScroll)), 0x226A, amount)
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
		public SoinPreventifScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SoinPreventifScroll)), 0x226A, amount)
		{
			Name = "Soin Preventif";
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
		public CageDeGlaceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CageDeGlaceScroll)), 0x226A, amount)
		{
			Name = "Cage De Glace";
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
		public AuraCryogeniseeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraCryogeniseeScroll)), 0x226A, amount)
		{
			Name = "Aura Cryogenisee";
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
		public PieuxDeGlaceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PieuxDeGlaceScroll)), 0x226A, amount)
		{
			Name = "Pieux De Glace";
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
		public CerveauGeleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CerveauGeleScroll)), 0x226A, amount)
		{
			Name = "Cerveau Gele";
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
		public AuraRefrigeranteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraRefrigeranteScroll)), 0x226A, amount)
		{
			Name = "Aura Refrigerante";
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
		public AvatarDuFroidScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AvatarDuFroidScroll)), 0x226A, amount)
		{
			Name = "Avatar Du Froid";
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
		public BlizzardScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BlizzardScroll)), 0x226A, amount)
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
		public SecondSouffleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SecondSouffleScroll)), 0x226C, amount)
		{
			Name = "Second Souffle";
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
		public ProvocationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ProvocationScroll)), 0x226C, amount)
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
		public SautDevastateurScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SautDevastateurScroll)), 0x226C, amount)
		{
			Name = "Saut Devastateur";
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
		public DuelScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DuelScroll)), 0x226C, amount)
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
		public ChargeFurieuseScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ChargeFurieuseScroll)), 0x226C, amount)
		{
			Name = "Charge Furieuse";
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
		public EnrageScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(EnrageScroll)), 0x226C, amount)
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
		public BouclierMagiqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BouclierMagiqueScroll)), 0x226C, amount)
		{
			Name = "Bouclier Magique";
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
		public CommandementScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CommandementScroll)), 0x226C, amount)
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
		public PresenceInspiranteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PresenceInspiranteScroll)), 0x226C, amount)
		{
			Name = "Presence Inspirante";
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
		public AngeGardienScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AngeGardienScroll)), 0x226C, amount)
		{
			Name = "Ange Gardien";
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
		public DiversionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DiversionScroll)), 0x226E, amount)
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
		public CalmeToiScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CalmeToiScroll)), 0x226E, amount)
		{
			Name = "Calme-Toi";
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
		public DesorienterScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DesorienterScroll)), 0x226E, amount)
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
		public DefiScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DefiScroll)), 0x226E, amount)
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
		public DecrescendoManiaqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DecrescendoManiaqueScroll)), 0x226E, amount)
		{
			Name = "Decrescendo Maniaque";
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
		public InspirationElementaireScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InspirationElementaireScroll)), 0x226E, amount)
		{
			Name = "Inspiration Elementaire";
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
		public AbsorbationSonoreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AbsorbationSonoreScroll)), 0x226E, amount)
		{
			Name = "Absorbation Sonore";
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
		public ParfaiteAspirationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ParfaiteAspirationScroll)), 0x226E, amount)
		{
			Name = "Parfaite Aspiration";
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
		public RevelationDiscordanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RevelationDiscordanteScroll)), 0x226E, amount)
		{
			Name = "Revelation Discordante";
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
		public HavreDePaixScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(HavreDePaixScroll)), 0x226E, amount)
		{
			Name = "Havre De Paix";
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
		public SoifDeSangScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SoifDeSangScroll)), 0x2270, amount)
		{
			Name = "Soif De Sang";
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
		public ToucheAbsorbantScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ToucheAbsorbantScroll)), 0x2270, amount)
		{
			Name = "Touche Absorbant";
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
		public InfectionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InfectionScroll)), 0x2270, amount)
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
		public ArmureOsScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ArmureOsScroll)), 0x2270, amount)
		{
			Name = "Armure d'Os";
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
		public FamilierMorbideScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FamilierMorbideScroll)), 0x2270, amount)
		{
			Name = "Familier Morbide";
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
		public ReanimationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ReanimationScroll)), 0x2270, amount)
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
		public ConsommationMortelleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ConsommationMortelleScroll)), 0x2270, amount)
		{
			Name = "Consommation Mortelle";
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
		public AuraVampiriqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraVampiriqueScroll)), 0x2270, amount)
		{
			Name = "Aura Vampirique";
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
		public AppelDuSangScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AppelDuSangScroll)), 0x2270, amount)
		{
			Name = "Appel Du Sang";
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
		public PluieDeSangScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PluieDeSangScroll)), 0x2270, amount)
		{
			Name = "Pluie De Sang";
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
		public FormeCycloniqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeCycloniqueScroll)), 0x2272, amount)
		{
			Name = "Forme Cyclonique";
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
		public FormeMetalliqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeMetalliqueScroll)), 0x2272, amount)
		{
			Name = "Forme Metallique";
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
		public FormeTerrestreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeTerrestreScroll)), 0x2272, amount)
		{
			Name = "Forme Terrestre";
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
		public FormeEmpoisonneeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeEmpoisonneeScroll)), 0x2272, amount)
		{
			Name = "Forme Empoisonnee";
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
		public FormeGivranteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeGivranteScroll)), 0x2272, amount)
		{
			Name = "Forme Givrante";
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
		public FormeLiquideScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeLiquideScroll)), 0x2272, amount)
		{
			Name = "Forme Liquide";
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
		public FormeCristallineScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeCristallineScroll)), 0x2272, amount)
		{
			Name = "Forme Cristalline";
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
		public FormeElectrisanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeElectrisanteScroll)), 0x2272, amount)
		{
			Name = "Forme Electrisante";
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
		public FormeEnflammeeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeEnflammeeScroll)), 0x2272, amount)
		{
			Name = "Forme Enflammee";
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
		public FormeEnsanglanteeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeEnsanglanteeScroll)), 0x2272, amount)
		{
			Name = "Forme Ensanglantee";
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
		public BouclierDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BouclierDeFeuScroll)), 0x2274, amount)
		{
			Name = "Bouclier De Feu";
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
		public BouleDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BouleDeFeuScroll)), 0x2274, amount)
		{
			Name = "Boule De Feu";
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
		public CeleriteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CeleriteScroll)), 0x2274, amount)
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
		public SupernovaScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SupernovaScroll)), 0x2274, amount)
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
		public AuraRechauffanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraRechauffanteScroll)), 0x2274, amount)
		{
			Name = "Aura Rechauffante";
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
		public FrenesieDouloureuseScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FrenesieDouloureuseScroll)), 0x2274, amount)
		{
			Name = "Frenesie Douloureuse";
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
		public FolieArdenteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FolieArdenteScroll)), 0x2274, amount)
		{
			Name = "Folie Ardente";
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
		public AuraExaltationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraExaltationScroll)), 0x2274, amount)
		{
			Name = "Aura Exaltation";
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
		public CageDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CageDeFeuScroll)), 0x2274, amount)
		{
			Name = "Cage De Feu";
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
		public PassionArdenteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PassionArdenteScroll)), 0x2274, amount)
		{
			Name = "Passion Ardente";
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
		public AdrenalineScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AdrenalineScroll)), 0x2276, amount)
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
		public SommeilScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SommeilScroll)), 0x2276, amount)
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
		public LancerPrecisScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LancerPrecisScroll)), 0x2276, amount)
		{
			Name = "Lancer Precis";
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
		public CoupArriereScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupArriereScroll)), 0x2276, amount)
		{
			Name = "Coup Arriere";
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
		public EvasionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(EvasionScroll)), 0x2276, amount)
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
		public AttiranceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AttiranceScroll)), 0x2276, amount)
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
		public MainBlesseeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MainBlesseeScroll)), 0x2276, amount)
		{
			Name = "Main Blessee";
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
		public CoupureDesTendonsScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupureDesTendonsScroll)), 0x2276, amount)
		{
			Name = "Coupure Des Tendons";
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
		public GazEndormantScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(GazEndormantScroll)), 0x2276, amount)
		{
			Name = "Gaz Endormant";
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
		public CoupMortelScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupMortelScroll)), 0x2276, amount)
		{
			Name = "Coup Mortel";
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
		public TotemDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDeFeuScroll)), 0x2278, amount)
		{
			Name = "Totem De Feu";
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
		public TotemDeauScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDeauScroll)), 0x2276, amount)
		{
			Name = "Totem D'eau";
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
		public TotemDeTerreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDeTerreScroll)), 0x2276, amount)
		{
			Name = "Totem De Terre";
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
		public TotemDeVentScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDeVentScroll)), 0x2276, amount)
		{
			Name = "Totem De Vent";
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
		public AbsorbationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AbsorbationScroll)), 0x2276, amount)
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
		public LierParEspritScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LierParEspritScroll)), 0x2276, amount)
		{
			Name = "Lier Par Esprit";
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
		public SuperChargeurScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SuperChargeurScroll)), 0x2276, amount)
		{
			Name = "Super Chargeur";
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
		public MurTotemiqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurTotemiqueScroll)), 0x2276, amount)
		{
			Name = "Mur Totemique";
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
		public AppelSpirituelScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AppelSpirituelScroll)), 0x2276, amount)
		{
			Name = "Appel Spirituel";
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
		public MarcheAsuivreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MarcheAsuivreScroll)), 0x2276, amount)
		{
			Name = "Marche A Suivre";
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