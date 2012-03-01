using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Engines.XmlSpawner2
{
   public class XmlFollow : XmlAttachment
   {
       private int m_DataValue;

       [CommandProperty(AccessLevel.GameMaster)]
       public int Distance
       {
           get { return m_DataValue; }
           set
           {
               m_DataValue = value;
               if (AttachedTo is BaseCreature)
               {
                   ((BaseCreature)AttachedTo).FollowRange = m_DataValue;
               }
           }
       }

       // These are the various ways in which the message attachment can be constructed.  
       // These can be called via the [addatt interface, via scripts, via the spawner ATTACH keyword.
       // Other overloads could be defined to handle other types of arguments

       // a serial constructor is REQUIRED
       public XmlFollow(ASerial serial)
           : base(serial)
       {
       }

       [Attachable]
       public XmlFollow(int distance)
       {
           Distance = distance;
       }

       [Attachable]
       public XmlFollow(int distance, double expiresin)
       {
           Distance = distance;
           Expiration = TimeSpan.FromMinutes(expiresin);

       }

       public override void Serialize(GenericWriter writer)
       {
           base.Serialize(writer);

           writer.Write((int)0);
           // version 0
           writer.Write(m_DataValue);

       }

       public override void Deserialize(GenericReader reader)
       {
           base.Deserialize(reader);

           int version = reader.ReadInt();
           // version 0
           m_DataValue = reader.ReadInt();
       }

       public override void OnDelete()
       {
           base.OnDelete();

           // remove the mod
           if (AttachedTo is BaseCreature)
           {
               ((BaseCreature)AttachedTo).FollowRange = -1;
           }
       }

       public override void OnAttach()
       {
           base.OnAttach();

           // apply the mod immediately if attached to a mob
           if (AttachedTo is BaseCreature)
           {
               ((BaseCreature)AttachedTo).FollowRange = Distance;
           }
       }

       public override void OnReattach()
       {
           base.OnReattach();

           // reapply the mod if attached to a mob
           if (AttachedTo is BaseCreature)
           {
               ((BaseCreature)AttachedTo).FollowRange = Distance;
           }
       }

       public override string OnIdentify(Mobile from)
       {
           if (from == null || from.AccessLevel == AccessLevel.Player || !(AttachedTo is BaseCreature)) return null;

           BaseCreature b = AttachedTo as BaseCreature;

           if (Expiration > TimeSpan.Zero)
           {

               return String.Format("Following {0} at Distance {1} expires in {2} mins", b.SummonMaster, Distance, Expiration.TotalMinutes);
           }
           else
           {
               return String.Format("Following {0} at Distance {1}", b.SummonMaster, Distance);
           }
       }
   }
}
