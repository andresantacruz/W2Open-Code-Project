using W2Open.Common.Game.v752;

namespace W2Open.Common.Game
{
    public class CMob
    {
        public const int MAX_MOVE_SPEED = 6;

        public UMobBase Base { get; set; }
        public UMobExtra Extra { get; set; }
        // TODO: our fields here.

        public CMob()
        {
            Base = new UMobBase();
            Extra = new UMobExtra();
        }
    }
}