using System;
using System.Collections.Generic;

namespace Server.Mobiles 
{ 
    public class BeekeeperExp : BaseVendor 
    { 
        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();
        [Constructable]
        public BeekeeperExp()
            : base("Apiculteur")
        { 
        }

        public BeekeeperExp(Serial serial)
            : base(serial)
        { 
        }

        public override VendorShoeType ShoeType
        {
            get
            {
                return VendorShoeType.Boots;
            }
        }
        protected override List<SBInfo> SBInfos
        {
            get
            {
                return this.m_SBInfos;
            }
        }
        public override void InitSBInfo() 
        { 
            this.m_SBInfos.Add(new SBBeekeeperExp()); 
        }

        public override void Serialize(GenericWriter writer) 
        { 
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
