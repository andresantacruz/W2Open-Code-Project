using System;
using System.Runtime.InteropServices;
using W2Open.Common.Game.v752;

namespace W2Open.Common.Game
{
    [StructLayout(LayoutKind.Sequential, Pack = ProjectBasics.DEFAULT_PACK)]
    public struct UMob
    {
        public const int MAX_MOVE_SPEED = 6;
        
        public UMobBase Base { get; set; }
        public UMobExtra Extra { get; set; }
        // TODO: our fields here.
    }
}