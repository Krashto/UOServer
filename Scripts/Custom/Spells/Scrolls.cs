using System;
using Server;
using Server.Custom;
using Server.Custom.Spells.NewSpells.Aeromancie;
using Server.Custom.Spells.NewSpells.Chasseur;
using Server.Custom.Spells.NewSpells.Defenseur;
using Server.Custom.Spells.NewSpells.Geomancie;
using Server.Custom.Spells.NewSpells.Guerison;
using Server.Custom.Spells.NewSpells.Hydromancie;
using Server.Custom.Spells.NewSpells.Martial;
using Server.Custom.Spells.NewSpells.Musique;
using Server.Custom.Spells.NewSpells.Necromancie;
using Server.Custom.Spells.NewSpells.Polymorphie;
using Server.Custom.Spells.NewSpells.Pyromancie;
using Server.Custom.Spells.NewSpells.Roublardise;
using Server.Custom.Spells.NewSpells.Totemique;
using Server.Engines.Blackthorn;
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
		public AveuglementScroll( int amount ) : base( SpellRegistry.GetSpellIdFromType(typeof(AveuglementSpell)), 0x1F2D, amount )
		{
			Name = "Aveuglement";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public BrouillardScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BrouillardSpell)), 0x1F2D, amount)
		{
			Name = "Brouillard";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public TeleportationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TeleportationSpell)), 0x1F2D, amount)
		{
			Name = "Teleportation";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public TornadoScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TornadoSpell)), 0x1F2D, amount)
		{
			Name = "Tornado";
			Hue = (int)AptitudeColor.Aeromancie;
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
	public class AuraElectrisanteScroll : SpellScroll
	{
		[Constructable]
		public AuraElectrisanteScroll() : this(1)
		{
		}

		[Constructable]
		public AuraElectrisanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraElectrisanteSpell)), 0x1F2D, amount)
		{
			Name = "Aura Electrisante";
			Hue = (int)AptitudeColor.Aeromancie;
		}

		public AuraElectrisanteScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
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
		public ExTeleportationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ExTeleportationSpell)), 0x1F2D, amount)
		{
			Name = "Ex-Teleportation";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public ToucherSuffocantScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ToucherSuffocantSpell)), 0x1F2D, amount)
		{
			Name = "Toucher suffocant";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public AuraDeBrouillardScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraDeBrouillardSpell)), 0x1F2D, amount)
		{
			Name = "Aura De Brouillard";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public VentFavorableScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(VentFavorableSpell)), 0x1F2D, amount)
		{
			Name = "Vent Favorable";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public VortexScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(VortexSpell)), 0x1F2D, amount)
		{
			Name = "Vortex";
			Hue = (int)AptitudeColor.Aeromancie;
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
		public AntidoteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AntidoteSpell)), 0x1F2D, amount)
		{
			Name = "Antidote";
			Hue = (int)AptitudeColor.Chasseur;
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
		public MarquerScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MarquerSpell)), 0x1F2D, amount)
		{
			Name = "Marquer";
			Hue = (int)AptitudeColor.Chasseur;
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
		public CompagnonAnimalScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CompagnonAnimalSpell)), 0x1F2D, amount)
		{
			Name = "Compagnon Animal";
			Hue = (int)AptitudeColor.Chasseur;
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
		public SoinAnimalierScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SoinAnimalierSpell)), 0x1F2D, amount)
		{
			Name = "Soin Animalier";
			Hue = (int)AptitudeColor.Chasseur;
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
		public RugissementScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RugissementSpell)), 0x1F2D, amount)
		{
			Name = "Rugissement";
			Hue = (int)AptitudeColor.Chasseur;
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
		public FrappeEnsanglanteeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FrappeEnsanglanteeSpell)), 0x1F2D, amount)
		{
			Name = "Frappe Ensanglantee";
			Hue = (int)AptitudeColor.Chasseur;
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
		public SautAggressifScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SautAggressifSpell)), 0x1F2D, amount)
		{
			Name = "Saut Aggressif";
			Hue = (int)AptitudeColor.Chasseur;
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
		public CoupDansLeGenouScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupDansLeGenouSpell)), 0x1F2D, amount)
		{
			Name = "Coup Dans Le Genou";
			Hue = (int)AptitudeColor.Chasseur;
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
		public ChasseurDePrimeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ChasseurDePrimeSpell)), 0x1F2D, amount)
		{
			Name = "Chasseur De Prime";
			Hue = (int)AptitudeColor.Chasseur;
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
		public ContratResoluScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ContratResoluSpell)), 0x1F2D, amount)
		{
			Name = "Contrat Resolu";
			Hue = (int)AptitudeColor.Chasseur;
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
	public class InterventionScroll : SpellScroll
	{
		[Constructable]
		public InterventionScroll() : this(1)
		{
		}

		[Constructable]
		public InterventionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InterventionSpell)), 0x1F2D, amount)
		{
			Name = "Intervention";
			Hue = (int)AptitudeColor.Defenseur;
		}

		public InterventionScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
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
		public BravadeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BravadeSpell)), 0x1F2D, amount)
		{
			Name = "Bravade";
			Hue = (int)AptitudeColor.Defenseur;
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
		public DevotionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DevotionSpell)), 0x1F2D, amount)
		{
			Name = "Devotion";
			Hue = (int)AptitudeColor.Defenseur;
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
		public MutinerieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MutinerieSpell)), 0x1F2D, amount)
		{
			Name = "Mutinerie";
			Hue = (int)AptitudeColor.Defenseur;
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
		public MentorScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MentorSpell)), 0x1F2D, amount)
		{
			Name = "Mentor";
			Hue = (int)AptitudeColor.Defenseur;
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
		public LienDeVieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LienDeVieSpell)), 0x1F2D, amount)
		{
			Name = "Lien De Vie";
			Hue = (int)AptitudeColor.Defenseur;
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
		public MiracleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MiracleSpell)), 0x1F2D, amount)
		{
			Name = "Miracle";
			Hue = (int)AptitudeColor.Defenseur;
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
		public IndomptableScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(IndomptableSpell)), 0x1F2D, amount)
		{
			Name = "Indomptable";
			Hue = (int)AptitudeColor.Defenseur;
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
		public InsensibleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InsensibleSpell)), 0x1F2D, amount)
		{
			Name = "Insensible";
			Hue = (int)AptitudeColor.Defenseur;
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
		public PiedsAuSolScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PiedsAuSolSpell)), 0x1F2D, amount)
		{
			Name = "Pieds Au Sol";
			Hue = (int)AptitudeColor.Defenseur;
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
		public FortifieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FortifieSpell)), 0x1F2D, amount)
		{
			Name = "Fortifie";
			Hue = (int)AptitudeColor.Geomancie;
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
		public RocheScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RocheSpell)), 0x1F2D, amount)
		{
			Name = "Roche";
			Hue = (int)AptitudeColor.Geomancie;
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
		public ContaminationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ContaminationSpell)), 0x1F2D, amount)
		{
			Name = "Contamination";
			Hue = (int)AptitudeColor.Geomancie;
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
		public EmpalementScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(EmpalementSpell)), 0x1F2D, amount)
		{
			Name = "Empalement";
			Hue = (int)AptitudeColor.Geomancie;
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
		public AuraFortifianteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraFortifianteSpell)), 0x1F2D, amount)
		{
			Name = "Aura Fortifiante";
			Hue = (int)AptitudeColor.Geomancie;
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
		public MurDePlanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurDePlanteSpell)), 0x1F2D, amount)
		{
			Name = "Mur De Plante";
			Hue = (int)AptitudeColor.Geomancie;
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
		public ExplosionDeRochesScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ExplosionDeRochesSpell)), 0x1F2D, amount)
		{
			Name = "Explosion De Roches";
			Hue = (int)AptitudeColor.Geomancie;
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
	public class AuraPreservationManaiqueScroll : SpellScroll
	{
		[Constructable]
		public AuraPreservationManaiqueScroll() : this(1)
		{
		}

		[Constructable]
		public AuraPreservationManaiqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraPreservationManaiqueSpell)), 0x1F2D, amount)
		{
			Name = "Aura Preservation Manaique";
			Hue = (int)AptitudeColor.Geomancie;
		}

		public AuraPreservationManaiqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
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
		public RacinesScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RacinesSpell)), 0x1F2D, amount)
		{
			Name = "Racines";
			Hue = (int)AptitudeColor.Geomancie;
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
		public FleauTerrestreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FleauTerrestreSpell)), 0x1F2D, amount)
		{
			Name = "Fleau Terrestre";
			Hue = (int)AptitudeColor.Geomancie;
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
		public MainCicatrisanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MainCicatrisanteSpell)), 0x1F2D, amount)
		{
			Name = "Main Cicatrisante";
			Hue = (int)AptitudeColor.Guerison;
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
		public RemedeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RemedeSpell)), 0x1F2D, amount)
		{
			Name = "Remede";
			Hue = (int)AptitudeColor.Guerison;
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
		public MurDePierreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurDePierreSpell)), 0x1F2D, amount)
		{
			Name = "Mur De Pierre";
			Hue = (int)AptitudeColor.Guerison;
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
		public RayonCelesteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RayonCelesteSpell)), 0x1F2D, amount)
		{
			Name = "Rayon Celeste";
			Hue = (int)AptitudeColor.Guerison;
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
		public LumiereSacreeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LumiereSacreeSpell)), 0x1F2D, amount)
		{
			Name = "Lumiere Sacree";
			Hue = (int)AptitudeColor.Guerison;
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
		public FrayeurScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FrayeurSpell)), 0x1F2D, amount)
		{
			Name = "Frayeur";
			Hue = (int)AptitudeColor.Guerison;
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
		public FerveurDivineScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FerveurDivineSpell)), 0x1F2D, amount)
		{
			Name = "Ferveur Divine";
			Hue = (int)AptitudeColor.Guerison;
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
		public InquisitionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InquisitionSpell)), 0x1F2D, amount)
		{
			Name = "Inquisition";
			Hue = (int)AptitudeColor.Guerison;
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
		public MurDeLumiereScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurDeLumiereSpell)), 0x1F2D, amount)
		{
			Name = "Mur De Lumiere";
			Hue = (int)AptitudeColor.Guerison;
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
		public DonDeLaVieScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DonDeLaVieSpell)), 0x1F2D, amount)
		{
			Name = "Don De La Vie";
			Hue = (int)AptitudeColor.Guerison;
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
		public ArmureDeGlaceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ArmureDeGlaceSpell)), 0x1F2D, amount)
		{
			Name = "Armure De Glace";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public RestaurationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RestaurationSpell)), 0x1F2D, amount)
		{
			Name = "Restauration";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public SoinPreventifScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SoinPreventifSpell)), 0x1F2D, amount)
		{
			Name = "Soin Preventif";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public CageDeGlaceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CageDeGlaceSpell)), 0x1F2D, amount)
		{
			Name = "Cage De Glace";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public AuraCryogeniseeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraCryogeniseeSpell)), 0x1F2D, amount)
		{
			Name = "Aura Cryogenisee";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public PieuxDeGlaceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PieuxDeGlaceSpell)), 0x1F2D, amount)
		{
			Name = "Pieux De Glace";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public CerveauGeleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CerveauGeleSpell)), 0x1F2D, amount)
		{
			Name = "Cerveau Gele";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public AuraRefrigeranteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraRefrigeranteSpell)), 0x1F2D, amount)
		{
			Name = "Aura Refrigerante";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public AvatarDuFroidScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AvatarDuFroidSpell)), 0x1F2D, amount)
		{
			Name = "Avatar Du Froid";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public BlizzardScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BlizzardSpell)), 0x1F2D, amount)
		{
			Name = "Blizzard";
			Hue = (int)AptitudeColor.Hydromancie;
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
		public SecondSouffleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SecondSouffleSpell)), 0x1F2D, amount)
		{
			Name = "Second Souffle";
			Hue = (int)AptitudeColor.Martial;
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
		public ProvocationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ProvocationSpell)), 0x1F2D, amount)
		{
			Name = "Provocation";
			Hue = (int)AptitudeColor.Martial;
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
		public SautDevastateurScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SautDevastateurSpell)), 0x1F2D, amount)
		{
			Name = "Saut Devastateur";
			Hue = (int)AptitudeColor.Martial;
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
		public DuelScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DuelSpell)), 0x1F2D, amount)
		{
			Name = "Duel";
			Hue = (int)AptitudeColor.Martial;
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
		public ChargeFurieuseScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ChargeFurieuseSpell)), 0x1F2D, amount)
		{
			Name = "Charge Furieuse";
			Hue = (int)AptitudeColor.Martial;
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
		public EnrageScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(EnrageSpell)), 0x1F2D, amount)
		{
			Name = "Enrage";
			Hue = (int)AptitudeColor.Martial;
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
		public BouclierMagiqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BouclierMagiqueSpell)), 0x1F2D, amount)
		{
			Name = "Bouclier Magique";
			Hue = (int)AptitudeColor.Martial;
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
		public CommandementScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CommandementSpell)), 0x1F2D, amount)
		{
			Name = "Commandement";
			Hue = (int)AptitudeColor.Martial;
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
		public PresenceInspiranteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PresenceInspiranteSpell)), 0x1F2D, amount)
		{
			Name = "Presence Inspirante";
			Hue = (int)AptitudeColor.Martial;
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
		public AngeGardienScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AngeGardienSpell)), 0x1F2D, amount)
		{
			Name = "Ange Gardien";
			Hue = (int)AptitudeColor.Martial;
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
		public DiversionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DiversionSpell)), 0x1F2D, amount)
		{
			Name = "Diversion";
			Hue = (int)AptitudeColor.Musique;
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
		public CalmeToiScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CalmeToiSpell)), 0x1F2D, amount)
		{
			Name = "Calme-Toi";
			Hue = (int)AptitudeColor.Musique;
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
		public DesorienterScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DesorienterSpell)), 0x1F2D, amount)
		{
			Name = "Desorienter";
			Hue = (int)AptitudeColor.Musique;
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
		public DefiScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DefiSpell)), 0x1F2D, amount)
		{
			Name = "Defi";
			Hue = (int)AptitudeColor.Musique;
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
	public class DecrescendoManaiqueScroll : SpellScroll
	{
		[Constructable]
		public DecrescendoManaiqueScroll() : this(1)
		{
		}

		[Constructable]
		public DecrescendoManaiqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(DecrescendoManaiqueSpell)), 0x1F2D, amount)
		{
			Name = "Decrescendo Manaique";
			Hue = (int)AptitudeColor.Musique;
		}

		public DecrescendoManaiqueScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
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
		public InspirationElementaireScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InspirationElementaireSpell)), 0x1F2D, amount)
		{
			Name = "Inspiration Elementaire";
			Hue = (int)AptitudeColor.Musique;
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
		public AbsorbationSonoreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AbsorbationSonoreSpell)), 0x1F2D, amount)
		{
			Name = "Absorbation Sonore";
			Hue = (int)AptitudeColor.Musique;
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
		public ParfaiteAspirationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ParfaiteAspirationSpell)), 0x1F2D, amount)
		{
			Name = "Parfaite Aspiration";
			Hue = (int)AptitudeColor.Musique;
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
		public RevelationDiscordanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(RevelationDiscordanteSpell)), 0x1F2D, amount)
		{
			Name = "Revelation Discordante";
			Hue = (int)AptitudeColor.Musique;
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
		public HavreDePaixScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(HavreDePaixSpell)), 0x1F2D, amount)
		{
			Name = "Havre De Paix";
			Hue = (int)AptitudeColor.Musique;
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
		public SoifDeSangScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SoifDeSangSpell)), 0x1F2D, amount)
		{
			Name = "Soif De Sang";
			Hue = (int)AptitudeColor.Necromancie;
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
		public ToucheAbsorbantScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ToucheAbsorbantSpell)), 0x1F2D, amount)
		{
			Name = "Touche Absorbant";
			Hue = (int)AptitudeColor.Necromancie;
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
		public InfectionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(InfectionSpell)), 0x1F2D, amount)
		{
			Name = "Infection";
			Hue = (int)AptitudeColor.Necromancie;
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
		public ArmureOsScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ArmureOsSpell)), 0x1F2D, amount)
		{
			Name = "Armure d'Os";
			Hue = (int)AptitudeColor.Necromancie;
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
		public FamilierMorbideScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FamilierMorbideSpell)), 0x1F2D, amount)
		{
			Name = "Familier Morbide";
			Hue = (int)AptitudeColor.Necromancie;
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
		public ReanimationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ReanimationSpell)), 0x1F2D, amount)
		{
			Name = "Reanimation";
			Hue = (int)AptitudeColor.Necromancie;
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
		public ConsommationMortelleScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(ConsommationMortelleSpell)), 0x1F2D, amount)
		{
			Name = "Consommation Mortelle";
			Hue = (int)AptitudeColor.Necromancie;
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
		public AuraVampiriqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraVampiriqueSpell)), 0x1F2D, amount)
		{
			Name = "Aura Vampirique";
			Hue = (int)AptitudeColor.Necromancie;
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
		public AppelDuSangScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AppelDuSangSpell)), 0x1F2D, amount)
		{
			Name = "Appel Du Sang";
			Hue = (int)AptitudeColor.Necromancie;
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
		public PluieDeSangScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PluieDeSangSpell)), 0x1F2D, amount)
		{
			Name = "Pluie De Sang";
			Hue = (int)AptitudeColor.Necromancie;
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
		public FormeCycloniqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeCycloniqueSpell)), 0x1F2D, amount)
		{
			Name = "Forme Cyclonique";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeMetalliqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeMetalliqueSpell)), 0x1F2D, amount)
		{
			Name = "Forme Metallique";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeTerrestreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeTerrestreSpell)), 0x1F2D, amount)
		{
			Name = "Forme Terrestre";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeEmpoisonneeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeEmpoisonneeSpell)), 0x1F2D, amount)
		{
			Name = "Forme Empoisonnee";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeGivranteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeGivranteSpell)), 0x1F2D, amount)
		{
			Name = "Forme Givrante";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeLiquideScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeLiquideSpell)), 0x1F2D, amount)
		{
			Name = "Forme Liquide";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeCristallineScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeCristallineSpell)), 0x1F2D, amount)
		{
			Name = "Forme Cristalline";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeElectrisanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeElectrisanteSpell)), 0x1F2D, amount)
		{
			Name = "Forme Electrisante";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeEnflammeeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeEnflammeeSpell)), 0x1F2D, amount)
		{
			Name = "Forme Enflammee";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public FormeEnsanglanteeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FormeEnsanglanteeSpell)), 0x1F2D, amount)
		{
			Name = "Forme Ensanglantee";
			Hue = (int)AptitudeColor.Polymorphie;
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
		public BouclierDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BouclierDeFeuSpell)), 0x1F2D, amount)
		{
			Name = "Bouclier De Feu";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public BouleDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(BouleDeFeuSpell)), 0x1F2D, amount)
		{
			Name = "Boule De Feu";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public CeleriteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CeleriteSpell)), 0x1F2D, amount)
		{
			Name = "Celerite";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public SupernovaScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SupernovaSpell)), 0x1F2D, amount)
		{
			Name = "Supernova";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public AuraRechauffanteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraRechauffanteSpell)), 0x1F2D, amount)
		{
			Name = "Aura Rechauffante";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public FrenesieDouloureuseScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FrenesieDouloureuseSpell)), 0x1F2D, amount)
		{
			Name = "Frenesie Douloureuse";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public FolieArdenteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(FolieArdenteSpell)), 0x1F2D, amount)
		{
			Name = "Folie Ardente";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public AuraExaltationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AuraExaltationSpell)), 0x1F2D, amount)
		{
			Name = "Aura Exaltation";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public CageDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CageDeFeuSpell)), 0x1F2D, amount)
		{
			Name = "Cage De Feu";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public PassionArdenteScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(PassionArdenteSpell)), 0x1F2D, amount)
		{
			Name = "Passion Ardente";
			Hue = (int)AptitudeColor.Pyromancie;
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
		public AdrenalineScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AdrenalineSpell)), 0x1F2D, amount)
		{
			Name = "Adrenaline";
			Hue = (int)AptitudeColor.Roublardise;
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
		public SommeilScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SommeilSpell)), 0x1F2D, amount)
		{
			Name = "Sommeil";
			Hue = (int)AptitudeColor.Roublardise;
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
		public LancerPrecisScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LancerPrecisSpell)), 0x1F2D, amount)
		{
			Name = "Lancer Precis";
			Hue = (int)AptitudeColor.Roublardise;
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
		public CoupArriereScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupArriereSpell)), 0x1F2D, amount)
		{
			Name = "Coup Arriere";
			Hue = (int)AptitudeColor.Roublardise;
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
		public EvasionScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(EvasionSpell)), 0x1F2D, amount)
		{
			Name = "Evasion";
			Hue = (int)AptitudeColor.Roublardise;
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
		public AttiranceScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AttiranceSpell)), 0x1F2D, amount)
		{
			Name = "Attirance";
			Hue = (int)AptitudeColor.Roublardise;
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
		public MainBlesseeScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MainBlesseeSpell)), 0x1F2D, amount)
		{
			Name = "Main Blessee";
			Hue = (int)AptitudeColor.Roublardise;
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
		public CoupureDesTendonsScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupureDesTendonsSpell)), 0x1F2D, amount)
		{
			Name = "Coupure Des Tendons";
			Hue = (int)AptitudeColor.Roublardise;
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
		public GazEndormantScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(GazEndormantSpell)), 0x1F2D, amount)
		{
			Name = "Gaz Endormant";
			Hue = (int)AptitudeColor.Roublardise;
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
		public CoupMortelScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(CoupMortelSpell)), 0x1F2D, amount)
		{
			Name = "Coup Mortel";
			Hue = (int)AptitudeColor.Roublardise;
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
		public TotemDeFeuScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDeFeuSpell)), 0x1F2D, amount)
		{
			Name = "Totem De Feu";
			Hue = (int)AptitudeColor.Totemique;
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
		public TotemDeauScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDeauSpell)), 0x1F2D, amount)
		{
			Name = "Totem D'eau";
			Hue = (int)AptitudeColor.Totemique;
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
		public TotemDeTerreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDeTerreSpell)), 0x1F2D, amount)
		{
			Name = "Totem De Terre";
			Hue = (int)AptitudeColor.Totemique;
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
	public class TotemDuVentScroll : SpellScroll
	{
		[Constructable]
		public TotemDuVentScroll() : this(1)
		{
		}

		[Constructable]
		public TotemDuVentScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(TotemDuVentSpell)), 0x1F2D, amount)
		{
			Name = "Totem Du Vent";
			Hue = (int)AptitudeColor.Totemique;
		}

		public TotemDuVentScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
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
		public AbsorbationScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AbsorbationSpell)), 0x1F2D, amount)
		{
			Name = "Absorbation";
			Hue = (int)AptitudeColor.Totemique;
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
		public LierParEspritScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(LierParEspritSpell)), 0x1F2D, amount)
		{
			Name = "Lier Par Esprit";
			Hue = (int)AptitudeColor.Totemique;
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
	public class SuperChargerScroll : SpellScroll
	{
		[Constructable]
		public SuperChargerScroll() : this(1)
		{
		}

		[Constructable]
		public SuperChargerScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(SuperChargerSpell)), 0x1F2D, amount)
		{
			Name = "Super Charger";
			Hue = (int)AptitudeColor.Totemique;
		}

		public SuperChargerScroll(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
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
		public MurTotemiqueScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MurTotemiqueSpell)), 0x1F2D, amount)
		{
			Name = "Mur Totemique";
			Hue = (int)AptitudeColor.Totemique;
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
		public AppelSpirituelScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(AppelSpirituelSpell)), 0x1F2D, amount)
		{
			Name = "Appel Spirituel";
			Hue = (int)AptitudeColor.Totemique;
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
		public MarcheAsuivreScroll(int amount) : base(SpellRegistry.GetSpellIdFromType(typeof(MarcheAsuivreSpell)), 0x1F2D, amount)
		{
			Name = "Marche A Suivre";
			Hue = (int)AptitudeColor.Totemique;
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