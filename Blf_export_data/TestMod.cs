﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blf_export_data
{
    internal class TestMod
    {
        public  const int TVIF_STATE = 0x8;
        public  const int TVIS_STATEIMAGEMASK = 0xF000;
        public  const int TV_FIRST = 0x1100;
        public  const int TVM_SETITEM = TV_FIRST + 63;
        public static void HideCheckBox(TreeView tvw, TreeNode node)
        {

            TVITEM tvi = new TVITEM();

            tvi.hItem = node.Handle;

            tvi.mask = TVIF_STATE;

            tvi.stateMask = TVIS_STATEIMAGEMASK;

            tvi.state = 0;

            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);

        }

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]

        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage; public int cChildren; public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);
    }
}
