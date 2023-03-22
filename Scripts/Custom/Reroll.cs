#region References
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
#endregion

namespace Server
{
    [Parsable]
    public class Reroll
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public double Experience { get; set; }

		public Reroll()
        {
        }

        public Reroll(CustomPlayerMobile pm)
        {
            Name = pm.Name;
			Experience = pm.Experience.Exp;
        }
    }
}
