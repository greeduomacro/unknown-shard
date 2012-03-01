//
//  Written by Haazen June 2005
//  Ported to RunUO 2.0 and Utopia by Dereckson.
//
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Prompts;
using Server.Multis;
using Server.Targeting;
using Server.Commands;
using System.Collections.Generic;

namespace Server.Gumps {
    public class BoatsGump : Gump {

        public static void Initialize () {
            CommandSystem.Register("Boats", AccessLevel.Counselor, new CommandEventHandler(FindBoat_OnCommand));
        }

        [Usage("Boats")]
        [Description("Finds all boats in the world.")]
        public static void FindBoat_OnCommand (CommandEventArgs e) {
            e.Mobile.SendGump(new BoatsGump(e.Mobile, BaseBoat.Boats, 1));
        }

        private List<BaseBoat> m_List;
        private int m_Page;
        private Mobile m_From;

        public void AddBlackAlpha (int x, int y, int width, int height) {
            AddImageTiled(x, y, width, height, 2624);
            AddAlphaRegion(x, y, width, height);
        }

        public static List<BaseBoat> ConvertList (ArrayList list) {
            List<BaseBoat> newList = new List<BaseBoat>(list.Count);
            foreach (object boat in list) {
                newList.Add((BaseBoat)boat);
            }
            return newList;
        }

        public BoatsGump (Mobile from, ArrayList list, int page)
            : this(from, ConvertList(list), page) {
        }

        public BoatsGump (Mobile from, List<BaseBoat> list, int page) : base(50, 40) {
            from.CloseGump(typeof(BoatsGump));

            int boats = 0;
            m_Page = page;
            m_From = from;
            int pageCount = 0;
            m_List = list;

            AddPage(0);

            AddBackground(0, 0, 520, 315, 5054);

            AddBlackAlpha(10, 10, 500, 280);

            if (m_List == null) {
                return;
            } else {
                boats = list.Count;

                if (list.Count % 12 == 0) {
                    pageCount = (list.Count / 12);
                } else {
                    pageCount = (list.Count / 12) + 1;
                }
            }

            AddLabelCropped(32, 16, 100, 20, 1152, "Ship Name");
            AddLabelCropped(132, 16, 120, 20, 1152, "Owner");
            AddLabelCropped(292, 16, 120, 20, 1152, "Location");
            AddLabel(80, 290, 93, String.Format("Haazen's Boat Locator             {0} Boats are on the water", boats));

            if (page > 1)
                AddButton(470, 18, 0x15E3, 0x15E7, 1, GumpButtonType.Reply, 0);
            else
                AddImage(470, 18, 0x25EA);

            if (pageCount > page)
                AddButton(487, 18, 0x15E1, 0x15E5, 2, GumpButtonType.Reply, 0);
            else
                AddImage(487, 18, 0x25E6);

            if (m_List.Count == 0)
                AddLabel(135, 80, 1152, "There are no boat on the water.");

            if (page == pageCount) {
                for (int i = (page * 12) -12 ; i < boats ; ++i)
                    AddDetails(i);
            } else {
                for (int i = (page * 12) -12 ; i < page * 12 ; ++i)
                    AddDetails(i);
            }
        }

        private void AddDetails (int index) {
            if (index < m_List.Count) {
                int btn;
                int row;
                btn = (index) + 101;
                row = index % 12;

                BaseBoat boat = m_List[index];

                AddLabel(32, 40 +(row * 20), 1152, String.Format("{0}", boat.ShipName));
                AddLabel(132, 40 +(row * 20), 1152, String.Format("{0}", boat.Owner));
                AddLabel(292, 40 +(row * 20), 1152, String.Format("{0} {1}", boat.GetWorldLocation(), boat.Map));

                AddButton(480, 45 +(row * 20), 2437, 2438, btn, GumpButtonType.Reply, 0);

            }
        }

        public override void OnResponse (NetState state, RelayInfo info) {
            Mobile from = state.Mobile;

            int buttonID = info.ButtonID;
            if (buttonID == 2) {
                m_Page++;
                from.CloseGump(typeof(BoatsGump));
                from.SendGump(new BoatsGump(from, m_List, m_Page));
            }
            if (buttonID == 1) {
                m_Page--;
                from.CloseGump(typeof(BoatsGump));
                from.SendGump(new BoatsGump(from, m_List, m_Page));
            }
            if (buttonID > 100) {
                int index = buttonID - 101;
                BaseBoat boat = m_List[index] as BaseBoat;
                Point3D xyz = boat.GetWorldLocation();
                int x = xyz.X;
                int y = xyz.Y;
                int z = -2;

                Point3D dest = new Point3D(x, y, z);
                from.MoveToWorld(dest, boat.Map);

            }
        }
    }
}