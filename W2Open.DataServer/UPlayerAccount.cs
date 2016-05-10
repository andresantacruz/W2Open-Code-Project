using System;
using System.Runtime.InteropServices;
using W2Open.Common;
using W2Open.Common.Game;
using W2Open.Common.Game.v752;

namespace W2Open.DataServer
{
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct UPlayerAccount
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_LOGIN)]
        public String Login;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_PASSWORD)]
        public String Password;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public UMob[] Mobs;

        public UCargo Cargo;
    }
}