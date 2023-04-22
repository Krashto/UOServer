using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Custom.Items.Spells
{
	public abstract class BaseTrainingWand : BaseBashing
	{
		private int m_Charges;

		[CommandProperty(AccessLevel.GameMaster)]
		public int Charges
		{
			get
			{
				return m_Charges;
			}
			set
			{
				m_Charges = value;
				InvalidateProperties();
			}
		}

		[Constructable]
		public BaseTrainingWand() : base(0xDF2)
		{
			Name = "Baguette d'entrainement";
			m_Charges = 100;
			Layer = Layer.OneHanded;
		}

		public BaseTrainingWand(Serial serial) : base(serial)
		{
		}

		public override void AddNameProperties(ObjectPropertyList list)
		{
			base.AddNameProperties(list);

			list.Add($"Compétence: {DefSkill}");
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!from.BeginAction(typeof(BaseTrainingWand)))
			{
				from.SendMessage("Vous devez attendre un peu avant d'utiliser ceci.");
				return;
			}

			from.CheckSkill(DefSkill, 0.0, 50.0);

			var list = new List<string>() 
			{ 
				"Aberto", "Accio", "Aguamenti", "Alohomora", "Anapneo", "Aparecium", "Apparate", "Ascendio", "Avada kedevra", "Avis",
				"Bat-Bogey Hex", "Bombardo", "Brackium Emendo", "Capacious Extremis", "Confundo", "Crinus Muto", "Crucio", "Diffindo", 
				"Disapparate", "Engorgio", "Episke", "Expecto patronum", "Erecto", "Evanesco", "Expelliarmus", "Ferula", 
				"Finite Incantatem", "Furnunculus Curse", "Geminio", "Glisseo", "Homenum Revelio", "Immobulus", "Impedimenta", "Incarcerous", 
				"Imperio", "Impervius", "Incendio", "Langlock", "Legilimens", "Levicorpus", "Locomotor Mortis", "Lumos", "Morsmordre", 
				"Mucus Ad Nauseam", "Muffliato", "Nox", "Obliviate", "Obscuro", "Oculus Reparo", "Oppugno", "Petrificus Totalus", "Periculum", 
				"Piertotum Locomotor", "Protego", "Reducto", "Reducio", "Renneverate", "Reparifors", "Reparo", "Rictusempra", "Riddikulus", 
				"Scourgify", "Sectumsempra", "Serpensortia", "Silencio", "Sonorus", "Spongify", "Stupefy ", "Tarantallegra", "Wingardium Leviosa"
			};

			m_Charges--;

			from.Emote($"[{list[Utility.Random(list.Count - 1)]}]");

			Point3D ourLoc = GetWorldLocation();

			Point3D startLoc = new Point3D(ourLoc.X, ourLoc.Y, ourLoc.Z + 10);
			Point3D endLoc = new Point3D(startLoc.X + Utility.RandomMinMax(-2, 2), startLoc.Y + Utility.RandomMinMax(-2, 2), startLoc.Z + 32);

			Effects.SendMovingEffect(new Entity(Serial.Zero, startLoc, from.Map), new Entity(Serial.Zero, endLoc, from.Map),
				0x36E4, 5, 0, false, false);

			Timer.DelayCall(TimeSpan.FromSeconds(1.0), new TimerStateCallback(FinishLaunch), new object[] { from, endLoc, from.Map });

			Timer.DelayCall(TimeSpan.FromSeconds(2), m => m.EndAction(typeof(BaseTrainingWand)), from);

			if (m_Charges < 0)
			{
				Delete();
				from.SendMessage("Votre baguette se brise.");
			}
		}

		private void FinishLaunch(object state)
		{
			object[] states = (object[])state;

			Mobile from = (Mobile)states[0];
			Point3D endLoc = (Point3D)states[1];
			Map map = (Map)states[2];

			int hue = Utility.Random(40);

			if (hue < 8)
				hue = 0x66D;
			else if (hue < 10)
				hue = 0x482;
			else if (hue < 12)
				hue = 0x47E;
			else if (hue < 16)
				hue = 0x480;
			else if (hue < 20)
				hue = 0x47F;
			else
				hue = 0;

			if (Utility.RandomBool())
				hue = Utility.RandomList(0x47E, 0x47F, 0x480, 0x482, 0x66D);

			int renderMode = Utility.RandomList(0, 2, 3, 4, 5, 7);

			Effects.PlaySound(endLoc, map, Utility.Random(0x11B, 4));
			Effects.SendLocationEffect(endLoc, map, 0x373A + (0x10 * Utility.Random(4)), 16, 10, hue, renderMode);
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version
			writer.Write(m_Charges);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			m_Charges = reader.ReadInt();
		}
	}
}
