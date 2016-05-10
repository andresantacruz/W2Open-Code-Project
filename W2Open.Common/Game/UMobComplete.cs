using System;
using System.Runtime.InteropServices;
using W2Open.Common.Game.v752;

namespace W2Open.Common.Game
{
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct UMob
    {
        public UMobBase Base;
        public UMobExtra Extra;
        // TODO: our fields here.
    }
}