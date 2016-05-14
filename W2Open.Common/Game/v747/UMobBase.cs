using System;
using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747
{
    /// <summary>
    /// The character class in the game
    /// </summary>
    public enum EMobClass : byte
    {
        /// <summary>
        /// Trans Knight.
        /// </summary>
        TK = 0,
        /// <summary>
        /// Foema.
        /// </summary>
        FM = 1,
        /// <summary>
        /// Beast Master.
        /// </summary>
        BM = 2,
        /// <summary>
        /// Huntress.
        /// </summary>
        HT = 3
    }

    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK, CharSet = CharSet.Ansi)]
    public struct UMobBase
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = W2Basics.MAXL_MOB_NAME)]
        public string Name;

        public byte CapeInfo;
        public byte Direction;

        public ushort GuildIndex;

        public EMobClass ClassType;
        public byte QuestIndex;

        public short CityZone;

        public int Gold;
        public uint Experience;

        public BPosition Pos;

        public BMobStatus BaseStatus;
        public BMobStatus FinalStatus;

        public UEquip Equip;
        public UInventory Inventory;

        public uint LearnedSpell;

        public short ScoreBonus, SpecialBonus, SkillBonus;

        public byte Critical;
        public byte SaveMana;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SkillBar;

        public short GuildMemberType;

        public byte RegenHP, RegenMP;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Resist;

        public short CharSlot;
        public short ClientIndex;

        public short Perfuration;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Skillbar2;

        public int Holding;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 26)]
        public string TabInfo;

        public uint Recall;

        public int TimeStamp;

        public ushort Speed;

        public int GreatHP;

        public int Arch;
        public int Celestial;

        public uint QuestInfo;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string GuildName;

        public int Time;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 148)]
        public byte[] NotUsage;

        public BPosition Stomp;
        public BPosition Last;

        public BPosition Gema;

        public short Evasion;

        public short SubClass;

        public int ClassMaster;

        public ushort IsAdmin;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = W2Basics.MAXC_MOB_AFFECT)]
        public BAffect[] Affect;

        public ushort MagicIncrement;

        public short Instance;

        public int WeaponDamage;
    }
}