using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.TMSS.Items
{
	[FlipableAttribute]
	public class BaseSamuraiSword : Item
	{
		private int[] m_VarnishIDs = new int[] { 0x2844, 0x2845 };
		private int[] m_BlackIDs = new int[] { 0x2842, 0x2843 };
		private Mobile m_Owner = null;
		private BaseWeapon m_Item = null;
		private int[] m_NormalItemIDs = new int[2];
		private int[] m_EmptyItemIDs = new int[2];
		private bool m_IsFlipped = false;
		private bool m_IsEmpty = true;

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Owner { get { return m_Owner; } set { m_Owner = value; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public BaseWeapon Item { get { return m_Item; } set { m_Item = value; } }

		public BaseSamuraiSword(bool varnish, int norm, int flip) : base(norm)
		{ 
			m_EmptyItemIDs = varnish ? m_VarnishIDs : m_BlackIDs;
			ItemID = m_EmptyItemIDs[0];
			m_NormalItemIDs = new int[2];
			m_NormalItemIDs[0] = norm;
			m_NormalItemIDs[1] = flip;
			Weight = 20.0;
			Name = "A Sword Stand";
			//Flip();
		}
		public BaseSamuraiSword(Serial serial) : base(serial) { }

		public void Flip()
		{ 
			int flip = (m_IsFlipped=!m_IsFlipped) ? 1 : 0;
			ItemID = !m_IsEmpty ? m_NormalItemIDs[flip] : m_EmptyItemIDs[flip]; 
		}

		public override void OnDoubleClick(Mobile from)
		{
			if( from != m_Owner ) { from.SendMessage("You are not the sword's owner."); return; }
			if (from == m_Owner && m_Item == null)
			{ from.SendMessage("Please select the item to bond."); from.Target = new SwordTarget(this); }
			else
				ToggleState();
		}

		private void ToggleState()
		{
			if (!(m_IsEmpty = !m_IsEmpty))
				m_Item.Internalize();
			else
				m_Owner.AddToBackpack(m_Item);
			int flip = m_IsFlipped ? 1 : 0;
			ItemID = m_IsEmpty ? m_EmptyItemIDs[flip] : m_NormalItemIDs[flip];
			m_Owner.SendMessage(m_IsEmpty ? "You retrieve the weapon." : "You replace the weapon in its stand.");
		}

		#region SerDeser
		public override void Serialize(GenericWriter writer)
		{
			writer.Write(1);
			writer.Write(m_IsFlipped);
			writer.Write(m_IsEmpty);
			writer.Write(m_NormalItemIDs[0]);
			writer.Write(m_NormalItemIDs[1]);
			writer.Write(m_EmptyItemIDs[0]);
			writer.Write(m_EmptyItemIDs[1]);
			writer.Write(m_Owner);
			writer.Write(m_Item);
			base.Serialize(writer);
		}
		public override void Deserialize(GenericReader reader)
		{
			int ver = reader.ReadInt();
			if (ver == 1)
			{
				m_IsFlipped = reader.ReadBool();
				m_IsEmpty = reader.ReadBool();
				m_NormalItemIDs = new int[2];
				m_NormalItemIDs[0] = reader.ReadInt();
				m_NormalItemIDs[1] = reader.ReadInt();
				m_EmptyItemIDs = new int[2];
				m_EmptyItemIDs[0] = reader.ReadInt();
				m_EmptyItemIDs[1] = reader.ReadInt();
				m_Owner = reader.ReadMobile();
				m_Item = (BaseWeapon)reader.ReadItem();
			}
			base.Deserialize(reader);
		}
		#endregion

		private class SwordTarget : Target 
		{
			private BaseSamuraiSword m_Sword;
			public SwordTarget(BaseSamuraiSword sword) : base (5, false, TargetFlags.None) { m_Sword = sword; }
			protected override void OnTarget(Mobile from, object targeted)
			{
				if (targeted is BaseWeapon)
				{ m_Sword.Item = (BaseWeapon)targeted; m_Sword.ToggleState(); }
				else
				{ from.SendMessage("The item must be a weapon."); from.Target = new SwordTarget(m_Sword); }
			}
		}	
	}

	#region Sword Classes
	[FlipableAttribute]
	public class RedSwordBig : BaseSamuraiSword
	{
		[Constructable]
		public RedSwordBig() : base(false, 0x2851, 0x2852) { }
		public RedSwordBig(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	[FlipableAttribute]
	public class BlackSwordBig : BaseSamuraiSword
	{
		[Constructable]
		public BlackSwordBig() : base(true, 10323, 10324) {}
		public BlackSwordBig(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	[FlipableAttribute]
	public class PurpleSwordBig : BaseSamuraiSword
	{
		[Constructable]
		public PurpleSwordBig() : base(false,10524, 10525) { }
		public PurpleSwordBig(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	[FlipableAttribute]
	public class GreenSwordBig : BaseSamuraiSword
	{
		[Constructable]
		public GreenSwordBig() : base(false,10526, 10527) { }
		public GreenSwordBig(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	[FlipableAttribute]
	public class RedSwordSmall : BaseSamuraiSword
	{
		[Constructable]
		public RedSwordSmall() : base(false,10821, 10822) {}
		public RedSwordSmall(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	[FlipableAttribute]
	public class BlackSwordSmall : BaseSamuraiSword
	{
		[Constructable]
		public BlackSwordSmall() : base(true,10823, 10824) {}
		public BlackSwordSmall(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	[FlipableAttribute]
	public class PurpleSwordSmall : BaseSamuraiSword
	{
		[Constructable]
		public PurpleSwordSmall() : base(false,10825, 10826) { }
		public PurpleSwordSmall(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	[FlipableAttribute]
	public class GreenSwordSmall : BaseSamuraiSword
	{
		[Constructable]
		public GreenSwordSmall() : base(false,10827, 10826) { }
		public GreenSwordSmall(Serial serial) : base(serial) { }
		public override void Serialize(GenericWriter writer) { base.Serialize(writer); }
		public override void Deserialize(GenericReader reader) { base.Deserialize(reader); }
	}
	#endregion
}
