using System; 
using Server; 
using Server.Network; 
using Server.Mobiles; 
using System.Collections; 

namespace Server.Items 
{ 
   public class HangoverCure : Item 
   { 
    
      [Constructable] 
      public HangoverCure() : base(0xF0B)
      { 
         Weight = 1.0; 
          LootType = LootType.Blessed; 
          Movable = true; 
         Name="Dr. Spock's Hangover Cure";
         Hue=47; 
      } 

      public HangoverCure( Serial serial ) : base( serial ) 
      { 
          
      
      } 
      public override void OnDoubleClick( Mobile from ) 
      { 
         if (!IsChildOf(from.Backpack)) 
         { 
            from.SendLocalizedMessage( 1042010 ); //You must have the object in your backpack to use it. 
            return; 
         } 
         else if(from.BAC>=1) 
         { 
      
            from.PlaySound( 0x2D6 );
            from.Animate( 34, 5, 1, true, false, 0 ); 
            from.BAC=1; 
            from.SendLocalizedMessage(501206); 
            this.Delete(); 
             
         } 
         else 
            { 
               from.SendMessage( "You decide against drinking it sober. You can read the ingredients label..."); 
            } 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); 
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 
      } 


       public override void OnAosSingleClick( Mobile from ) 
        { 
                            
                      
                  this.LabelTo( from, this.Name); 
        } 
        
   } 
} 
