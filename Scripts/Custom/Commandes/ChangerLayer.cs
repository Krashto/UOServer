using System;
using Server.Commands;
using Server.Gumps;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Scripts.Commands
{

	public class LayerTarget : Target
	{
		public static Layer[] ValidLayers
		{
			get
			{
				Layer[] lays =
				{
					Layer.Arms,
					Layer.Bracelet,
					Layer.Cloak,
					Layer.Earrings,
					Layer.Gloves,
					Layer.Helm,
					Layer.InnerTorso,
					Layer.MiddleTorso,
					Layer.Neck,
					Layer.OuterLegs,
					Layer.OuterTorso,
					Layer.Pants,
					Layer.Ring,
					Layer.Shirt,
					Layer.Shoes,
					Layer.Talisman,
					Layer.Waist
				};
				return lays;
			}
		}

		public static bool IsValid(Layer lay)
		{
			for (int i = 0; i < ValidLayers.Length; i++)
				if (ValidLayers[i] == lay)
					return true;

			return false;
		}


		public LayerTarget()
			: base(1, false, TargetFlags.None)
		{
			
		}

		protected override void OnTarget(Mobile from, object target)
		{

			if (target is BaseClothing)
			{
				BaseClothing clothing = (BaseClothing)target;

				if ((clothing.RootParent != from) || !(clothing.IsChildOf(from.Backpack)))
				{
					from.SendMessage("Vous devez sélectionner un item dans votre sac et non sur vous.");
					return;
				}

				if (!(IsValid(clothing.Layer)))
				{
					from.SendMessage("Vous devez sélectionner un item avec un layer valide.");
					return;
				}
		
				clothing.Movable = false;

				if (from.HasGump(typeof(LayerChangeGump)))
					from.CloseGump(typeof(LayerChangeGump));

				from.SendGump(new LayerChangeGump(clothing));
			}
			else
				from.SendMessage("Item invalide");
		}
	}



	public class ChangerLayer
    {
        public static void Initialize()
        {
            CommandSystem.Register("ChangerLayer", AccessLevel.Player, new CommandEventHandler(ChangerLayer_OnCommand));
        }

        [Usage("ChangerLayer")]
        [Description("Permet de de changer le layer à un objet.")]
        public static void ChangerLayer_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

			from.SendMessage("Sélectionner un item pour changer son Layer");
			from.Target = new LayerTarget(); // Call our target


		}
    }
}

namespace Server.Gumps
{
	public class LayerChangeGump : Gump
	{
		private BaseClothing m_Cloth;
		private Layer m_Selection;
		private Layer[] m_Layers;

		public LayerChangeGump(BaseClothing cloth) : this(cloth, Layer.Invalid)
		{
		}
		public LayerChangeGump(BaseClothing cloth, Layer selection) : base(50, 50)
		{
			m_Cloth = cloth;
			m_Selection = selection;
			
			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;
			m_Layers = Scripts.Commands.LayerTarget.ValidLayers;

			int space = 25;

			AddBackground();

			for (int i = 1; i < 3; i++)
			{
				AddPage(i);
				for (int j = 0; j < 9; j++)
				{
					if ((m_Layers.Length >= (i - 1) * 9 + j + 1) && (m_Layers[(i - 1) * 9 + j] != m_Selection))
						AddButton(80, 117 + space * j, 1202, 1204, (i - 1) * 9 + j + 1, GumpButtonType.Reply, 0);
				}
				AddBackground(76, 116, 165, 225, 9200);
				for (int j = 0; j < 9; j++)
				{
					if ((m_Layers.Length >= (i - 1) * 9 + j + 1) && (m_Layers[(i - 1) * 9 + j] != m_Selection))
						AddLabel(103, 115 + space * j, 0, m_Layers[(i - 1) * 9 + j].ToString());
				}

				if (i == 1)
					AddButton(213, 341, 5224, 248, 30, GumpButtonType.Page, 2);
				else if (i == 2)
					AddButton(84, 341, 5223, 5223, 40, GumpButtonType.Page, 1);

				if (m_Selection != Layer.Invalid)
					AddButton(139, 372, 247, 248, 50, GumpButtonType.Reply, 0);

				AddButton(42, 372, 242, 243, 0, GumpButtonType.Reply, 0);
			}

		}
		private void AddBackground()
		{
			AddPage(0);
			AddBackground(4, 4, 244, 404, 9200);
			AddItem(18, 138, m_Cloth.ItemID, m_Cloth.Hue);
			AddLabel(49, 12, 0, @"Menu Changement de Layer");
			AddLabel(20, 39, 0, @"Nom de l'Item: " + (String.IsNullOrEmpty(m_Cloth.Name) ? m_Cloth.GetType().Name : m_Cloth.Name));
			AddLabel(13, 62, 0, @"Layer Actuel: " + m_Cloth.Layer.ToString());

			if (m_Selection != Layer.Invalid)
				AddLabel(20, 87, 0, @"Changer Pour: " + m_Selection.ToString());
		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile from = sender.Mobile;

			switch (info.ButtonID)
			{
				case 0:
					{
						m_Cloth.Movable = true;
						break;
					}
				case 50:
					{
						if (m_Selection != Layer.Invalid)
						{
							m_Cloth.Layer = m_Selection;
							m_Cloth.Movable = true;						
						}
						from.SendGump(new LayerChangeGump( m_Cloth, m_Selection ));
						break;
					}
				default:
					{
						if (from.HasGump(typeof(LayerChangeGump)))
							from.CloseGump(typeof(LayerChangeGump));

						from.SendGump(new LayerChangeGump( m_Cloth, m_Layers[info.ButtonID - 1]));
						break;
					}
			}
		}
	}
}