using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2Open.Common.Game.v752
{
    public static class W2Basics
    {
        #region Account
        public const int MAXC_MOB_PER_ACCOUNT = 4;
        public const int MAXL_LOGIN = 16;
        public const int MAXL_PASSWORD = 12;
        public const int MAXC_CARGO = 128;
        #endregion

        #region Mob
        public const int MAX_MOB_MOVE_SPEED = 6;
        public const int MAXC_MOB_SPECIAL = 4;
        public const int MAXL_MOB_NAME = 16;
        public const int MAXC_MOB_EQUIP = 16;
        public const int MAXC_MOB_INVENTORY = 64;
        #endregion

        public const int MAXC_ITEM_EFFECT = 3;
    }
}