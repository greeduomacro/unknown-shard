using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using Server.Multis;
using Server.Mobiles;


namespace Server.Items
{

	public class EmptyRuneBook : Item
	{
		[Constructable]
		public EmptyRuneBook() : this( null )
		{
		}

		[Constructable]
		public EmptyRuneBook ( string name ) : base ( 0x22C5 )
		{
			Name = "An Empty Rune Book";
			LootType = LootType.Blessed;
			Hue = 373;
		}

		public EmptyRuneBook ( Serial serial ) : base ( serial )
		{
		}

      		
		public override void OnDoubleClick( Mobile m )

		{
			Item a = m.Backpack.FindItemByType( typeof(GR1) );
			if ( a != null )
			{	
			Item b = m.Backpack.FindItemByType( typeof(GR2) );
			if ( b != null )
			{
			Item c = m.Backpack.FindItemByType( typeof(GR3) );
			if ( c != null )
			{
			Item d = m.Backpack.FindItemByType( typeof(GR4) );
			if ( d != null )
			{
			Item e = m.Backpack.FindItemByType( typeof(GR5) );
			if ( e != null )
			{
			Item f = m.Backpack.FindItemByType( typeof(GR6) );
			if ( f != null )
			{
			Item g = m.Backpack.FindItemByType( typeof(GR7) );
			if ( g != null )
			{
			Item h = m.Backpack.FindItemByType( typeof(GR8) );
			if ( h != null )
			{
			Item i = m.Backpack.FindItemByType( typeof(GR9) );
			if ( i != null )
			{
			Item j = m.Backpack.FindItemByType( typeof(GR10) );
			if ( j != null )
			{
			Item k = m.Backpack.FindItemByType( typeof(GR11) );
			if ( k != null )
			{
			Item l = m.Backpack.FindItemByType( typeof(GR12) );
			if ( l != null )
			{
			Item l2 = m.Backpack.FindItemByType( typeof(GR13) );
			if ( l2 != null )
			{
			Item n = m.Backpack.FindItemByType( typeof(GR14) );
			if ( n != null )
			{
			Item o = m.Backpack.FindItemByType( typeof(GR15) );
			if ( o != null )
			{
			Item p = m.Backpack.FindItemByType( typeof(GR16) );
			if ( p != null )
			{
			Item q = m.Backpack.FindItemByType( typeof(GR17) );
			if ( q != null )
			{
			Item r = m.Backpack.FindItemByType( typeof(GR18) );
			if ( r != null )
			{
			Item s = m.Backpack.FindItemByType( typeof(GR19) );
			if ( s != null )
			{
			Item t = m.Backpack.FindItemByType( typeof(GR20) );
			if ( t != null )
			{
			Item u = m.Backpack.FindItemByType( typeof(GR21) );
			if ( u != null )
			{
			Item v = m.Backpack.FindItemByType( typeof(GR22) );
			if ( v != null )
			{
			Item w = m.Backpack.FindItemByType( typeof(GR23) );
			if ( w != null )
			{
			Item x = m.Backpack.FindItemByType( typeof(GR24) );
			if ( x != null )
			{
			Item y = m.Backpack.FindItemByType( typeof(GR25) );
			if ( y != null )
			{
			Item z = m.Backpack.FindItemByType( typeof(GR26) );
			if ( z != null )
			{
			Item aa = m.Backpack.FindItemByType( typeof(GR27) );
			if ( aa != null )
			{
			Item ab = m.Backpack.FindItemByType( typeof(GR28) );
			if ( ab != null )
			{
			Item ac = m.Backpack.FindItemByType( typeof(GR29) );
			if ( ac != null )
			{
			Item ad = m.Backpack.FindItemByType( typeof(GR30) );
			if ( ad != null )
			{
			Item ae = m.Backpack.FindItemByType( typeof(GR31) );
			if ( ae != null )
			{
			Item af = m.Backpack.FindItemByType( typeof(GR32) );
			if ( af != null )
			{
			Item ag = m.Backpack.FindItemByType( typeof(GR33) );
			if ( ag != null )
			{
			Item ah = m.Backpack.FindItemByType( typeof(GR34) );
			if ( ah != null )
			{
			Item ai = m.Backpack.FindItemByType( typeof(GR35) );
			if ( ai != null )
			{
			Item aj = m.Backpack.FindItemByType( typeof(GR36) );
			if ( aj != null )
			{
			Item ak = m.Backpack.FindItemByType( typeof(GR37) );
			if ( ak != null )
			{
			Item al = m.Backpack.FindItemByType( typeof(GR38) );
			if ( al != null )
			{
			Item am = m.Backpack.FindItemByType( typeof(GR39) );
			if ( am != null )
			{
			Item an = m.Backpack.FindItemByType( typeof(GR40) );
			if ( an != null )
			{
			Item ao = m.Backpack.FindItemByType( typeof(GR41) );
			if ( ao != null )
			{
			Item ap = m.Backpack.FindItemByType( typeof(GR42) );
			if ( ap != null )
			{
			Item aq = m.Backpack.FindItemByType( typeof(GR43) );
			if ( aq != null )
			{
			Item ar = m.Backpack.FindItemByType( typeof(GR44) );
			if ( ar != null )
			{
			Item ar2 = m.Backpack.FindItemByType( typeof(GR45) );
			if ( ar2 != null )
			{
			Item at = m.Backpack.FindItemByType( typeof(GR46) );
			if ( at != null )
			{
			Item au = m.Backpack.FindItemByType( typeof(GR47) );
			if ( au != null )
			{
			Item av = m.Backpack.FindItemByType( typeof(GR48) );
			if ( av != null )
			{
			Item aw = m.Backpack.FindItemByType( typeof(GR49) );
			if ( aw != null )
			{
			Item ax = m.Backpack.FindItemByType( typeof(GR50) );
			if ( ax != null )
			{
			Item ay = m.Backpack.FindItemByType( typeof(GR51) );
			if ( ay != null )
			{
			Item az = m.Backpack.FindItemByType( typeof(GR52) );
			if ( az != null )
			{
			Item ba = m.Backpack.FindItemByType( typeof(GR53) );
			if ( ba != null )
			{
			Item bb = m.Backpack.FindItemByType( typeof(GR54) );
			if ( bb != null )
			{
			Item bc = m.Backpack.FindItemByType( typeof(GR55) );
			if ( bc != null )
			{
			Item bd = m.Backpack.FindItemByType( typeof(GR56) );
			if ( bd != null )
			{
			Item be = m.Backpack.FindItemByType( typeof(GR57) );
			if ( be != null )
			{
			Item bf = m.Backpack.FindItemByType( typeof(GR58) );
			if ( bf != null )
			{
			Item bg = m.Backpack.FindItemByType( typeof(GR59) );
			if ( bg != null )
			{
			Item bh = m.Backpack.FindItemByType( typeof(GR60) );
			if ( bh != null )
			{
			Item bi = m.Backpack.FindItemByType( typeof(GR61) );
			if ( bi != null )
			{
			Item bj = m.Backpack.FindItemByType( typeof(GR62) );
			if ( bj != null )
			{
			Item bk = m.Backpack.FindItemByType( typeof(GR63) );
			if ( bk != null )
			{
			Item bl = m.Backpack.FindItemByType( typeof(GR64) );
			if ( bl != null )
			{
			Item bm = m.Backpack.FindItemByType( typeof(GR65) );
			if ( bm != null )
			{
			Item bn = m.Backpack.FindItemByType( typeof(GR66) );
			if ( bn != null )
			{
			Item bo = m.Backpack.FindItemByType( typeof(GR67) );
			if ( bo != null )
			{
			Item bp = m.Backpack.FindItemByType( typeof(GR68) );
			if ( bp != null )
			{
			Item bq = m.Backpack.FindItemByType( typeof(GR69) );
			if ( bq != null )
			{
			Item br = m.Backpack.FindItemByType( typeof(GR70) );
			if ( br != null )
			{
			Item bs = m.Backpack.FindItemByType( typeof(GR71) );
			if ( bs != null )
			{
			Item bt = m.Backpack.FindItemByType( typeof(GR72) );
			if ( bt != null )
			{
			Item bu = m.Backpack.FindItemByType( typeof(GR73) );
			if ( bu != null )
			{
			Item bv = m.Backpack.FindItemByType( typeof(GR74) );
			if ( bv != null )
			{
			Item bw = m.Backpack.FindItemByType( typeof(GR75) );
			if ( bw != null )
			{
			Item bx = m.Backpack.FindItemByType( typeof(GR76) );
			if ( bx != null )
			{
			Item by = m.Backpack.FindItemByType( typeof(GR77) );
			if ( by != null )
			{
			Item bz = m.Backpack.FindItemByType( typeof(GR78) );
			if ( bz != null )
			{
			Item ca = m.Backpack.FindItemByType( typeof(GR79) );
			if ( ca != null )
			{
			Item cb = m.Backpack.FindItemByType( typeof(GR80) );
			if ( cb != null )
			{
			Item cc = m.Backpack.FindItemByType( typeof(GR81) );
			if ( cc != null )
			{
			Item cd = m.Backpack.FindItemByType( typeof(GR82) );
			if ( cd != null )
			{
			Item ce = m.Backpack.FindItemByType( typeof(GR83) );
			if ( ce != null )
			{
			Item cf = m.Backpack.FindItemByType( typeof(GR84) );
			if ( cf != null )
			{
			Item cg = m.Backpack.FindItemByType( typeof(GR85) );
			if ( cg != null )
			{
			Item ch = m.Backpack.FindItemByType( typeof(GR86) );
			if ( ch != null )
			{
			Item ci = m.Backpack.FindItemByType( typeof(GR87) );
			if ( ci != null )
			{
			Item cj = m.Backpack.FindItemByType( typeof(GR88) );
			if ( cj != null )
			{
			Item ck = m.Backpack.FindItemByType( typeof(GR89) );
			if ( ck != null )
			{
			Item cl = m.Backpack.FindItemByType( typeof(GR90) );
			if ( cl != null )
			{
			Item cm = m.Backpack.FindItemByType( typeof(GR91) );
			if ( cm != null )
			{
			Item cn = m.Backpack.FindItemByType( typeof(GR92) );
			if ( cn != null )
			{
			Item co = m.Backpack.FindItemByType( typeof(GR93) );
			if ( co != null )
			{
			Item cp = m.Backpack.FindItemByType( typeof(GR94) );
			if ( cp != null )
			{
			Item cq = m.Backpack.FindItemByType( typeof(GR95) );
			if ( cq != null )
			{
			
				m.AddToBackpack( new FullRuneBook() );
				a.Delete();
				b.Delete();
				c.Delete();
				d.Delete();
				e.Delete();
				f.Delete();
				g.Delete();
				h.Delete();
				i.Delete();
				j.Delete();
				k.Delete();
				l.Delete();
				l2.Delete();
				n.Delete();
				o.Delete();
				p.Delete();
				q.Delete();
				r.Delete();
				s.Delete();
				t.Delete();
				u.Delete();
				v.Delete();
				w.Delete();
				x.Delete();
				y.Delete();
				z.Delete();
				aa.Delete();
				ab.Delete();
				ac.Delete();
				ad.Delete();
				ae.Delete();
				af.Delete();
				ag.Delete();
				ah.Delete();
				ai.Delete();
				aj.Delete();
				ak.Delete();
				al.Delete();
				am.Delete();
				an.Delete();
				ao.Delete();
				ap.Delete();
				aq.Delete();
				ar.Delete();
				ar2.Delete();
				at.Delete();
				au.Delete();
				av.Delete();
				aw.Delete();
				ax.Delete();
				ay.Delete();
				az.Delete();
				ba.Delete();
				bb.Delete();
				bc.Delete();
				bd.Delete();
				be.Delete();
				bf.Delete();
				bg.Delete();
				bh.Delete();
				bi.Delete();
				bj.Delete();
				bk.Delete();
				bl.Delete();
				bm.Delete();
				bn.Delete();
				bo.Delete();
				bp.Delete();
				bq.Delete();
				br.Delete();
				bs.Delete();
				bt.Delete();
				bu.Delete();
				bv.Delete();
				bw.Delete();
				bx.Delete();
				by.Delete();
				bz.Delete();
				ca.Delete();
				cb.Delete();
				cc.Delete();
				cd.Delete();
				ce.Delete();
				cf.Delete();
				cg.Delete();
				ch.Delete();
				ci.Delete();
				cj.Delete();
				ck.Delete();
				cl.Delete();
				cm.Delete();
				cn.Delete();
				co.Delete();
				cp.Delete();
				cq.Delete();
				m.SendMessage( "You place all the runes into the Empty Rune Book." );
				this.Delete();
			}
			}
				else
			{
				m.SendMessage( "You are missing some runes." );
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}
		}

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}