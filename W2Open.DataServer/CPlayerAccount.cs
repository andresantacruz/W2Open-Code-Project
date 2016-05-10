using System;
using W2Open.Common;
using W2Open.Common.Game;
using W2Open.Common.Game.v752;

namespace W2Open.DataServer
{
    public class CPlayerAccount
    {
        public UBoundedString Login { get; set; }
        public UBoundedString Password { get; set; }

        public UMob[] Mobs;

        public UCargo Cargo;

        public CPlayerAccount(String login, String password)
        {
            Login = new UBoundedString(login, 16);
            Password = new UBoundedString(password, 12);

            Mobs = new UMob[4];

            Cargo = new UCargo();
        }

        public class UCargo : UItemCollection
        {
            public UCargo() : base(128) { }
        }
    }
}