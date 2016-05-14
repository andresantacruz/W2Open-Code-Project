using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace W2Open.Common.Game.v747
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct UCharList
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public BPosition[] LastPosition;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public UName[] MobName;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public BMobStatus[] MobStatus;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public UEquip[] MobEquip;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public ushort[] MobGuildInfo;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public int[] MobGold;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_PER_ACCOUNT)]
        public uint[] MobExp;

        public UCharList(UPlayerAccount userAcc)
        {
            LastPosition = new BPosition[4];
            MobName = new UName[4];
            MobStatus = new BMobStatus[4];
            MobEquip = new UEquip[4];
            MobGuildInfo = new ushort[4];
            MobGold = new int[4];
            MobExp = new uint[4];

            for (int i = 0; i < userAcc.Character.Length; i++)
            {
                if (userAcc.Character[i].Name != null)
                {
                    MobName[i].Value = userAcc.Character[i].Name;
                    LastPosition[i] = userAcc.Character[i].Pos;
                    MobStatus[i] = userAcc.Character[i].BaseStatus;
                    MobEquip[i] = userAcc.Character[i].Equip;
                    MobGuildInfo[i] = userAcc.Character[i].GuildIndex;
                    MobGold[i] = userAcc.Character[i].Gold;
                    MobExp[i] = userAcc.Character[i].Experience;
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UName
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string Value;
        }
    }
}
