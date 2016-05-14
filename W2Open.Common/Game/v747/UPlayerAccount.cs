using System;
using System.Runtime.InteropServices;
using W2Open.Common;
using W2Open.Common.Game;

namespace W2Open.Common.Game.v747
{
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
    public struct UPlayerAccount
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_LOGIN)]
        public string Login;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_PASSWORD)]
        public string Password;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public UMobBase[] Character;

        public UCargo Cargo;
    }
}