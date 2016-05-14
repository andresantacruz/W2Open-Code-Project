using System.Runtime.InteropServices;

namespace W2Open.Common.Game.v747
{
    /// <summary>
    /// Represents a set of information regard to a mob's status.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = W2Basics.DEFAULT_MEM_PACK)]
    public struct BMobStatus
    {
        public ushort Level;

        public short Defense;
        public short Attack;

        public byte Merchant;
        private byte m_MovementSpeed;

        public short MaxHP;
        public short MaxMP;

        public short CurrentHP;
        public short CurrentMP;

        public short Str;
        public short Int;
        public short Dex;
        public short Con;

        public unsafe fixed short Special[W2Basics.MAXC_MOB_SPECIAL]; // The 4 special points ("pontos de aprendizagem").

        public byte MovementSpeed
        {
            get { return m_MovementSpeed; }
            set { m_MovementSpeed = (value > W2Basics.MAX_MOB_MOVE_SPEED) ? (byte)W2Basics.MAX_MOB_MOVE_SPEED : value; }
        }
    }
}