
////////////////////////////////////////
//                                    //
//      Generated by CEO's YAAAG      //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BigScreenTVEastAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {1834, 0, -2, 0}, {1824, 0, 0, 0}, {1827, 1, 2, 0}// 1	2	3	
			, {9269, 1, 0, 0}, {1824, 0, 2, 15}, {6226, 0, 0, 20}// 4	5	6	
			, {4400, 1, 0, 0}, {9269, 1, 1, 0}, {1824, 0, -1, 5}// 7	8	9	
			, {1824, 0, 2, 10}, {1824, 0, 1, 15}, {1824, 0, -1, 15}// 10	11	12	
			, {1835, 1, 3, 0}, {1824, 0, 0, 15}, {1824, 0, 1, 0}// 13	14	15	
			, {1824, 0, -1, 0}, {1824, 0, 2, 5}, {1824, 0, 2, 0}// 16	17	18	
			, {1824, 0, -1, 10}, {1837, 1, -2, 0}, {1836, 0, 3, 0}// 20	21	22	
			, {1827, 1, -1, 0}, {4240, 1, 0, 0}// 23	25	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new BigScreenTVEastAddonDeed();
			}
		}

		[ Constructable ]
		public BigScreenTVEastAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 6686, 0, 0, 5, 6, -1, "pure energy" );// 19
			AddComplexComponent( (BaseAddon) this, 6686, 0, 1, 5, 6, -1, "pure energy" );// 24

		}

		public BigScreenTVEastAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class BigScreenTVEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new BigScreenTVEastAddon();
			}
		}

		[Constructable]
		public BigScreenTVEastAddonDeed()
		{
			Name = "BigScreenTVEast";
		}

		public BigScreenTVEastAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}