using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class AnimalFarmer : BaseVendor
	{
		private ArrayList m_SBInfos = new ArrayList();
		protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public AnimalFarmer() : base( "the farmer" )
		{
			SetSkill( SkillName.Herding, 36.0, 68.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );
			SetSkill( SkillName.Cooking, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBAnimalFarmer() );
		}

		public override VendorShoeType ShoeType
		{
            get { return VendorShoeType.Sandals; }
		}

		public override int GetShoeHue()
		{
			return 0;
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

            switch (Utility.Random (2))
            {
                case 0:
                    AddItem(new Server.Items.StrawHat(Utility.RandomNeutralHue()));
                break;
                
                case 1:
                    AddItem(new Server.Items.TallStrawHat(Utility.RandomNeutralHue()));
                break;
            }

            switch (Utility.Random(2))
            {
                case 0:
                    AddItem(new Server.Items.FullApron(Utility.RandomNeutralHue()));
                    break;

                case 1:
                    AddItem(new Server.Items.HalfApron(Utility.RandomNeutralHue()));
                    break;
            }

            AddItem(new Server.Items.Pitchfork());
            AddItem(new Server.Items.Shirt(Utility.RandomNeutralHue()));
		}

		public AnimalFarmer( Serial serial ) : base( serial )
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
}