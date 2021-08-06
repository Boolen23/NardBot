using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class GameClient
    {
        public GameClient(Game g, Identity identity)
        {
            if (identity == Identity.White)
                game.WhiteMove += MoveStarted;
            else
                game.BlackMove += MoveStarted;

            this.ClientIdentity = identity;
        }
        private Game game;
        protected virtual void MoveStarted(object sender, MoveEventArgs e)
        {
        }

        public Identity ClientIdentity { get; private set; }

    }
}
